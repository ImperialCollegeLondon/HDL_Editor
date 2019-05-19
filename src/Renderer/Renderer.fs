module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open AboutWindow
open Menubar
open Jointjs
open Fable.Import.Electron

let init() = 
    menubarInit()
    //addBlock()
    result()

init() |> ignore

electron.ipcRenderer.on("update-jointjs-version", unbox(fun (content:WebContents) ->
    let el = Browser.document.firstChild
    //getElementById("jointjs-version")
    printfn "el: %A" el
    //el.innerHTML <- jointVersion
)) |> ignore
