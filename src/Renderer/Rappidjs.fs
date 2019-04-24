// ts2fable 0.0.0
module rec Rappidjs
open System
open Fable.Core
open Fable.Import.JS
open Backbone

module Joint = Jointjs
let [<Import("ui","rappid")>] ui: Ui.IExports = jsNative

module Ui =

    type [<AllowNullLiteral>] IExports =
        abstract SelectionView: SelectionViewStatic

    type [<AllowNullLiteral>] Handle =
        abstract name: string with get, set
        abstract position: string with get, set
        abstract icon: string with get, set

    type [<AllowNullLiteral>] SelectionView =
        inherit Backbone.Model
        abstract paper: Joint.Dia.Paper with get, set
        abstract graph: Joint.Dia.Graph with get, set
        abstract model: Backbone.Collection<Joint.Dia.Cell> with get, set
        abstract createSelectionBox: cellView: Joint.Dia.CellView -> unit
        abstract destroySelectionBox: cellView: Joint.Dia.CellView -> unit
        abstract startSelecting: evt: obj option -> unit
        abstract cancelSelection: unit -> unit
        abstract addHandle: handle: Handle -> unit
        abstract removeHandle: name: string -> unit
        abstract changeHandle: name: string * handle: Handle -> unit

    type [<AllowNullLiteral>] SelectionViewStatic =
        [<Emit "new $0($1...)">] abstract Create: opt: SelectionViewStaticOpt -> SelectionView

    type [<AllowNullLiteral>] SelectionViewStaticOpt =
        abstract paper: Joint.Dia.Paper with get, set
        abstract graph: Joint.Dia.Graph with get, set
        abstract model: Backbone.Collection<Joint.Dia.Cell> with get, set
