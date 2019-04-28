module HTMLUtilities

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Electron
open Node.Exports

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
    