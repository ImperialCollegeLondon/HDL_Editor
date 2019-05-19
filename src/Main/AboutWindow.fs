module AboutWindow

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let joint : obj = importAll "jointjs"

[<Emit("joint.version")>]
let jointVersion : string = jsNative

let createAboutWindow () = 
    electron.ipcRenderer.send("open-about-window")
