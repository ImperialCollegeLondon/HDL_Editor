module MonacoEditor

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Browser
open Node.Exports
open System

[<Import("*", from="../../node_modules/monaco-editor")>]
let monaco : obj = jsNative

[<Import("*", from="../../node_modules/monaco-editor/min/vs/loader.js")>]
let monacoEditorLoader : obj = jsNative

//[<Emit("")>]
let monacoEditorRequire = monacoEditorLoader?require

//let monacoEditorDefine : obj = monacoEditorLoader?require?define

[<Emit("undefined")>]
let jsUndefined : obj = jsNative

let monacoEditorInit () = 
    monacoEditorRequire?config(
        createObj [
            "baseUrl" ==> "../../node_modules/monaco-editor/min"
        ]) |> ignore

    self?``module`` <- jsUndefined

    let monacoInnterFunction () = 
        let config = 
            createObj [
                "value" ==> [ "Hello world"]
                "language" ==> "javascript"
            ]
        let editor = monaco?editor?create(document.getElementById("monaco"), config)
        editor
    monacoEditorRequire(["vs/editor/editor.main"], monacoInnterFunction())