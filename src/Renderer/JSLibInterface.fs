module JSLibInterface

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

let joint : obj = importAll "jointjs"

type PaperBackgroundColor = 
    abstract color: string option with get, set

type PaperSettings = 
    abstract el: HTMLElement option with get, set
    abstract model: obj option with get, set
    abstract width: int option with get, set
    abstract height: int option with get, set
    abstract gridSize: int option with get, set
    abstract drawGrid: bool option with get, set
    abstract background: PaperBackgroundColor option with get, set

type RectangleBody = 
    abstract fill: string option with get, set

type RectangleLabel = 
    abstract text: string option with get, set
    abstract fill: string option with get, set

type RectangleAttr = 
    abstract body: RectangleBody option with get, set
    abstract label: RectangleLabel option with get, set

type AnchorName = 
    abstract name: string option with get, set

type AnchorArgs = 
    abstract rotate: bool option with get, set
    abstract dx: U2<int, string> option with get, set
    abstract dy: U2<int, string> option with get,set

type Anchor = 
    abstract anchor: AnchorName option with get, set
    abstract args: AnchorArgs option with get, set

type ConnectionPointArgs = 
    abstract offset: int option with get, set

type ConnectionPoint = 
    abstract name: string option with get, set
    abstract args: ConnectionPointArgs option with get, set

type PaperDefaultConnectionPointArgs = 
    abstract sticky: bool option with get, set

type PaperDecaultConnectionPoint = 
    abstract name: string option with get, set
    abstract args: PaperDefaultConnectionPointArgs option with get, set

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
        [<Emit("$0.clone()")>] abstract member Clone: cloneTarget:obj -> obj
    
    
    