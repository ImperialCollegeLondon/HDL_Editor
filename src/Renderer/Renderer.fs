module Renderer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Electron
open Node.Exports

let filesize = import<obj> "*" "file-size"
// This is a dynamic programming instruction because we don't have a binding for file-size lib
let sizeToHuman (size: float) : string = (filesize $ (size))?human $ ("si") |> unbox<string>


// Used to storage a reference of the about window
// Otherwise, the window is destroy by the Garbage Collector
let mutable aboutWindow : BrowserWindow option = Option.None

// Reference to the electron process
// This allow us to create new window later for example
let remote = importMember<Remote> "electron"

// Data pass on a navigation event
type Navigate =
    { Path : string }

// Create a navigation event which handle path update
let navigation = Event<Navigate>()


let init () =
    null

init()