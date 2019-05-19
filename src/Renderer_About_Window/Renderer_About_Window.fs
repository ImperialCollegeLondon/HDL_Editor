module Renderer_About_Window

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

let joint : obj = importAll "jointjs"

[<Emit("joint.version")>]
let jointVersion : string = jsNative

let init() = 
    //addBlock()
    printfn "The About window is initialized."

init() |> ignore

electron.ipcRenderer.on("update-jointjs-version", unbox(fun (content:WebContents) ->
    let el = Browser.getElementById("jointjs-version")
    printfn "el: %A" el
    el.innerHTML <- jointVersion
)) |> ignore
