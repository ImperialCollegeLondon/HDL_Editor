module blockConfigureWindow

open Fable.Core.JsInterop
open Fable.Import.Browser
open Fable.Import
open Fable.Import.Electron
open Fable.Import.Node
open HTMLUtilities
open Ref
open Helper


/// bind the event listener to to the user input field to update the GUI
let bindEventUpdateGUI () =                                  
    let lst = document.getElementsByTagName_input ()
    
    fun e -> findElementSetValue "block-input-number" lst InputNumber
             updatePortConfiguration InputNumber inputNumber
    |> getElementBindEvent "block-input-number" "input"     
    
    fun e -> findElementSetValue "block-output-number" lst OutputNumber
             updatePortConfiguration OutputNumber outputNumber    
    |> getElementBindEvent "block-output-number" "input"
    
    fun e -> findElementSetValue "block-name-field" lst BlockName  
    |> getElementBindEvent "block-name-field" "input"

    fun e -> let div = document.getElementById "truth-table"
             div.innerHTML <- ""
             updateTruthTableDisplay ()
    |> getElementBindEvent "update-truth-table" "click"

    fun e -> let div = document.getElementById "icon-generate"
             div.innerHTML <- ""
             createIcon ()
    |> getElementBindEvent "generate-button" "click"

    fun e -> let window = electron.remote.getCurrentWindow ()
             window.close ()
    |> getElementBindEvent "cancel-button" "click"

    fun e -> let inputIds = (document.getElementById "input-settings").getElementsByTagName_div () 
                            |> extractNames 
                            |> List.toArray 
             let outputIds = (document.getElementById "output-settings").getElementsByTagName_div ()
                             |> extractNames
                             |> List.toArray
                                 
             let truthTable = 
                let container = document.getElementsByTagName_input ()
                                    
                let getOneRow (rowNumber:int) =                                         
                    [0..outputIds.Length - 1]
                    |> List.map (fun i -> let id = outputIds.[i] + "div" + (rowNumber |> string)
                                          getValueFromInputs id container)                                        
                    |> List.toArray
                    |> String.concat ""
                
                let inputCounts = int (2.** float inputIds.Length)
                let outputConfigs = 
                   [0..inputCounts]
                   |> List.map (fun i -> getOneRow i)
                                         
                [0..inputCounts-1]
                |> List.map (fun i -> outputConfigs.[i])
                |> List.toArray                                 
                                 
             let contentGenerator () = 
                let mutable content = "module"

                let moduleName =
                    match blockName with
                    | Some name -> name
                    | option.None -> "MyModule"

                content <- content + " " + moduleName + "("                                                                       

                let outputNames = outputIds |> String.concat ", "

                content <- content + outputNames + ", "

                let inputNames = inputIds |> String.concat ", "
                                    
                content <- content + inputNames + ", clock); \n"
                content <- content + "  " + "input " + inputNames + ", clock; \n"
                content <- content + "  " + "output " + outputNames + "; \n"
                                    
                let rec outputReg (index:int) (res:string) (lst:string array)= 
                    match index with
                    | a when a < lst.Length -> outputReg (index+1) (res + "  reg " + outputIds.[a] + " = 1b'0; \n") lst
                    | _ -> res

                content <- outputReg 0 content outputIds
                content <- content + "\n  always @ (posedge clock)\n"
                content <- content + "  begin\n"
                content <- content + "    case({" + inputNames + "})\n"

                let rec caseStatementInnerBeginEnd (row:int) (outputCount:int) (outputs:string array) (truthTable:string array) (res:string) =                    
                    match outputCount with
                    | a when a < outputs.Length -> caseStatementInnerBeginEnd row (outputCount+1) outputs truthTable (res + outputs.[a] + " <= " + "1'b" + string truthTable.[row].[a] + ";\n      ")
                    | _ -> res

                let rec lookupTableHorizontalLine (index:int) (truthTable:string array) (inputWidth:int) (res:string) = 
                    match index with
                    | a when a < truthTable.Length -> let lookupIn = "    " + (string inputWidth) + "'b" + (intToBinaryConverter a inputWidth) + ":\n"
                                                      let beginStatement = "      begin\n"
                                                      let innerStatements = caseStatementInnerBeginEnd a 0 outputIds truthTable "      "                                                      
                                                      let endStatement = "end\n"
                                                      lookupTableHorizontalLine (index+1) truthTable inputWidth (res + lookupIn + beginStatement + innerStatements + endStatement)

                    | _ -> res
                                            
                let defaultCaseTruthTable = 
                    let stringRes = [0..outputIds.Length-1]
                                    |> List.map (fun el -> "0")
                                    |> String.concat ""
                    [|stringRes|]

                content <- lookupTableHorizontalLine 0 truthTable inputIds.Length content
                content <- content + "    default: \n      begin\n" + caseStatementInnerBeginEnd 0 0 outputIds defaultCaseTruthTable "      " + "end\n"
                content <- content + "    endcase\n"
                content <- content + "  end"
                content <- content + "\n" + "endmodule\n\n"
                content                                                                  

             let saveDialogOptions = createEmpty<SaveDialogOptions>
             saveDialogOptions.title <- Some "Save file to"
             saveDialogOptions.defaultPath <- Some ("../new.json")                                         
             saveDialogOptions.filters <- option.None

             /// return the directory and the file name that is to be saved
             let fileSaveDialog = electron.remote.dialog.showSaveDialog (saveDialogOptions)
                                 
             let contents = 
                 createObj[
                    "name" ==> blockName
                    "inputs" ==> inputIds
                    "outputs" ==> outputIds
                    "truthTable" ==> truthTable
                    "Verilog" ==> fileSaveDialog + ".v"
                 ]
                
             match fileSaveDialog with
             | a when checkUndefined a <> true -> let errorHandler error =                                                     
                                                    electron.ipcRenderer.send("new-block-information", 
                                                        (blockName, inputIds.Length, outputIds.Length, inputIds, outputIds, truthTable, contentGenerator ()))
                                                    let errorHandlerClosingWindow error =                                                                           
                                                        let window = electron.remote.getCurrentWindow ()
                                                        window.close ()
                                                    fs.writeFile (fileSaveDialog + ".v", contentGenerator (), errorHandlerClosingWindow)
                                                  fs.writeFile (fileSaveDialog, JS.JSON.stringify contents, errorHandler)                                                  
             | _ -> ()                               
    |> getElementBindEvent "ok-button" "click"        
   
bindEventUpdateGUI ()
