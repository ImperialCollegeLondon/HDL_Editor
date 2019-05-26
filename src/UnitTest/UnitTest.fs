module UnitTest

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Electron
open Fable.Import.Mocha
open System
open Fable.Import
open Fable.Core.Testing

let [<Global>] describe (name: string) (f: unit -> unit) = jsNative
let [<Global>] it (msg: string) (f: unit -> unit) = jsNative

let assertEqual expected actual: unit =
    Assert.AreEqual(actual, expected)

let run () =
    describe "tests" <| fun () ->
        it "asserts 1 is 1" <| fun () ->
            assertEqual 1 1

run ()

(*
let spectron : obj = importAll "spectron"
let application : obj = spectron?application

let electronPath : obj = importAll "electron"

[<Emit("new Application($0)")>]
let newApplication appConfig = jsNative

let app : obj = 
    let mainScriptPath = Node.Exports.path.join(Node.Globals.__dirname, "../app/js/main.js")
    let appConfig =
        createObj [
            "path" ==> electronPath
            "args" ==> [mainScriptPath]
        ]
    newApplication appConfig

let useAssert : obj = importAll "assert"


[<Emit("beforeEach($0")>]
let beforeEach beforeEachFunction = jsNative

[<Emit("afterEach($0)")>]
let afterEach afterEachFunction = jsNative

let mochaJunitReporter :obj = importAll "mocha-junit-reporter"

let mochaSettings = createEmpty<MochaSetupOptions>
mochaSettings.timeout <- Some 100000.
mochaSettings.reporter <- Some mochaJunitReporter
mochaSettings.bail <- Some false

let mochaTester = createEmpty<Mocha>
mochaTester.setup mochaSettings |> ignore

let describe (unitTestDescription:string) (unitTestFunction:unit->unit) = 
    let unitTestDescribe = createEmpty<IContextDefinition>
    let describeOutcome = unitTestDescribe.Invoke (unitTestDescription, unitTestFunction)
    describeOutcome

let beforeEachFunctionDefination () = 
    app?start()

let afterEachFunctionDefination () =
    if app?isRunning()
        then app?stop()

//let itDefinition (itDescriptionText:string) 
*)




