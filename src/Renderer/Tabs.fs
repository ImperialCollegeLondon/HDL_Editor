module Tabs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open JSLibInterface
open HTMLUtilities
open System.Collections.Generic

/// tab number counter
let mutable tabCounter = 0

/// possible modes to toggle tabs
type TabOperations = 
    | Close
    | Switch
    | OpenNew

/// function to update the tab row
let updateTabRow (mode:TabOperations) (tabName:string) = 
    match mode with
    | Close -> console.log(tabName, "close")
    | Switch -> console.log(tabName, "switch")               
    | OpenNew -> let newTab = document.createElement_button ()     
                 newTab.innerHTML <- "pane" + string tabCounter 
                 newTab.className <- "tab-element"
                 newTab.id <- "pane" + string tabCounter                 

                 let newTabCloseButton = document.createElement_button ()
                 newTabCloseButton.innerHTML <- "x"
                 newTabCloseButton.className <- "tab-close-element"
                 newTabCloseButton.id <- "pane" + string tabCounter + "-close-button"

                 tabCounter <- tabCounter + 1

                 let newTabDiv = document.createElement_div ()
                 newTabDiv.id <- "pane" + string tabCounter + "-div"

                 newTabDiv.appendChild newTab |> ignore
                 newTabDiv.appendChild newTabCloseButton |> ignore
                 
                 let tabRow = document.getElementById "tab-row"

                 let removeDiv = fun e -> tabRow.removeChild newTabDiv |> ignore
                 newTabCloseButton.addEventListener("click", U2.Case1 removeDiv, false)

                 tabRow.insertBefore (newTabDiv, (document.getElementById "new-tab-button"))
                 |> ignore                 

/// the "+" button to add new tabs
let newTabButtonInit () =     
    fun e -> updateTabRow OpenNew "New tab"
    |> getElementBindEvent "new-tab-button" "click" 