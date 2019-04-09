module main

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Node.Exports

let mutable mainWindow: BrowserWindow option = Option.None

let createMainWindow () = 
    let options = createEmpty<BrowserWindowOptions>
    options.width <- Some 1368.
    options.height <- Some 1024.
    options.autoHideMenuBar <- Some false
    let window = electron.BrowserWindow.Create(options)

    let opts = createEmpty<Node.Url.Url<obj>>
    opts.pathname <- Some <| Path.join(Node.Globals.___dirname, "app/index.html")
    opts.protocol <- Some "file:"
    window.loadURL(Url.format(opts))

    mainWindow <- Some window