/// the module generates a template for building the menu
/// for better understanding the way to create menus
/// please refer to the source code of Fable.Import.Electron
/// at https://github.com/fable-compiler/fable-import/blob/master/Electron/Fable.Import.Electron.fs
/// most of the methods have the same names as the ones appear in Node.js

module Menubar

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open System
open Fable.Import.Browser
open Ref
open Helper
open About
open Fable.Import.Node

/// to avoid code dulication
/// only the fields that ofter differ from one and other menu items
/// are listed here
type MenuSetupMustHave =     
    { clickData:Func<MenuItem, BrowserWindow, unit> option;
      labelData:string option;
      acceleratorData:string option; 
      roleData:U2<MenuItemRole, MenuItemRoleMac> option }

/// fields that do not often differ from one and other menu items
/// are listed here
type MenuSetupOptional = 
    {
      typeData:MenuItemType option; 
      sublabelData:string option; 
      iconData:U2<NativeImage, string> option;
      enabledData:bool option;
      visibleData:bool option;
      checkedData:bool option;
      idData:string option;
      positionData:string option;
      submenuData:U2<Menu, ResizeArray<MenuItemOptions>> option;
    }

/// a default settings for the optional part of a menu item configuration
let defaultMenuSetupOptional = 
    {
      typeData = option.None; 
      sublabelData = option.None; 
      iconData = option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      idData = option.None;
      positionData = option.None;
      submenuData = option.None;
    }

/// the bar in a drop down menu that separates the menu items
let menuSeparator = 
    ({  clickData = option.None;
        labelData = option.None;
        acceleratorData = option.None;
        roleData = option.None},
        {defaultMenuSetupOptional with typeData = MenuItemType.Separator |> Some})

/// build the one menu item from a tuple of parameters
/// the first parameter must be different from one and another menu items
/// the second parameter may not be different from each other
let menuBuilder ((menuMustHaveContent:MenuSetupMustHave), (menuOptionalContent:MenuSetupOptional)) = 
    let menu = createEmpty<MenuItemOptions>
    menu.click <- menuMustHaveContent.clickData
    menu.``type`` <- menuOptionalContent.typeData
    menu.label <- menuMustHaveContent.labelData
    menu.sublabel <- menuOptionalContent.sublabelData
    menu.accelerator <- menuMustHaveContent.acceleratorData
    menu.icon <- menuOptionalContent.iconData
    menu.enabled <- menuOptionalContent.enabledData
    menu.visible <- menuOptionalContent.visibleData
    menu.``checked`` <- menuOptionalContent.checkedData
    menu.submenu <- menuOptionalContent.submenuData
    menu.id <- menuOptionalContent.idData
    menu.position <- menuOptionalContent.positionData
    menu.role <- menuMustHaveContent.roleData
    menu

/// replace the sub menu field of a menu item
let replaceSubmenuData submenu = 
    {defaultMenuSetupOptional with submenuData = submenu 
                                                 |> List.map menuBuilder 
                                                 |> ResizeArray<MenuItemOptions> 
                                                 |> U2.Case2
                                                 |> Some}

////////////////////////////////////////////////////////////////////////////
///                                                                      ///
///          Menu Settings: set the submenu, then the main menu          ///
///                                                                      ///
////////////////////////////////////////////////////////////////////////////
let fileSubmenu = 
    let fileSave () =         
        let graph = match currentGraphModel with
                    | Some model -> model?set("graphCustomProperty", true)
                                    JS.JSON.stringify (model?toJSON())                                                                        
                    | option.None -> "no graph data"

        let paper = match currentPaperModel with
                    | Some model -> createObj[                                                                                
                                        "width" ==> model?options?width 
                                        "height" ==> model?options?height                                        
                                    ]
                                    |> JS.JSON.stringify                                    
                    | option.None -> "no paper data"
        
        let content = createObj[
                         "graph" ==> graph
                         "paper" ==> paper
                         "buttons" ==> Map.toArray blockNameConfigMapping
                      ]
                      |> JS.JSON.stringify
        
        match fileSavingPath with
        | Some a -> a
                    |> getFileName
                    |> updateTabName
                    let errorHandler error = ()
                    fs.writeFile (a, content, errorHandler)
        | option.None -> let saveDialogOptions = createEmpty<SaveDialogOptions>
                         saveDialogOptions.title <- Some "Save file to"
                         saveDialogOptions.defaultPath <- Some ("../new.project.json")                                         
                         let fileFilter =  new ResizeArray<obj> ()
                         let sufficSetting = 
                           createObj[
                               "name" ==> "JSON Format"
                               "extensions" ==> [|"project.json"|]
                           ]
                         fileFilter.Add sufficSetting
                                                     
                         saveDialogOptions.filters <- Some fileFilter

                         /// return the directory and the file name that is to be saved
                         let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)
        
                         match fileSaveDialog with
                         | a when checkUndefined a <> true -> a
                                                              |> getFileName
                                                              |> updateTabName

                                                              fileSavingPath <- Some a
                                                              
                                                              let errorHandler error = ()
                                                              fs.writeFile (fileSaveDialog, content, errorHandler)
                         | _ -> ()
        
    let fileRead () = 
        let openDialogOptions = createEmpty<OpenDialogOptions>
        openDialogOptions.title <- Some "Open file from"
        openDialogOptions.defaultPath <- option.None
        let fileFilter =  new ResizeArray<obj> ()
        let sufficSetting = 
          createObj[
              "name" ==> "JSON Format Project File"
              "extensions" ==> [|"project.json"|]
          ]
        fileFilter.Add sufficSetting
                                                
        openDialogOptions.filters <- Some fileFilter

        /// return the directory and the file name that is to be saved
        let fileOpenDialog = electron.remote.dialog.showOpenDialog (openDialogOptions)
        
        match fileOpenDialog with
        | a when checkUndefined a.[0] <> true -> //a.[0]
                                                 //|> getFileName
                                                 //|> updateTabName
                                                 let errorHandler (error:Base.NodeJS.ErrnoException option) (res:string)  =                                                      
                                                     
                                                     //let graph = (JS.JSON.parse res)?graph |> JS.JSON.parse
                                                     //let paper = (JS.JSON.parse res)?paper |> JS.JSON.parse                                                     
                                                     electron.ipcRenderer.send("load-file", res)

                                                 let readFileOptions = 
                                                    createObj[
                                                        "encoding" ==> "UTF8"
                                                    ]

                                                 fs.readFile (fileOpenDialog.[0], readFileOptions, errorHandler)                                                 
        | _ -> ()

    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some

    let clickFunctionSave = handlerCaster (fun _ _  -> fileSave())

    let clickFunctionRead = handlerCaster (fun  _ _ -> fileRead())

    [
        ({  clickData = option.None;
            labelData = Some "New";
            acceleratorData = Some "CmdOrCtrl + N"; 
            roleData = option.None },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = clickFunctionSave;
            labelData = Some "Save";
            acceleratorData = Some "CmdOrCtrl + S"; 
            roleData = option.None },
            defaultMenuSetupOptional);

        ({  clickData = clickFunctionSave;
            labelData = Some "Save As";
            acceleratorData = Some "CmdOrCtrl + Shift + S"; 
            roleData = option.None },
            defaultMenuSetupOptional);

        ({  clickData = clickFunctionRead; 
            labelData = Some "Open";
            acceleratorData = Some "CmdOrCtrl + O"; 
            roleData = option.None },
            defaultMenuSetupOptional);
      
        ({  clickData = option.None;
            labelData = Some "Close";
            acceleratorData = Some "CmdOrCtrl + W"; 
            roleData = option.None },
            defaultMenuSetupOptional);

        menuSeparator;

        (*
        ({  clickData = option.None;
            labelData = Some "Preference";
            acceleratorData = Some "CmdOrCtrl + P"; 
            roleData = option.None },
            defaultMenuSetupOptional);
        *)

        ({  clickData = option.None;
            labelData = Some "Exit";
            acceleratorData = Some "CmdOrCtrl + Q"; 
            roleData = MenuItemRole.Quit |> U2.Case1 |> Some },
            defaultMenuSetupOptional)
    ]

