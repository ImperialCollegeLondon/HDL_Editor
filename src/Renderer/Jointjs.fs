module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

[<Import("default", from="../../node_modules/jointjs/node_modules/jquery/dist/jquery")>]
let jquery: obj = failwith "JS Only"

[<Import("default", from="../../node_modules/jointjs/node_modules/lodash/lodash")>]
let lodash: obj = jsNative

[<Import("default", from="../../node_modules/jointjs/node_modules/backbone/backbone")>]
let backbone: obj = jsNative

[<Import("default", from="../../node_modules/jointjs/dist/joint")>]
let joint: obj = jsNative

type PaperSettings = 
    abstract el: HTMLElement with get, set
    abstract model: obj with get, set
    abstract width: int with get, set
    abstract height: int with get, set
    abstract gridSize: int with get, set

type [<Pojo>] PaperRecord = 
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
   
    //let graph = createNew (joint?dia?Graph())
    let graph = graphInit
      
    (*
    let paperSettings = createEmpty<PaperSettings>
    paperSettings.el <- document.getElementById("myholder")
    paperSettings.model <- graph
    paperSettings.width <- 600
    paperSettings.height <- 100
    paperSettings.gridSize <- 1
    *)
    
    let paperSettings = 
        createObj [
            "el" ==> document.getElementById("myholder")
            "model" ==> graph
            "width" ==> uint64 600
            "height" ==> uint64 100
            "gridSize" ==> uint64 1
        ]
   
    //let paper = createNew (joint?dia?Paper(paperSettings))
    let paper = createNew (joint?dia?Paper [
            "el" ==> document.getElementById("myholder")
            "model" ==> graph
            "width" ==> "600."
            "height" ==> "100."
            "gridSize" ==> "1."
        ])

    let rect = createNew (joint?shapes?standard?Rectangle [])

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

    setPosition 100 30
    
    (*
    rect1?position(100., 30.)
    rect1?resize(100., 40.)
    rect1?attr(attr)
    rect1?addTo(graph)
    *)

    //setPosition rect 100 30