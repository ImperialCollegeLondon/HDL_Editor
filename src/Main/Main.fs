module Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Node.Exports
open System

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mutable mainWindow: BrowserWindow option = Option.None
let mutable aboutWindow: BrowserWindow option = Option.None

let createAboutWindow () = 
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 400.
    options.height <- Some 300.
    options.autoHideMenuBar <- Some true
    options.resizable <- Some false
    let window = electron.BrowserWindow.Create(options)

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.__dirname, "../about.html")
    opts.protocol <- Some "file:"
    window.loadURL(Url.format(opts))

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        aboutWindow <- Option.None
    )) |> ignore

    window.show()

    aboutWindow <- Some window

type MenuSetup =     
    { clickData:Func<MenuItem, BrowserWindow, unit> option;
      typeData:MenuItemType option; 
      labelData:string option;
      sublabelData:string option; 
      acceleratorData:string option; 
      iconData:U2<NativeImage, string> option;
      enabledData:bool option;
      visibleData:bool option;
      checkedData:bool option;
      submenuData:U2<Menu, ResizeArray<MenuItemOptions>> option;
      idData:string option;
      positionData:string option;
      roleData:U2<MenuItemRole, MenuItemRoleMac> option }
    
let menuBuilder (menuContent:MenuSetup) = 
    let menu = createEmpty<MenuItemOptions>
    menu.click <- menuContent.clickData
    menu.``type`` <- menuContent.typeData
    menu.label <- menuContent.labelData
    menu.sublabel <- menuContent.sublabelData
    menu.accelerator <- menuContent.acceleratorData
    menu.icon <- menuContent.iconData
    menu.enabled <- menuContent.enabledData
    menu.visible <- menuContent.visibleData
    menu.``checked`` <- menuContent.checkedData
    menu.submenu <- menuContent.submenuData
    menu.id <- menuContent.idData
    menu.position <- menuContent.positionData
    menu.role <- menuContent.roleData
    menu

let submenuBuilder (submenuContent:MenuSetup list) = 
    let submenu = submenuContent 
                  |> List.map menuBuilder
    let submenuResizeArray = submenu
                             |> ResizeArray<MenuItemOptions> 
                             |> U2.Case2
                             |> Some
    submenuResizeArray

let fileMenuSubmenuSettings = 
    [ { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "New";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = Option.None;
      idData = Some "File_Sub_Menu_New";
      positionData = Option.None;
      roleData = Option.None };

      { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "Open";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = Option.None;
      idData = Some "File_Sub_Menu_Open";
      positionData = Option.None;
      roleData = Option.None };
      
      { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "Close";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = Option.None;
      idData = Some "File_Sub_Menu_Close";
      positionData = Option.None;
      roleData = Option.None };
      
      { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "Exit";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = Option.None;
      idData = Some "File_Sub_Menu_Exit";
      positionData = Option.None;
      roleData = Some (U2.Case1 MenuItemRole.Quit) } ]

let fileMenuSettings= 
    { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "File";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = fileMenuSubmenuSettings |> submenuBuilder;
      idData = Some "File_Menu";
      positionData = Option.None;
      roleData = Option.None }

let helpMenuSubmenuSettings = 
    let handlerCaster f = System.Func<MenuItem, BrowserWindow, unit> f |> Some
    let clickFunction = handlerCaster (fun _ _ -> createAboutWindow())
    [ { clickData = clickFunction;
      typeData = Option.None; 
      labelData = Some "About";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = Option.None;
      idData = Some "Help_Sub_Menu_About";
      positionData = Option.None;
      roleData = Option.None } ]

let helpMenuSettings= 
    { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "Help";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = helpMenuSubmenuSettings |> submenuBuilder;
      idData = Some "Help_Menu";
      positionData = Option.None;
      roleData = Option.None }

let createMainWindow () =
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 900.
    options.height <- Some 600.
    options.autoHideMenuBar <- Some false
    let window = electron.BrowserWindow.Create(options)

    // Load the index.html of the app.
    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.__dirname, "../index.html")
    opts.protocol <- Some "file:"
    window.loadURL(Url.format(opts))
    
    let template = ResizeArray<MenuItemOptions> [
        fileMenuSettings |> menuBuilder;
        helpMenuSettings |> menuBuilder;
    ]
    electron.Menu.setApplicationMenu(electron.Menu.buildFromTemplate(template))

    #if DEBUG
    Fs.watch(Path.join(Node.Globals.__dirname, "renderer.js"), fun _ _ ->
        window.webContents.reloadIgnoringCache()
    ) |> ignore
    #endif

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        mainWindow <- Option.None
    )) |> ignore

    // Maximize the window
    window.show()

    mainWindow <- Some window

// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
electron.app.on("ready", unbox createMainWindow) |> ignore

// Quit when all windows are closed.
electron.app.on("window-all-closed", unbox(fun () ->
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if Node.Globals.``process``.platform <> Node.Base.NodeJS.Darwin then
        electron.app.quit()
)) |> ignore

electron.app.on("activate", unbox(fun () ->
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if mainWindow.IsNone then
        createMainWindow()
)) |> ignore
