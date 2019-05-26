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
    describe "Non-GUI tests" <| fun () ->
        it "asserts 1 is 1" <| fun () ->
            assertEqual 1 1

run ()