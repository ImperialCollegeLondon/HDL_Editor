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
      idData = Some "File_Menu";
      positionData = Option.None;
      roleData = Some (U2.Case1 MenuItemRole.Quit) }

let fileMenuSettings= 
    let fileSubmenu = submenuBuilder [fileMenuSubmenuSettings]
    { clickData = Option.None;
      typeData = Option.None; 
      labelData = Some "File";
      sublabelData = Option.None; 
      acceleratorData = Option.None; 
      iconData = Option.None;
      enabledData = Some true;
      visibleData = Some true;
      checkedData = Some false;
      submenuData = fileSubmenu;
      idData = Some "File_Menu";
      positionData = Option.None;
      roleData = Option.None }

let createMainWindow () =
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 1366.
    options.height <- Some 1024.
    options.autoHideMenuBar <- Some false
    let window = electron.BrowserWindow.Create(options)

    // Load the index.html of the app.
    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.__dirname, "../index.html")
    opts.protocol <- Some "file:"
    window.loadURL(Url.format(opts))
    
    let filemenu = menuBuilder(fileMenuSettings)
    let template = ResizeArray<MenuItemOptions> [
        filemenu
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
    window.maximize()

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
