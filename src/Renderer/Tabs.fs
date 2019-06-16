module Tabs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open Ref
open Helper
open Jointjs
open HTMLUtilities
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Node

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
                                          && text.[0] <> "container"
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
                                       if text.[0] = tabName 
                                          && text.[0] <> "tabRow" 
                                          && document.contains (lst.[index])
                                          && text.[0] <> "container"
                                       then //let rootContainer = document.getElementById "container"
                                            //rootContainer.removeChild (lst.Item index) |> ignore
                                            (lst.Item index).innerHTML <- ""
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
                                       if text.[0] <> tabName 
                                          && text.[0] <> "tabRow"
                                          && text.[0] <> "container"
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

    let infoPaneCloseButtonInit = 
        let button = document.createElement_button ()
        button.innerHTML <- ">"
        button.style.width <- "1%"
        button.style.position <- "absolute"
        button.style.left <- "77%"
        button.style.height <- "94%"
        button.style.borderStyle <- "none"
        button.style.background <- "grey"
        button.id <- title + "-resizeButton"        

        button

    let infoPaneInit =        
        let infoPane = document.createElement_div ()
        infoPane.id <- title + "-infoPane"
        infoPane.className <- "info-pane"
        infoPane.style.display <- "block"

        let blockConfigure = document.createElement_div ()
        blockConfigure.id <- title + "-blockConfigure"
        blockConfigure.className <- "block-configure"

        let blockConfigurationTitle = document.createElement "h3"
        blockConfigurationTitle.innerHTML <- "Block Configuration"
        blockConfigure.appendChild blockConfigurationTitle |> ignore

        let blockNameLabel = document.createElement_label ()
        blockNameLabel.innerHTML <- "Name:"
        blockConfigure.appendChild blockNameLabel |> ignore

        let inputElementName = document.createElement_input ()
        inputElementName.id <- title + "-blockName"
        inputElementName.``type`` <- "text"
        inputElementName.name <- ""
        inputElementName.value <- ""
        blockConfigure.appendChild inputElementName |> ignore

        let br = document.createElement_br ()
        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore

        let typeLabel = document.createElement "h5"
        typeLabel.innerHTML <- "Type: "
        blockConfigure.appendChild typeLabel |> ignore
        
        let typeInfoLabel = document.createElement "h5"
        typeInfoLabel.id <- title + "-blockTypeLabel"
        typeInfoLabel.innerHTML <- ""
        blockConfigure.appendChild typeInfoLabel |> ignore

        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore
        
        blockConfigure.appendChild br
        |> blockConfigure.appendChild
        |> ignore

        let locationLabel = document.createElement "h5"
        locationLabel.innerHTML <- "Location:"
        blockConfigure.appendChild locationLabel |> ignore

        let locationXLabel = document.createElement_label ()
        locationXLabel.innerHTML <- "X:"
        blockConfigure.appendChild locationXLabel |> ignore

        let locationXInputField = document.createElement_input ()
        locationXInputField.className <- "coordinate-field"
        locationXInputField.``type`` <- "int"
        locationXInputField.value <- ""
        locationXInputField.id <- title + "-positionX"
        blockConfigure.appendChild locationXInputField |> ignore

        let locationYLabel = document.createElement_label ()
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
        deleteBlockButton.innerHTML <- "Delete Block and connections"
        blockConfigure.appendChild deleteBlockButton |> ignore

        let resetZoomButton = document.createElement_button ()
        resetZoomButton.id <- title + "-resetZoomButton"
        resetZoomButton.``type`` <- "button"
        resetZoomButton.innerHTML <- "Zoom = 100%. Click to reset."
        blockConfigure.appendChild resetZoomButton |> ignore

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

        createButton (title + "-clearSelectionButton") "" "Clear"
        |> addBlockButtonGroup.appendChild
        |> ignore        
        
        infoPane.appendChild blockConfigure |> ignore        

        let hr = document.createElement_hr ()
        infoPane.appendChild hr |> ignore

        infoPane.appendChild addBlockButtonGroup |> ignore

        infoPane

    root.appendChild workingPaneInit |> ignore
    root.appendChild infoPaneCloseButtonInit |> ignore
    root.appendChild infoPaneInit |> ignore  
    root

