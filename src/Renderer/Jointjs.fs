module Jointjs

open Fable.Core.JsInterop
open Fable.Import.Browser
open Ref
open Helper
open JSLibInterface
open HTMLUtilities
open System
open Fable.Import
open Fable.Import.Electron
open Fable.Core
open Fable.Import.Node

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
let inputPortInit (counter:int) =
    let inputPortBlock = blockWithPortInit ()
    inputPortBlock?set("inPorts", [||])
    inputPortBlock?set("outPorts", [|"out"|])
    inputPortBlock?attr(".label/text", "In-in" + string counter)
    inputPortBlock?attr(".label/fontSize", 14)
    inputPortBlock?attr(".label/textVerticalAnchor", "middle")
        
    let radius = createObj[
                    "r" ==> 5
                 ]
    inputPortBlock?portProp("out", "attrs/circle", radius)
    
    inputPortBlock
    |> jointJSCreator.Resize 90 20


/// create output blocks
let outputPortInit (counter:int) = 
    let outputPort = blockWithPortInit ()
    outputPort?set("inPorts", [|"in"|])
    outputPort?set("outPorts",[||])
    outputPort?attr(".label/text", "Out-out" + string counter)
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
 
/// resize the port's circle size and position
let rec resizePort (index:int) (portNames:string array) (el:obj) = 
    match index with
    | a when a < portNames.Length -> let radius = 
                                        createObj[
                                            "r" ==> 5
                                        ]
                                     el?portProp(portNames.[index], "attrs/circle", radius)                                       
                                     el?portProp(portNames.[index], "args/y", 20*(index)+10)
                                     resizePort (index+1) portNames el
    | _ -> ()

