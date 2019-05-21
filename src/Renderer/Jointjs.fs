module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System
open JSLibInterface

let joint : obj = importAll "jointjs"

let canvasInit() = 
   
    let lib = createEmpty<Joint.JointJS>
    let graph = lib.graph
    let mutable canvas : HTMLElement = unbox document.getElementById "myholder"

    let backgroundColor = createEmpty<PaperBackgroundColor>
    backgroundColor.color <- Some "rgba(0, 0, 0, 0)"

    let paperSettings = createEmpty<PaperSettings>
    paperSettings.el <- Some canvas
    paperSettings.model <- Some graph
    paperSettings.width <- Some 1000
    paperSettings.height <- Some 700
    paperSettings.gridSize <- Some 10
    paperSettings.drawGrid <- Some true
    paperSettings.background <- Some backgroundColor

    let paper = paperInit paperSettings

    let paperDefaultConnectionPointArgs = createEmpty<PaperDefaultConnectionPointArgs>
    paperDefaultConnectionPointArgs.sticky <- Some true
    let paperDefaultConnectionPoint = createEmpty<PaperDecaultConnectionPoint>
    paperDefaultConnectionPoint.name <- Some "anchor"
    paperDefaultConnectionPoint.args <- Some paperDefaultConnectionPointArgs

    paper?options?defaultConnectionPoint <- paperDefaultConnectionPoint

    let rect = lib.rectangle

    let rectangleBody = createEmpty<RectangleBody>
    rectangleBody.fill <- Some "white"

    let rectangleLabel = createEmpty<RectangleLabel>
    rectangleLabel.fill <- Some "Black"
    rectangleLabel.text <- Some "Hello"

    let rectangleAttr = createEmpty<RectangleAttr>
    rectangleAttr.body <- Some rectangleBody
    rectangleAttr.label <- Some rectangleLabel
    
    //lib.position rect 100 30 |> ignore
    rect?position(100, 30) |> ignore
    rect?resize(100, 40) |> ignore
    rect?attr(rectangleAttr) |> ignore
    rect?addTo(graph) |> ignore

    let rect2 = rect?clone()
    rect2?translate(300, 0) |> ignore
    rect2?attr("label/text", "world!") |> ignore
    rect2?addTo(graph) |> ignore

    let anchorNameSource = createEmpty<AnchorName>
    anchorNameSource.name <- Some "right"
    let anchorArgsSource = createEmpty<AnchorArgs>
    anchorArgsSource.rotate <- Some false
    anchorArgsSource.dx <- Some (U2.Case2 "0%")
    anchorArgsSource.dy <- Some (U2.Case2 "0%")
    let anchorSource = createEmpty<Anchor>
    anchorSource.anchor <- Some anchorNameSource
    anchorSource.args <- Some anchorArgsSource

    let link = lib.link
    link?source(rect, anchorSource) |> ignore

    let anchorNameTarget = createEmpty<AnchorName>
    anchorNameTarget.name <- Some "left"
    let anchorTarget = createEmpty<Anchor>
    anchorTarget.anchor <- Some anchorNameTarget

    let targetConnectionPointArgs = createEmpty<ConnectionPointArgs>
    targetConnectionPointArgs.offset <- Some 10
    let targetConnectionPoint = createEmpty<ConnectionPoint>
    targetConnectionPoint.args <- Some targetConnectionPointArgs
    targetConnectionPoint.name <- Some "anchor"

    link?target(rect2, anchorTarget) |> ignore
    link?router("orthogonal") |> ignore
    link?addTo(graph) |> ignore


    let statusRect = rect?clone()
    statusRect?translate(500, 500)
              ?attr("label/text", "Status")
              ?addTo(graph) |> ignore
    