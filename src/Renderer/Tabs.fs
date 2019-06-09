module Tabs

open Fable.Core
open Fable.Import.Browser
open Jointjs
open HTMLUtilities

/// tab number counter
let mutable tabCounter = 1

/// helper function to hide and show divs
let hideAndShowDiv (tabName:string) = 
    let divLst = document.getElementsByTagName_div ()

    let rec hideAndShowDiv' (lst:NodeListOf<HTMLDivElement>) (index:int) (tabName:string) = 
        match index with
        | a when a < int lst.length -> let text = lst.[index].id.Split [|'-'|]
                                       let classNames = lst.[index].className
                                       if text.[0] <> tabName 
                                          && text.[0] <> "tabRow" 
                                          && text.[1] <> "buttonDiv"
                                          && classNames <> "joint-paper-background"
                                          && classNames <> "joint-paper-grid"
                                       then (lst.Item index).style.display <- "none"                                          
                                            hideAndShowDiv' lst (index + 1) tabName
                                       else (lst.Item index).style.display <- "block"
                                            hideAndShowDiv' lst (index+1) tabName
        | _ -> ()
    hideAndShowDiv' divLst 0 tabName

/// helper function to remove divs
let removeDiv (tabName:string) = 
    let divLst = document.getElementsByTagName_div ()

    let rec removeDiv' (lst:NodeListOf<HTMLDivElement>) (index:int) (tabName:string) = 
        match index with
        | a when a < int lst.length -> let text = lst.[index].id.Split [|'-'|]                                       
                                       if text.[0] <> tabName && text.[0] <> "tabRow"
                                       then document.removeChild (lst.Item index) |> ignore
                                            removeDiv' lst (index + 1) tabName
                                       else removeDiv' lst (index+1) tabName
        | _ -> ()
    removeDiv' divLst 0 tabName

/// helper function to rename divs
let renameDiv (tabName:string) (renamedName:string) = 
    let divLst = document.getElementsByTagName_div ()

    let rec renameDiv' (lst:NodeListOf<HTMLDivElement>) (index:int) (tabName:string) = 
        match index with
        | a when a < int lst.length -> let text = lst.[index].id.Split [|'-'|]                                       
                                       if text.[0] <> tabName && text.[0] <> "tabRow"
                                       then (lst.Item index).id <- renamedName + text.[1]
                                            renameDiv' lst (index + 1) tabName
                                       else renameDiv' lst (index+1) tabName
        | _ -> ()
    renameDiv' divLst 0 tabName

