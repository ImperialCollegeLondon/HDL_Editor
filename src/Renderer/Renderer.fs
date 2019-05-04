module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open AboutWindow
open Menubar

let init() = 
    menubarInit()

init()
