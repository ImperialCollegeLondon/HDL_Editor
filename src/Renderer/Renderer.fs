module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open Menubar
open Jointjs
open Tabs
open Fable.Import.Electron

/// initializes the GUI
/// order of initializing each element is important
let init() = 
    menubarInit()        
    newTabButtonInit()    
    //canvasInit "pane1div"

init() |> ignore
