module AboutWindow

open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Node.Exports

let createAboutWindow () = 
    let mutable aboutWindow: BrowserWindow option = Option.None
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 400.
    options.height <- Some 300.
    options.autoHideMenuBar <- Some true
    options.resizable <- Some false
    options.parent <- Some (electron.remote.getCurrentWindow())
    options.modal <- Some true
    options.title <- Some "About HDL Editor"
    let prefs = createEmpty<WebPreferences>
    prefs.nodeIntegration <- Some true
    options.webPreferences <- Some prefs
    let window = electron.remote.BrowserWindow.Create(options)

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.__dirname, "about.html")
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
