module Tabs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open HTMLUtilities
open System.Collections.Generic

/// tab number counter
let mutable tabCounter = 0

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