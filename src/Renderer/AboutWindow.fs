module AboutWindow

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let createAboutWindow () = 
    electron.ipcRenderer.send("open-about-window")
