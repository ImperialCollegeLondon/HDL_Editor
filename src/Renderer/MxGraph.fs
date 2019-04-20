// ts2fable 0.0.0
module rec MxGraph
open System
open Fable.Core
open Fable.Import.JS

let [<Import("*","mxgraph")>] mxgraph: Mxgraph.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract mxgraph: opts: obj option * [<ParamArray>] args: ResizeArray<obj option> -> obj option

module Mxgraph =

    type [<AllowNullLiteral>] IExports =
        abstract prototype: TypeLiteral_01

    type [<AllowNullLiteral>] TypeLiteral_01 =
        interface end
