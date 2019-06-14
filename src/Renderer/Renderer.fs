module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open Menubar
open Jointjs
open Tabs
open Fable.Import.Electron
open Fable.Import.Browser

/// initializes the GUI
/// order of initializing each element is important
let init() = 
    menubarInit()        
    newTabButtonInit()    

init() |> ignore

let handler:IpcRendererEventListener = 
    let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
    let createWindow = handlerCaster (fun a b -> //console.log(a)
                                                 printfn("hello"))
    createWindow    

electron.ipcRenderer.on("new-blocks", handler) |> ignore

