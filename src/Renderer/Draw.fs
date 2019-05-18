module Draw

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser

module DrawWithJointJS = 

    type Graph = obj

    type PaperConfig = 
        {
            el: HTMLDivElement
            model: Graph
            width: int
            height: int
            gridSize: int
        }

    type Paper = obj

    type RectBody = 
        abstract member fill: string with get, set

    type RectLabel = 
        abstract member text: string with get, set
        abstract member fill: string with get, set

    type RectAttr = 
        abstract member body: RectBody with get, set
        abstract member label: RectLabel with get, set

    type Rect = obj

    type ICreateGraph = 
        abstract createGraph: unit -> Graph
     
    type ICreatePaper = 
        abstract createPaper: paperConfig : PaperConfig -> Paper

    type ICreateRect = 
        abstract createRect: unit -> Rect

    [<Import("default", from="jointjs")>]
    let drawWithJointJS : ICreateRect = jsNative