/// create a block diagram editor interface
let blockDiagramEditorInit (title:string) = 
    let root = document.createElement_div ()
    root.id <- title   

    let workingPaneInit = 
        let workingPane = document.createElement_div ()
        workingPane.id <- title + "-workingPane"
        workingPane.className <- "working-pane"

        let canvas = document.createElement_div ()
        canvas.id <- title + "-canvas"

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

        let blockNameLabel = document.createElement_p ()
        blockNameLabel.innerHTML <- "Name:"
        blockConfigure.appendChild blockNameLabel |> ignore

        let inputElementName = document.createElement_input ()
        inputElementName.id <- title + "element-name-field"
        inputElementName.``type`` <- "text"
        inputElementName.name <- ""
        inputElementName.value <- ""
        blockConfigure.appendChild inputElementName |> ignore

        let br = document.createElement_br ()
        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore

        let typeLabel = document.createElement_p ()
        typeLabel.innerHTML <- "Type: "
        blockConfigure.appendChild typeLabel |> ignore
        
        let typeInfoLabel = document.createElement_label ()
        typeInfoLabel.id <- title + "-blockTypeLabel"
        blockConfigure.appendChild typeInfoLabel |> ignore

        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore

        let booleanEquationLabel = document.createElement_label ()
        booleanEquationLabel.innerHTML <- "Boolean Equation: "
        blockConfigure.appendChild booleanEquationLabel |> ignore

        let booleanEquationEntryField = document.createElement_input ()
        booleanEquationEntryField.id <- title + "-booleanEquation"
        booleanEquationEntryField.``type`` <- "text"
        booleanEquationEntryField.value <- ""
        blockConfigure.appendChild booleanEquationEntryField |> ignore

        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore

        let locationLabel = document.createElement_p ()
        locationLabel.innerHTML <- "Location:"
        blockConfigure.appendChild locationLabel |> ignore

        let locationXLabel = document.createElement_p ()
        locationXLabel.innerHTML <- "X:"
        blockConfigure.appendChild locationXLabel |> ignore

        let locationXInputField = document.createElement_input ()
        locationXInputField.className <- "coordinate-field"
        locationXInputField.``type`` <- "int"
        locationXInputField.value <- ""
        locationXInputField.id <- title + "-positionX"
        blockConfigure.appendChild locationXInputField |> ignore

        let locationYLabel = document.createElement_p ()
        locationYLabel.innerHTML <- "Y:"
        blockConfigure.appendChild locationYLabel |> ignore

        let locationYInputField = document.createElement_input ()
        locationYInputField.className <- "coordinate-field"
        locationYInputField.``type`` <- "int"
        locationYInputField.value <- ""
        locationYInputField.id <- title + "-positionY"
        blockConfigure.appendChild locationYInputField |> ignore

        let updateInfoButton = document.createElement_button ()
        updateInfoButton.id <- title + "-updateInfoButton"
        updateInfoButton.``type`` <- "button"
        updateInfoButton.innerHTML <- "Update Configuration"
        blockConfigure.appendChild updateInfoButton |> ignore

        let deleteBlockButton = document.createElement_button ()
        deleteBlockButton.id <- title + "-deleteBlockButton"
        deleteBlockButton.``type`` <- "button"
        deleteBlockButton.innerHTML <- "Delete Block and all connections"
        blockConfigure.appendChild deleteBlockButton |> ignore

        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore        

        let addBlockButtonGroup = document.createElement_div ()
        addBlockButtonGroup.id <- title + "-addBlockButtons"
        addBlockButtonGroup.className <- "add-block-button-group"

        let addBlockButtonHeading = document.createElement "h3"
        addBlockButtonHeading.innerHTML <- "Add Blocks"
        addBlockButtonGroup.appendChild addBlockButtonHeading |> ignore

        createButton (title + "-inputAddButton") "" "Input"
        |> addBlockButtonGroup.appendChild
        |> ignore

        createButton (title + "-outputAddButton") "" "Output"
        |> addBlockButtonGroup.appendChild
        |> ignore

        createButton (title + "-logicElementAddButton") "" "Logic Element"
        |> addBlockButtonGroup.appendChild
        |> ignore

        createButton (title + "-registerAddButton") "" "Register"
        |> addBlockButtonGroup.appendChild
        |> ignore

        createButton (title + "-clearSelectionButton") "" "Clear"
        |> addBlockButtonGroup.appendChild
        |> ignore        
        
        infoPane.appendChild blockConfigure |> ignore        

        let hr = document.createElement_hr ()
        infoPane.appendChild hr |> ignore

        infoPane.appendChild addBlockButtonGroup |> ignore

        infoPane

    root.appendChild workingPaneInit |> ignore
    root.appendChild infoPaneInit |> ignore  
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

    /// attach the event listener to the button that switches between different tabs
    fun e -> hideAndShowDiv namePrefix
    |> getElementBindEvent (namePrefix + "-tabButton") "click"

    canvasInit namePrefix

/// the "+" button to add new tabs
let newTabButtonInit () =    
    /// bind the action triggered when clicking the "+" button
    fun e -> createNewPaneWithButton ()
    |> getElementBindEvent "new-tab-button" "click" 

    /// create at least one pane when the application launches
    createNewPaneWithButton ()