/// create a new pane with button associated with the pane
let createNewPaneWithButton () = 
    /// create the prefix for naming any div elements
    let namePrefix = "pane" + string tabCounter + "div"
    
    /// create the button with the text
    /// that repesents the pane
    let newTab = document.createElement_button ()     
    newTab.innerHTML <- "new" + string tabCounter + ".json"
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
    let removeDivFunc = fun e -> match newTab.innerHTML with
                                 | a when a.[a.Length-1] = '*' -> let dialogOptions = createEmpty<ShowMessageBoxOptions>
                                                                  dialogOptions.title <- Some "Unsaved work"
                                                                  dialogOptions.message <- Some "You have unsaved work. Are you sure you want to quit?"

                                                                  let buttons = new ResizeArray<string>()
                                                                  buttons.Add "Cancel"
                                                                  buttons.Add "Ok"
                                                                  dialogOptions.buttons <- Some buttons
                                                                  let handlerCaster f = System.Func<float, unit> f

                                                                  let quitDialogCallback (res:float) = 
                                                                     match res with
                                                                     | a when a=1.0 ->  let graph = match currentGraphModel with
                                                                                                    | Some model -> model?set("graphCustomProperty", true)
                                                                                                                    JS.JSON.stringify (model?toJSON())                                                                        
                                                                                                    | option.None -> "no graph data"

                                                                                        let paper = match currentPaperModel with
                                                                                                    | Some model -> createObj[
                                                                                                                        "background" ==> model?options?background
                                                                                                                        "defaultRouter" ==> model?options?defaultRounter
                                                                                                                        "drawGrid" ==> model?options?drawGrid
                                                                                                                        "gridSize" ==> model?options?gridSize
                                                                                                                        "width" ==> model?options?width 
                                                                                                                        "height" ==> model?options?height 
                                                                                                                        "snapLinks" ==> model?options?snapLinks
                                                                                                                    ]
                                                                                                                    |> JS.JSON.stringify                                    
                                                                                                    | option.None -> "no paper data"
                                                                         
                                                                                        let content = 
                                                                                            createObj[
                                                                                                "graph" ==> graph
                                                                                                "paper" ==> paper
                                                                                            ]
                                                                                            |> JS.JSON.stringify
                                                                         
                                                                                        let saveDialogOptions = createEmpty<SaveDialogOptions>
                                                                                        saveDialogOptions.title <- Some "Save file to"
                                                                                        saveDialogOptions.defaultPath <- Some ("../new.json")                                         
                                                                                        saveDialogOptions.filters <- option.None                                                                                        

                                                                                        /// return the directory and the file name that is to be saved
                                                                                        let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)
                                                                         
                                                                                        match fileSaveDialog with
                                                                                        | a when checkUndefined a <> true -> a
                                                                                                                             |> getFileName
                                                                                                                             |> updateTabName
                                                                                                                             let errorHandler error = removeDiv namePrefix
                                                                                                                             fs.writeFile (fileSaveDialog, content, errorHandler)
                                                                                                                             removeDiv namePrefix
                                                                                        | _ -> ()                                                                            
                                                                                        
                                                                     | _ -> ()                                                                                                                                                                                                   

                                                                  let castedCallback = handlerCaster (fun a -> quitDialogCallback a)
                                                                  
                                                                  electron.remote.dialog.showMessageBox (dialogOptions, castedCallback)|> ignore
                                 | _ -> removeDiv namePrefix
    newTabCloseButton.addEventListener("click", U2.Case1 removeDivFunc, false)  
    
    /// after closing the tab, remove the reference to the global mutabl variables
    currentGraphModel <- option.None
    currentPaperModel <- option.None    
    activeTabId <- option.None
    
    /// the div element that holds all the elements that are newly created
    let newDiv = blockDiagramEditorInit namePrefix

    /// hide all other divs
    hideAndShowDiv namePrefix    
    
    let rootContainer = document.getElementById "container"
    rootContainer.appendChild newDiv |> ignore

    /// bind the function to the show or diaplay button that hides or shows the information pane
    fun e -> let infoPaneDisplayStatus = (document.getElementById (namePrefix + "-infoPane")).style.width = "0%"                                         
             match infoPaneDisplayStatus with
             | true -> (document.getElementById (namePrefix + "-infoPane")).style.width <- "21%"
                       (document.getElementById (namePrefix + "-infoPane")).style.left <- "78%"
                       (document.getElementById (namePrefix + "-resizeButton")).style.left <- "77%"
                       (document.getElementById (namePrefix + "-resizeButton")).innerHTML <- ">"
                       (document.getElementById (namePrefix + "-workingPane")).style.width <- "77%"
             | false -> (document.getElementById (namePrefix + "-infoPane")).style.width <- "0%"
                        (document.getElementById (namePrefix + "-infoPane")).style.left <- "99%"
                        (document.getElementById (namePrefix + "-resizeButton")).style.left <- "98%"
                        (document.getElementById (namePrefix + "-resizeButton")).innerHTML <- "<"
                        (document.getElementById (namePrefix + "-workingPane")).style.width <- "98%"
    |> getElementBindEvent (namePrefix + "-resizeButton") "click"    


    /// increase the pane counter when creating new panes
    tabCounter <- tabCounter + 1

    /// insert the div that contains the two buttons in the tab row
    tabRow.insertBefore (newTabDiv, (document.getElementById "new-tab-button")) |> ignore

    /// attach the event listener to the button that switches between different tabs
    fun e -> hideAndShowDiv namePrefix
    |> getElementBindEvent (namePrefix + "-tabButton") "click"

    canvasInit namePrefix

    activeTabId <- Some namePrefix

    /// highlight the button
    highlightTab namePrefix

    electron.ipcRenderer.send("change-channel", namePrefix)

/// the "+" button to add new tabs
let newTabButtonInit () =    
    /// bind the action triggered when clicking the "+" button
    fun e -> createNewPaneWithButton ()
    |> getElementBindEvent "new-tab-button" "click" 

    /// create at least one pane when the application launches
    createNewPaneWithButton ()
    