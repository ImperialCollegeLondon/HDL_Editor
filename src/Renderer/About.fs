module About

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let joint : obj = importAll "jointjs"

[<Emit("joint.version")>]
let jointVersion : string = jsNative

[<Emit("process.versions.electron")>]
let electronVersion : string = jsNative

[<Emit("process.versions.node")>]
let nodeVersion : string = jsNative

[<Emit("process.versions.chrome")>]
let chromeVersion : string = jsNative


let aboutWindowInit () = 
    let message = 
        [
            "JointJS version: ";
            jointVersion; "\n";
            "Electron version: ";
            electronVersion; "\n";
            "Node version: ";
            nodeVersion; "\n";
            "Chrome version: ";
            chromeVersion; "\n";
            "Author: Lei Wang (Wilson)\n";
            "License: MIT"
        ]
        |> String.concat " "

    let dialogOptions = createEmpty<Fable.Import.Electron.ShowMessageBoxOptions>
    dialogOptions.title <- Some "About HDL Editor"
    dialogOptions.message <- Some message
    dialogOptions.``type`` <- option.None
       
    let handlerCaster f = System.Func<float, unit> f

    let aboutDialogCallback (res:float) = ()
    
    let castedCallback = handlerCaster (fun a -> aboutDialogCallback a)

    let win = electron.remote.getCurrentWindow ()
    electron.remote.dialog.showMessageBox (win, dialogOptions, castedCallback)|> ignore