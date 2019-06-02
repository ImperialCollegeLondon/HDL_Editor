module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System
open JSLibInterface

let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

/// initialize the tool pane
let toolPaneInit() = 
    let toolPane = jointJSCreator.RectangleInit ()

    //let attr = generateRectangleAttr "white" "Tool Pane" "black" "start" "start"

    //let e = generateNewElementAttrSub 1 "#000000" "rgba(255,0,0,0.3)"
    let e = createObj[
                "strokeWidth" ==> 1
                "stroke" ==> "#000000"
                "fill" ==> "rgba(255,0,0,0)"
            ]

    let r = generateNewElementAttrSub 1 "#000000" "rgba(0,255,0,0)"
       
    let c = generateNewElementAttrSub 1 "#000000" "rgba(0,0,255,0)"
    
    let outline = 
        createObj[
            "refX" ==> 0
            "refY" ==> 0
            "refWidth" ==> "100%"
            "refHeight" ==> "100%"
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "strokeDasharray" ==> "5 5"
            "strokeDashoffset" ==> 2.5
            "fill" ==> "none"
        ]

    let individualAttr = 
        createObj[
            "e" ==> e            
            "r" ==> r
            "c" ==> c    
            "outline" ==> outline
        ]

    let attr = createEmpty<NewElementConfig>
    attr.attr <- Some individualAttr

    
    let markupArray = generateMarkupArray [|"ellipse"; "e";                                    
                                            "rect"; "r";
                                            "circle"; "c";
                                            "rect"; "outline"                                            
                                          |]

    let ToolPane = jointJSCreator.Define "custom.ToolPane" attr markupArray

    let shape = createNew ToolPane ()
    
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
    
    shape
    |> jointJSCreator.Attr elementAttr
    
       

    (*
    toolPane
    |> jointJSCreator.Attr attr 
    *)


/// initialize the canvas
let canvasInit() =      
    
    let graph = jointJSCreator.GraphInit ()
    
    let mutable canvas : HTMLElement = unbox document.getElementById "myholder"

    let paperSettings = generatePaperSettings canvas graph 1400 650 10 true "rgba(0, 0, 0, 0)"

    let paper = jointJSCreator.PaperInit paperSettings

    let rect = jointJSCreator.RectangleInit ()

    let rectangleAttr = generateRectangleAttr "white" "Hello" "Black" "middle" "middle"
    
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

    let sourceAnchorConfig = generateAnchor Right true (U2.Case1 0) (U2.Case1 0)
    let sinkAnchorConfig = generateAnchor Left true (U2.Case1 0) (U2.Case1 0)

    let link = jointJSCreator.LinkInit ()
    link
    |> jointJSCreator.Source rect sourceAnchorConfig
    |> jointJSCreator.Target rect2 sinkAnchorConfig
    |> jointJSCreator.AddTo graph
    |> ignore
    
    jointJSCreator.Router link Orthogonal |> ignore

    let toolPane = toolPaneInit ()
    toolPane?position(600, 5) |> ignore
    toolPane?resize(100, 100) |> ignore
    toolPane?addTo(graph) |> ignore
