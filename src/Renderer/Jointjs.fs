module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface

let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

[<Emit("$0.on($1, $2)")>]
let paperOnFunction paper (event:string) func = jsNative

/// define the blocks that can be added to the graph
type BlockType = 
    | InputPort
    | OutputPort
    | LogicElement

/// create input blocks
let inputPortInit () = 
    let rect = jointJSCreator.RectangleInit ()
    
    let rectangleAttr = generateRectangleAttr "white" "InputPort" "Black" "middle" "middle"

    rect 
    |> jointJSCreator.Resize 100 40 
    |> jointJSCreator.Attr rectangleAttr

/// create output blocks
let outputPortInit () = 
    let rect = jointJSCreator.RectangleInit ()
    
    let rectangleAttr = generateRectangleAttr "white" "OutputPort" "Black" "middle" "middle"

    rect 
    |> jointJSCreator.Resize 100 40 
    |> jointJSCreator.Attr rectangleAttr

/// create logic element blocks
let logicElementInit () = 
    let rect = jointJSCreator.RectangleInit ()
        
    let rectangleAttr = generateRectangleAttr "white" "LE" "Black" "middle" "middle"
    
    rect 
    |> jointJSCreator.Resize 100 40 
    |> jointJSCreator.Attr rectangleAttr
    
/// the active button indicates the blocks to be added to the graph
/// when the application initializes, it is set to be none
let mutable (activeBlockType: BlockType option) = option.None

