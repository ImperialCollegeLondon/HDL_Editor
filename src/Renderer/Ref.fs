(*
    The module stores the reference to the units in the GUI
*)
module Ref

open Fable.Core.JsInterop

/// store the current active pane
let mutable activePaneName:string = ""

/// store the current selected element
/// for copying and cutting
let mutable selectedElement:obj = createObj[]

/// store the current graph model
/// for file saving and loading
let mutable currentGraphModel:obj = createObj[]

/// store the current paper model
/// for file saving and loading
let mutable currentPaperModel:obj = createObj[]

/// store the current relational mode
/// for file saving and loading
//let mutable currentRelationalModel: