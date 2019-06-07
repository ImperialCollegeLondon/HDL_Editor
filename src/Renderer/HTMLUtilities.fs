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
let getValueFromElement (elType:HTMLElementType) (itemIndex:int) =
    match elType with
    | InputBox -> (((document.getElementsByTagName_input) ()).Item itemIndex).value

/// get the HTML element
let setHTMLElementValue (elType:HTMLElementType) (itemIndex:int) (value:string) = 
    match elType with
    | InputBox -> (((document.getElementsByTagName_input) ()).Item itemIndex).value <- value

/// get the HTML element
/// set the innterHTML
let getElementSetInnerHTML (id:string) (innerHTML:string) = 
    (document.getElementById id).innerHTML <- innerHTML