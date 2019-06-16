module blockConfigureWindow

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Node

let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS

[<Emit("typeof $0 == \"undefined\"")>]
let checkUndefined target : bool = jsNative

/// input types
type InputType = 
    | BlockName
    | InputNumber
    | OutputNumber

/// block name
let mutable blockName : string option = option.None

/// number of inputs
let mutable inputNumber : int option = option.None

/// number of outputs
let mutable outputNumber : int option = option.None

/// set the mutable variable values
let setMutableVariableValue (inputType:InputType) (value:string) = 
    match inputType with
    | BlockName -> blockName <- Some value
    | InputNumber -> inputNumber <- value |> int |> Some
    | OutputNumber -> outputNumber <- value |> int |> Some

/// helper function find the input element
let findElementSetValue (id:string) (lst:NodeListOf<HTMLInputElement>) (inputType:InputType) =     
    let rec findElementSetValue' (index:int) =
        match index with
        | a when a < (lst.length |> int) -> match lst.[a].id with
                                            | b when b = id -> setMutableVariableValue inputType lst.[a].value
                                            | _ -> findElementSetValue' (index+1)
        | _ -> ()
    
    findElementSetValue' 0        

/// update the port configuration field
let updatePortConfiguration (portType:InputType) (portCount':int option) = 
    let portCount = match portCount' with
                    | Some a -> a
                    | option.None -> 0

    let fieldRoot, portType = match portType with
                              | InputNumber -> document.getElementById "input-settings", "in"
                              | OutputNumber -> document.getElementById "output-settings", "out"   
                              | BlockName -> failwithf "Not possible. The event should not be triggered when the user is change the block name."
                   
    let createOnePortConfigField (portIndex:int) (portType:string) = 
        let root = document.createElement_div ()
        root.id <- portType + "port" + (portIndex |> string)

        let label = document.createElement_label ()
        label.innerHTML <- portType + (portIndex |> string) + ":"

        let input = document.createElement_input ()
        input.innerHTML <- portType + (portIndex |> string)
        input.value <- portType + (portIndex |> string)

        root.appendChild label |> ignore
        root.appendChild input |> ignore

        root

    let rec appendConfigField (index:int) = 
        match index with
        | a when a < portCount -> let configField = createOnePortConfigField index portType
                                  fieldRoot.appendChild configField |> ignore                                  
                                  appendConfigField (index+1)                                        
        | _ -> ()

    fieldRoot.innerHTML <- ""
    appendConfigField 0

/// convert int to binary
/// from https://richiban.uk/2013/07/19/converting-decimal-integers-to-binary-strings-in-different-languages/
let intToBinaryConverter x (width:int) = 
    let rec intToBinaryConverter' i =
        match i with
        | 0 | 1 -> string i
        | _ -> let bit = string (i % 2)
               (intToBinaryConverter' (i / 2)) + bit
    let res = intToBinaryConverter' x
    match res with
    | a when a.Length < width -> (String.replicate (width-a.Length) "0") + a
    | _ -> res

/// extract the names from a list of HTML div elements
let rec extractNames (index:int) (lst:NodeListOf<HTMLDivElement>) (nameLst:string list) = 
    match index with
    | a when a < (lst.length |> int) -> let input = lst.[a].getElementsByTagName_input ()
                                        let inputValue = input.[0].value
                                        extractNames (index+1) lst (nameLst |> List.append [inputValue])
    | _ -> nameLst

let rec getValueFromInputs (index:int) (id:string) (lst:NodeListOf<HTMLInputElement>) = 
    match index with
    | a when a < (lst.length |> int) -> match (lst.Item index).id with
                                        | b when b = id -> match (lst.Item index).value with
                                                           | "1" | "0" -> (lst.Item index).value
                                                           | _ -> "0"
                                        | _ -> getValueFromInputs (index+1) id lst                                                              
    | _ -> ""

/// update the truth table display
let updateTruthTableDisplay () = 
    let root = document.getElementById "truth-table"
    root.innerHTML <- ""    

    let inPortNodes = (document.getElementById "input-settings").getElementsByTagName_div ()    
    let outPortNodes = (document.getElementById "output-settings").getElementsByTagName_div ()

    let inputIds = extractNames 0 inPortNodes []
    let outputIds = extractNames 0 outPortNodes []

    let generateColumn (label:string) (index:int) = 
        let columnRoot = document.createElement_div ()
        columnRoot.className <- "column-inline"
        
        let columnLabel = document.createElement_div ()
        columnLabel.innerHTML <- label
        columnLabel.id <- label
        
        columnRoot.appendChild columnLabel |> ignore

        let count = 2.**(float inputIds.Length) |> int
        
        [0..count-1]
        |> List.map (fun i -> let input = document.createElement_input ()
                              input.style.width <- "60%"
                              input.``type`` <- "text"
                              input.pattern <- "[Xx10]{1}"
                              input.value <- let res = intToBinaryConverter i inputIds.Length
                                             res.[index] |> string          
                              let div = document.createElement_div ()
                              div.style.paddingTop <- "10%"
                              input.id <- label+ (string i)
                              div.appendChild input |> ignore
                              columnRoot.appendChild div |> ignore)
        |> ignore
        
        columnRoot

    let generateColumnForOutputs (label:string) = 
        let columnRoot = document.createElement_div ()
        columnRoot.className <- "column-inline"
        
        let columnLabel = document.createElement_div ()
        columnLabel.innerHTML <- label
        columnLabel.id <- label
        
        columnRoot.appendChild columnLabel |> ignore

        let count = 2.**(float inputIds.Length) |> int
        
        [0..count-1]
        |> List.map (fun i -> let input = document.createElement_input ()
                              input.style.width <- "60%"
                              input.``type`` <- "text"
                              input.id <- label + string i
                              input.pattern <- "[10]{1}"
                              input.value <- "0"       
                              let div = document.createElement_div ()
                              div.style.paddingTop <- "10%"
                              div.id <- label + (string i)                               
                              div.appendChild input |> ignore
                              columnRoot.appendChild div |> ignore)
        |> ignore
        
        columnRoot

    [0..inputIds.Length-1]
    |> List.map (fun el -> let column = generateColumn inputIds.[el] el
                           root.appendChild column |> ignore)
    |> ignore

    
    [0..outputIds.Length-1]
    |> List.map (fun el -> let column = generateColumnForOutputs (outputIds.[el] + "div")
                           root.appendChild column |> ignore)
    |> ignore

/// update the icon that is going to be used on the block diagram editor
let createIcon () = 
    /// get the in ports and the out ports
    let inPortNodes = (document.getElementById "input-settings").getElementsByTagName_div ()    
    let outPortNodes = (document.getElementById "output-settings").getElementsByTagName_div ()

    let inputIds = extractNames 0 inPortNodes []
                   |> List.toArray 
    let outputIds = extractNames 0 outPortNodes []
                    |> List.toArray

    let width, height = 90, ((max inputIds.Length outputIds.Length)*20)

    /// initialize the graoh
    let graph = jointJSCreator.GraphInit ()

    /// create a mutable canvas in case of resizing
    let canvas : HTMLElement = document.getElementById "icon-generate"

    /// create the paper settings
    let paperSettings = generatePaperSettings canvas graph 200 (height+40) 10 true "rgba(0, 0, 0, 0)"

    /// initialize the paer using the paperSettings
    let paper = jointJSCreator.PaperInit paperSettings

    let routerSetting = createObj[
        "name" ==> "manhattan"
        "args" ==> createObj[
                      "padding" ==> 10
                   ]
    ]
    paper?options?defaultRouter <- routerSetting

    let logicElement = createNew joint?shapes?devs?Model ()

    let nameOfBlock = (((document.getElementById "block-name-input").getElementsByTagName_input ()).Item 0).value + "-"

    logicElement?set("inPorts", inputIds)
    logicElement?set("outPorts", outputIds)
    logicElement?attr(".label/text", nameOfBlock)
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
    
    resizePort 0 inputIds
    resizePort 0 outputIds        

    logicElement
    |> jointJSCreator.Resize 90 ((max inputIds.Length outputIds.Length)*20)
    |> jointJSCreator.Position 70 20
    |> jointJSCreator.AddTo graph    
    |> ignore

/// bind the event listener to to the user input field to update the GUI
let bindEventUpdateGUI () =  
    let blockInputNumber = document.getElementById "block-input-number"
   
    let blockOutputNumber = document.getElementById "block-output-number"   
    
    let blockNameField = document.getElementById "block-name-field"

    let updateTruthTableButton = document.getElementById "update-truth-table"

    let updateIconButton = document.getElementById "generate-button"

    let closeCurrentWindowButton = document.getElementById "cancel-button"

    let okButton = document.getElementById "ok-button"
    
    let lst = document.getElementsByTagName_input ()

    let updateInputFields = fun e -> findElementSetValue "block-input-number" lst InputNumber
                                     updatePortConfiguration InputNumber inputNumber

    let updateOutputFields = fun e -> findElementSetValue "block-output-number" lst OutputNumber
                                      updatePortConfiguration OutputNumber outputNumber                                      

    let updateNameFields = fun e -> findElementSetValue "block-name-field" lst BlockName                                    

    let updateTruthTable = fun e -> let div = document.getElementById "truth-table"
                                    div.innerHTML <- ""
                                    updateTruthTableDisplay ()

    let updateIcon = fun e -> let div = document.getElementById "icon-generate"
                              div.innerHTML <- ""
                              createIcon ()

    let closeCurrentWindow = fun e -> let window = electron.remote.getCurrentWindow ()
                                      window.close ()

    let OkButtonEvent = fun e -> let inPortNodes = (document.getElementById "input-settings").getElementsByTagName_div ()    
                                 let outPortNodes = (document.getElementById "output-settings").getElementsByTagName_div ()

                                 let inputIds = extractNames 0 inPortNodes []
                                                |> List.toArray 
                                 let outputIds = extractNames 0 outPortNodes []
                                                 |> List.toArray
                                 
                                 let truthTable = 
                                    let container = document.getElementsByTagName_input ()
                                    
                                    let getOneRow (rowNumber:int) =                                         
                                        [0..outputIds.Length - 1]
                                        |> List.map (fun i -> let id = outputIds.[i] + "div" + (rowNumber |> string)
                                                              getValueFromInputs 0 id container)                                        
                                        |> List.toArray
                                        |> String.concat ""

                                    let inputCounts = int (2.** float inputIds.Length)
                                    let outputConfigs = 
                                        [0..inputCounts]
                                        |> List.map (fun i -> getOneRow i)
                                    
                                    [0..inputCounts-1]
                                    |> List.map (fun i -> outputConfigs.[i])
                                    |> List.toArray
                                    
                                 
                                 let contentGenerator () = 
                                    let mutable content = "module"

                                    let moduleName =
                                        match blockName with
                                        | Some name -> name
                                        | option.None -> "MyModule"

                                    content <- content + " " + moduleName + "("                                                                       

                                    let outputNames = outputIds |> String.concat ", "

                                    content <- content + outputNames + ", "

                                    let inputNames = inputIds |> String.concat ", "
                                    
                                    content <- content + inputNames + ", clock); \n"

                                    content <- content + "  " + "input " + inputNames + ", clock; \n"
                                    content <- content + "  " + "output " + outputNames + "; \n"
                                    
                                    let rec outputReg (index:int) (res:string) (lst:string array)= 
                                        match index with
                                        | a when a < lst.Length -> outputReg (index+1) (res + "  reg " + outputIds.[a] + " = 1b'0; \n") lst
                                        | _ -> res

                                    content <- outputReg 0 content outputIds
                                    content <- content + "\n  always @ (posedge clock)\n"
                                    content <- content + "  begin\n"
                                    content <- content + "    case({" + inputNames + "})\n"

                                    let rec caseStatementInnerBeginEnd (row:int) (outputCount:int) (outputs:string array) (truthTable:string array) (res:string) = 
                                        match outputCount with
                                        | a when a < outputs.Length -> caseStatementInnerBeginEnd row (outputCount+1) outputs truthTable (res + outputs.[a] + " <= " + "1'b" + string truthTable.[row].[a] + ";\n      ")
                                        | _ -> res

                                    let rec lookupTableHorizontalLine (index:int) (truthTable:string array) (inputWidth:int) (res:string) = 
                                        match index with
                                        | a when a < truthTable.Length -> let lookupIn = "    " + (string inputWidth) + "'b" + (intToBinaryConverter a inputWidth) + ":\n"
                                                                          let beginStatement = "      begin\n"
                                                                          let innerStatements = caseStatementInnerBeginEnd a 0 outputIds truthTable "      "
                                                                          let endStatement = "end\n"
                                                                          lookupTableHorizontalLine (index+1) truthTable inputWidth (res + lookupIn + beginStatement + innerStatements + endStatement)

                                        | _ -> res
                                            
                                    let defaultCaseTruthTable = 
                                        let stringRes = [0..outputIds.Length-1]
                                                        |> List.map (fun el -> "0")
                                                        |> String.concat ""
                                        [|stringRes|]

                                    content <- lookupTableHorizontalLine 0 truthTable inputIds.Length content
                                    content <- content + "    default: \n      begin\n" + caseStatementInnerBeginEnd 0 0 outputIds defaultCaseTruthTable "      " + "end\n"
                                    content <- content + "    endcase\n"
                                    content <- content + "  end"
                                    content <- content + "\n" + "endmodule\n\n"
                                    content                                                                  

                                 let saveDialogOptions = createEmpty<SaveDialogOptions>
                                 saveDialogOptions.title <- Some "Save file to"
                                 saveDialogOptions.defaultPath <- Some ("../new.json")                                         
                                 saveDialogOptions.filters <- option.None

                                 /// return the directory and the file name that is to be saved
                                 let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)
                                 
                                 let contents = 
                                    createObj[
                                        "name" ==> blockName
                                        "inputs" ==> inputIds
                                        "outputs" ==> outputIds
                                        "truthTable" ==> truthTable
                                        "Verilog" ==> fileSaveDialog + ".v"
                                    ]
                                 match fileSaveDialog with
                                 | a when checkUndefined a <> true -> let errorHandler error = 
                                                                          electron.ipcRenderer.send("new-block-information", 
                                                                            (blockName, inputIds.Length, outputIds.Length, inputIds, outputIds, truthTable, contentGenerator ()))
                                                                      fs.writeFile (fileSaveDialog, JS.JSON.stringify contents, errorHandler)
                                                                      let errorHandlerClosingWindow error =                                                                           
                                                                          let window = electron.remote.getCurrentWindow ()
                                                                          window.close ()
                                                                      fs.writeFile (fileSaveDialog + ".v", contentGenerator (), errorHandlerClosingWindow)
                                 | _ -> ()                                 

    blockInputNumber.addEventListener("input", U2.Case1 updateInputFields, false)
    blockOutputNumber.addEventListener("input", U2.Case1 updateOutputFields, false)
    blockNameField.addEventListener("input", U2.Case1 updateNameFields, false)
    updateTruthTableButton.addEventListener("click", U2.Case1 updateTruthTable, false)
    updateIconButton.addEventListener("click", U2.Case1 updateIcon, false)
    closeCurrentWindowButton.addEventListener("click", U2.Case1 closeCurrentWindow, false)
    okButton.addEventListener("click", U2.Case1 OkButtonEvent, false)
   
bindEventUpdateGUI ()
