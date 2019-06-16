module Jointjs

open Fable.Core.JsInterop
open Fable.Import.Browser
open Ref
open JSLibInterface
open HTMLUtilities
open System
open Fable.Import
open Fable.Import.Electron
open Fable.Core

let joint : obj = importAll "jointjs"

/// highlight the selected tab
let highlightTab (tabName:string) =     
    let tabs = (document.getElementById "tabRow").getElementsByTagName_button ()
    
    let rec highlightTab' (lst:NodeListOf<HTMLButtonElement>) (index:int) =         
        match index with
        | a when a < int lst.length -> match lst.[index].id with                                       
                                       | b when b = (tabName + "-tabButton") -> (lst.[index]).style.backgroundColor <- "green"
                                                                                highlightTab' lst (index + 1)                                       
                                       | _ -> (lst.Item index).style.backgroundColor <- "inherit"
                                              highlightTab' lst (index + 1)
        | _ -> ()
    highlightTab' tabs 0

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

/// define the blocks that can be added to the graph
type BlockType = 
    | InputPort
    | OutputPort
    | LogicElement

/// initialize rect that has ports for connections to other blocks
let blockWithPortInit () =     
    createNew joint?shapes?devs?Model ()    

/// create input blocks
let inputPortInit () =
    let inputPortBlock = blockWithPortInit ()
    inputPortBlock?set("inPorts", [||])
    inputPortBlock?set("outPorts", [|"out"|])
    inputPortBlock?attr(".label/text", "In-block")
    inputPortBlock?attr(".label/fontSize", 14)
    inputPortBlock?attr(".label/textVerticalAnchor", "middle")
        
    let radius = createObj[
                    "r" ==> 5
                 ]
    inputPortBlock?portProp("out", "attrs/circle", radius)
    
    inputPortBlock
    |> jointJSCreator.Resize 90 20


/// create output blocks
let outputPortInit () = 
    let outputPort = blockWithPortInit ()
    outputPort?set("inPorts", [|"in"|])
    outputPort?set("outPorts",[||])
    outputPort?attr(".label/text", "Out-block")
    outputPort?attr(".label/fontSize", 14)
    outputPort?attr(".label/textVerticalAnchor", "middle")

    let radius = createObj[
        "r" ==> 5
     ]
    outputPort?portProp("in", "attrs/circle", radius)

    outputPort 
    |> jointJSCreator.Resize 90 20    

/// create logic element blocks
let logicElementInit () = 
    let logicElement = blockWithPortInit ()
    logicElement?set("inPorts", [|"in"|])
    logicElement?set("outPorts",[|"out"|])
    logicElement?attr(".label/text", "LE-block")
    logicElement?attr(".label/fontSize", 14)
    logicElement?attr(".label/textVerticalAnchor", "middle")
    
    let radius = createObj[
        "r" ==> 5
     ]
    logicElement?portProp("in", "attrs/circle", radius)
    logicElement?portProp("out", "attrs/circle", radius)

    logicElement 
    |> jointJSCreator.Resize 90 20     
 
/// create custom logic blocks
let customLogicElementInit (inPorts:string array) (outPorts:string array) (blockName:string) = 
    let logicElement = blockWithPortInit ()
    logicElement?set("inPorts", inPorts)
    logicElement?set("outPorts", outPorts)
    logicElement?attr(".label/text", blockName)
    logicElement?attr(".label/fontSize", 14)
    logicElement?attr(".label/textVerticalAnchor", "middle")

    let radius = createObj[
        "r" ==> 5
     ]

    let rec resizePort (index:int) (portNames:string array) = 
        match index with
        | a when a < portNames.Length -> logicElement?portProp(portNames.[index], "attrs/circle", radius)                                       
                                         logicElement?portProp(portNames.[index], "args/y", 20*(index)+10)
                                         resizePort (index+1) portNames
        | _ -> ()
    
    resizePort 0 inPorts
    resizePort 0 outPorts    

    logicElement
    |> jointJSCreator.Resize 90 ((max inPorts.Length outPorts.Length)*20)

let registerInit () = 
    let register = blockWithPortInit ()
    register?set("inPorts", [|"in"|])
    register?set("outPorts",[|"out"|])
    register?attr(".label/text", "Reg-block")
    register?attr(".label/fontSize", 14)
    register?attr(".label/textVerticalAnchor", "middle")

    
    let radius = createObj[
        "r" ==> 5
     ]
    register?portProp("in", "attrs/circle", radius)
    register?portProp("out", "attrs/circle", radius)

    register 
    |> jointJSCreator.Resize 90 20     
 
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
    let mutable modelRef:obj option = option.None

    /// store the custom logic block
    let mutable customLogicBlock = Map.empty

    /// store the current active logic block name
    let mutable activeBlockName :string = ""
    
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
    
    /// force updating the model and the paper reference when the block diagram editor is firstly initialized
    currentGraphModel <- Some graph
    currentPaperModel <- Some paper
    activeTabId <- Some paneName    

    /// add "*" after the pane button when it is modified but not saved
    let updatePaneName () = 
        let button = document.getElementById (paneName + "-tabButton")
        let buttonText = button.innerHTML
        match buttonText with
        | a when a.[a.Length-1] = '*' -> ()
        | _ -> button.innerHTML <- buttonText + "*"

    /// bind event listener to the add bock buttons
    fun e -> activeBlockType <- Some InputPort
    |> getElementBindEvent (paneName + "-inputAddButton") "click" 

    fun e -> activeBlockType <- Some OutputPort
    |> getElementBindEvent (paneName + "-outputAddButton") "click" 

    fun e -> activeBlockType <- option.None
             modelRef <- option.None
             setHTMLElementValue InputBox (paneName + "-positionX") ""                
             setHTMLElementValue InputBox (paneName + "-positionY") ""
             resetAllSelected paper 
    |> getElementBindEvent (paneName + "-clearSelectionButton") "click" 
                                    
    fun e -> match modelRef with
             | Some a -> let position = ((getValueFromElement InputBox (paneName + "-positionX") |> int)*10, 
                                         (getValueFromElement InputBox (paneName + "-positionY") |> int)*10)
                                        |> generateBlockCoordinate 
              
                         a?set("position", position)
                         let labelName = getValueFromElement InputBox (paneName + "-blockName")
                         let modelLabel:string = a?attr(".label/text")
                         let splitString = modelLabel.Split([|'-'|], 2, StringSplitOptions.None)
                         let labelType = splitString.[0]
                         a?attr(".label/text", labelType + "-" + labelName)
                          
                         /// update the global reference
                         currentGraphModel <- Some graph
                         currentPaperModel <- Some paper
                         activeTabId <- Some paneName

                         /// update the local reference
                         modelRef <- Some a

                         updatePaneName ()
             | option.None -> ()              
    |> getElementBindEvent (paneName + "-updateInfoButton") "click"        
    
    let removeButtonFunction = fun e -> match modelRef with
                                        | Some a -> a?remove()
                                                    modelRef <- option.None
                                                    setHTMLElementValue InputBox (paneName + "-positionX") ""                 
                                                    setHTMLElementValue InputBox (paneName + "-positionY") ""
                                        | option.None -> ()
                                        updatePaneName ()
    getElementBindEvent (paneName + "-deleteBlockButton") "click" removeButtonFunction   
    
    let resetZoomButtonFunction = fun e -> paper?scale(1)  
                                           scale <- 1.
                                           (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
    getElementBindEvent (paneName + "-resetZoomButton") "click" resetZoomButtonFunction

    /// force updating the model and the paper reference everytime the tab is clicked
    /// also update the current active tab
    let updateModelAndPaperReference = fun e -> /// update the global reference                                                
                                                currentGraphModel <- Some graph
                                                currentPaperModel <- Some paper
                                                activeTabId <- Some paneName
                                                highlightTab paneName
                                                electron.ipcRenderer.send("change-channel", paneName)
    getElementBindEvent (paneName + "-tabButton") "click" updateModelAndPaperReference

    /// set the response when double click on a block is detected in the canvas           
    fun elementView -> /// clear the highlightings of all the blocks
                       resetAllSelected paper                   
        
                       /// get the element model
                       let model = elementView?model

                       /// update the mutable value that references the current element model
                       modelRef <- Some model
                       
                       /// highlight the block selected
                       model?attr("rect/fill", "orange")
                       model?attr("body/fill", "orange")
        
                       /// update the label in the GUI that shows the block type
                       let blockText:string = model?attr(".label/text")
                       let splitedString = blockText.Split([|'-'|], 2, StringSplitOptions.None)
                       
                       getElementSetInnerHTML (paneName + "-blockTypeLabel") splitedString.[0]   
                       setHTMLElementValue InputBox (paneName + "-blockName") splitedString.[1]
        
                       /// update the GUI to show the coordinates of the block
                       setHTMLElementValue InputBox (paneName + "-positionX") (((model?get("position")?x |> int)/10) |> string)
                       setHTMLElementValue InputBox (paneName + "-positionY") (((model?get("position")?y |> int)/10) |> string)
    |> paperOnFunction paper "cell:pointerdblclick"

    fun cell -> let checkLink:bool = cell?isLink()
                match checkLink with
                | true -> console.log(cell)
                          cell?on("change", fun e ->
                              console.log(e?attributes)
                          ) |> ignore
                | false -> console.log(cell)              
    |> paperOnFunction graph "add"

    /// function to resize the paper (canvas)
    let resizeCanvas x y = 
        match x > canvasXDimension-100, y > canvasYDimension-100 with
        | true, true -> paper?setDimensions(x + 200, y + 200)
                        canvasXDimension <- x + 200
                        canvasYDimension <- y + 200
        | true, false -> paper?setDimensions(x + 200, canvasYDimension)
                         canvasXDimension <- x + 200
        | false, true -> paper?setDimensions(canvasXDimension, y + 200)
                         canvasYDimension <- y + 200
        | _, _ -> ()

        /// update the global reference
        currentGraphModel <- Some graph
        currentPaperModel <- Some paper
        activeTabId <- Some paneName

    fun args -> resetAllSelected paper 
                setHTMLElementValue InputBox (paneName + "-positionX") ""                 
                setHTMLElementValue InputBox (paneName + "-positionY") ""
                args?originalEvent?stopPropagation()

                let xCoordinate = (args?offsetX - (args?offsetX)%10)
                let yCoordinate = (args?offsetY - (args?offsetY)%10)

                resizeCanvas xCoordinate yCoordinate 
                console.log(args)
                let ctrlKeyHold:bool = args?ctrlKey                
                match ctrlKeyHold with
                | true -> scale <- 1.0
                          paper?scale(scale)
                          (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                | false -> match activeBlockType with
                           | Some InputPort -> scale <- 1.0
                                               paper?scale(scale)
                                               inputPortInit ()                                                          
                                               |> jointJSCreator.Position xCoordinate yCoordinate
                                               |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                               |> jointJSCreator.AddTo graph
                                               |> ignore 
                                               activeBlockType <- option.None
                                               (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                                               updatePaneName ()
                           | Some OutputPort -> scale <- 1.0
                                                paper?scale(scale)
                                                outputPortInit ()
                                                |> jointJSCreator.Position xCoordinate yCoordinate
                                                |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                |> jointJSCreator.AddTo graph
                                                |> ignore
                                                activeBlockType <- option.None
                                                (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                                                updatePaneName ()
                           | Some LogicElement -> ///logicElementInit ()
                                                  scale <- 1.0
                                                  paper?scale(scale)                                                  
                                                  let logicElementConfig:string array = customLogicBlock.[activeBlockName]
                                                  let inputCount = logicElementConfig.[1] |> int
                                                  let outputCount = logicElementConfig.[2] |> int
                                                  let logicElementInputs = logicElementConfig.[3..2+inputCount]
                                                  let logicElementOutputs = logicElementConfig.[3+inputCount..2+inputCount+outputCount]
                                                  customLogicElementInit logicElementInputs logicElementOutputs (activeBlockName + "-block")
                                                  |> jointJSCreator.Position xCoordinate yCoordinate
                                                  |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                  |> jointJSCreator.AddTo graph
                                                  |> ignore
                                                  activeBlockType <- option.None
                                                  (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                                                  updatePaneName ()
                           | option.None -> modelRef <- option.None   
                           
                /// update the global reference
                currentGraphModel <- Some graph
                currentPaperModel <- Some paper
                activeTabId <- Some paneName
    |> paperOnFunction paper "blank:pointerclick"

    fun args -> let ctrlKeyHold:bool = args?ctrlKey
                match ctrlKeyHold with
                | true -> let delta:float = -args?originalEvent?deltaY
                          let calculatedScale = max (min ((delta*0.00099+1.0)*scale) 2.0) 0.2                  
                          paper?scale(calculatedScale)  
                          scale <- calculatedScale
                          (document.getElementById (paneName + "-resetZoomButton")).innerHTML 
                            <- "Zoom = " + (System.Math.Round ((calculatedScale*100.),2) |> string) + "%. Click to reset." 
                | false -> ()       
    |> paperOnFunction paper "blank:mousewheel"

    let appendNewBlockButton (buttonName:string) = 
        let rootDiv = document.createElement_div ()
        rootDiv.id <- paneName + "-" + buttonName + "div"        

        let button = document.createElement_button ()
        button.``type`` <- "button"
        button.id <- paneName + "-" + buttonName
        button.innerHTML <- buttonName
        button.style.width <- "70%"
        button.style.left <- "0%"
        button.style.cssFloat <- "left"
        rootDiv.appendChild button |> ignore

        let clickAddBlickEvent = fun e -> activeBlockType <- Some LogicElement
                                          activeBlockName <- buttonName                                          
        button.addEventListener("click", U2.Case1 clickAddBlickEvent, false)

        let deleteButton = document.createElement_button ()
        deleteButton.id <- paneName + "-" + buttonName + "deleteButton"
        deleteButton.``type`` <- "button"
        deleteButton.innerHTML <- "X"
        deleteButton.style.width <- "30%"
        deleteButton.style.left <- "70%"
        deleteButton.style.cssFloat <- "left"
        rootDiv.appendChild deleteButton |> ignore

        let clickDeleteButtonEvent = fun e -> activeBlockType <- option.None
                                              activeBlockName <- ""
                                              customLogicBlock <- customLogicBlock.Remove buttonName
                                              let parentNode = deleteButton.parentNode
                                              parentNode.removeChild deleteButton |> ignore
                                              parentNode.removeChild button |> ignore
                                              parentNode.parentNode.removeChild parentNode |> ignore
                                              let elements:obj array = graph?getElements()
                                              
                                              let rec removeChildWithType (index:int) (blockType:string) (lst:obj array) = 
                                                 match index with
                                                 | a when a < lst.Length -> let text : string = lst.[a]?attr(".label/text")
                                                                            if (text.Split '-').[0] = blockType
                                                                            then lst.[a]?remove()
                                                                                 removeChildWithType (index+1) blockType lst
                                                                            else removeChildWithType (index+1) blockType lst
                                                 | _ -> ()

                                              removeChildWithType 0 buttonName elements
                                              updatePaneName ()
        deleteButton.addEventListener("click", U2.Case1 clickDeleteButtonEvent, false)


        let root = document.getElementById (paneName + "-addBlockButtons")
        let insertBefore = document.getElementById (paneName + "-clearSelectionButton")
        root.insertBefore (rootDiv, insertBefore) |> ignore

        updatePaneName ()

    let newBlockhandler:IpcRendererEventListener = 
        let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
        let updateLogicBlockStorage = handlerCaster (fun a b -> let res = (string b).Split ','
                                                                let numberOfInputs = res.[1] |> int
                                                                let numberOfOutputs = res.[2] |> int

                                                                let inputPorts = res.[3..2+numberOfInputs]
                                                                let outputPorts = res.[3+numberOfInputs..2+numberOfInputs+numberOfOutputs]
                                                                let checkRepeat = customLogicBlock.ContainsKey res.[0]                                                     
                                                                match checkRepeat with
                                                                | false -> customLogicBlock <- customLogicBlock.Add(res.[0], res)
                                                                           appendNewBlockButton res.[0]
                                                                           updatePaneName ()
                                                                | true -> console.log("repeated name detected")
                                                                )
        updateLogicBlockStorage    
    
    electron.ipcRenderer.on(paneName + "-new-blocks", newBlockhandler) |> ignore

    let clearBlockSelectionHandler:IpcRendererEventListener = 
        let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
        let clearBlockSelection = handlerCaster (fun a b -> resetAllSelected paper 
                                                            setHTMLElementValue InputBox (paneName + "-positionX") ""                 
                                                            setHTMLElementValue InputBox (paneName + "-positionY") ""
                                                            modelRef <- option.None)
        clearBlockSelection

    electron.ipcRenderer.on(paneName + "-clear-block-selection", clearBlockSelectionHandler) |> ignore


    

