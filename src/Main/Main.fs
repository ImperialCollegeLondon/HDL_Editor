module Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Browser
open Fable.Import.Node

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mutable mainWindow: BrowserWindow option = option.None

let mutable aboutWindow: BrowserWindow option = option.None

let mutable customLogicalElementConfigWindow: BrowserWindow option = option.None

/// craete the main window and set some of the properties
let createMainWindow () =
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 1500.
    options.height <- Some 800.
    options.autoHideMenuBar <- Some false
    options.title <- Some "HDL Editor"
    options.icon <- Some (U2.Case2 (path.join(Fable.Import.Node.Globals.__dirname, "../../icon.ico")))
    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    options.webPreferences <- Some prefs


    let window = electron.BrowserWindow.Create options
    
    // Load the index.html of the app.
    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some (path.join(Fable.Import.Node.Globals.__dirname, "../index.html"))
    opts.protocol <- Some "file:"
    window.loadURL (url.format(opts))
    window.setMenuBarVisibility true
    
    //window.webContents.openDevTools()

    window.on("ready-to-show", (fun () -> 
        window.show() 
        options.backgroundColor <- Some "#F0F0F0"
        window.focus()
     )) |> ignore

    
    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        mainWindow <- option.None
    )) |> ignore

    mainWindow <- Some window

let createAboutWindow () = 
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 400.
    options.height <- Some 300.
    options.autoHideMenuBar <- Some true
    options.resizable <- Some false
    options.modal <- Some true
    options.parent <- mainWindow
    options.title <- Some "About HDL Editor"
    options.icon <- Some (U2.Case2 (path.join(Fable.Import.Node.Globals.__dirname, "../../icon.ico")))
    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    options.webPreferences <- Some prefs
    let window = electron.BrowserWindow.Create options

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some (path.join(Fable.Import.Node.Globals.__dirname, "../about.html"))
    opts.protocol <- Some "file:"
    window.loadURL(url.format(opts))

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        aboutWindow <- option.None
    )) |> ignore

    window.show()

    aboutWindow <- Some window

let createCustomLogicElementConfigWindow () = 
    /// get the screen size of the primary display
    /// the height and the width of the window is set on the percentage of the display size
    let windowSize = electron.screen.getPrimaryDisplay().workAreaSize
    let width = windowSize.width * 0.3
    let height = windowSize.height * 0.3

    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some width
    options.height <- Some height
    options.autoHideMenuBar <- Some true
    options.resizable <- Some true
    options.modal <- Some true
    options.parent <- mainWindow
    options.title <- Some "Create new logical blocks"

    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    
    options.webPreferences <- Some prefs

    let window = electron.BrowserWindow.Create options

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some (path.join(Fable.Import.Node.Globals.__dirname, "../custom-block-config.html"))
    opts.protocol <- Some "file:"
    window.loadURL(url.format(opts))       

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        customLogicalElementConfigWindow <- option.None
    )) |> ignore

    window.show()

    customLogicalElementConfigWindow <- Some window


// This method will be called when Electron has finished
// initialization and is ready to create browser windows.
electron.app.on("ready", unbox createMainWindow) |> ignore

// Quit when all windows are closed.
electron.app.on("window-all-closed", unbox(fun () ->
    // On OS X it is common for applications and their menu bar
    // to stay active until the user quits explicitly with Cmd + Q
    if Fable.Import.Node.Globals.``process``.platform <> Fable.Import.Node.Base.NodeJS.Darwin then
        electron.app.quit()
)) |> ignore

electron.app.on("activate", unbox(fun () ->
    // On OS X it's common to re-create a window in the app when the
    // dock icon is clicked and there are no other windows open.
    if mainWindow.IsNone then
        createMainWindow ()
)) |> ignore

electron.ipcMain.on("open-about-window", unbox(fun (event:IpcMainEvent) ->
    if aboutWindow.IsNone then
        createAboutWindow ()
)) |> ignore

let handler:IpcMainEventListener = 
    let handlerCaster f = System.Func<IpcMainEvent, obj, unit> f
    let createWindow = handlerCaster (fun a b -> //console.log(a)
                                                 console.log(b)
                                                 createCustomLogicElementConfigWindow ())
    createWindow    

electron.ipcMain.on("open-new-logic-window", handler) |> ignore
