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
    | Register

/// initialize rect that has ports for connections to other blocks
let blockWithPortInit () =     
    createNew joint?shapes?devs?Model ()    

/// create input blocks
let inputPortInit () =
    let inputPortBlock = blockWithPortInit ()
    inputPortBlock?set("inPorts", [||])
    inputPortBlock?set("outPorts", [|"out"|])
    inputPortBlock?attr(".label/text", "In")   
        
    let radius = createObj[
                    "r" ==> 5
                 ]
    inputPortBlock?portProp("out", "attrs/circle", radius)
    
    inputPortBlock
    |> jointJSCreator.Resize 60 40


/// create output blocks
let outputPortInit () = 
    let outputPort = blockWithPortInit ()
    outputPort?set("inPorts", [|"in"|])
    outputPort?set("outPorts",[||])
    outputPort?attr(".label/text", "Out")

    let radius = createObj[
        "r" ==> 5
     ]
    outputPort?portProp("in", "attrs/circle", radius)

    outputPort 
    |> jointJSCreator.Resize 60 40    

/// create logic element blocks
let logicElementInit () = 
    let logicElement = blockWithPortInit ()
    logicElement?set("inPorts", [|"in"|])
    logicElement?set("outPorts",[|"out"|])
    logicElement?attr(".label/text", "LE")
    
    let radius = createObj[
        "r" ==> 5
     ]
    logicElement?portProp("in", "attrs/circle", radius)
    logicElement?portProp("out", "attrs/circle", radius)

    logicElement 
    |> jointJSCreator.Resize 60 40     
 
let registerInit () = 
    let register = blockWithPortInit ()
    register?set("inPorts", [|"in"|])
    register?set("outPorts",[|"out"|])
    register?attr(".label/text", "Reg")
    
    let radius = createObj[
        "r" ==> 5
     ]
    register?portProp("in", "attrs/circle", radius)
    register?portProp("out", "attrs/circle", radius)

    register 
    |> jointJSCreator.Resize 60 40     
 
/// reset the coloring of the unselected elements
let resetAllSelected paper = 
    let elements : obj array = paper?model?getElements()
    [0..elements.Length-1]
    |> List.map (fun el -> (elements.[el])?attr("body/fill", "white")
                           (elements.[el])?attr("rect/fill", "white")) 
    |> ignore

