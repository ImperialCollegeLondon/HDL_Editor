module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Node.Exports
open Menubar

let init() = 
    menubarInit()

let handleDocumentReady = { new EventListenerObject with
    member x.handleEvent (_ : Event) = init()
     }

init()

document.addEventListener ("ready", U2.Case2 handleDocumentReady)
