module Renderer

open Tabs
open Menubar
open Fable.Import
open Fable.Import.Electron

/// initializes the GUI
/// order of initializing each element is important
let init() = 
    menubarInit()        
    newTabButtonInit()    

init()


let createNewTabHandler:IpcRendererEventListener = 
    let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
    let newTabHandler = handlerCaster (fun a b -> createNewPaneWithButton ())

    newTabHandler

electron.ipcRenderer.on("initialize-new-tab", createNewTabHandler) |> ignore

