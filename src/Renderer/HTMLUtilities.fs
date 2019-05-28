module HTMLUtilities

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Electron
open Node.Exports

/// HTML helper function
let replaceChildren (root: Browser.HTMLElement) children =
    while not (isNull root.firstChild) do
        root.removeChild(root.firstChild)
        |> ignore

    for child in children do
        root.appendChild(child)
        |> ignore

let createIcon faIcon =
    let root = Browser.document.createElement_span()
    let icon = Browser.document.createElement_i()

    root.className <- "icon"
    icon.className <- "fa " + faIcon
    root.appendChild(icon) |> ignore
    root

let createLink filename =
    let root = Browser.document.createElement_a()
    root.href <- "#"
    root.innerText <- filename
    root

let getElementWithID (id:string) = Browser.document.getElementById(id)

type CreateElementType = 
    | Paragraph
    | Button

type OutputElementType = 
    | Paragraph' of el:Browser.HTMLParagraphElement
    | Button' of el:Browser.HTMLButtonElement

let createElementUsingIdWithContent (id:string) (content:string) (elementType:CreateElementType) = 
    match elementType with
    | Paragraph -> let el = Browser.document.createElement_p()
                   el.id <- id
                   el.innerText <- content
                   Paragraph'(el = el)
    | Button -> let el = Browser.document.createElement_button()
                el.id <- id
                el.innerText <- content
                Button'(el = el)

(*
function openCity(evt, cityName) {
      // Declare all variables
      var i, tabcontent, tablinks;

      // Get all elements with class="tabcontent" and hide them
      tabcontent = document.getElementsByClassName("tabcontent");
      for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
      }

      // Get all elements with class="tablinks" and remove the class "active"
      tablinks = document.getElementsByClassName("tablinks");
      for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
      }

      // Show the current tab, and add an "active" class to the button that opened the tab
      document.getElementById(cityName).style.display = "block";
      evt.currentTarget.className += " active";
    }  
*)

(*
let openTab evt tabName = 
    let tabContent = document.getElementsByClassName("tabcontent")

    let updateTabContent (lst : NodeListOf<Element>) : NodeListOf<Element> = 
        

    let tabLinks = document.getElementsByClassName("tablinks")
                   |> List.map (fun el -> el.className = el.className.replace(" active", ""))

    let currentTab = document.getElementById(tabName)

    currentTab.style.display = "block"
*)
            

