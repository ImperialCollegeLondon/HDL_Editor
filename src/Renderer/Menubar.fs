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
open AboutWindow

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
      typeData = Option.None; 
      sublabelData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      idData = Option.None;
      positionData = Option.None;
      submenuData = Option.None;
    }

/// the bar in a drop down menu that separates the menu items
let menuSeparator = 
    ({  clickData = Option.None;
        labelData = Option.None;
        acceleratorData = Option.None;
        roleData = Option.None},
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
    [
        ({  clickData = Option.None;
            labelData = Some "New";
            acceleratorData = Some "CmdOrCtrl + N"; 
            roleData = Option.None },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Save";
            acceleratorData = Some "CmdOrCtrl + S"; 
            roleData = Option.None },
            defaultMenuSetupOptional);

        ({  clickData = Option.None;
            labelData = Some "Save As";
            acceleratorData = Some "CmdOrCtrl + Shift + S"; 
            roleData = Option.None },
            defaultMenuSetupOptional);

        ({  clickData = Option.None; 
            labelData = Some "Open";
            acceleratorData = Some "CmdOrCtrl + O"; 
            roleData = Option.None },
            defaultMenuSetupOptional);
      
        ({  clickData = Option.None;
            labelData = Some "Close";
            acceleratorData = Some "CmdOrCtrl + W"; 
            roleData = Option.None },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Preference";
            acceleratorData = Some "CmdOrCtrl + S"; 
            roleData = Option.None },
            defaultMenuSetupOptional);
     
        ({  clickData = Option.None;
            labelData = Some "Exit";
            acceleratorData = Some "CmdOrCtrl + Q"; 
            roleData = MenuItemRole.Quit |> U2.Case1 |> Some },
            defaultMenuSetupOptional)
    ]

let fileMenu =     
    ({ clickData = Option.None;
      labelData = Some "File";
      acceleratorData = Option.None; 
      roleData = Option.None },
      replaceSubmenuData fileSubmenu)

let editSubmenu = 
    [
        ({  clickData = Option.None;
            labelData = Some "Undo";
            acceleratorData = Some "CmdOrCtrl + Z"; 
            roleData = MenuItemRole.Undo |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = Option.None;
            labelData = Some "Redo";
            acceleratorData = Some "CmdOrCtrl + Y"; 
            roleData = MenuItemRole.Redo |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Cut";
            acceleratorData = Some "CmdOrCtrl + X"; 
            roleData = MenuItemRole.Cut |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = Option.None; 
            labelData = Some "Copy";
            acceleratorData = Some "CmdOrCtrl + C"; 
            roleData = MenuItemRole.Copy |> U2.Case1 |> Some },
            defaultMenuSetupOptional);
      
        ({  clickData = Option.None;
            labelData = Some "Paste";
            acceleratorData = Some "CmdOrCtrl + V"; 
            roleData = MenuItemRole.Paste |> U2.Case1 |> Some },
            defaultMenuSetupOptional);
        
        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Select All";
            acceleratorData = Some "CmdOrCtrl + A"; 
            roleData = MenuItemRole.Selectall |> U2.Case1 |> Some },
            defaultMenuSetupOptional)
    ]

let editMenu =     
    ({ clickData = Option.None;
      labelData = Some "Edit";
      acceleratorData = Option.None; 
      roleData = Option.None },
      replaceSubmenuData editSubmenu)

let viewSubmenu = 
    [
        ({  clickData = Option.None;
            labelData = Some "Toggle Full Screen";
            acceleratorData = Some "F11"; 
            roleData = MenuItemRole.Togglefullscreen |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Zoom In";
            acceleratorData = Some "CmdOrCtrl + Shift + ="; 
            roleData = MenuItemRole.Zoomin |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = Option.None;
            labelData = Some "Zoom Out";
            acceleratorData = Some "CmdOrCtrl + Shift + -"; 
            roleData = MenuItemRole.Zoomout |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        ({  clickData = Option.None; 
            labelData = Some "Reset Zoom";
            acceleratorData = Some "CmdOrCtrl + Shift + 0"; 
            roleData = MenuItemRole.Resetzoom |> U2.Case1 |> Some },
            defaultMenuSetupOptional);

        menuSeparator;

        ({  clickData = Option.None;
            labelData = Some "Toggle Dev Tool";
            acceleratorData = Some "CmdOrCtrl + Shift + I"; 
            roleData = MenuItemRole.Toggledevtools |> U2.Case1 |> Some },
            defaultMenuSetupOptional);  
    ]

let viewMenu =     
    ({ clickData = Option.None;
      labelData = Some "View";
      acceleratorData = Option.None; 
      roleData = Option.None },
      replaceSubmenuData viewSubmenu)
   
let helpSubmenu = 
    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some
    let clickFunction = handlerCaster (fun _ _ -> createAboutWindow())
    [   
        ({  clickData = option.None;
            labelData = Some "Online Documentation";
            acceleratorData = Option.None; 
            roleData = Option.None },
            defaultMenuSetupOptional);
        
        menuSeparator;

        ({  clickData = clickFunction;
            labelData = Some "About";
            acceleratorData = Option.None; 
            roleData = Option.None },
            defaultMenuSetupOptional)
    ]

let helpMenu= 
    ({  clickData = Option.None;
        labelData = Some "Help";
        acceleratorData = Option.None; 
        roleData = Option.None },
        replaceSubmenuData helpSubmenu)

/// template used in Main for building the menu
/// refer to the Fable.Import.Electron.fs source code for type requirement
let menubarInit () = 
    [ fileMenu; 
      editMenu;
      viewMenu;
      helpMenu ]
    |> List.map menuBuilder
    |> ResizeArray<MenuItemOptions> 
    |> electron.remote.Menu.buildFromTemplate
    |> electron.remote.Menu.setApplicationMenu

