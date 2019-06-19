module Helper

open Ref
open Fable.Import
open Fable.Import.Node
open Fable.Import.Browser
open Fable.Core
open Fable.Import.Electron

/// check whether something is "undefined"
[<Emit("typeof $0 == \"undefined\"")>]
let checkUndefined target : bool = jsNative


/// check whether something is "null"
[<Emit("$0 == null")>]
let checkNull target : bool = jsNative


/// get the file name from the complete path that includes the file
let getFileName (completePath:string) = 
    match os.platform () with
    | a when a = Base.NodeJS.Platform.Win32 -> let splitString = completePath.Split '\\'
                                               let len = splitString |> Array.length
                                               splitString.[len-1]
    | b when b = Base.NodeJS.Platform.Darwin -> let splitString = completePath.Split '/'
                                                let len = splitString |> Array.length
                                                splitString.[len-1]
    | c when c = Base.NodeJS.Platform.Linux  -> let splitString = completePath.Split '/'
                                                let len = splitString |> Array.length
                                                splitString.[len-1]
    | _ -> failwithf "other platforms are currently not supported"


/// update the tab name
let updateTabName (name:string) = 
    match activeTabId with
        | Some id -> (document.getElementById (id + "-tabButton")).innerHTML <- name
        | option.None -> ()


/// function for saving files with dialog windows
let saveFileWithDialogWindow (defaultPath:string) (content:obj) callbackHandler =    
    let saveDialogOptions = Fable.Core.JsInterop.createEmpty<SaveDialogOptions>
    saveDialogOptions.title <- Some "Save file to"
    saveDialogOptions.defaultPath <- Some defaultPath
    saveDialogOptions.filters <- option.None

    /// return the directory and the file name that is to be saved
    let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)                       
   
    match fileSaveDialog with
    | a when checkUndefined a <> true -> fs.writeFile (fileSaveDialog, JS.JSON.stringify content, callbackHandler)                                         
    | _ -> () 


/// function for saving files directly without dialog windows
let saveFileWithoutDialogWindow (path:string) (content:obj) callbackHandler = 
    fs.writeFile (path, content, callbackHandler)
