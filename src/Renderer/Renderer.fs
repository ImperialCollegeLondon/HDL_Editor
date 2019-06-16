module Renderer

open Tabs
open Menubar

/// initializes the GUI
/// order of initializing each element is important
let init() = 
    menubarInit()        
    newTabButtonInit()    

init() |> ignore

