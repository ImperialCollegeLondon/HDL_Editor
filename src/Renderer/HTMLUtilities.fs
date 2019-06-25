(*
    The module is used as the helper functions to manipulate HTML elements
*)
module HTMLUtilities

open Fable.Import.Browser
open Fable.Core
open Fable.Core.JsInterop
open JSLibInterface


/// HTML element type
type HTMLElementType = 
    | InputBox


/// use the JointJS bindings by upcasting the interface
let joint : obj = importAll "jointjs"
let jointJSCreatorInterface = new createElement()
let jointJSCreator = jointJSCreatorInterface :> JointJS


/// get the element
/// bind an event listener
/// bind a function that is triggered when the event listener is triggered
let getElementBindEvent (el:string) (event:string) (eventFunc:EventListener) = 
    document.getElementById(el).addEventListener(event, U2.Case1 eventFunc, false)

/// get the value from the input box
let getValueFromElement (elType:HTMLElementType) (id:string) : string =    
    match elType with
    | InputBox -> let nodeList = document.getElementsByTagName_input ()   
                  let rec selectUsingId (lst:NodeListOf<HTMLInputElement>) (index:int) = 
                      match index with
                      | a when a < int lst.length -> if lst.[index].id = id then (lst.Item index).value else selectUsingId lst (index+1)                                                     
                      | _ -> failwithf "not found"
                  selectUsingId nodeList 0                  

/// get the HTML element
let setHTMLElementValue (elType:HTMLElementType) (id:string) (value:string) = 
    match elType with
    | InputBox -> let nodeList = document.getElementsByTagName_input ()   
                  let rec selectUsingId (lst:NodeListOf<HTMLInputElement>) (index:int) = 
                      match index with
                      | a when a < int lst.length -> if lst.[index].id = id then (lst.Item index).value <- value else selectUsingId lst (index+1)                                                     
                      | _ -> failwithf "not found"
                  selectUsingId nodeList 0                                

/// get the HTML element
/// set the innterHTML
let getElementSetInnerHTML (id:string) (innerHTML:string) = 
    (document.getElementById id).innerHTML <- innerHTML

/// create a button
/// id, class and innerHTML are given
let createButton (id:string) (className:string) (text:string) = 
    let button = document.createElement_button ()
    
    button.id <- id
    button.className <- className
    button.innerHTML <- text

    button


/// update the tab name if the canvas were changed but not saved
let updatePaneName paneName = 
    let button = document.getElementById (paneName + "-tabButton")
    let buttonText = button.innerHTML
    match buttonText with
    | a when a.[a.Length-1] = '*' -> ()
    | _ -> button.innerHTML <- buttonText + "*"


/// port radius setting
let radius = createObj[
    "r" ==> 5
 ]


/// initialize the input port
let inputPortInit (counter:int) =    
    jointJSCreator.PortBlockInit ()
    |> jointJSCreator.SetPorts "inPorts" [||]
    |> jointJSCreator.SetPorts "outPorts" [|"out"|]
    |> jointJSCreator.AttrBySelector ".label/text" ("In-in" + string counter)
    |> jointJSCreator.AttrFont ".label/fontSize" 14
    |> jointJSCreator.AttrBySelector ".label/textVerticalAnchor" "middle"
    |> jointJSCreator.SetPortProperty "out" "attrs/circle" radius              
    |> jointJSCreator.Resize 90 20


/// create output blocks
let outputPortInit (counter:int) = 
    jointJSCreator.PortBlockInit ()
    |> jointJSCreator.SetPorts "inPorts" [|"in"|]
    |> jointJSCreator.SetPorts "outPorts" [||]
    |> jointJSCreator.AttrBySelector ".label/text" ("Out-out" + string counter)
    |> jointJSCreator.AttrFont ".label/fontSize" 14
    |> jointJSCreator.AttrBySelector ".label/textVerticalAnchor" "middle"
    |> jointJSCreator.SetPortProperty "in" "attrs/circle" radius              
    |> jointJSCreator.Resize 90 20
    
    
/// resize the port's circle size and position
let resizePort (portNames:string array) (el:obj) =     
    let rec resizePort' (index:int) (portNames:string array) (el:obj) = 
        match index with
        | a when a < portNames.Length -> el
                                         |> jointJSCreator.SetPortProperty portNames.[index] "attrs/circle" radius
                                         |> jointJSCreator.SetPortProperty portNames.[index] "args/y" (20*(index)+10)                                     
                                         |> resizePort' (index+1) portNames
        | _ -> ()
    resizePort' 0 portNames el
    el


/// create custom logic blocks
let customLogicElementInit (inPorts:string array) (outPorts:string array) (blockName:string) = 
    jointJSCreator.PortBlockInit ()
    |> jointJSCreator.SetPorts "inPorts" inPorts
    |> jointJSCreator.SetPorts "outPorts" outPorts
    |> jointJSCreator.AttrBySelector ".label/text" blockName
    |> jointJSCreator.AttrFont ".label/fontSize" 14
    |> jointJSCreator.AttrBySelector ".label/textVerticalAnchor" "middle"
    |> jointJSCreator.Resize 90 20
    |> resizePort inPorts
    |> resizePort outPorts
    |> jointJSCreator.Resize 90 ((max inPorts.Length outPorts.Length)*20)

 
/// reset the coloring of the unselected elements
let resetAllSelected paper = 
    let elements : obj array = paper?model?getElements()
    [0..elements.Length-1]
    |> List.map (fun el -> jointJSCreator.AttrBySelector "rect/fill" "white" elements.[el]) 
    |> ignore


/// create a button and style it
let buttonInit paneName buttonName buttonIdSuffix text width leftRatio = 
    let button = document.createElement_button ()
    button.``type`` <- "button"
    button.id <- paneName + "-" + buttonName + buttonIdSuffix
    button.innerHTML <- text
    button.style.width <- width
    button.style.left <- leftRatio
    button.style.cssFloat <- "left"

    button