module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System
open JSLibInterface

let joint : obj = importAll "jointjs"
    
let canvasInit() = 
   
    let lib = createEmpty<JointJS>
  
    let jointJSCreatorInterface = new createElement()
    let jointJSCreator = jointJSCreatorInterface :> JointJS
    let graph = jointJSCreator.GraphInit ()

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

    let paper = jointJSCreator.PaperInit paperSettings

    let paperDefaultConnectionPointArgs = createEmpty<PaperDefaultConnectionPointArgs>
    paperDefaultConnectionPointArgs.sticky <- Some true
    let paperDefaultConnectionPoint = createEmpty<PaperDecaultConnectionPoint>
    paperDefaultConnectionPoint.name <- Some "anchor"
    paperDefaultConnectionPoint.args <- Some paperDefaultConnectionPointArgs

    paper?options?defaultConnectionPoint <- paperDefaultConnectionPoint

    let rect = jointJSCreator.RectangleInit ()

    let rectangleBody = createEmpty<RectangleBody>
    rectangleBody.fill <- Some "white"

    let rectangleLabel = createEmpty<RectangleLabel>
    rectangleLabel.fill <- Some "Black"
    rectangleLabel.text <- Some "Hello"

    let rectangleAttr = createEmpty<RectangleAttr>
    rectangleAttr.body <- Some rectangleBody
    rectangleAttr.label <- Some rectangleLabel
    
    rect 
    |> jointJSCreator.Position 100 30
    |> jointJSCreator.Resize 100 40 
    |> jointJSCreator.Attr rectangleAttr
    |> jointJSCreator.AddTo graph
    |> ignore

    let rect2 = jointJSCreator.Clone rect
    rect2
    |> jointJSCreator.Translate 300 0
    |> jointJSCreator.AttrBySelector "label/text" "world!"
    |> jointJSCreator.AddTo graph
    |> ignore

    let anchorNameSource = createEmpty<AnchorName>
    anchorNameSource.name <- Some "right"
    let anchorArgsSource = createEmpty<AnchorArgs>
    anchorArgsSource.rotate <- Some false
    anchorArgsSource.dx <- Some (U2.Case2 "0%")
    anchorArgsSource.dy <- Some (U2.Case2 "0%")
    let anchorSource = createEmpty<Anchor>
    anchorSource.anchor <- Some anchorNameSource
    anchorSource.args <- Some anchorArgsSource

    let link = jointJSCreator.LinkInit ()
    link?source(rect, anchorNameSource) |> ignore

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
    jointJSCreator.Router link Manhattan |> ignore
    link?addTo(graph) |> ignore


    let statusRect = rect?clone()
    statusRect?translate(500, 500)
              ?attr("label/text", "Status")
              ?addTo(graph) |> ignore

    ///
    
    let toolPane = jointJSCreator.RectangleInit ()

    let rectangleBodyToolPane = createEmpty<RectangleBody>
    rectangleBodyToolPane.fill <- Some "white"

    let rectangleLabelToolPane = createEmpty<RectangleLabel>
    rectangleLabelToolPane.fill <- Some "Black"
    rectangleLabelToolPane.text <- Some "Tool Pane"
    //rectangleLabelToolPane.textAnchor <- Some "start"
    //rectangleLabelToolPane.textVerticalAnchor <- Some "start"

    let rectangleAttrToolPane = createEmpty<RectangleAttr>
    rectangleAttrToolPane.body <- Some rectangleBodyToolPane
    rectangleAttrToolPane.label <- Some rectangleLabelToolPane
    
    //lib.position rect 100 30 |> ignore
    toolPane?position(600, 50) |> ignore
    toolPane?resize(300, 600) |> ignore
    toolPane?attr(rectangleAttrToolPane) |> ignore
    toolPane?addTo(graph) |> ignore
    
    let e = 
        createObj[
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "fill" ==> "rgba(255,0,0,0.3)"
        ]

    let r = 
        createObj[
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "fill" ==> "rgba(0,255,0,0.3)"
        ]

    let c = 
        createObj[
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "fill" ==> "rgba(0,0,255,0.3)"
        ]
    
    let outline = 
        createObj[
            "refX" ==> 0
            "refY" ==> 0
            "refWidth" ==> "100%"
            "refHeight" ==> "100%"
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "strokeDasharray" ==> "5 5"
            "fill" ==> "none"
        ]

    let attrs = 
        createObj[
            "e" ==> e
            "r" ==> r
            "c" ==> c
            "outline" ==> outline
        ]
    
    let markup = 
        [|
            createObj[
                "tagName" ==> "ellipse"
                "selector" ==> "e"
            ];
            createObj[
                "tagName" ==> "rect"
                "selector" ==> "r"
            ];
            createObj[
                "tagName" ==> "circle"
                "selector" ==> "c"
            ];
            createObj[
                "tagName" ==> "rect"
                "selector" ==> "outline"
            ]
        |]

    let paneConfig = 
        createObj[
            "attrs" ==> attrs
        ]

    let markupList = 
        createObj[
            "markup" ==> markup
        ]

    let CustomElement  = joint?dia?Element?define("examples.Pane", paneConfig, markupList)

    let element = createNew CustomElement ()

    let elementAttre = 
        createObj[
            "refRx" ==> "50%"
            "refRy" ==> "25%"
            "refCx" ==> "50%"
            "refCy" ==> 0
            "refX" ==> "-50%"
            "refY" ==> "25%"
        ]

    let elementAttrr = 
        createObj[
            "refX" ==> "100%"
            "x" ==> "-10" // additional x offset
            "refY" ==> "100%"
            "y" ==> "-10" // additional y offset
            "refWidth" ==> "50%"
            "refHeight" ==> "50%"
        ]

    let elementAttrc = 
        createObj[
            "refRCircumscribed" ==> "50%"
            "refCx" ==> "50%"
            "refCy" ==> "50%"
        ]

    let elementAttr = 
        createObj[
            "e" ==> elementAttre
            "r" ==> elementAttrr
            "c" ==> elementAttrc
        ]

    element?attr(elementAttr) |> ignore
    element?position(600, 50) |> ignore
    element?resize(40, 40) |> ignore
    element?addTo(graph) |> ignore
