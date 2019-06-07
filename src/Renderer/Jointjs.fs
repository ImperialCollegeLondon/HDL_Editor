module Jointjs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open HTMLUtilities

let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

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

/// initialize the canvas
let canvasInit() =      
    
    /// initialize the graoh
    let graph = jointJSCreator.GraphInit ()
    
    /// create a mutable canvas in case of resizing
    let mutable canvas : HTMLElement = unbox document.getElementById "block-editor-canvas"

    /// create the paper settings
    let paperSettings = generatePaperSettings canvas graph 1200 700 10 true "rgba(0, 0, 0, 0)"

    /// initialize the paer using the paperSettings
    let paper = jointJSCreator.PaperInit paperSettings    

    /// bind event listener to the add bock buttons
    fun e -> activeBlockType <- Some InputPort
    |> getElementBindEvent "input-add-button" "click" 

    fun e -> activeBlockType <- Some OutputPort
    |> getElementBindEvent "output-add-button" "click" 

    fun e -> activeBlockType <- Some LogicElement
    |> getElementBindEvent "logic-element-add-button" "click"

    fun e -> activeBlockType <- option.None
    |> getElementBindEvent "clear-add-button" "click" 
                                    
    let mutable scale:float = 1.0
    let mutable modelRef:obj = createObj[]    

    fun e ->  let position = (getValueFromElement InputBox 2 |> int, getValueFromElement InputBox 3 |> int)
                             |> generateBlockCoordinate                                                 
              modelRef?set("position", position)    
    |> getElementBindEvent "update-block-information-button" "click"        
    
    let removeButtonFunction = fun e -> modelRef?remove()
    getElementBindEvent "delete-block-button" "click" removeButtonFunction    

    /// set the response when double click on a block is detected in the canvas           
    fun elementView -> /// clear the highlightings of all the blocks
                       resetAllSelected paper                   
        
                       /// get the element model
                       let model = elementView?model

                       /// update the mutable value that references the current element model
                       modelRef <- model

                       /// highlight the block selected
                       model?attr("body/fill", "orange")
        
                       /// update the label in the GUI that shows the block type
                       getElementSetInnerHTML "element-type-label" (model?attributes?attrs?label?text)        
        
                       /// update the GUI to show the coordinates of the block
                       setHTMLElementValue InputBox 2 (model?get("position")?x)                 
                       setHTMLElementValue InputBox 3 (model?get("position")?y)                
    |> paperOnFunction paper "element:pointerdblclick"

    fun args -> resetAllSelected paper        
                args?originalEvent?stopPropagation()
                let ctrlKeyHold:bool = args?ctrlKey
                match ctrlKeyHold with
                | true -> scale <- 1.0
                          paper?scale(scale)         
                | false -> scale <- 1.0
                           paper?scale(scale)
                           match activeBlockType with
                           | Some InputPort -> //let block = inputPortInit()                                                          
                                               inputPortInit()                                                          
                                               |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                                               |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                               |> jointJSCreator.AddTo graph
                                               |> ignore 
                           | Some OutputPort -> outputPortInit()
                                                |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                                                |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                |> jointJSCreator.AddTo graph
                                                |> ignore
                           | Some LogicElement -> logicElementInit()
                                                  |> jointJSCreator.Position (args?offsetX - (args?offsetX)%10) (args?offsetY - (args?offsetY)%10)
                                                  |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                  |> jointJSCreator.AddTo graph
                                                  |> ignore
                           | option.None -> console.log("no block")                                
    |> paperOnFunction paper "blank:pointerclick"

    fun args -> let ctrlKeyHold:bool = args?ctrlKey
                match ctrlKeyHold with
                | true -> let delta:float = -args?originalEvent?deltaY
                          let calculatedScale = max (min ((delta*0.00099+1.0)*scale) 2.0) 0.01                  
                          paper?scale(calculatedScale)  
                          scale <- calculatedScale
                          let scaleSetting = "scale(" + string scale + "," + string scale + ")"
                          let cssStyling = createEmpty<CSSStyleDeclaration>
                          cssStyling.zoom <- scaleSetting
                          //document.getElementById("block-editor-canvas").style <- cssStyling                              
                | false -> printfn "hold ctrl to zoom in or out"       
    |> paperOnFunction paper "blank:mousewheel"