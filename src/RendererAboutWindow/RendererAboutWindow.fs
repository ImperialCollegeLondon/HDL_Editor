module RendererAboutWindow

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser

let joint : obj = importAll "jointjs"

[<Emit("joint.version")>]
let jointVersion : string = jsNative

[<Emit("process.versions.electron")>]
let electronVersion : string = jsNative

[<Emit("process.versions.node")>]
let nodeVersion : string = jsNative

[<Emit("process.versions.chrome")>]
let chromeVersion : string = jsNative


let init() = 

    document.getElementById("jointjs-version").innerHTML <- "JointJS version: " + jointVersion
    document.getElementById("electron-version").innerHTML <- "Electron version: " + electronVersion
    document.getElementById("node-version").innerHTML <- "Node version: " + nodeVersion
    document.getElementById("chrome-version").innerHTML <- "Chrome version: " + chromeVersion

init() |> ignore