let fileMenu =     
    ({ clickData = option.None;
      labelData = Some "File";
      acceleratorData = option.None; 
      roleData = option.None },
      replaceSubmenuData fileSubmenu)

let createCustomBlockConfigWindow () = 
    electron.ipcRenderer.send("open-new-logic-window", ["yes"])

let editSubmenu = 
    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some
    let clickFunction = handlerCaster (fun _ _ -> createCustomBlockConfigWindow())

    let fileRead () = 
        let openDialogOptions = createEmpty<OpenDialogOptions>
        openDialogOptions.title <- Some "Open file from"
        openDialogOptions.defaultPath <- option.None
        openDialogOptions.filters <- option.None

        /// return the directory and the file name that is to be saved
        let fileOpenDialog = electron.remote.dialog.showOpenDialog (openDialogOptions)
        
        match fileOpenDialog with
        | a when checkUndefined a.[0] <> true -> let readFileOptions = 
                                                     createObj[
                                                         "encoding" ==> "UTF8"
                                                     ]

                                                 let errorHandler (error:Base.NodeJS.ErrnoException option) (res:string)  = 
                                                     let parsedJSON = JS.JSON.parse res
                                                     let name:string = parsedJSON?name
                                                     let inputs:string array = parsedJSON?inputs
                                                     let outputs:string array = parsedJSON?outputs
                                                     let truthTable = parsedJSON?truthTable
                                                     let verilogFileLocation:string = fileOpenDialog.[0] + ".v"
                                                     
                                                     let mutable VerilogCode = ""

                                                     let internalErrorHandler (error:Base.NodeJS.ErrnoException option) res =
                                                        VerilogCode <- res
                                                        electron.ipcRenderer.send("new-block-information", 
                                                            (name, inputs.Length, outputs.Length, inputs, outputs, truthTable, VerilogCode))   

                                                     fs.readFile (verilogFileLocation, readFileOptions, internalErrorHandler)                                                                                                                                                                                                                                                                  
                                                 fs.readFile (fileOpenDialog.[0], readFileOptions, errorHandler)                                                 
        | _ -> ()

    let clickFunctionReadBlock = handlerCaster (fun  _ _ -> fileRead())
    
    let unSelectAll () = 
        electron.ipcRenderer.send("clear-selection")

    let unSelectAllFunction = handlerCaster (fun _ _ -> unSelectAll())

    let generateBlockFromDesign () = 
        electron.ipcRenderer.send("generate-block-from-design")

    let generateBlockFromDesignFunction = handlerCaster (fun _ _ -> generateBlockFromDesign())

    [
        ({  clickData = clickFunction;
            labelData = Some "Create new logic blocks";
            acceleratorData = Some "CmdOrCtrl + B";
            roleData = option.None},
            defaultMenuSetupOptional);

        ({  clickData = clickFunctionReadBlock;
            labelData = Some "Load logic blocks";
            acceleratorData = Some "CmdOrCtrl + R";
            roleData = option.None},
            defaultMenuSetupOptional);

        ({  clickData = generateBlockFromDesignFunction;
            labelData = Some "Generate logic block";
            acceleratorData = Some "CmdOrCtrl + G";
            roleData = option.None},
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = option.None;
            labelData = Some "Undo";
            acceleratorData = Some "CmdOrCtrl + Z"; 
            roleData = MenuItemRole.Undo |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = option.None;
            labelData = Some "Redo";
            acceleratorData = Some "CmdOrCtrl + Y"; 
            roleData = MenuItemRole.Redo |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = option.None;
            labelData = Some "Cut";
            acceleratorData = Some "CmdOrCtrl + X"; 
            roleData = MenuItemRole.Cut |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = option.None; 
            labelData = Some "Copy";
            acceleratorData = Some "CmdOrCtrl + C"; 
            roleData = MenuItemRole.Copy |> U2.Case1 |> Some },
            defaultMenuSetupOptional);
      
        ({  clickData = option.None;
            labelData = Some "Paste";
            acceleratorData = Some "CmdOrCtrl + V"; 
            roleData = MenuItemRole.Paste |> U2.Case1 |> Some },
            defaultMenuSetupOptional);
        
        menuSeparator;

        ({  clickData = option.None;
            labelData = Some "Select All";
            acceleratorData = Some "CmdOrCtrl + A"; 
            roleData = MenuItemRole.Selectall |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = unSelectAllFunction;
            labelData = Some "Unselect All";
            acceleratorData = Some "Esc"; 
            roleData = option.None },
            defaultMenuSetupOptional)
    ]

