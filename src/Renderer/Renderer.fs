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
