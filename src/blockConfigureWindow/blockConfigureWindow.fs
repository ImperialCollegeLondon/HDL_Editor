module blockConfigureWindow

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open Fable.Import.Electron

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

/// update the truth table display
let updateTruthTableDisplay () = 
    let root = document.getElementById "truth-table"
    root.innerHTML <- ""

    let inPortNodes = (document.getElementById "input-settings").getElementsByTagName_div ()    
    let outPortNodes = (document.getElementById "output-settings").getElementsByTagName_div ()

    let rec extractNames (index:int) (lst:NodeListOf<HTMLDivElement>) (nameLst:string list) = 
        match index with
        | a when a < (lst.length |> int) -> let input = lst.[a].getElementsByTagName_input ()
                                            let inputValue = input.[0].value
                                            extractNames (index+1) lst (nameLst |> List.append [inputValue])
        | _ -> nameLst

    let generateColumn (label:string) = 
        let columnRoot = document.createElement_div ()
        
        let columnLabel = document.createElement_label ()
        columnLabel.innerHTML <- label
        

    ()

/// bind the event listener to to the user input field to update the GUI
let bindEventUpdateGUI () =  
    let blockInputNumber = document.getElementById "block-input-number"
   
    let blockOutputNumber = document.getElementById "block-output-number"   
    
    let blockNameField = document.getElementById "block-name-field"
    
    let lst = document.getElementsByTagName_input ()

    let updateInputFields = fun e -> findElementSetValue "block-input-number" lst InputNumber
                                     updatePortConfiguration InputNumber inputNumber

    let updateOutputFields = fun e -> findElementSetValue "block-output-number" lst OutputNumber
                                      updatePortConfiguration OutputNumber outputNumber                                      

    let updateNameFields = fun e -> findElementSetValue "block-name-field" lst BlockName
                                    console.log(blockName)

    blockInputNumber.addEventListener("input", U2.Case1 updateInputFields, false)
    blockOutputNumber.addEventListener("input", U2.Case1 updateOutputFields, false)
    blockNameField.addEventListener("input", U2.Case1 updateNameFields, false)
   
   (*
/// collect information from the user input
let collectInfo () =
    let blockName = findInputGetValue "box-name"    
    let numberOfInputs = match findInputGetValue "block-input-number" with
                         | Some value -> value |> int
                         | option.None -> failwithf "not found"
    let numberOfOutputs = match findInputGetValue "block-output-number" with
                          | Some value -> value |> int
                          | option.None -> failwithf "not found"
       
    ()
    

    collectInfo ()


*)
bindEventUpdateGUI ()