/// initialize the canvas
let canvasInit (paneName:string) =  
    /// the active button indicates the blocks to be added to the graph
    /// when the application initializes, it is set to be none
    let mutable (activeBlockType: BlockType option) = option.None
    
    /// the scale of the pape with default value of 1.0
    let mutable scale:float = 1.0
    
    /// the reference to the model that is being operated on
    let mutable modelRef:obj = createObj[]                 
    
    /// the dimensions of the paper (the canvas)
    let mutable canvasXDimension:int = 1800
    let mutable canvasYDimension:int = 1000

    /// initialize the graoh
    let graph = jointJSCreator.GraphInit ()
    
    /// create a mutable canvas in case of resizing
    let canvas : HTMLElement = document.getElementById (paneName + "-canvas")

    /// create the paper settings
    let paperSettings = generatePaperSettings canvas graph canvasXDimension canvasYDimension 10 true "rgba(0, 0, 0, 0)"

    /// initialize the paer using the paperSettings
    let paper = jointJSCreator.PaperInit paperSettings
    let routerSetting = createObj[
                            "name" ==> "manhattan"
                            "args" ==> createObj[
                                          "padding" ==> 10
                                       ]
                        ]
    paper?options?defaultRouter <- routerSetting
    
    /// bind event listener to the add bock buttons
    fun e -> activeBlockType <- Some InputPort
    |> getElementBindEvent (paneName + "-inputAddButton") "click" 

    fun e -> activeBlockType <- Some OutputPort
    |> getElementBindEvent (paneName + "-outputAddButton") "click" 

    fun e -> activeBlockType <- Some LogicElement
    |> getElementBindEvent (paneName + "-logicElementAddButton") "click"

    fun e -> activeBlockType <- Some Register
    |> getElementBindEvent (paneName + "-registerAddButton") "click"

    fun e -> activeBlockType <- option.None
             setHTMLElementValue InputBox (paneName + "-positionX") ""                
             setHTMLElementValue InputBox (paneName + "-positionY") ""
    |> getElementBindEvent (paneName + "-clearSelectionButton") "click" 
                                    
    fun e ->  let position = (getValueFromElement InputBox (paneName + "-positionX") |> int, 
                              getValueFromElement InputBox (paneName + "-positionY") |> int)
                             |> generateBlockCoordinate                                                 
              modelRef?set("position", position)    
    |> getElementBindEvent (paneName + "-updateInfoButton") "click"        
    
    let removeButtonFunction = fun e -> modelRef?remove()
                                        setHTMLElementValue InputBox (paneName + "-positionX") ""                 
                                        setHTMLElementValue InputBox (paneName + "-positionY") ""
    getElementBindEvent (paneName + "-deleteBlockButton") "click" removeButtonFunction    

    /// set the response when double click on a block is detected in the canvas           
    fun elementView -> /// clear the highlightings of all the blocks
                       resetAllSelected paper                   
        
                       /// get the element model
                       let model = elementView?model

                       /// update the mutable value that references the current element model
                       modelRef <- model

                       /// highlight the block selected
                       model?attr("rect/fill", "orange")
                       model?attr("body/fill", "orange")
        
                       /// update the label in the GUI that shows the block type
                       getElementSetInnerHTML (paneName + "-blockTypeLabel")  (model?attributes?attrs?label?text)        
        
                       /// update the GUI to show the coordinates of the block
                       setHTMLElementValue InputBox (paneName + "-positionX") (((model?get("position")?x |> int)/10) |> string)
                       setHTMLElementValue InputBox (paneName + "-positionY") (((model?get("position")?y |> int)/10) |> string)
    |> paperOnFunction paper "cell:pointerdblclick"

    /// function to resize the paper (canvas)
    let resizeCanvas x y = 
        match x > canvasXDimension-100, y > canvasYDimension-100 with
        | true, _ | _, true -> paper?setDimensions(x + 200, y + 200)
                               canvasXDimension <- x + 200
                               canvasYDimension <- y + 200
        | _, _ -> ()

    fun args -> resetAllSelected paper 
                setHTMLElementValue InputBox (paneName + "-positionX") ""                 
                setHTMLElementValue InputBox (paneName + "-positionY") ""
                args?originalEvent?stopPropagation()

                let xCoordinate = (args?offsetX - (args?offsetX)%10)
                let yCoordinate = (args?offsetY - (args?offsetY)%10)

                resizeCanvas xCoordinate yCoordinate 
                
                let ctrlKeyHold:bool = args?ctrlKey                
                match ctrlKeyHold with
                | true -> scale <- 1.0
                          paper?scale(scale)
                | false -> scale <- 1.0
                           paper?scale(scale)
                           match activeBlockType with
                           | Some InputPort -> inputPortInit ()                                                          
                                               |> jointJSCreator.Position xCoordinate yCoordinate
                                               |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                               |> jointJSCreator.AddTo graph
                                               |> ignore 
                           | Some OutputPort -> outputPortInit ()
                                                |> jointJSCreator.Position xCoordinate yCoordinate
                                                |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                |> jointJSCreator.AddTo graph
                                                |> ignore
                           | Some LogicElement -> logicElementInit ()
                                                  |> jointJSCreator.Position xCoordinate yCoordinate
                                                  |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                  |> jointJSCreator.AddTo graph
                                                  |> ignore
                           | Some Register -> registerInit ()
                                              |> jointJSCreator.Position xCoordinate yCoordinate
                                              |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                              |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                              |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                              |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                              |> jointJSCreator.AddTo graph
                                              |> ignore

                           | option.None -> ()                                                                                         
    |> paperOnFunction paper "blank:pointerclick"

    fun args -> let ctrlKeyHold:bool = args?ctrlKey
                match ctrlKeyHold with
                | true -> let delta:float = -args?originalEvent?deltaY
                          let calculatedScale = max (min ((delta*0.00099+1.0)*scale) 2.0) 0.2                  
                          paper?scale(calculatedScale)  
                          scale <- calculatedScale
                | false -> ()       
    |> paperOnFunction paper "blank:mousewheel"

    ()

