module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open Fable.Import.Electron
open System

[<Import("*", from="jquery")>]
let JQuery: obj = jsNative

[<Import("*", from="lodash")>]
let Lodash: obj = jsNative

[<Import("*", from="backbone")>]
let Backbone: obj = jsNative

[<Import("*", from="jointjs")>]
let joint: obj = jsNative

[<Emit("undefined")>]
let undefined : obj = jsNative

let addBlock() = 
    console.log(undefined)

[<Emit("$0 + $1")>]
let add (x: int) (y: int): float = jsNative
    
let result() = 
    console.log(add 1 2)

    (*
    let graph: obj = !!createNew joint?dia?Graph

    let paperSettings = 
        createObj [
            "el" ==> document.getElementById("myholder")
            "model" ==> graph
            "width" ==> 600
            "height" ==> 100
            "gridSize" ==> 1
        ]

    let paper = createNew joint?dia?Paper

    let rect = createNew joint?shapes?standard?Rectangle()

    let rectAttr = 
        createObj [
            "text" ==> "hello"
        ]

    let rectAttr' = 
        createObj [
            "label" ==> rectAttr
        ]


    rect?position(100,30)
    rect?resize(100,40)
    rect?attr(rectAttr')
    rect?addTo(graph)
    *)


(*
var graph = new joint.dia.Graph;

var paper = new joint.dia.Paper({
    el: document.getElementById('myholder'),
    model: graph,
    width: 600,
    height: 100,
    gridSize: 1
});

var rect = new joint.shapes.standard.Rectangle();
rect.position(100, 30);
rect.resize(100, 40);
rect.attr({
    body: {
        fill: 'blue'
    },
    label: {
        text: 'Hello',
        fill: 'white'
    }
});
rect.addTo(graph);

var rect2 = rect.clone();
rect2.translate(300, 0);
rect2.attr('label/text', 'World!');
rect2.addTo(graph);

var link = new joint.shapes.standard.Link();
link.source(rect);
link.target(rect2);
link.addTo(graph);

*)