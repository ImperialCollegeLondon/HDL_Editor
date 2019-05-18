module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

let css : obj = importAll "../../node_modules/jointjs/dist/joint.css";

let joint : obj = importAll "../../node_modules/jointjs"

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

[<Emit("$0 instanceof joint.dia.Graph")>]
let checkGraph graphInstance : bool = jsNative

[<Emit("$0 instanceof joint.dia.Paper")>]
let checkPaper paperInstance : bool = jsNative

[<Emit("$0 instanceof joint.shapes.standard.Rectangle")>]
let checkRect rectInstance : bool = jsNative

let result() = 
   
    let graph = graphInit
    let mutable canvas : HTMLDivElement = unbox document.getElementById "myholder"

    let paperSettings = 
        createObj [
            "el" ==> canvas
            "model" ==> graph
            "width" ==> 600
            "height" ==> 100
            "gridSize" ==> 1
        ]

    let paper = paperInit paperSettings

    let rect = rectInit

    let body = 
        createObj [
            "fill" ==> "white"
        ]

    let label =
        createObj [
            "text" ==> "hello"
            "fill" ==> "black"
        ]

    let attr = 
        createObj [
            "body" ==> body
            "label" ==> label
        ]
    
    rect?position(100, 30) |> ignore
    rect?resize(100, 40) |> ignore
    rect?attr(attr) |> ignore
    rect?addTo(graph) |> ignore

    let rect2 = rect?clone()
    rect2?translate(300, 0) |> ignore
    rect2?attr("label/text", "world!") |> ignore
    rect2?addTo(graph) |> ignore

    let link = linkInit
    link?source(rect) |> ignore
    link?target(rect2) |> ignore
    link?addTo(graph) |> ignore
    