module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

[<Import("default", from="../../node_modules/jointjs/node_modules/jquery/dist/jquery")>]
let jquery: obj = jsNative

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

[<Emit("$0.position($1, $2)")>]
let setPosition item x y = jsNative

[<Emit("$0.resize($1, $2)")>]
let resize item width height = jsNative

[<Emit("$0.addTo($1)")>]
let addToGraph item graph = jsNative

let result() = 
   
    let graph = createNew joint?dia?Graph
    //let graph = graphInit 

    graph
      
    (*
    let paperSettings = createEmpty<PaperSettings>
    paperSettings.el <- document.getElementById("myholder")
    paperSettings.model <- graph
    paperSettings.width <- 600
    paperSettings.height <- 100
    paperSettings.gridSize <- 1
    *)

    (*
    let paperSettings = 
        createObj [
            "el" ==> document.getElementById("myholder")
            "model" ==> graph
            "width" ==> 600
            "height" ==> 100
            "gridSize" ==> 1
        ]
    *)

    (*
    let paperSettings = 
        {
            el = document.getElementById("myholder");
            model = graph;
            width = 600;
            height = 100;
            gridSize = 1;
        }
    *)
   
    //let paper = paperInit paperSettings
    //let paper = createNew Joint?dia?Paper paperSettings
    //let rect = rectInit ()
    //let rect = createNew joint?shapes?standard?Rectangle ()

    //setPosition rect 100 30
    (*
    resize rect 100 40
    addToGraph rect graph
    printfn "here"
    *)

    //rect?position(100, 30)


    //printfn "%A" <| rect
    //rect
