module JSLibInterface

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

let joint : obj = importAll "jointjs"

type PaperSettings = 
    abstract el: HTMLElement with get, set
    abstract model: obj with get, set
    abstract width: int with get, set
    abstract height: int with get, set
    abstract gridSize: int with get, set

[<Emit("new joint.dia.Graph")>]
let graphInit : obj = jsNative

[<Emit("new joint.dia.Paper($0)")>]
let paperInit paperConfig : obj = jsNative

[<Emit("new joint.shapes.standard.Rectangle()")>]
let rectInit : obj = jsNative

[<Emit("new joint.shapes.standard.Link()")>]
let linkInit : obj = jsNative

[<Emit("joint.version")>]
let jointVersion : string = jsNative

module Joint = 
    type [<Import("*", from="jointjs")>] JointJS = 
        [<Emit("new joint.dia.Graph")>] abstract graph: obj
        [<Emit("new joint.dia.Paper($0)")>] abstract member paper: obj -> obj
        [<Emit("new joint.shapes.standard.Rectangle()")>] abstract member rectangle: obj
        [<Emit("new joint.shapes.standard.Link()")>] abstract member link: obj
        [<Emit("$0.position($1, $2)")>] abstract member position: el:obj -> x:int -> y:int -> obj
    
    
    