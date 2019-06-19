(*
    The module stores the reference to the units in the GUI
*)
module Ref

/// store the current active pane
let mutable activePaneName:string = ""

/// store the current selected element
/// for copying and cutting
let mutable selectedElement:obj option = option.None

/// store the current graph model
/// for file saving and loading
let mutable currentGraphModel:obj option = option.None

/// store the current paper model
/// for file saving and loading
let mutable currentPaperModel:obj option = option.None

/// store the current active tab id
let mutable activeTabId:string option = option.None

/// store the current file saving path
let mutable fileSavingPath:string option = option.None

/// store the mapping between block names and its corresponding configuration
let mutable blockNameConfigMapping:Map<string, string array> = Map.empty