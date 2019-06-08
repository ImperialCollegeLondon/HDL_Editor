module Tabs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open HTMLUtilities
open System.Collections.Generic

/// tab number counter
let mutable tabCounter = 1

/// create a block diagram editor interface
let blockDiagramEditorInit (title:string) : Node = 
    let root = document.createElement_div ()
    root.id <- title

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

/// create a new pane with button associated with the pane
let createNewPaneWithButton () = 
    /// create the button with the text
    /// that repesents the name of the pane
    let newTab = document.createElement_button ()     
    newTab.innerHTML <- "pane" + string tabCounter 
    newTab.className <- "tab-element"
    newTab.id <- "pane" + string tabCounter                 

    /// create the button that is used to close the pane
    let newTabCloseButton = document.createElement_button ()
    newTabCloseButton.innerHTML <- "x"
    newTabCloseButton.className <- "tab-close-element"
    newTabCloseButton.id <- "pane" + string tabCounter + "-close-button"                 

    /// create the div element that contains both buttons created above
    let newTabDiv = document.createElement_div ()
    newTabDiv.id <- "pane" + string tabCounter + "-div"

    /// append the two buttons to the div
    newTabDiv.appendChild newTab |> ignore
    newTabDiv.appendChild newTabCloseButton |> ignore
     
    /// get all the buttons
    let tabRow = document.getElementById "tab-row"
    
    /// define the action when the remove-pane button is clicked
    let removeDiv = fun e -> tabRow.removeChild newTabDiv |> ignore
    newTabCloseButton.addEventListener("click", U2.Case1 removeDiv, false)   
    
    /// the div element that holds all the elements that are newly created
    let newDiv = blockDiagramEditorInit ("paneDiv-" + string tabCounter)

    /// hide all other divs
    let divLst = document.getElementsByTagName_div ()
    let rec hideDiv (lst:NodeListOf<HTMLDivElement>) (index:int) = 
        match index with
        | a when a < int lst.length -> let text = lst.[index].id
                                       console.log(text)
                                       if text.[..7] = "paneDiv-"  + string tabCounter && text <> "tab-row"
                                       then console.log(text, "hidden")
                                            (lst.Item index).setAttribute ("style", "visibility:hidden")
                                       else hideDiv lst (index+1)                                                     
        | _ -> console.log("not found")
    hideDiv divLst 0 
    
    let rec showDiv (lst:NodeListOf<HTMLDivElement>) (index:int) = 
        match index with
        | a when a < int lst.length -> console.log(lst.[index].id)
                                       if lst.[index].id = "paneDiv-" + string tabCounter then (lst.Item index).setAttribute ("style", "visibility:visible")
                                       else hideDiv lst (index+1)                                                     
        | _ -> console.log("not shown")
    //showDiv divLst 0

    document.body.appendChild newDiv |> ignore

    /// increase the pane counter when creating new panes
    tabCounter <- tabCounter + 1

    /// insert the div that contains the two buttons in the tab row
    tabRow.insertBefore (newTabDiv, (document.getElementById "new-tab-button")) |> ignore

/// the "+" button to add new tabs
let newTabButtonInit () =    
    /// bind the action triggered when clicking the "+" button
    fun e -> createNewPaneWithButton ()
    |> getElementBindEvent "new-tab-button" "click" 

    /// create at least one pane when the application launches
    createNewPaneWithButton ()