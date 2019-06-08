module Tabs

open Fable.Core
open Fable.Import.Browser
open JSLibInterface
open HTMLUtilities

/// tab number counter
let mutable tabCounter = 1

/// helper function to hide and show divs
let hideAndShowDiv (tabName:string) = 
    let divLst = document.getElementsByTagName_div ()

    let rec hideAndShowDiv' (lst:NodeListOf<HTMLDivElement>) (index:int) (tabName:string) = 
        match index with
        | a when a < int lst.length -> let text = lst.[index].id.Split [|'-'|]                                       
                                       if text.[0] <> tabName && text.[0] <> "tabRow" && text.[1] <> "buttonDiv"
                                       then (lst.Item index).setAttribute ("style", "display:none")
                                            hideAndShowDiv' lst (index + 1) tabName
                                       else (lst.Item index).setAttribute ("style", "display:block")
                                            hideAndShowDiv' lst (index+1) tabName
        | _ -> ()
    hideAndShowDiv' divLst 0 tabName

/// create a block diagram editor interface
let blockDiagramEditorInit (title:string) = 
    let root = document.createElement_div ()
    root.id <- title
    
    //root.innerHTML <- "Hello" + title

    let workingPaneInit = 
        let workingPane = document.createElement_div ()
        workingPane.id <- title + "-workingPane"
        workingPane.className <- "working-pane"

        let canvas = document.createElement_div ()
        canvas.id <- title + "-canvas"
        canvas.className <- "block-configure"

        canvas
        |> workingPane.appendChild
        |> ignore
        
        workingPane

    let infoPaneInit =        
        let infoPane = document.createElement_div ()
        infoPane.id <- title + "-infoPane"
        infoPane.className <- "info-pane"

        let blockConfigure = document.createElement_div ()
        blockConfigure.id <- title + "-blockConfigure"
        blockConfigure.className <- "block-configure"

        let blockConfigurationTitle = document.createElement "h3"
        blockConfigurationTitle.innerHTML <- "Block Configuration" + title
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
        |> ignore

        infoPane

    (root.appendChild workingPaneInit).appendChild infoPaneInit |> ignore  
    root

/// create a new pane with button associated with the pane
let createNewPaneWithButton () = 
    /// create the prefix for naming any div elements
    let namePrefix = "pane" + string tabCounter + "div"
    
    /// create the button with the text
    /// that repesents the pane
    let newTab = document.createElement_button ()     
    newTab.innerHTML <- "pane" + string tabCounter 
    newTab.className <- "tab-element"
    newTab.id <- namePrefix + "-tabButton"

    /// create the button that is used to close the pane
    let newTabCloseButton = document.createElement_button ()
    newTabCloseButton.innerHTML <- "x"
    newTabCloseButton.className <- "tab-close-element"
    newTabCloseButton.id <- namePrefix + "-closeButton"                 

    /// create the div element that contains both buttons created above
    let newTabDiv = document.createElement_div ()
    newTabDiv.id <- namePrefix + "-buttonDiv"

    /// append the two buttons to the div
    newTabDiv.appendChild newTab |> ignore
    newTabDiv.appendChild newTabCloseButton |> ignore
     
    /// get all the buttons
    let tabRow = document.getElementById "tabRow"
    
    /// define the action when the remove-pane button is clicked
    let removeDiv = fun e -> tabRow.removeChild newTabDiv |> ignore
    newTabCloseButton.addEventListener("click", U2.Case1 removeDiv, false)   
    
    /// the div element that holds all the elements that are newly created
    let newDiv = blockDiagramEditorInit namePrefix

    /// hide all other divs
    hideAndShowDiv namePrefix
    
    document.body.appendChild newDiv |> ignore

    /// increase the pane counter when creating new panes
    tabCounter <- tabCounter + 1

    /// insert the div that contains the two buttons in the tab row
    tabRow.insertBefore (newTabDiv, (document.getElementById "new-tab-button")) |> ignore

    /// attach the event listener to the button
    fun e -> hideAndShowDiv namePrefix
    |> getElementBindEvent (namePrefix + "-tabButton") "click"

/// the "+" button to add new tabs
let newTabButtonInit () =    
    /// bind the action triggered when clicking the "+" button
    fun e -> createNewPaneWithButton ()
    |> getElementBindEvent "new-tab-button" "click" 

    /// create at least one pane when the application launches
    createNewPaneWithButton ()