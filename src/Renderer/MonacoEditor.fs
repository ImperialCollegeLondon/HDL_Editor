module MonacoEditor

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Browser
open Node.Exports
open System

let monaco : obj = importAll "../../node_modules/monaco-editor/esm/vs/editor/editor.main"

[<Emit("monaco.editor.create($0, $1)")>]
let create el para = jsNative

let monacoEditorInit () = 
    let para = 
        createObj [
            "value" ==> "console.log(\"hello\")"
            "language" ==> "javascript"
        ]

    let el = document.getElementById("monaco")
    let inst = create el para
    inst