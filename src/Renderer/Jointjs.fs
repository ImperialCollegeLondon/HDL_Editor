module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System
open JSLibInterface

let joint : obj = importAll "jointjs"

let result() = 
   
    let lib = createEmpty<Joint.JointJS>
    let graph = lib.graph
    let mutable canvas : HTMLDivElement = unbox document.getElementById "myholder"

    let paperSettings = 
        createObj [
            "el" ==> canvas
            "model" ==> graph
            "width" ==> 1000
            "height" ==> 700
            "gridSize" ==> 10
            "drawGrid" ==> true
            "background" ==> createObj [
                "color" ==> "rgba(0, 0, 0, 0)"
            ]
        ]

    let paper = paperInit paperSettings

    let rect = lib.rectangle

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
    
    //lib.position rect 100 30 |> ignore
    rect?position(100, 30) |> ignore
    rect?resize(100, 40) |> ignore
    rect?attr(attr) |> ignore
    rect?addTo(graph) |> ignore

    let rect2 = rect?clone()
    rect2?translate(300, 0) |> ignore
    rect2?attr("label/text", "world!") |> ignore
    rect2?addTo(graph) |> ignore

    let link = lib.link
    link?source(rect) |> ignore
    link?target(rect2) |> ignore
    link?router("orthogonal") |> ignore
    link?addTo(graph) |> ignore

    let statusRect = rect?clone()
    statusRect?translate(500, 500)
              ?attr("label/text", "Status")
              ?addTo(graph) |> ignore
    