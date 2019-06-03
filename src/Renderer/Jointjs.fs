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

    let r5 = generateNewElementAttrSub 1 "#000000" "rgba(0,100,255,0.3)" "Something" "white"

    let r6 = generateNewElementAttrSub 1 "#000000" "rgba(0,100,255,0.3)" "Something" "white"

    let r7 = generateNewElementAttrSub 1 "#000000" "rgba(0,100,255,0.3)" "Something" "white"
    
    let r8 = generateNewElementAttrSub 1 "#000000" "rgba(0,100,255,0.3)" "Something" "white"

    let textConfigCreator textAnchor fontSize = 
        createObj[
            "textAnchor" ==> textAnchor
            "fontSize" ==> fontSize
        ]

    let t1 = textConfigCreator "middle" 15

    let button = 
        createObj[
            "cursor" ==> "pointer"
            "ref" ==> "buttonLabel"
            "refWidth" ==> "150%"
            "refHeight" ==> "150%"
            "refX" ==> "-25%"
            "refY" ==> "-25%"
        ]
    
    let buttonLabel = 
        createObj[
            "pointerEvents" ==> "none"
            "refX" ==> "100%"
            "refY" ==> 0
            "textAnchor" ==> "middle"
            "textVerticalAnchor" ==> "middle"
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
            "r5" ==> r5
            "r6" ==> r6
            "r7" ==> r7
            "r8" ==> r8
            "outline" ==> outline
            "text1" ==> t1
            "text2" ==> t1
            "text3" ==> t1
            "text4" ==> t1
            "text5" ==> t1
            "text6" ==> t1
            "text7" ==> t1
            "text8" ==> t1
            "button" ==> button
            "buttonLabel" ==> buttonLabel
        ]

    let attr = generateNewElementConfig individualAttr    
    
    let markupArray = generateMarkupArray [|"rect"; "r1";                                    
                                            "rect"; "r2";
                                            "rect"; "r3";
                                            "rect"; "r4";
                                            "rect"; "r5";
                                            "rect"; "r6";
                                            "rect"; "r7";
                                            "rect"; "r8";
                                            "rect"; "outline";   
                                            "text"; "text1";
                                            "text"; "text2";
                                            "text"; "text3";
                                            "text"; "text4";
                                            "text"; "text5";
                                            "text"; "text6";
                                            "text"; "text7";
                                            "text"; "text8";
                                            "rect"; "button";
                                            "text"; "buttonLabel"
                                          |]

    let ToolPane = jointJSCreator.Define "custom.ToolPane" attr markupArray

    let shape = createNew ToolPane ()
    
    let elementAttrR1 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "15%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
            "visibility" ==> "visible"
          ]

    let elementAttrR2 = 
          createObj[
            "refX" ==> "55%"
            "x" ==> "0" // additional x offset
            "refY" ==> "15%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR3 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "35%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR4 = 
          createObj[
            "refX" ==> "55%"
            "x" ==> "0" // additional x offset
            "refY" ==> "35%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR5 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "60%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR6 = 
          createObj[
            "refX" ==> "55%"
            "x" ==> "0" // additional x offset
            "refY" ==> "60%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR7 = 
          createObj[
            "refX" ==> "5%"
            "x" ==> "0" // additional x offset
            "refY" ==> "80%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]

    let elementAttrR8 = 
          createObj[
            "refX" ==> "55%"
            "x" ==> "0" // additional x offset
            "refY" ==> "80%"
            "y" ==> "0" // additional y offset
            "refWidth" ==> "40%"
            "refHeight" ==> "10%"
          ]            

    let elementAttrText1 = 
        createObj[
            "refX" ==> "25%"
            "refY" ==> "18%"
            "text" ==> "test1"
        ]

    let elementAttrText2 = 
        createObj[
            "refX" ==> "75%"
            "refY" ==> "18%"
            "text" ==> "test2"
        ]

    let elementAttrText3 = 
        createObj[
            "refX" ==> "25%"
            "refY" ==> "38%"
            "text" ==> "test3"
        ]

    let elementAttrText4 = 
        createObj[
            "refX" ==> "75%"
            "refY" ==> "38%"
            "text" ==> "test4"
        ]

    let elementAttrText5 = 
        createObj[
            "refX" ==> "25%"
            "refY" ==> "63%"
            "text" ==> "test5"
        ]

    let elementAttrText6 = 
        createObj[
            "refX" ==> "75%"
            "refY" ==> "63%"
            "text" ==> "test6"
        ]

    let elementAttrText7 = 
        createObj[
            "refX" ==> "25%"
            "refY" ==> "83%"
            "text" ==> "test7"
        ]

    let elementAttrText8 = 
        createObj[
            "refX" ==> "75%"
            "refY" ==> "83%"
            "text" ==> "test8"
        ]

    let elementButton = 
        createObj[
            "event" ==> "element:button:pointerdown"
            "fill" ==> "orange"
            "stroke" ==> "black"
            "strokeWidth" ==> 2
        ]

    let elementButtonLabel = 
        createObj[
            "text" ==> "__" // fullwidth underscore
            "fill" ==> "black"
            "fontSize" ==> 8
            "fontWeight" ==> "bold"
        ]

    let elementAttr = 
          createObj[
              "r1" ==> elementAttrR1
              "r2" ==> elementAttrR2
              "r3" ==> elementAttrR3
              "r4" ==> elementAttrR4
              "r5" ==> elementAttrR5
              "r6" ==> elementAttrR6
              "r7" ==> elementAttrR7
              "r8" ==> elementAttrR8
              "text1" ==> elementAttrText1
              "text2" ==> elementAttrText2
              "text3" ==> elementAttrText3
              "text4" ==> elementAttrText4
              "text5" ==> elementAttrText5
              "text6" ==> elementAttrText6
              "text7" ==> elementAttrText7
              "text8" ==> elementAttrText8
              "button" ==> elementButton
              "buttonLabel" ==> elementButtonLabel
          ]
    
    shape
    |> jointJSCreator.Attr elementAttr                 

let menuHideTestInit() = 
    let attrs = 
        createObj[
            "attrs" ==> createObj[
                            "body" ==> createObj[
                                          "refWidth" ==> "100%"
                                          "refHeight" ==> "100%"
                                          "strokeWidth" ==> 2
                                          "stroke" ==> "black"
                                          "fill" ==> "white"
                                       ]
                            "label" ==> createObj[
                                           "textVerticalAnchor" ==> "middle"
                                           "textAnchor" ==> "middle"
                                           "refX" ==> "50%"
                                           "refY" ==> "50%"
                                           "fontSize" ==> 14
                                           "fill" ==> "black"
                                        ]
                            "button" ==> createObj[
                                            "cursor" ==> "pointer"
                                            "ref" ==> "buttonLabel"
                                            "refWidth" ==> "150%"
                                            "refHeight" ==> "150%"
                                            "refX" ==> "-25%"
                                            "refY" ==> "-25%"
                                         ]
                            "buttonLabel" ==> createObj[
                                                 "pointerEvents" ==> "none"
                                                 "refX" ==> "100%"
                                                 "refY" ==> 0
                                                 "textAnchor" ==> "middle"
                                                 "textVerticalAnchor" ==> "middle"
                                              ]
                        ]
        ]

    let markupArray = generateMarkupArray [|"rect";"body";
                                            "text";"label";
                                            "rect";"button";
                                            "text";"buttonLabel"
                                          |]

    let CustomElement = joint?dia?Element?define("examples.CustomElement", attrs, markupArray)  

    let testBox = createNew CustomElement ()

    let testBoxConfig = 
        createObj[
            "label" ==> createObj[
                            "pointerEvents" ==> "none"
                            "visibility" ==> "visible"
                            "text" ==> "Element"
                        ]
            "body" ==> createObj[
                           "cursor" ==> "default"
                           "visibility" ==> "visible"
                       ]
            "button" ==> createObj[
                            "event" ==> "element:button:pointerdown"
                            "fill" ==> "orange"
                            "stroke" ==> "black"
                            "strokeWidth" ==> 2
                         ]
            "buttonLabel" ==> createObj[
                                 "text" ==> "__" // fullwidth underscore
                                 "fill" ==> "black"
                                 "fontSize" ==> 8
                                 "fontWeight" ==> "bold"
                              ]
        ]

    testBox
    |> jointJSCreator.Attr testBoxConfig

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

    let testBox = menuHideTestInit ()

    testBox
    |> jointJSCreator.Position 400 400
    |> jointJSCreator.Resize 100 40
    |> jointJSCreator.AddTo graph
    |> ignore

    paper?on("element:button:pointerdown", unbox (fun (elementView) ->
        //evt?stopPropagation() |> ignore

        let model = elementView?model     

        if model?attr("body/visibility") = "visible" then model?attr("body/visibility", "hidden") else model?attr("body/visibility", "visible")
        model?attr("r1/visibility", "hidden")

    )) |> ignore
    

    paper?on("blank:pointerdblclick", unbox (fun () ->
        let background = 
            createObj[
                "color" ==> "orange"
            ]
        
        paper?drawBackground(background)
            
    )) |> ignore