let editMenu =     
    ({ clickData = option.None;
      labelData = Some "Edit";
      acceleratorData = option.None; 
      roleData = option.None },
      replaceSubmenuData editSubmenu)

let viewSubmenu = 
    [
        ({  clickData = option.None;
            labelData = Some "Toggle Full Screen";
            acceleratorData = Some "F11"; 
            roleData = MenuItemRole.Togglefullscreen |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = option.None;
            labelData = Some "Zoom In";
            acceleratorData = Some "CmdOrCtrl + Shift + ="; 
            roleData = MenuItemRole.Zoomin |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = option.None;
            labelData = Some "Zoom Out";
            acceleratorData = Some "CmdOrCtrl + Shift + -"; 
            roleData = MenuItemRole.Zoomout |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = option.None; 
            labelData = Some "Reset Zoom";
            acceleratorData = Some "CmdOrCtrl + Shift + 0"; 
            roleData = MenuItemRole.Resetzoom |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = option.None;
            labelData = Some "Toggle Dev Tool";
            acceleratorData = Some "CmdOrCtrl + Shift + I"; 
            roleData = MenuItemRole.Toggledevtools |> U2.Case1 |> Some },
            defaultMenuSetupOptional);  
    ]

let viewMenu =     
    ({ clickData = option.None;
      labelData = Some "View";
      acceleratorData = option.None; 
      roleData = option.None },
      replaceSubmenuData viewSubmenu)
 
let createAboutWindow () =     
    aboutWindowInit ()

let helpSubmenu = 
    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some
    let openExternalLink = handlerCaster (fun _ _ -> electron.shell.openExternal "https://github.com/ImperialCollegeLondon/HDL_Editor" |> ignore)
    let clickFunction = handlerCaster (fun _ _ -> createAboutWindow ())
    [   
        ({  clickData = openExternalLink;
            labelData = Some "GitHub Repository";
            acceleratorData = option.None; 
            roleData = option.None },
            defaultMenuSetupOptional);
        
        menuSeparator;

        ({  clickData = clickFunction;
            labelData = Some "About";
            acceleratorData = option.None; 
            roleData = option.None },
            {defaultMenuSetupOptional with idData = Some "aboutMenuItem"})
    ]

let helpMenu= 
    ({  clickData = option.None;
        labelData = Some "Help";
        acceleratorData = option.None; 
        roleData = option.None },
        replaceSubmenuData helpSubmenu)

let popupMenuInit () =
    let menu = electron.remote.Menu.Create()
    let menuItemOptions = createEmpty<MenuItemOptions>
    menuItemOptions.label <- Some "YES"
    menuItemOptions.visible <- Some true
    [menuItemOptions]
    |> List.map electron.remote.MenuItem.Create
    |> List.iter menu.append
    menu.popup (electron.remote.getCurrentWindow())

/// template used in Main for building the menu
/// refer to the Fable.Import.Electron.fs source code for type requirement
let menubarInit () = 
    [ fileMenu; 
      editMenu;
      viewMenu;
      helpMenu
    ]
    |> List.map menuBuilder
    |> ResizeArray<MenuItemOptions> 
    |> electron.remote.Menu.buildFromTemplate
    |> electron.remote.Menu.setApplicationMenu

