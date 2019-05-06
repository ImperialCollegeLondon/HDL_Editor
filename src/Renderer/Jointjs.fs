module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

[<Import("default", from="jquery")>]
let JQuery: obj = jsNative

[<Import("default", from="lodash")>]
let Lodash: obj = jsNative

[<Import("default", from="backbone")>]
let Backbone: obj = jsNative

[<Import("default", from="jointjs")>]
let Joint: obj = importAll "jointjs"

[<Emit("undefined")>]
let undefined : obj = jsNative

let addBlock() = 
    printfn "%A" undefined

[<Emit("$0 + $1")>]
let add (x: int) (y: int): float = jsNative

type PaperSettings = 
    abstract el: HTMLElement with get, set
    abstract model: obj with get, set
    abstract width: int with get, set
    abstract height: int with get, set
    abstract gridSize: int with get, set

//[<Emit("new joint.dia.Graph")>]
//let graphInit =

[<Emit("new joint.dia.Paper($0)")>]
let paperInit args = jsNative

[<Emit("new joint.shapes.standard.Rectangle()")>]
let rectInit () = jsNative

[<Emit("$0.position($1, $2)")>]
let setPosition item x y = jsNative

[<Emit("$0.resize($1, $2)")>]
let resize item width height = jsNative

[<Emit("$0.addTo($1)")>]
let addToGraph item graph = jsNative

let result() = 
   
    let graph = createNew Joint?dia?Graph
      
    let paperSettings = createEmpty<PaperSettings>
    paperSettings.el <- document.getElementById("myholder")
    paperSettings.model <- graph
    paperSettings.width <- 600
    paperSettings.height <- 100
    paperSettings.gridSize <- 1

    let paper = paperInit paperSettings
    let rect = rectInit ()

    setPosition rect 100 30
    resize rect 100 40
    addToGraph rect graph
    printfn "here"
