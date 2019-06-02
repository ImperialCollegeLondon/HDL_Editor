module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface

let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

/// initialize the tool pane
let toolPaneInit() = 
    let r1 = generateNewElementAttrSub 1 "#000000" "rgba(255,0,0,0.3)" "Register" "white"

    let r2 = generateNewElementAttrSub 1 "#000000" "rgba(0,255,0,0.3)" "Gates" "white"
       
    let r3 = generateNewElementAttrSub 1 "#000000" "rgba(0,0,255,0.3)" "D-FF" "white"

    let r4 = generateNewElementAttrSub 1 "#000000" "rgba(0,100,255,0.3)" "Something" "white"

    let t1 = 
        createObj[
            "textAnchor" ==> "left"
            "fontSize" ==> 15
        ]
    
    let outline = 
        createObj[
            "refX" ==> 0
            "refY" ==> 0
            "refWidth" ==> "100%"
            "refHeight" ==> "100%"
            "strokeWidth" ==> 1
            "stroke" ==> "#000000"
            "fill" ==> "none"
        ]

    let individualAttr = 
        createObj[
            "r1" ==> r1            
            "r2" ==> r2
            "r3" ==> r3    
            "r4" ==> r4
            "outline" ==> outline
            "text" ==> t1
        ]

    let attr = generateNewElementConfig individualAttr    
    
    let markupArray = generateMarkupArray [|"rect"; "r1";                                    
                                            "rect"; "r2";
                                            "rect"; "r3";
                                            "rect"; "r4";
                                            "rect"; "outline"   
                                            "text"; "text"
                                          |]

    let ToolPane = jointJSCreator.Define "custom.ToolPane" attr markupArray

    let shape = createNew ToolPane ()
    
    let elementAttrR1 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "10%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR2 = 
          createObj[
            "refX" ==> "55%"
            "x" ==> "0" // additional x offset
            "refY" ==> "10%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR3 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "30%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR4 = 
          createObj[
            "refX" ==> "54%"
            "x" ==> "0" // additional x offset
            "refY" ==> "30%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrText = 
        createObj[
            "refX" ==> "10%"
            "refY" ==> "12%"
            "text" ==> "test"
        ]

    let elementAttr = 
          createObj[
              "r1" ==> elementAttrR1
              "r2" ==> elementAttrR2
              "r3" ==> elementAttrR3
              "r4" ==> elementAttrR4
              "text" ==> elementAttrText
          ]
    
    shape
    |> jointJSCreator.Attr elementAttr                 


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
    
    jointJSCreator.Router link Manhattan |> ignore

    let toolPane = toolPaneInit ()

    toolPane
    |> jointJSCreator.Position 600 10
    |> jointJSCreator.Resize 200 400
    |> jointJSCreator.AddTo graph
    |> ignore
    
