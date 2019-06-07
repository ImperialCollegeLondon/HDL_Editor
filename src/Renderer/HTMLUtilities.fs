(*
    The module is used as the helper functions to manipulate HTML elements
*)
module HTMLUtilities

open Fable.Core
open Fable.Import
open Fable.Import.Browser


/// HTML element type
type HTMLElementType = 
    | InputBox

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
                                //(((document.getElementsByTagName_input) ()).Item itemIndex).value <- value

/// get the HTML element
/// set the innterHTML
let getElementSetInnerHTML (id:string) (innerHTML:string) = 
    (document.getElementById id).innerHTML <- innerHTML

/// create a block diagram editor interface
let blockDiagramEditorInit (title:string) : Node = 
    let root = document.createElement_div ()
    root.title <- title

    let workingPaneInit = 
        let workingPane = document.createElement_div ()
        workingPane.id <- title + "-working-pane"
        workingPane.className <- "working-pane"

        let canvas = document.createElement_div ()
        canvas.id <- title + "block-editor-canvas"
        canvas.className <- "block-configure"

        canvas
        |> workingPane.appendChild 

    let infoPaneInit =        
        let infoPane = document.createElement_div ()
        infoPane.id <- title + "info-pane"
        infoPane.className <- "info-pane"

        let blockConfigure = document.createElement_div ()
        blockConfigure.id <- title + "block-configure"
        blockConfigure.className <- "block-configure"

        let blockConfigurationTitle = document.createElement "h3"
        blockConfigurationTitle.innerHTML <- "Block Configuration"
        blockConfigure.appendChild blockConfigurationTitle |> ignore

        let inputElementName = document.createElement_input ()
        inputElementName.id <- title + "element-name-field"
        inputElementName.``type`` <- "text"
        inputElementName.name <- ""
        inputElementName.value <- ""
        blockConfigure.appendChild inputElementName |> ignore



        let addBlockButtonGroup = document.createElement_div ()
        addBlockButtonGroup.id <- title + "add-block-button-group"
        addBlockButtonGroup.className <- "add-block-button-group"

        blockConfigure
        |> infoPane.appendChild
        |> ignore

        addBlockButtonGroup
        |> infoPane.appendChild 
        
    (root.appendChild workingPaneInit).appendChild infoPaneInit