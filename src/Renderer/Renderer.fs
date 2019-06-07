module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open Menubar
open Jointjs
open Fable.Import.Electron
open MonacoEditor

let init() = 
    menubarInit()
    canvasInit()
    monacoEditorInit()

init() |> ignore
