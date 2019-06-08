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

/// get the HTML element
/// set the innterHTML
let getElementSetInnerHTML (id:string) (innerHTML:string) = 
    (document.getElementById id).innerHTML <- innerHTML