/// initialize the tool pane
let toolPaneInit() = 
    let r1 = generateNewElementAttrSub 1 "#000000" "rgba(255,0,0,0.3)" "Register" "white"

    let r2 = generateNewElementAttrSub 1 "#000000" "rgba(0,255,0,0.3)" "Gates" "white"
       
    let r3 = generateNewElementAttrSub 1 "#000000" "rgba(0,0,255,0.3)" "D-FF" "white"

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
            "outline" ==> outline
            "text1" ==> t1
            "text2" ==> t1
            "text3" ==> t1
            "button" ==> button
            "buttonLabel" ==> buttonLabel
        ]

    let attr = generateNewElementConfig individualAttr    
    
    let markupArray = generateMarkupArray [|"rect"; "r1";                                    
                                            "rect"; "r2";
                                            "rect"; "r3";
                                            "rect"; "outline";   
                                            "text"; "text1";
                                            "text"; "text2";
                                            "text"; "text3";
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
            "cursor" ==> "pointer"
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

    let elementButton = 
        createObj[            
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
              "text1" ==> elementAttrText1
              "text2" ==> elementAttrText2
              "text3" ==> elementAttrText3
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

/// initoalize rect that has ports for connections to other blocks
let connectRectTest() =     

    let ports = 
        createNew[
            "groups" ==> createObj[
                            "in" ==> createObj[
                                        "attrs" ==> createObj[
                                                    ".port-body" ==> createObj[
                                                                        "fill" ==> "#16A085"
                                                                        ]
                                                    ]
                                     ]
                            "out" ==> createObj[
                                        "attrs" ==> createObj[
                                                        ".port-body" ==> createObj[
                                                                            "fill" ==> "#E74C3C"
                                                                         ]
                                                    ]
                                      ]
                         ]
        ]
        
    let element = createNew joint?shapes?devs?Model ()
    
    element?set("inPorts", [|"newIn1"; "newIn2"; "newIn3"|])
    element?set("outPorts", [|"newOut1"; "newOut2"|])
    //element?set("ports", ports)
    element?attr("label/text", "yes")

/// reset the coloring of the unselected elements
let resetAllSelected paper = 
    let elements : obj array = paper?model?getElements()
    [0..elements.Length-1]
    |> List.map (fun el -> (elements.[el])?attr("body/fill", "white")) 
    |> ignore

    paper

/// initialize the canvas
let canvasInit() =      
    
    /// initialize the graoh
    let graph = jointJSCreator.GraphInit ()
    
    /// create a mutable canvas in case of resizing
    let mutable canvas : HTMLElement = unbox document.getElementById "myholder"

    /// create the paper settings
    let paperSettings = generatePaperSettings canvas graph 1400 1000 10 true "rgba(0, 0, 0, 0)"

    /// initialize the paer using the paperSettings
    let mutable paper = jointJSCreator.PaperInit paperSettings    

    let switchToInputPort = fun e -> activeBlockType <- Some InputPort
    let switchToOutputPort = fun e -> activeBlockType <- Some OutputPort
    let switchToLogicElement = fun e -> activeBlockType <- Some LogicElement
    let switchToNo = fun e -> activeBlockType <- option.None

    /// bind event listener to the add bock buttons
    document.getElementById("input-add-button").addEventListener("click", U2.Case1 switchToInputPort, false) 
    document.getElementById("output-add-button").addEventListener("click", U2.Case1 switchToOutputPort, false) 
    document.getElementById("logic-element-add-button").addEventListener("click", U2.Case1 switchToLogicElement, false) 
    document.getElementById("clear-add-button").addEventListener("click", U2.Case1 switchToNo, false) 

    (*
    let linkTest = connectRectTest ()
    linkTest
    |> jointJSCreator.Position 300 300
    |> jointJSCreator.Resize 100 100
    |> ignore

    graph?addCell([|linkTest|])

    let linkTest' = connectRectTest ()
    linkTest'
    |> jointJSCreator.Position 100 300
    |> jointJSCreator.Resize 100 100
    |> ignore    

    graph?addCell([|linkTest'|])      
    *)        

    paper?on("element:pointerdblclick", unbox(fun elementView ->          
        /// clear the highlights of all the blocks
        paper <- resetAllSelected paper                   
        
        /// get the cid of the selected block
        let elementcCid = elementView?model?cid
        
        /// get all the elements on the graph, exclude links
        let modelArray:obj array = graph?getElements()
        
        /// get the element with the right cid name
        let modelSelect = modelArray
                          |> Array.choose (fun el -> if el?cid = elementcCid then Some el else option.None)                          
        
        /// cid should be unique
        /// hence the array should have only one element
        let model = modelSelect.[0]             
        console.log(model?isElement())
        /// highlight the block selected
        model?attr("body/fill", "orange")
        
        let inputBoxList = document.getElementById "element-type-label"

        inputBoxList.innerHTML <- (model?attributes?attrs?label?text)
        
        let removeElement = fun e -> model?remove()
        (document.getElementById "delete-block-button").addEventListener("click", U2.Case1 removeElement, false)

        let positionXInputBox = (((document.getElementsByTagName_input) ()).Item 2)
        positionXInputBox.value <- model?get("position")?x

        let positionYInputBox = (((document.getElementsByTagName_input) ()).Item 3)
        positionYInputBox.value <- model?get("position")?y
            
        let updateButtonFunction = fun e -> //console.log(e)                                            
                                            let position = createObj[
                                                            "x" ==> 5//int positionXInputBox.value
                                                            "y" ==> 5//int positionYInputBox.value
                                                        ]
                                            model?set("position", position)                                                                                                                                   
        (document.getElementById "update-block-information-button").addEventListener("click", U2.Case1 updateButtonFunction, true) 
        |> ignore                 
        )) |> ignore 

    paper?on("blank:pointerclick", unbox(fun args ->   
        paper <- resetAllSelected paper        
        args?originalEvent?stopPropagation()
        match activeBlockType with
        | Some InputPort -> //let block = inputPortInit()                                                          
                            inputPortInit()                                                          
                            |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                            |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                            |> jointJSCreator.AddTo graph
                            |> ignore 
                                        (*
                            block?on("element:pointerdblclick", unbox(fun element ->  
                                console.log("from element.on")
                                console.log(element?cid)    
                                //console.log(element)                                    
                                )) |> ignore 
                                *)
        | Some OutputPort -> outputPortInit()
                             |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                             |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                             /// |> jointJSCreator.AttrBySelector "body/event" "element:pointerclick"
                             /// |> jointJSCreator.AttrBySelector "label/event" "none"
                             |> jointJSCreator.AddTo graph
                             |> ignore
        | Some LogicElement -> logicElementInit()
                               |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                               |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                               /// |> jointJSCreator.AttrBySelector "body/event" "element:pointerclick"
                               /// |> jointJSCreator.AttrBySelector "label/event" "none"
                               |> jointJSCreator.AddTo graph
                               |> ignore
        | option.None -> console.log("no block")                             
    )) |> ignore

