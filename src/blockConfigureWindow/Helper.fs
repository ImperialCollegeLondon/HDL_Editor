module Helper

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open Ref


let joint : obj = importAll "jointjs"

/// use the JointJS bindings by upcasting the interface
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS


/// check whether the object returned is undefined
[<Emit("typeof $0 == \"undefined\"")>]
let checkUndefined target : bool = jsNative


/// set the mutable variable values
let setMutableVariableValue (inputType:UserInputType) (value:string) = 
    match inputType with
    | BlockName -> blockName <- Some value
    | InputNumber -> inputNumber <- value |> int |> Some
    | OutputNumber -> outputNumber <- value |> int |> Some


/// find the input HTML element with the id
/// then set the mutable variable value
let findElementSetValue (id:string) (lst:NodeListOf<HTMLInputElement>) (inputType:UserInputType) =     
    let rec findElementSetValue' (index:int) =
        match index with
        | i when i < (lst.length |> int) -> match lst.[i].id with
                                            | b when b = id -> setMutableVariableValue inputType lst.[i].value
                                            | _ -> findElementSetValue' (i+1)
        | _ -> ()
    
    findElementSetValue' 0        


/// add one entry to the port configuration field
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

/// update the port configuration field
let updatePortConfiguration (portType:UserInputType) (portCount':int option) = 
    let portCount = match portCount' with
                    | Some a -> a
                    | option.None -> 0

    let fieldRoot, portType = match portType with
                              | InputNumber -> document.getElementById "input-settings", "in"
                              | OutputNumber -> document.getElementById "output-settings", "out"   
                              | BlockName -> failwithf "Not possible. The event should not be triggered when the user is change the block name."                           

    /// recursively create and append port configuration entries
    let rec appendConfigField (index:int) = 
        match index with
        | a when a < portCount -> let configField = createOnePortConfigField index portType
                                  fieldRoot.appendChild configField |> ignore                                  
                                  appendConfigField (index+1)                                        
        | _ -> ()

    /// clear the root HTML div element before appending new entries
    fieldRoot.innerHTML <- ""    
    appendConfigField 0


/// convert int to binary
/// from https://richiban.uk/2013/07/19/converting-decimal-integers-to-binary-strings-in-different-languages/
let intToBinaryConverter (x:int) (width:int) = 
    let rec intToBinaryConverter' i =
        match i with
        | 0 | 1 -> string i
        | _ -> let bit = string (i % 2)
               (intToBinaryConverter' (i / 2)) + bit
    
    match intToBinaryConverter' x with
    | a when a.Length < width -> (String.replicate (width-a.Length) "0") + a
    | b -> b


/// extract the names from a list of HTML div elements
let extractNames (lst:NodeListOf<HTMLDivElement>) = 
    let rec extractNames' (index:int) (lst:NodeListOf<HTMLDivElement>) (nameLst:string list) = 
        match index with
        | a when a < (lst.length |> int) -> let input = lst.[a].getElementsByTagName_input ()
                                            let inputValue = input.[0].value
                                            extractNames' (index+1) lst (nameLst |> List.append [inputValue])
        | _ -> nameLst

    extractNames' 0 lst []


/// extract one column of the truth table
let getValueFromInputs (id:string) (lst:NodeListOf<HTMLInputElement>) = 
    let rec getValueFromInputs' (index:int) (id:string) (lst:NodeListOf<HTMLInputElement>) = 
        match index with
        | a when a < (lst.length |> int) -> match (lst.Item index).id with
                                            | b when b = id -> match (lst.Item index).value with
                                                               | "1" | "0" -> (lst.Item index).value
                                                               | _ -> "0"
                                            | _ -> getValueFromInputs' (index+1) id lst                                                              
        | _ -> ""

    getValueFromInputs' 0 id lst


/// update the truth table display
let updateTruthTableDisplay () = 
    let root = document.getElementById "truth-table"
    root.innerHTML <- ""    

    let inputIds = (document.getElementById "input-settings").getElementsByTagName_div ()    
                   |> extractNames
    let outputIds = (document.getElementById "output-settings").getElementsByTagName_div ()
                    |> extractNames        

    let generateColumn (label:string) (index:int option) = 
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
                              input.value <- match index with
                                             | Some a -> let res = intToBinaryConverter i inputIds.Length
                                                         res.[a] |> string   
                                             | option.None -> "0"
                              let div = document.createElement_div ()
                              div.style.paddingTop <- "10%"
                              input.id <- label+ (string i)
                              div.appendChild input |> ignore
                              columnRoot.appendChild div)
        |> ignore
        
        columnRoot

    /// generate and fill in the input part of the truth table
    [0..inputIds.Length-1]
    |> List.map (fun el -> let column = generateColumn inputIds.[el] (Some el)
                           root.appendChild column |> ignore)
    |> ignore

    /// generate and fill in the output part of the truth table
    [0..outputIds.Length-1]
    |> List.map (fun el -> let column = generateColumn outputIds.[el] option.None
                           root.appendChild column |> ignore)
    |> ignore


/// update the icon that is going to be used in the block diagram editor
let createIcon () = 
    /// get the in ports and the out ports
    let inPortNodes = (document.getElementById "input-settings").getElementsByTagName_div ()    
    let outPortNodes = (document.getElementById "output-settings").getElementsByTagName_div ()

    let inputIds = extractNames inPortNodes
                   |> List.toArray 
    let outputIds = extractNames outPortNodes
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
