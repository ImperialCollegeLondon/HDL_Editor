module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

(*
[<Import("default", from="../../node_modules/jointjs/node_modules/jquery/dist/jquery")>]
let jquery: obj = jsNative

[<Import("default", from="../../node_modules/jointjs/node_modules/lodash/lodash")>]
let lodash: obj = jsNative

[<Import("default", from="../../node_modules/jointjs/node_modules/backbone/backbone")>]
let backbone: obj = jsNative

[<Import("*", from="../../node_modules/jointjs/dist/joint.js")>]
let joint : obj = jsNative
*)

let joint:obj = importAll "../../node_modules/jointjs"

//[<Import("*", from="../../app/js/JointJS_API")>]
//let jointAPI : obj = jsNative

type PaperSettings = 
    abstract el: HTMLElement with get, set
    abstract model: obj with get, set
    abstract width: int with get, set
    abstract height: int with get, set
    abstract gridSize: int with get, set

[<Pojo>]
type PaperRecord = 
    {
        el: HTMLElement;
        model: obj;
        width: int;
        height: int;
        gridSize: int;
    }


[<Emit("new joint.dia.Graph")>]
let graphInit : obj = jsNative

[<Emit("new joint.dia.Paper($0)")>]
let paperInit paperConfig : obj = jsNative

[<Emit("new joint.shapes.standard.Rectangle()")>]
let rectInit : obj = jsNative

[<Emit("rect.position($0, $1)")>]
let setPosition x y = jsNative

[<Emit("$0.resize($1, $2)")>]
let resize item width height = jsNative

[<Emit("$0.addTo($1)")>]
let addToGraph item graph = jsNative

[<Emit("$0 instanceof joint.dia.Graph")>]
let checkGraph graphInstance : bool = jsNative

[<Emit("$0 instanceof joint.dia.Paper")>]
let checkPaper paperInstance : bool = jsNative

[<Emit("$0 instanceof joint.shapes.standard.Rectangle")>]
let checkRect rectInstance : bool = jsNative

let result() = 
   
    (**)
    let graph = graphInit
    let mutable canvas : HTMLDivElement = unbox document.getElementById "myholder"

    printfn "Check graph: %A" <| checkGraph graph


    let paperSettings = 
        createObj [
            "el" ==> canvas
            "model" ==> graph
            "width" ==> 600
            "height" ==> 100
            "gridSize" ==> 1
        ]


    let paper = paperInit paperSettings

    printfn "Check paper: %A" <| checkPaper paper

    let rect = rectInit

    printfn "Check rect: %A" <| checkRect rect

    let body = 
        createObj [
            "fill" ==> "blue"
        ]

    let label =
        createObj [
            "text" ==> "hello"
            "fill" ==> "white"
        ]

    let attr = 
        createObj [
            "body" ==> body
            "label" ==> label
        ]
    
    let r = rect
    r?position(100, 30) |> ignore
    r?resize(100, 40) |> ignore
    r?attr(attr) |> ignore
    r?addTo(graph) |> ignore
    

    (*
    let canvas = document.getElementById("myCanvas")
    let ctx = canvas?getContext("2d")
    ctx?fillStyle <- "#FF0000"
    ctx?fillRect <- (0,0,150,75)
    *)
    //printfn "%O" attr
    console.log(attr)

    //setPosition rect 100 30
   

    
    //let res = jointAPI?all()
    //res
    