module Main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open System
open Fable.Import.Node
open BlockLogic

/// block storage
let mutable (blockStorage : BlockInfo List) = []

/// connection storage
let mutable (connectionStorage : ConnectionInfo List) = []

// Keep a global reference of the window object, if you don't, the window will
// be closed automatically when the JavaScript object is garbage collected.
let mutable mainWindow: BrowserWindow option = Option.None

let mutable aboutWindow: BrowserWindow option = Option.None

let createMainWindow () =
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 1500.
    options.height <- Some 800.
    options.autoHideMenuBar <- Some false
    options.title <- Some "HDL Editor"
    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    options.webPreferences <- Some prefs


    let window = electron.BrowserWindow.Create(options)
    
    // Load the index.html of the app.
    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some (Node.Exports.path.join(Node.Globals.__dirname, "../index.html"))
    opts.protocol <- Some "file:"
    window.loadURL(Node.Exports.url.format(opts))

    
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
        mainWindow <- Option.None
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
    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    options.webPreferences <- Some prefs
    let window = electron.BrowserWindow.Create(options)

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some (Node.Exports.path.join(Node.Globals.__dirname, "../about.html"))
    opts.protocol <- Some "file:"
    window.loadURL(Node.Exports.url.format(opts))

    // Emitted when the window is closed.
    window.on("closed", unbox(fun () ->
        // Dereference the window object, usually you would store windows
        // in an array if your app supports multi windows, this is the time
        // when you should delete the corresponding element.
        aboutWindow <- Option.None
    )) |> ignore

    window.show()

    aboutWindow <- Some window

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

electron.ipcMain.on("open-about-window", unbox(fun (event:IpcMainEvent) ->
    if aboutWindow.IsNone then
        createAboutWindow()
        let windowContent = match aboutWindow with
                            | option.None -> failwithf "the About window should have contents"
                            | Some content -> content.webContents
        event.sender.send("update-jointjs-version", windowContent)
)) |> ignore