module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Node.Exports
open AboutWindow
open Menubar
open Electron

let remote = importMember<Remote> "electron"

let init() = 
    menubarInit()

init()
