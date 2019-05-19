module Renderer_About_Window

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser

let joint : obj = importAll "jointjs"

[<Emit("joint.version")>]
let jointVersion : string = jsNative

let init() = 
    //addBlock()
    printfn "The About window is initialized."
    let el = Browser.document.getElementById("jointjs-version")
    printfn "el: %A" el
    el.innerHTML <- jointVersion

init() |> ignore