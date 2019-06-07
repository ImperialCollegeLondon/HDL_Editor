module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open Menubar
open Jointjs
open Tabs
open Fable.Import.Electron

let init() = 
    canvasInit()
    newTabButtonInit()
    menubarInit()    

init() |> ignore
