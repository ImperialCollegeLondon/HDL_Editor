module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

[<Import("default", from="../../node_modules/jointjs/node_modules/jquery/dist/jquery")>]
let jquery: unit = jsNative

[<Import("default", from="../../node_modules/jointjs/node_modules/lodash/lodash")>]
let lodash: unit = jsNative

[<Import("default", from="../../node_modules/jointjs/node_modules/backbone/backbone")>]
let backbone: unit = jsNative

let joint : unit = importAll "jointjs"

[<Import("*", from="../../app/js/JointJS_API")>]
let jointAPI : obj = jsNative

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
let paperInit args : obj = jsNative

[<Emit("new joint.shapes.standard.Rectangle()")>]
let rectInit () = jsNative

[<Emit("rect.position($0, $1)")>]
let setPosition x y = jsNative

[<Emit("$0.resize($1, $2)")>]
let resize item width height = jsNative

[<Emit("$0.addTo($1)")>]
let addToGraph item graph = jsNative

let result() = 
   
    let graph = createNew joint?dia?Graph
    printfn "%O" graph
    let paperSettings = 
        createObj [
            "el" ==> document.getElementById("myholder")
            "width" ==> 600
            "height" ==> 100
            "gridSize" ==> 1
            "model" ==> graph
        ]

    let paper = createNew (unbox(joint?dia?Paper (paperSettings)))
    printfn "%O" paper
    let rect = createNew joint?shapes?standard?Rectangle
    printfn "%O" rect

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
    
    (*
    rect?position(100, 30)
    rect?resize(100, 40)
    rect?attr(attr)
    rect?addTo(graph)
    *)

    let canvas = document.getElementById("myCanvas")
    let ctx = canvas?getContext("2d")
    ctx?fillStyle <- "#FF0000"
    ctx?fillRect <- (0,0,150,75)
    printfn "%O" attr
    console.log(attr)

    //setPosition rect 100 30
   

    (*
    let res = jointAPI?all()
    res
    *)