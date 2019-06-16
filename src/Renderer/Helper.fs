module Helper

open Fable.Core
open Fable.Import.Node
open Ref
open Fable.Import.Browser

/// check whether something is "undefined"
[<Emit("typeof $0 == \"undefined\"")>]
let checkUndefined target : bool = jsNative

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