/// create custom logic blocks
let customLogicElementInit (inPorts:string array) (outPorts:string array) (blockName:string) = 
    let logicElement = blockWithPortInit ()
    logicElement?set("inPorts", inPorts)
    logicElement?set("outPorts", outPorts)
    logicElement?attr(".label/text", blockName)
    logicElement?attr(".label/fontSize", 14)
    logicElement?attr(".label/textVerticalAnchor", "middle")
    
    resizePort 0 inPorts logicElement
    resizePort 0 outPorts logicElement

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
    electron.ipcRenderer.send("change-channel", paneName)
    /// the active button indicates the blocks to be added to the graph
    /// when the application initializes, it is set to be none
    let mutable (activeBlockType: BlockType option) = option.None
    
    /// the scale of the pape with default value of 1.0
    let mutable scale:float = 1.0
    
    /// the reference to the model that is being operated on
    let mutable modelRef:obj option = option.None

    /// store the custom logic block
    let mutable customLogicBlock = Map.empty
    blockNameConfigMapping <- customLogicBlock

    /// store the current active logic block name
    let mutable activeBlockName :string = ""
    
    /// the dimensions of the paper (the canvas)
    let mutable canvasXDimension:int = 1800
    let mutable canvasYDimension:int = 1000    

    /// counter for different types of blocks
    let mutable inputCounter:int = 0
    let mutable outputCounter:int = 0
    let mutable logicBlockCounter:int = 0;

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

    electron.ipcRenderer.send("retrieving-design")
    
    /// add "*" after the pane button when it is modified but not saved
    let updatePaneName () = 
        let button = document.getElementById (paneName + "-tabButton")
        let buttonText = button.innerHTML
        match buttonText with
        | a when a.[a.Length-1] = '*' -> ()
        | _ -> button.innerHTML <- buttonText + "*"

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
                                              blockNameConfigMapping <- customLogicBlock
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

    let receivingFileHandler:IpcRendererEventListener = 
        let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
        let receivingFileFunction = handlerCaster (fun a b -> let parsedJson = (JS.JSON.parse (string b))?buttons                                                              
                                                              let loadedButtonNameMap = Map.ofArray parsedJson                                                              
                                                              customLogicBlock <- loadedButtonNameMap
                                                              for KeyValue(k, v) in customLogicBlock do                                                                 
                                                                 appendNewBlockButton k                                                                 
                                                              let graphInfo = (JS.JSON.parse (string b))?graph |> JS.JSON.parse
                                                              graph?fromJSON(graphInfo)
                                                              graph?get("graphCustomProperty")       
                                                              let paperInfo = (JS.JSON.parse (string b))?paper |> JS.JSON.parse
                                                              paper?setDimensions(paperInfo?width, paperInfo?height)
                                                              let blocks:obj array = graph?getElements()
                                                              for block in blocks do
                                                                 let blockText:string = block?attr(".label/text")        
                                                                 let blockType = (blockText.Split [|'-'|]).[0]
                                                                 if blockType<>"In" && blockType<>"Out"
                                                                 then let inPortsNmuber = int customLogicBlock.[blockType].[1]
                                                                      let outPortsNmuber = int customLogicBlock.[blockType].[2]
                                                                      let inPorts = customLogicBlock.[blockType].[3..3+inPortsNmuber-1]                                                                      
                                                                      let outPorts = customLogicBlock.[blockType].[3+inPortsNmuber..3+inPortsNmuber-1+outPortsNmuber]                                                                      
                                                                      resizePort 0 inPorts block
                                                                      resizePort 0 outPorts block
                                                                 elif blockType="In" then resizePort 0 [|"out"|] block
                                                                 elif blockType="Out" then resizePort 0 [|"in"|] block
                                                                 else ()
                                                                 
                                                              currentGraphModel <- Some graph
                                                              blockNameConfigMapping <- customLogicBlock)
        receivingFileFunction

    electron.ipcRenderer.on(paneName + "-send-design-file", receivingFileHandler) |> ignore
    
    /// force updating the model and the paper reference when the block diagram editor is firstly initialized
    currentGraphModel <- Some graph
    currentPaperModel <- Some paper
    activeTabId <- Some paneName    

    

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
                                                fileSavingPath <- option.None
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
                let ctrlKeyHold:bool = args?ctrlKey                
                match ctrlKeyHold with
                | true -> scale <- 1.0
                          paper?scale(scale)
                          (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                | false -> match activeBlockType with
                           | Some InputPort -> scale <- 1.0
                                               paper?scale(scale)
                                               inputPortInit inputCounter                                                          
                                               |> jointJSCreator.Position xCoordinate yCoordinate
                                               |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                               |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"                                               
                                               |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                               |> jointJSCreator.AddTo graph
                                               |> ignore 
                                               inputCounter <- inputCounter + 1
                                               activeBlockType <- option.None
                                               (document.getElementById (paneName + "-resetZoomButton")).innerHTML <- "Zoom = 100%. Click to reset."
                                               updatePaneName ()
                           | Some OutputPort -> scale <- 1.0
                                                paper?scale(scale)
                                                outputPortInit outputCounter
                                                |> jointJSCreator.Position xCoordinate yCoordinate
                                                |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                |> jointJSCreator.AddTo graph
                                                |> ignore
                                                outputCounter <- outputCounter + 1
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
                                                  customLogicElementInit logicElementInputs logicElementOutputs (activeBlockName + "-block" + string logicBlockCounter)
                                                  |> jointJSCreator.Position xCoordinate yCoordinate
                                                  |> jointJSCreator.AttrBySelector "body/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "rect/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector ".label/cursor" "pointer"
                                                  |> jointJSCreator.AttrBySelector "label/cursor" "pointer"
                                                  |> jointJSCreator.AddTo graph
                                                  |> ignore
                                                  logicBlockCounter <- logicBlockCounter + 1
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

    let newBlockhandler:IpcRendererEventListener = 
        let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
        let updateLogicBlockStorage = handlerCaster (fun a b -> let res = (string b).Split ','
                                                                let numberOfInputs = res.[1] |> int
                                                                let numberOfOutputs = res.[2] |> int

                                                                let truthTableLangth = 2.**float numberOfInputs |> int
                                                                let VerilogCodeIndex = 2 + numberOfInputs + numberOfOutputs + truthTableLangth + 1
                                                                let VerilogCode = String.concat "" res.[VerilogCodeIndex..]

                                                                let inputPorts = res.[3..2+numberOfInputs]
                                                                let outputPorts = res.[3+numberOfInputs..2+numberOfInputs+numberOfOutputs]
                                                                let checkRepeat = customLogicBlock.ContainsKey res.[0]  
                                                                
                                                                let res' = Array.append res.[0..2+numberOfInputs+numberOfOutputs+truthTableLangth] [|VerilogCode|]

                                                                match checkRepeat with
                                                                | false -> customLogicBlock <- customLogicBlock.Add(res.[0], res')
                                                                           blockNameConfigMapping <- customLogicBlock
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

    let generateVerilog (moduleName:string) =        
        let mutable VerilogMainBody = ""        
        for KeyValue(k, v) in customLogicBlock do            
            let moduleNumberOfInputs = float v.[1]
            let truthTableLength = 2.**moduleNumberOfInputs |> int
            let moduleVerilogCodeIndexPosition = 2 + int v.[1] + int v.[2] + truthTableLength + 1
            VerilogMainBody <- VerilogMainBody + v.[moduleVerilogCodeIndexPosition]
            VerilogMainBody <- VerilogMainBody + "\n"

        /// fill in the content of the main body
        VerilogMainBody <- VerilogMainBody + "\nmodule " + moduleName + "("

        let allBlocks:obj array = graph?getElements()

        let checkLinkConnected (link:obj) resFunction1 resFunction2 = 
            match link?getSourceElement(), link?getTargetElement() with
            | a, b when checkNull a = true && checkNull b <> true -> resFunction1
            | m, n when checkNull m <> true && checkNull n = true -> resFunction1
            | r, s when checkNull r = true && checkNull s = true -> resFunction1
            | p, q when checkNull p <> true && checkNull q <> true -> resFunction2
            | _, _ -> failwithf "Not possible. All possible outcomes handled."

        let allLinks:obj array = 
            let linkArray:obj array = graph?getLinks()

            let rec checkLinkConnected' (index:int) (res:obj array) = 
                match index with
                | i when i < linkArray.Length -> let resFunc1 = checkLinkConnected' (i+1) res
                                                 let resFunc2 = checkLinkConnected' (i+1) (Array.append res [|linkArray.[i]|])
                                                 checkLinkConnected (linkArray.[i]) resFunc1 resFunc2                                                
                | _ -> res
            checkLinkConnected' 0 [||]            
               
        let inputBlocks, inputIds = 
            let mutable resBlock:obj array = [||]
            let mutable resId:string array = [||]
            allBlocks
            |> Array.map (fun el -> let labelText:string = el?attr(".label/text")                                    
                                    if (labelText.Split '-').[0] = "In" 
                                    then resBlock <- Array.append resBlock [|el|]
                                         resId <- Array.append resId [|labelText.[3..]|]
                                    else ())
            |> ignore
            resBlock, resId

        let outputs, outputIds = 
            let mutable resBlock:obj array = [||]
            let mutable resId:string array = [||]
            allBlocks
            |> Array.map (fun el -> let labelText:string = el?attr(".label/text")
                                    if (labelText.Split '-').[0] = "Out" 
                                    then resBlock <- Array.append resBlock [|el|]
                                         resId <- Array.append resId [|labelText.[4..]|]
                                    else ())
            |> ignore
            resBlock, resId

        let logicBlocks = 
            let mutable res:obj array = [||]
            allBlocks
            |> Array.map (fun el -> let labelText:string = el?attr(".label/text")
                                    if (labelText.Split '-').[0] <> "Out" && (labelText.Split '-').[0] <> "In" then res <- Array.append res [|el|]
                                    else ())
            |> ignore
            res

        let linkNameGenerate = 
            [|0..allLinks.Length|]
            |> Array.map (fun el -> "link" + string el)

        let attachLinkNames = 
            let linkWithNames = [|0..allLinks.Length-1|]
                                |> Array.map (fun el -> (allLinks.[el])?attr(".label/name", linkNameGenerate.[el]))

            let rec checkInOutPorts (index:int) (linkArray:obj array) = 
                match index with
                | a when a < linkArray.Length -> let linkSource:string = linkArray.[a]?getSourceElement()?attr(".label/text")
                                                 let linkTarget:string = linkArray.[a]?getTargetElement()?attr(".label/text")
                                                 
                                                 match linkSource, linkTarget with
                                                 | portNameA, _ when (portNameA.Split '-').[0] = "In" -> linkArray.[a]?attr(".label/name", portNameA.[3..])
                                                                                                         checkInOutPorts (a+1) (linkArray)
                                                 | portNameA, _ when (portNameA.Split '-').[0] = "Out" -> linkArray.[a]?attr(".label/name", portNameA.[4..])
                                                                                                          checkInOutPorts (a+1) (linkArray)
                                                 | _, portNameB when (portNameB.Split '-').[0] = "In" -> linkArray.[a]?attr(".label/name", portNameB.[3..])
                                                                                                         checkInOutPorts (a+1) (linkArray)
                                                 | _, portNameB when (portNameB.Split '-').[0] = "Out" -> linkArray.[a]?attr(".label/name", portNameB.[4..])
                                                                                                          checkInOutPorts (a+1) (linkArray)
                                                 | _, _ -> checkInOutPorts (a+1) (linkArray)
                | _ -> linkArray

            checkInOutPorts 0 linkWithNames

        let extractLinkNames:string array = 
            [0..attachLinkNames.Length-1]
            |> List.map (fun el -> attachLinkNames.[el]?attr(".label/name"))    
            |> List.toArray

        VerilogMainBody <- VerilogMainBody + String.concat ", " inputIds + ", " + String.concat ", " outputIds + ", clock);\n"
        VerilogMainBody <- VerilogMainBody + "  input " + String.concat ", " inputIds + ", clock;\n"
        VerilogMainBody <- VerilogMainBody + "  output " + String.concat ", " outputIds + ";\n"
        VerilogMainBody <- VerilogMainBody + "  wire " + String.concat ", " extractLinkNames + ";\n"
        
        let mutable blockCounter:int = 0;

        [0..logicBlocks.Length-1]
        |> List.map (fun i -> let block = logicBlocks.[i]
                              let blockNameFull:string = logicBlocks.[i]?attr(".label/text")
                              let blockType = (blockNameFull.Split '-').[0]
                              let connectedLinks:obj array = graph?getConnectedLinks(block)
                              
                              let rec checkLinkConnected' (index:int) (res:obj array) = 
                                  match index with
                                  | i when i < connectedLinks.Length -> let resFunc1 = checkLinkConnected' (i+1) res
                                                                        let resFunc2 = checkLinkConnected' (i+1) (Array.append res [|connectedLinks.[i]|])
                                                                        checkLinkConnected (connectedLinks.[i]) resFunc1 resFunc2                                                
                                  | _ -> res
                              let checkedLinks = checkLinkConnected' 0 [||]

                              let extractPortLabelText:string array = 
                                [|0..checkedLinks.Length-1|]
                                |> Array.map (fun i -> (checkedLinks.[i])?attr(".label/name"))
                              
                              let portLabelText = String.concat ", " extractPortLabelText
                              
                              let rowContent = "  " + blockType + " Inst" + string blockCounter + "(" + portLabelText + ", clock);\n"
                              blockCounter <- blockCounter + 1
                              VerilogMainBody <- VerilogMainBody + rowContent)
        |> ignore

        VerilogMainBody <- VerilogMainBody + "endmodule\n"        
        VerilogMainBody, inputIds, outputIds

    let generateBlockHandler:IpcRendererEventListener = 
        let handlerCaster f = System.Func<IpcRendererEvent, obj, unit> f
        let generateBlock = handlerCaster (fun a b -> let saveDialogOptions = createEmpty<SaveDialogOptions>
                                                      saveDialogOptions.title <- Some "Save file to"
                                                      saveDialogOptions.defaultPath <- Some ("../new.json") 
                                                      let fileFilter =  new ResizeArray<obj> ()
                                                      let sufficSetting = 
                                                        createObj[
                                                            "name" ==> "JSON Format"
                                                            "extensions" ==> [|".json"|]
                                                        ]
                                                      fileFilter.Add sufficSetting
                                                     
                                                      saveDialogOptions.filters <- Some fileFilter

                                                      /// return the directory and the file name that is to be saved
                                                      let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)                                                                                                                                
                                                         
                                                      match fileSaveDialog with
                                                      | a when checkUndefined a <> true -> let fileName = a |> getFileName
                                                                                           let fileNameLength = fileName.Length
                                                                                           let blockName = fileName.[..fileNameLength-6]
                                                                                           let Verilog, inputIds, outputIds = generateVerilog blockName                                                                                           
                                                                                           console.log(Verilog)
                                                                                           let truthTable = 
                                                                                              let length = 2.**(float inputIds.Length) |> int
                                                                                              [0..length-1]
                                                                                              |> List.map (fun el -> "")
                                                                                              |> List.toArray

                                                                                           let contents = 
                                                                                              createObj[
                                                                                                 "name" ==> blockName
                                                                                                 "inputs" ==> inputIds
                                                                                                 "outputs" ==> outputIds      
                                                                                                 "truthTable" ==> truthTable
                                                                                                 "Verilog" ==> fileSaveDialog + ".v"
                                                                                              ]
                                                                                           let errorHandler error = ()
                                                                                           fs.writeFile (fileSaveDialog, JS.JSON.stringify contents, errorHandler)
                                                                                           let errorHandlerClosingWindow error = ()
                                                                                           fs.writeFile (fileSaveDialog + ".v", Verilog, errorHandlerClosingWindow)
                                                      | _ -> ()   )
        generateBlock

    electron.ipcRenderer.on(paneName + "-generate-block", generateBlockHandler) |> ignore

    

