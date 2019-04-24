// ts2fable 0.0.0
module rec Jointjs
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser
open Geometry
open Vectorizer

let [<Import("anchors","jointjs")>] anchors: Anchors.IExports = jsNative
let [<Import("connectionPoints","jointjs")>] connectionPoints: ConnectionPoints.IExports = jsNative
let [<Import("connectionStrategies","jointjs")>] connectionStrategies: ConnectionStrategies.IExports = jsNative
let [<Import("connectors","jointjs")>] connectors: Connectors.IExports = jsNative
let [<Import("dia","jointjs")>] dia: Dia.IExports = jsNative
let [<Import("env","jointjs")>] env: Env.IExports = jsNative
let [<Import("highlighters","jointjs")>] highlighters: Highlighters.IExports = jsNative
let [<Import("linkTools","jointjs")>] linkTools: LinkTools.IExports = jsNative
let [<Import("mvc","jointjs")>] mvc: Mvc.IExports = jsNative
let [<Import("routers","jointjs")>] routers: Routers.IExports = jsNative
let [<Import("util","jointjs")>] util: Util.IExports = jsNative

type [<AllowNullLiteral>] IExports =
    abstract setTheme: theme: string -> unit

module Dia =
    let [<Import("Cell","jointjs/dia")>] cell: Cell.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract Graph: GraphStatic
        abstract Cell: CellStatic
        abstract Element: ElementStatic
        abstract Link: LinkStatic
        abstract CellViewGeneric: CellViewGenericStatic
        abstract CellView: CellViewStatic
        abstract ElementView: ElementViewStatic
        abstract LinkView: LinkViewStatic
        abstract Paper: PaperStatic
        abstract ToolsView: ToolsViewStatic
        abstract ToolView: ToolViewStatic

    type Point =
        G.PlainPoint

    type BBox =
        G.PlainRect

    type Size =
        obj

    type [<AllowNullLiteral>] PaddingJSON =
        abstract left: float option with get, set
        abstract top: float option with get, set
        abstract right: float option with get, set
        abstract bottom: float option with get, set

    type Padding =
        U2<float, PaddingJSON>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Padding =
        let ofFloat v: Padding = v |> U2.Case1
        let isFloat (v: Padding) = match v with U2.Case1 _ -> true | _ -> false
        let asFloat (v: Padding) = match v with U2.Case1 o -> Some o | _ -> None
        let ofPaddingJSON v: Padding = v |> U2.Case2
        let isPaddingJSON (v: Padding) = match v with U2.Case2 _ -> true | _ -> false
        let asPaddingJSON (v: Padding) = match v with U2.Case2 o -> Some o | _ -> None

    type [<AllowNullLiteral>] SidesJSON =
        abstract left: float option with get, set
        abstract top: float option with get, set
        abstract right: float option with get, set
        abstract bottom: float option with get, set
        abstract horizontal: float option with get, set
        abstract vertical: float option with get, set

    type Sides =
        U2<float, SidesJSON>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Sides =
        let ofFloat v: Sides = v |> U2.Case1
        let isFloat (v: Sides) = match v with U2.Case1 _ -> true | _ -> false
        let asFloat (v: Sides) = match v with U2.Case1 o -> Some o | _ -> None
        let ofSidesJSON v: Sides = v |> U2.Case2
        let isSidesJSON (v: Sides) = match v with U2.Case2 _ -> true | _ -> false
        let asSidesJSON (v: Sides) = match v with U2.Case2 o -> Some o | _ -> None

    type [<StringEnum>] [<RequireQualifiedAccess>] OrthogonalDirection =
        | Left
        | Top
        | Right
        | Bottom

    type Direction =
        U5<OrthogonalDirection, string, string, string, string>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Direction =
        let ofOrthogonalDirection v: Direction = v |> U5.Case1
        let isOrthogonalDirection (v: Direction) = match v with U5.Case1 _ -> true | _ -> false
        let asOrthogonalDirection (v: Direction) = match v with U5.Case1 o -> Some o | _ -> None
        let ofCase2 v: Direction = v |> U5.Case2
        let isCase2 (v: Direction) = match v with U5.Case2 _ -> true | _ -> false
        let asCase2 (v: Direction) = match v with U5.Case2 o -> Some o | _ -> None
        let ofCase3 v: Direction = v |> U5.Case3
        let isCase3 (v: Direction) = match v with U5.Case3 _ -> true | _ -> false
        let asCase3 (v: Direction) = match v with U5.Case3 o -> Some o | _ -> None
        let ofCase4 v: Direction = v |> U5.Case4
        let isCase4 (v: Direction) = match v with U5.Case4 _ -> true | _ -> false
        let asCase4 (v: Direction) = match v with U5.Case4 o -> Some o | _ -> None
        let ofCase5 v: Direction = v |> U5.Case5
        let isCase5 (v: Direction) = match v with U5.Case5 _ -> true | _ -> false
        let asCase5 (v: Direction) = match v with U5.Case5 o -> Some o | _ -> None

    type [<StringEnum>] [<RequireQualifiedAccess>] LinkEnd =
        | Source
        | Target

    type [<AllowNullLiteral>] MarkupNodeJSON =
        abstract tagName: string with get, set
        abstract selector: string option with get, set
        abstract groupSelector: string option with get, set
        abstract namespaceUri: string option with get, set
        abstract className: string option with get, set
        abstract attributes: Attributes.NativeSVGAttributes option with get, set
        abstract style: TypeLiteral_11 option with get, set
        abstract children: MarkupJSON option with get, set
        abstract textContent: string option with get, set

    type MarkupJSON =
        ResizeArray<MarkupNodeJSON>

    module Graph =

        type [<AllowNullLiteral>] Options =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] ConnectionOptions =
            inherit Cell.EmbeddableOptions
            abstract inbound: bool option with get, set
            abstract outbound: bool option with get, set

        type [<AllowNullLiteral>] ExploreOptions =
            inherit ConnectionOptions
            abstract breadthFirst: bool option with get, set

    type [<AllowNullLiteral>] Graph =
        inherit Backbone.Model
        abstract addCell: cell: U2<Cell, ResizeArray<Cell>> * ?opt: GraphAddCellOpt -> Graph
        abstract addCells: cells: ResizeArray<Cell> * ?opt: GraphAddCellsOpt -> Graph
        abstract resetCells: cells: ResizeArray<Cell> * ?opt: GraphResetCellsOpt -> Graph
        abstract getCell: id: U3<string, float, Cell> -> Cell
        abstract getElements: unit -> ResizeArray<Element>
        abstract getLinks: unit -> ResizeArray<Link>
        abstract getCells: unit -> ResizeArray<Cell>
        abstract getFirstCell: unit -> Cell option
        abstract getLastCell: unit -> Cell option
        abstract getConnectedLinks: cell: Cell * ?opt: Graph.ConnectionOptions -> ResizeArray<Link>
        abstract disconnectLinks: cell: Cell * ?opt: GraphDisconnectLinksOpt -> unit
        abstract removeLinks: cell: Cell * ?opt: GraphRemoveLinksOpt -> unit
        abstract translate: tx: float * ?ty: float * ?opt: Element.TranslateOptions -> Graph
        abstract cloneCells: cells: ResizeArray<Cell> -> GraphCloneCellsReturn
        abstract getSubgraph: cells: ResizeArray<Cell> * ?opt: Cell.EmbeddableOptions -> ResizeArray<Cell>
        abstract cloneSubgraph: cells: ResizeArray<Cell> * ?opt: Cell.EmbeddableOptions -> GraphCloneSubgraphReturn
        abstract dfs: element: Element * iteratee: (Element -> float -> bool) * ?opt: Graph.ConnectionOptions -> unit
        abstract bfs: element: Element * iteratee: (Element -> float -> bool) * ?opt: Graph.ConnectionOptions -> unit
        abstract search: element: Element * iteratee: (Element -> float -> bool) * ?opt: Graph.ExploreOptions -> unit
        abstract getSuccessors: element: Element * ?opt: Graph.ExploreOptions -> ResizeArray<Element>
        abstract getPredecessors: element: Element * ?opt: Graph.ExploreOptions -> ResizeArray<Element>
        abstract isSuccessor: elementA: Element * elementB: Element -> bool
        abstract isPredecessor: elementA: Element * elementB: Element -> bool
        abstract isSource: element: Element -> bool
        abstract isSink: element: Element -> bool
        abstract getSources: unit -> ResizeArray<Element>
        abstract getSinks: unit -> ResizeArray<Element>
        abstract getNeighbors: element: Element * ?opt: Graph.ConnectionOptions -> ResizeArray<Element>
        abstract isNeighbor: elementA: Element * elementB: Element * ?opt: Graph.ConnectionOptions -> bool
        abstract getCommonAncestor: [<ParamArray>] cells: ResizeArray<Cell> -> Element option
        abstract toJSON: unit -> obj option
        abstract fromJSON: json: obj option * ?opt: GraphFromJSONOpt -> Graph
        abstract clear: ?opt: GraphClearOpt -> Graph
        abstract findModelsFromPoint: p: Point -> ResizeArray<Element>
        abstract findModelsInArea: rect: BBox * ?opt: GraphFindModelsInAreaOpt -> ResizeArray<Element>
        abstract findModelsUnderElement: element: Element * ?opt: GraphFindModelsUnderElementOpt -> ResizeArray<Element>
        abstract getBBox: ?cells: ResizeArray<Cell> * ?opt: Cell.EmbeddableOptions -> G.Rect option
        abstract getCellsBBox: cells: ResizeArray<Cell> * ?opt: Cell.EmbeddableOptions -> G.Rect option
        abstract hasActiveBatch: ?name: U2<string, ResizeArray<string>> -> bool
        abstract maxZIndex: unit -> float
        abstract minZIndex: unit -> float
        abstract removeCells: cells: ResizeArray<Cell> * ?opt: Cell.DisconnectableOptions -> Graph
        abstract resize: width: float * height: float * ?opt: GraphResizeOpt -> Graph
        abstract resizeCells: width: float * height: float * cells: ResizeArray<Cell> * ?opt: GraphResizeCellsOpt -> Graph
        abstract startBatch: name: string * ?data: GraphStartBatchData -> Graph
        abstract stopBatch: name: string * ?data: GraphStopBatchData -> Graph
        abstract toGraphLib: ?opt: GraphToGraphLibOpt -> obj option
        abstract fromGraphLib: glGraph: obj option * ?opt: GraphFromGraphLibOpt -> Graph

    type [<AllowNullLiteral>] GraphAddCellOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphAddCellsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphResetCellsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphDisconnectLinksOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphRemoveLinksOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphCloneCellsReturn =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: id: string -> Cell with get, set

    type [<AllowNullLiteral>] GraphCloneSubgraphReturn =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: id: string -> Cell with get, set

    type [<AllowNullLiteral>] GraphFromJSONOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphClearOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphFindModelsInAreaOpt =
        abstract strict: bool option with get, set

    type [<AllowNullLiteral>] GraphFindModelsUnderElementOpt =
        abstract searchBy: obj option with get, set

    type [<AllowNullLiteral>] GraphResizeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphResizeCellsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphStartBatchData =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphStopBatchData =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphToGraphLibOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphFromGraphLibOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GraphStatic =
        [<Emit "new $0($1...)">] abstract Create: ?attributes: obj * ?opt: GraphStaticOpt -> Graph

    type [<AllowNullLiteral>] GraphStaticOpt =
        abstract cellNamespace: obj option with get, set
        abstract cellModel: obj option with get, set

    module Cell =

        type [<AllowNullLiteral>] IExports =
            abstract Constructor: ConstructorStatic

        type [<AllowNullLiteral>] GenericAttributes<'T> =
            abstract attrs: 'T option with get, set
            abstract z: float option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Selectors =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: selector: string -> Attributes.SVGAttributes option with get, set

        type [<AllowNullLiteral>] Attributes =
            inherit GenericAttributes<Selectors>
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Constructor<'T> =
            interface end

        type [<AllowNullLiteral>] ConstructorStatic =
            [<Emit "new $0($1...)">] abstract Create: ?opt: ConstructorStaticOpt -> Constructor<'T>

        type [<AllowNullLiteral>] ConstructorStaticOpt =
            abstract id: string with get, set

        type [<AllowNullLiteral>] Options =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] EmbeddableOptions =
            inherit Options
            abstract deep: bool option with get, set

        type [<AllowNullLiteral>] DisconnectableOptions =
            abstract disconnectLinks: bool option with get, set

        type [<AllowNullLiteral>] TransitionOptions =
            inherit Options
            abstract delay: float option with get, set
            abstract duration: float option with get, set
            abstract timingFunction: Util.Timing.TimingFunction option with get, set
            abstract valueFunction: Util.Interpolate.InterpolateFunction<obj option> option with get, set

    type [<AllowNullLiteral>] Cell =
        inherit Backbone.Model
        abstract id: U2<string, float> with get, set
        abstract graph: Graph with get, set
        abstract toJSON: unit -> obj option
        abstract remove: ?opt: Cell.DisconnectableOptions -> Cell
        abstract toFront: ?opt: Cell.EmbeddableOptions -> Cell
        abstract toBack: ?opt: Cell.EmbeddableOptions -> Cell
        abstract parent: unit -> string
        abstract parent: parentId: string -> Cell
        abstract getParentCell: unit -> Cell option
        abstract getAncestors: unit -> ResizeArray<Cell>
        abstract getEmbeddedCells: ?opt: CellGetEmbeddedCellsOpt -> ResizeArray<Cell>
        abstract isEmbeddedIn: cell: Cell * ?opt: Cell.EmbeddableOptions -> bool
        abstract isEmbedded: unit -> bool
        abstract prop: key: U2<string, ResizeArray<string>> -> obj option
        abstract prop: ``object``: Cell.Attributes * ?opt: Cell.Options -> Cell
        abstract prop: key: U2<string, ResizeArray<string>> * value: obj option * ?opt: Cell.Options -> Cell
        abstract removeProp: path: U2<string, ResizeArray<string>> * ?opt: Cell.Options -> Cell
        abstract attr: ?key: string -> obj option
        abstract attr: ``object``: Cell.Selectors * ?opt: Cell.Options -> Cell
        abstract attr: key: string * value: obj option * ?opt: Cell.Options -> Cell
        abstract clone: unit -> Cell
        abstract clone: opt: Cell.EmbeddableOptions -> U2<Cell, ResizeArray<Cell>>
        abstract removeAttr: path: U2<string, ResizeArray<string>> * ?opt: Cell.Options -> Cell
        abstract transition: path: string * ?value: obj * ?opt: Cell.TransitionOptions * ?delim: string -> float
        abstract getTransitions: unit -> ResizeArray<string>
        abstract stopTransitions: ?path: string * ?delim: string -> Cell
        abstract embed: cell: Cell * ?opt: Graph.Options -> Cell
        abstract unembed: cell: Cell * ?opt: Graph.Options -> Cell
        abstract addTo: graph: Graph * ?opt: Graph.Options -> Cell
        abstract findView: paper: Paper -> CellView
        abstract isLink: unit -> bool
        abstract isElement: unit -> bool
        abstract startBatch: name: string * ?opt: Graph.Options -> Cell
        abstract stopBatch: name: string * ?opt: Graph.Options -> Cell
        abstract processPorts: unit -> unit

    type [<AllowNullLiteral>] CellGetEmbeddedCellsOpt =
        abstract deep: bool option with get, set
        abstract breadthFirst: bool option with get, set

    type [<AllowNullLiteral>] CellStatic =
        [<Emit "new $0($1...)">] abstract Create: ?attributes: Cell.Attributes * ?opt: Graph.Options -> Cell
        abstract define: ``type``: string * ?defaults: obj * ?protoProps: obj * ?staticProps: obj -> Cell.Constructor<Cell>

    module Element =

        type [<AllowNullLiteral>] GenericAttributes<'T> =
            inherit Cell.GenericAttributes<'T>
            abstract markup: U2<string, MarkupJSON> option with get, set
            abstract position: Point option with get, set
            abstract size: Size option with get, set
            abstract angle: float option with get, set
            abstract ports: TypeLiteral_02 option with get, set

        type [<AllowNullLiteral>] Attributes =
            inherit GenericAttributes<Cell.Selectors>
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type PositionType =
            U3<string, obj, obj>

        [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module PositionType =
            let ofString v: PositionType = v |> U3.Case1
            let isString (v: PositionType) = match v with U3.Case1 _ -> true | _ -> false
            let asString (v: PositionType) = match v with U3.Case1 o -> Some o | _ -> None
            let ofName v: PositionType = v |> U3.Case2
            let isName (v: PositionType) = match v with U3.Case2 _ -> true | _ -> false
            let asName (v: PositionType) = match v with U3.Case2 o -> Some o | _ -> None
            let ofArgs v: PositionType = v |> U3.Case3
            let isArgs (v: PositionType) = match v with U3.Case3 _ -> true | _ -> false
            let asArgs (v: PositionType) = match v with U3.Case3 o -> Some o | _ -> None

        type [<AllowNullLiteral>] PortGroup =
            abstract position: PositionType option with get, set
            abstract markup: string option with get, set
            abstract attrs: Cell.Selectors option with get, set
            abstract label: TypeLiteral_04 option with get, set

        type [<AllowNullLiteral>] Port =
            abstract id: string option with get, set
            abstract markup: string option with get, set
            abstract group: string option with get, set
            abstract attrs: Cell.Selectors option with get, set
            abstract args: TypeLiteral_03 option with get, set
            abstract label: TypeLiteral_04 option with get, set
            abstract z: U2<float, string> option with get, set

        type [<AllowNullLiteral>] PortPosition =
            inherit Point
            abstract angle: float with get, set

        type [<AllowNullLiteral>] TranslateOptions =
            abstract restrictedArea: BBox option with get, set
            abstract transition: Cell.TransitionOptions option with get, set

        type [<AllowNullLiteral>] TypeLiteral_02 =
            abstract groups: TypeLiteral_01 option with get, set
            abstract items: ResizeArray<Port> option with get, set

        type [<AllowNullLiteral>] TypeLiteral_04 =
            abstract markup: string option with get, set
            abstract position: PositionType option with get, set

        type [<AllowNullLiteral>] TypeLiteral_01 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> PortGroup with get, set

        type [<AllowNullLiteral>] TypeLiteral_03 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] Element =
        inherit Cell
        abstract isElement: unit -> bool
        abstract isLink: unit -> bool
        abstract translate: tx: float * ?ty: float * ?opt: Element.TranslateOptions -> Element
        abstract position: ?opt: ElementPositionOpt -> G.Point
        abstract position: x: float * y: float * ?opt: ElementPositionOpt_ -> Element
        abstract size: unit -> Size
        abstract size: width: float * ?height: float * ?opt: ElementSizeOpt -> Element
        abstract resize: width: float * height: float * ?opt: ElementResizeOpt -> Element
        abstract rotate: deg: float * ?absolute: bool * ?origin: Point * ?opt: ElementRotateOpt -> Element
        abstract angle: unit -> float
        abstract scale: scaleX: float * scaleY: float * ?origin: Point * ?opt: ElementScaleOpt -> Element
        abstract fitEmbeds: ?opt: ElementFitEmbedsOpt -> Element
        abstract getBBox: ?opt: Cell.EmbeddableOptions -> G.Rect
        abstract addPort: port: Element.Port * ?opt: Cell.Options -> Element
        abstract addPorts: ports: ResizeArray<Element.Port> * ?opt: Cell.Options -> Element
        abstract removePort: port: U2<string, Element.Port> * ?opt: Cell.Options -> Element
        abstract removePorts: ?opt: Cell.Options -> Element
        abstract removePorts: ports: Array<U2<Element.Port, string>> * ?opt: Cell.Options -> Element
        abstract hasPorts: unit -> bool
        abstract hasPort: id: string -> bool
        abstract getPorts: unit -> ResizeArray<Element.Port>
        abstract getPort: id: string -> Element.Port
        abstract getPortsPositions: groupName: string -> ElementGetPortsPositionsReturn
        abstract getPortIndex: port: U2<string, Element.Port> -> float
        abstract portProp: portId: string * path: obj option * ?value: obj * ?opt: Cell.Options -> Element

    type [<AllowNullLiteral>] ElementPositionOpt =
        abstract parentRelative: bool option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementPositionOpt_ =
        abstract parentRelative: bool option with get, set
        abstract deep: bool option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementSizeOpt =
        abstract direction: Direction option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementResizeOpt =
        abstract direction: Direction option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementRotateOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementScaleOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementFitEmbedsOpt =
        abstract deep: bool option with get, set
        abstract padding: Padding option with get, set

    type [<AllowNullLiteral>] ElementGetPortsPositionsReturn =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: id: string -> Element.PortPosition with get, set

    type [<AllowNullLiteral>] ElementStatic =
        [<Emit "new $0($1...)">] abstract Create: ?attributes: Element.Attributes * ?opt: Graph.Options -> Element
        abstract define: ``type``: string * ?defaults: obj * ?protoProps: obj * ?staticProps: obj -> Cell.Constructor<Element>

    module Link =

        type [<AllowNullLiteral>] EndCellArgs =
            abstract magnet: string option with get, set
            abstract selector: string option with get, set
            abstract port: string option with get, set
            abstract anchor: Anchors.AnchorJSON option with get, set
            abstract connectionPoint: ConnectionPoints.ConnectionPointJSON option with get, set

        type [<AllowNullLiteral>] EndCellJSON =
            inherit EndCellArgs
            abstract id: U2<float, string> with get, set

        type [<AllowNullLiteral>] EndPointJSON =
            abstract x: float with get, set
            abstract y: float with get, set

        type [<AllowNullLiteral>] GenericAttributes<'T> =
            inherit Cell.GenericAttributes<'T>
            abstract source: U2<EndCellJSON, EndPointJSON> option with get, set
            abstract target: U2<EndCellJSON, EndPointJSON> option with get, set
            abstract labels: ResizeArray<Label> option with get, set
            abstract vertices: ResizeArray<Point> option with get, set
            abstract manhattan: bool option with get, set
            abstract router: U2<Routers.Router, Routers.RouterJSON> option with get, set
            abstract smooth: bool option with get, set
            abstract connector: U2<Connectors.Connector, Connectors.ConnectorJSON> option with get, set

        type [<AllowNullLiteral>] LinkSelectors =
            inherit Cell.Selectors
            abstract ``.connection``: Attributes.SVGPathAttributes option with get, set
            abstract ``.connection-wrap``: Attributes.SVGPathAttributes option with get, set
            abstract ``.marker-source``: Attributes.SVGPathAttributes option with get, set
            abstract ``.marker-target``: Attributes.SVGPathAttributes option with get, set
            abstract ``.labels``: Attributes.SVGAttributes option with get, set
            abstract ``.marker-vertices``: Attributes.SVGAttributes option with get, set
            abstract ``.marker-arrowheads``: Attributes.SVGAttributes option with get, set
            abstract ``.link-tools``: Attributes.SVGAttributes option with get, set

        type [<AllowNullLiteral>] Attributes =
            inherit Cell.GenericAttributes<LinkSelectors>
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] LabelPosition =
            abstract distance: float option with get, set
            abstract offset: U2<float, TypeLiteral_05> option with get, set
            abstract args: LinkView.LabelOptions option with get, set

        type [<AllowNullLiteral>] Label =
            abstract markup: string option with get, set
            abstract position: U2<LabelPosition, float> option with get, set
            abstract attrs: Cell.Selectors option with get, set
            abstract size: Size option with get, set

        type [<AllowNullLiteral>] Vertex =
            inherit Point
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] TypeLiteral_05 =
            abstract x: float with get, set
            abstract y: float with get, set

    type [<AllowNullLiteral>] Link =
        inherit Cell
        abstract markup: string with get, set
        abstract toolMarkup: string with get, set
        abstract doubleToolMarkup: string option with get, set
        abstract vertexMarkup: string with get, set
        abstract arrowHeadMarkup: string with get, set
        abstract labelMarkup: string option with get, set
        abstract labelProps: Link.Label option with get, set
        abstract isElement: unit -> bool
        abstract isLink: unit -> bool
        abstract disconnect: unit -> Link
        abstract source: unit -> U2<Link.EndCellJSON, Link.EndPointJSON>
        abstract source: source: U2<Link.EndCellJSON, Link.EndPointJSON> * ?opt: Cell.Options -> Link
        abstract source: source: Cell * ?args: Link.EndCellArgs * ?opt: Cell.Options -> Link
        abstract target: unit -> U2<Link.EndCellJSON, Link.EndPointJSON>
        abstract target: target: U2<Link.EndCellJSON, Link.EndPointJSON> * ?opt: Cell.Options -> Link
        abstract target: target: Cell * ?args: Link.EndCellArgs * ?opt: Cell.Options -> Link
        abstract router: unit -> U2<Routers.Router, Routers.RouterJSON> option
        abstract router: router: U2<Routers.Router, Routers.RouterJSON> * ?opt: Cell.Options -> Link
        abstract router: name: Routers.RouterType * ?args: Routers.RouterArguments * ?opt: Cell.Options -> Link
        abstract connector: unit -> U2<Connectors.Connector, Connectors.ConnectorJSON> option
        abstract connector: connector: U2<Connectors.Connector, Connectors.ConnectorJSON> * ?opt: Cell.Options -> Link
        abstract connector: name: Connectors.ConnectorType * ?args: Connectors.ConnectorArguments * ?opt: Cell.Options -> Link
        abstract label: ?index: float -> Link.Label
        abstract label: index: float * label: Link.Label * ?opt: Cell.Options -> Link
        abstract labels: unit -> ResizeArray<Link.Label>
        abstract labels: labels: ResizeArray<Link.Label> -> Link
        abstract insertLabel: index: float * label: Link.Label * ?opt: Cell.Options -> ResizeArray<Link.Label>
        abstract appendLabel: label: Link.Label * ?opt: Cell.Options -> ResizeArray<Link.Label>
        abstract removeLabel: ?index: float * ?opt: Cell.Options -> ResizeArray<Link.Label>
        abstract vertex: ?index: float -> Link.Vertex
        abstract vertex: index: float * vertex: Link.Vertex * ?opt: Cell.Options -> Link
        abstract vertices: unit -> ResizeArray<Link.Vertex>
        abstract vertices: vertices: ResizeArray<Link.Vertex> -> Link
        abstract insertVertex: index: float * vertex: Link.Vertex * ?opt: Cell.Options -> ResizeArray<Link.Vertex>
        abstract removeVertex: ?index: float * ?opt: Cell.Options -> ResizeArray<Link.Vertex>
        abstract reparent: ?opt: Cell.Options -> Element
        abstract getSourceElement: unit -> Element option
        abstract getTargetElement: unit -> Element option
        abstract hasLoop: ?opt: Cell.EmbeddableOptions -> bool
        abstract getRelationshipAncestor: unit -> Element option
        abstract isRelationshipEmbeddedIn: cell: Cell -> bool
        abstract applyToPoints: fn: (Point -> Point) * ?opt: Cell.Options -> Link
        abstract scale: sx: float * sy: float * ?origin: Point * ?opt: Cell.Options -> Link
        abstract translate: tx: float * ty: float * ?opt: Cell.Options -> Link

    type [<AllowNullLiteral>] LinkStatic =
        [<Emit "new $0($1...)">] abstract Create: ?attributes: Link.Attributes * ?opt: Graph.Options -> Link
        abstract define: ``type``: string * ?defaults: obj * ?protoProps: obj * ?staticProps: obj -> Cell.Constructor<Link>

    module CellView =

        type [<AllowNullLiteral>] Options<'T> =
            inherit Mvc.ViewOptions<'T>
            abstract id: string option with get, set

        type [<AllowNullLiteral>] InteractivityOptions =
            inherit ElementView.InteractivityOptions
            inherit LinkView.InteractivityOptions

    type [<AllowNullLiteral>] CellViewGeneric<'T> =
        inherit Mvc.View<'T>
        abstract highlight: ?el: U3<SVGElement, JQuery, string> * ?opt: CellViewGenericHighlightOpt -> CellViewGeneric<'T>
        abstract unhighlight: ?el: U3<SVGElement, JQuery, string> * ?opt: CellViewGenericUnhighlightOpt -> CellViewGeneric<'T>
        abstract can: feature: string -> bool
        abstract findMagnet: el: U3<SVGElement, JQuery, string> -> SVGElement option
        abstract findBySelector: selector: string * ?root: U3<SVGElement, JQuery, string> -> JQuery
        abstract getSelector: el: SVGElement * ?prevSelector: string -> string
        abstract getStrokeBBox: ?el: SVGElement -> G.Rect
        abstract notify: eventName: string * [<ParamArray>] eventArguments: ResizeArray<obj option> -> unit
        abstract addTools: tools: Dia.ToolsView -> CellViewGeneric<'T>
        abstract hasTools: ?name: string -> bool
        abstract removeTools: unit -> CellViewGeneric<'T>
        abstract showTools: unit -> CellViewGeneric<'T>
        abstract hideTools: unit -> CellViewGeneric<'T>
        abstract updateTools: ?opt: CellViewGenericUpdateToolsOpt -> CellViewGeneric<'T>
        abstract onToolEvent: eventName: string -> unit
        abstract pointerdblclick: evt: JQuery.Event * x: float * y: float -> unit
        abstract pointerclick: evt: JQuery.Event * x: float * y: float -> unit
        abstract contextmenu: evt: JQuery.Event * x: float * y: float -> unit
        abstract pointerdown: evt: JQuery.Event * x: float * y: float -> unit
        abstract pointermove: evt: JQuery.Event * x: float * y: float -> unit
        abstract pointerup: evt: JQuery.Event * x: float * y: float -> unit
        abstract mouseover: evt: JQuery.Event -> unit
        abstract mouseout: evt: JQuery.Event -> unit
        abstract mouseenter: evt: JQuery.Event -> unit
        abstract mouseleave: evt: JQuery.Event -> unit
        abstract mousewheel: evt: JQuery.Event * x: float * y: float * delta: float -> unit
        abstract onevent: evt: JQuery.Event * eventName: string * x: float * y: float -> unit
        abstract onmagnet: evt: JQuery.Event * x: float * y: float -> unit

    type [<AllowNullLiteral>] CellViewGenericHighlightOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] CellViewGenericUnhighlightOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] CellViewGenericUpdateToolsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] CellViewGenericStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: CellView.Options<'T> -> CellViewGeneric<'T>
        abstract dispatchToolsEvent: paper: Dia.Paper * eventName: string -> unit

    type [<AllowNullLiteral>] CellView =
        inherit CellViewGeneric<Cell>

    type [<AllowNullLiteral>] CellViewStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> CellView

    module ElementView =

        type [<AllowNullLiteral>] InteractivityOptions =
            abstract elementMove: bool option with get, set
            abstract addLinkFromMagnet: bool option with get, set

    type [<AllowNullLiteral>] ElementView =
        inherit CellViewGeneric<Element>
        abstract getBBox: ?opt: ElementViewGetBBoxOpt -> G.Rect
        abstract getNodeBBox: magnet: SVGElement -> G.Rect
        abstract getNodeUnrotatedBBox: magnet: SVGElement -> G.Rect
        abstract update: element: Element * ?renderingOnlyAttrs: ElementViewUpdateRenderingOnlyAttrs -> unit
        abstract setInteractivity: value: U2<bool, ElementView.InteractivityOptions> -> unit
        abstract getDelegatedView: unit -> ElementView option
        abstract renderMarkup: unit -> unit
        abstract renderJSONMarkup: markup: MarkupJSON -> unit
        abstract renderStringMarkup: markup: string -> unit
        abstract dragStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragMagnetStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract drag: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragMagnet: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragMagnetEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragLinkStart: evt: JQuery.Event * magnet: SVGElement * x: float * y: float -> unit
        abstract addLinkFromMagnet: magnet: SVGElement * x: float * y: float -> LinkView

    type [<AllowNullLiteral>] ElementViewGetBBoxOpt =
        abstract useModelGeometry: bool option with get, set

    type [<AllowNullLiteral>] ElementViewUpdateRenderingOnlyAttrs =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] ElementViewStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> ElementView

    module LinkView =

        type [<AllowNullLiteral>] InteractivityOptions =
            abstract vertexAdd: bool option with get, set
            abstract vertexMove: bool option with get, set
            abstract vertexRemove: bool option with get, set
            abstract arrowheadMove: bool option with get, set
            abstract labelMove: bool option with get, set
            abstract useLinkTools: bool option with get, set

        type [<AllowNullLiteral>] GetConnectionPoint =
            [<Emit "$0($1...)">] abstract Invoke: linkView: LinkView * view: ElementView * magnet: SVGElement * reference: Point * ``end``: LinkEnd -> Point

        type [<AllowNullLiteral>] LabelOptions =
            inherit Cell.Options
            abstract absoluteDistance: bool option with get, set
            abstract reverseDistance: bool option with get, set
            abstract absoluteOffset: bool option with get, set

        type [<AllowNullLiteral>] VertexOptions =
            inherit Cell.Options

    type [<AllowNullLiteral>] LinkView =
        inherit CellViewGeneric<Link>
        abstract options: TypeLiteral_12 with get, set
        abstract sendToken: token: SVGElement * ?duration: float * ?callback: (unit -> unit) -> unit
        abstract sendToken: token: SVGElement * ?opt: LinkViewSendTokenOpt * ?callback: (unit -> unit) -> unit
        abstract addLabel: coordinates: Point * ?opt: LinkView.LabelOptions -> float
        abstract addLabel: x: float * y: float * ?opt: LinkView.LabelOptions -> float
        abstract addVertex: coordinates: Point * ?opt: LinkView.VertexOptions -> float
        abstract addVertex: x: float * y: float * ?opt: LinkView.VertexOptions -> float
        abstract getConnection: unit -> G.Path
        abstract getSerializedConnection: unit -> string
        abstract getConnectionSubdivisions: unit -> ResizeArray<ResizeArray<G.Curve>>
        abstract getConnectionLength: unit -> float
        abstract getPointAtLength: length: float -> G.Point
        abstract getPointAtRatio: ratio: float -> G.Point
        abstract getTangentAtLength: length: float -> G.Line
        abstract getTangentAtRatio: ratio: float -> G.Line
        abstract getClosestPoint: point: Point -> G.Point
        abstract getClosestPointLength: point: Point -> float
        abstract getClosestPointRatio: point: Point -> float
        abstract getLabelPosition: x: float * y: float * ?opt: LinkView.LabelOptions -> Link.LabelPosition
        abstract getLabelCoordinates: labelPosition: Link.LabelPosition -> G.Point
        abstract getVertexIndex: x: float * y: float -> float
        abstract getVertexIndex: point: Point -> float
        abstract update: link: Link * attributes: obj option * ?opt: LinkViewUpdateOpt -> LinkView
        abstract setInteractivity: value: U2<bool, LinkView.InteractivityOptions> -> unit
        abstract onLabelsChange: link: Link * labels: ResizeArray<Link.Label> * opt: LinkViewOnLabelsChangeOpt -> unit
        abstract onToolsChange: link: Link * toolsMarkup: string * opt: LinkViewOnToolsChangeOpt -> unit
        abstract onVerticesChange: link: Link * vertices: ResizeArray<Point> * opt: LinkViewOnVerticesChangeOpt -> unit
        abstract onSourceChange: element: Element * sourceEnd: obj option * opt: LinkViewOnSourceChangeOpt -> unit
        abstract onTargetChange: element: Element * targetEnd: obj option * opt: LinkViewOnTargetChangeOpt -> unit
        abstract onlabel: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragConnectionStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragLabelStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragVertexStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragArrowheadStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragStart: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragConnection: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragLabel: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragVertex: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragArrowhead: evt: JQuery.Event * x: float * y: float -> unit
        abstract drag: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragConnectionEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragLabelEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragVertexEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragArrowheadEnd: evt: JQuery.Event * x: float * y: float -> unit
        abstract dragEnd: evt: JQuery.Event * x: float * y: float -> unit

    type [<AllowNullLiteral>] LinkViewSendTokenOpt =
        abstract duration: float option with get, set
        abstract direction: string option with get, set
        abstract connection: string option with get, set

    type [<AllowNullLiteral>] LinkViewUpdateOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewOnLabelsChangeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewOnToolsChangeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewOnVerticesChangeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewOnSourceChangeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewOnTargetChangeOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] LinkViewStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> LinkView

    module Paper =

        type [<AllowNullLiteral>] GradientOptions =
            abstract id: string option with get, set
            abstract ``type``: U2<string, string> with get, set
            abstract stops: Array<TypeLiteral_06> with get, set

        type [<AllowNullLiteral>] GridOptions =
            abstract color: string option with get, set
            abstract thickness: float option with get, set
            abstract name: U4<string, string, string, string> option with get, set
            abstract args: U2<Array<TypeLiteral_07>, TypeLiteral_07> option with get, set

        type [<AllowNullLiteral>] BackgroundOptions =
            abstract color: string option with get, set
            abstract image: string option with get, set
            abstract quality: float option with get, set
            abstract position: U2<Point, string> option with get, set
            abstract size: U2<Size, string> option with get, set
            abstract repeat: string option with get, set
            abstract opacity: float option with get, set
            abstract waterMarkAngle: float option with get, set

        type Dimension =
            U2<float, string> option

        [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
        module Dimension =
            let ofFloatOption v: Dimension = v |> Microsoft.FSharp.Core.Option.map U2.Case1
            let ofFloat v: Dimension = v |> U2.Case1 |> Some
            let isFloat (v: Dimension) = match v with None -> false | Some o -> match o with U2.Case1 _ -> true | _ -> false
            let asFloat (v: Dimension) = match v with None -> None | Some o -> match o with U2.Case1 o -> Some o | _ -> None
            let ofStringOption v: Dimension = v |> Microsoft.FSharp.Core.Option.map U2.Case2
            let ofString v: Dimension = v |> U2.Case2 |> Some
            let isString (v: Dimension) = match v with None -> false | Some o -> match o with U2.Case2 _ -> true | _ -> false
            let asString (v: Dimension) = match v with None -> None | Some o -> match o with U2.Case2 o -> Some o | _ -> None

        type [<AllowNullLiteral>] Options =
            inherit Mvc.ViewOptions<Graph>
            abstract width: Dimension option with get, set
            abstract height: Dimension option with get, set
            abstract origin: Point option with get, set
            abstract perpendicularLinks: bool option with get, set
            abstract linkConnectionPoint: LinkView.GetConnectionPoint option with get, set
            abstract drawGrid: U3<bool, GridOptions, ResizeArray<GridOptions>> option with get, set
            abstract background: BackgroundOptions option with get, set
            abstract async: U2<bool, TypeLiteral_08> option with get, set
            abstract gridSize: float option with get, set
            abstract highlighting: TypeLiteral_09 option with get, set
            abstract interactive: U3<(CellView -> string -> bool), bool, CellView.InteractivityOptions> option with get, set
            abstract snapLinks: U2<bool, TypeLiteral_10> option with get, set
            abstract markAvailable: bool option with get, set
            abstract validateMagnet: (CellView -> SVGElement -> bool) option with get, set
            abstract validateConnection: (CellView -> SVGElement -> CellView -> SVGElement -> LinkEnd -> LinkView -> bool) option with get, set
            abstract restrictTranslate: U2<(ElementView -> BBox), bool> option with get, set
            abstract multiLinks: bool option with get, set
            abstract linkPinning: bool option with get, set
            abstract allowLink: (LinkView -> Paper -> bool) option with get, set
            abstract guard: (JQuery.Event -> CellView -> bool) option with get, set
            abstract preventContextMenu: bool option with get, set
            abstract preventDefaultBlankAction: bool option with get, set
            abstract clickThreshold: float option with get, set
            abstract moveThreshold: float option with get, set
            abstract magnetThreshold: U2<float, string> option with get, set
            abstract elementView: U2<obj, (Element -> obj)> option with get, set
            abstract linkView: U2<obj, (Link -> obj)> option with get, set
            abstract embeddingMode: bool option with get, set
            abstract findParentBy: U6<string, string, string, string, string, string> option with get, set
            abstract validateEmbedding: (ElementView -> ElementView -> bool) option with get, set
            abstract cellViewNamespace: obj option with get, set
            abstract highlighterNamespace: obj option with get, set
            abstract defaultLink: U2<(CellView -> SVGElement -> Link), Link> option with get, set
            abstract defaultRouter: U2<Routers.Router, Routers.RouterJSON> option with get, set
            abstract defaultConnector: U2<Connectors.Connector, Connectors.ConnectorJSON> option with get, set
            abstract defaultAnchor: U2<Anchors.AnchorJSON, Anchors.Anchor> option with get, set
            abstract defaultConnectionPoint: U2<ConnectionPoints.ConnectionPointJSON, ConnectionPoints.ConnectionPoint> option with get, set
            abstract connectionStrategy: ConnectionStrategies.ConnectionStrategy option with get, set

        type [<AllowNullLiteral>] ScaleContentOptions =
            abstract padding: float option with get, set
            abstract preserveAspectRatio: bool option with get, set
            abstract minScale: float option with get, set
            abstract minScaleX: float option with get, set
            abstract minScaleY: float option with get, set
            abstract maxScale: float option with get, set
            abstract maxScaleX: float option with get, set
            abstract maxScaleY: float option with get, set
            abstract scaleGrid: float option with get, set
            abstract fittingBBox: BBox option with get, set

        type [<AllowNullLiteral>] FitToContentOptions =
            abstract gridWidth: float option with get, set
            abstract gridHeight: float option with get, set
            abstract padding: Padding option with get, set
            abstract allowNewOrigin: U3<string, string, string> option with get, set
            abstract minWidth: float option with get, set
            abstract minHeight: float option with get, set
            abstract maxWidth: float option with get, set
            abstract maxHeight: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_08 =
            abstract batchSize: float with get, set

        type [<AllowNullLiteral>] TypeLiteral_06 =
            abstract offset: string with get, set
            abstract color: string with get, set
            abstract opacity: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_10 =
            abstract radius: float with get, set

        type [<AllowNullLiteral>] TypeLiteral_09 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: ``type``: string -> Highlighters.HighlighterJSON with get, set

        type [<AllowNullLiteral>] TypeLiteral_07 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] Paper =
        inherit Mvc.View<Graph>
        abstract options: Paper.Options with get, set
        abstract svg: SVGElement with get, set
        abstract viewport: SVGGElement with get, set
        abstract defs: SVGDefsElement with get, set
        abstract matrix: unit -> SVGMatrix
        abstract matrix: ctm: U2<SVGMatrix, Vectorizer.Matrix> -> Paper
        abstract clientMatrix: unit -> SVGMatrix
        abstract clientOffset: unit -> G.Point
        abstract pageOffset: unit -> G.Point
        abstract clientToLocalPoint: x: float * y: float -> G.Point
        abstract clientToLocalPoint: point: Point -> G.Point
        abstract clientToLocalRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract clientToLocalRect: rect: BBox -> G.Rect
        abstract localToClientPoint: x: float * y: float -> G.Point
        abstract localToClientPoint: point: Point -> G.Point
        abstract localToClientRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract localToClientRect: rect: BBox -> G.Rect
        abstract localToPagePoint: x: float * y: float -> G.Point
        abstract localToPagePoint: point: Point -> G.Point
        abstract localToPageRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract localToPageRect: rect: BBox -> G.Rect
        abstract localToPaperPoint: x: float * y: float -> G.Point
        abstract localToPaperPoint: point: Point -> G.Point
        abstract localToPaperRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract localToPaperRect: rect: BBox -> G.Rect
        abstract pageToLocalPoint: x: float * y: float -> G.Point
        abstract pageToLocalPoint: point: Point -> G.Point
        abstract pageToLocalRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract pageToLocalRect: rect: BBox -> G.Rect
        abstract paperToLocalPoint: x: float * y: float -> G.Point
        abstract paperToLocalPoint: point: Point -> G.Point
        abstract paperToLocalRect: x: float * y: float * width: float * height: float -> G.Rect
        abstract paperToLocalRect: x: BBox -> G.Rect
        abstract snapToGrid: x: float * y: float -> G.Point
        abstract snapToGrid: point: Point -> G.Point
        abstract defineFilter: filter: PaperDefineFilterFilter -> string
        abstract defineGradient: gradient: Paper.GradientOptions -> string
        abstract defineMarker: marker: PaperDefineMarkerMarker -> string
        abstract isDefined: defId: string -> bool
        abstract getComputedSize: unit -> Size
        abstract getArea: unit -> G.Rect
        abstract getRestrictedArea: unit -> G.Rect option
        abstract getContentArea: unit -> G.Rect
        abstract getContentBBox: unit -> G.Rect
        abstract findView: element: U3<string, JQuery, SVGElement> -> 'T
        abstract findViewByModel: model: U3<Cell, string, float> -> 'T
        abstract findViewsFromPoint: point: U2<string, Point> -> ResizeArray<ElementView>
        abstract findViewsInArea: rect: BBox * ?opt: PaperFindViewsInAreaOpt -> ResizeArray<ElementView>
        abstract fitToContent: ?opt: Paper.FitToContentOptions -> unit
        abstract fitToContent: ?gridWidth: float * ?gridHeight: float * ?padding: float * ?opt: obj -> unit
        abstract scaleContentToFit: ?opt: Paper.ScaleContentOptions -> unit
        abstract cancelRenderViews: unit -> unit
        abstract drawBackground: ?opt: Paper.BackgroundOptions -> Paper
        abstract drawGrid: ?opt: U2<Paper.GridOptions, ResizeArray<Paper.GridOptions>> -> Paper
        abstract clearGrid: unit -> Paper
        abstract getDefaultLink: cellView: CellView * magnet: SVGElement -> Link
        abstract getModelById: id: U3<string, float, Cell> -> Cell
        abstract setDimensions: width: Paper.Dimension * height: Paper.Dimension -> unit
        abstract setGridSize: gridSize: float -> Paper
        abstract setInteractivity: value: obj option -> unit
        abstract setOrigin: x: float * y: float -> Paper
        abstract scale: unit -> Vectorizer.Scale
        abstract scale: sx: float * ?sy: float * ?ox: float * ?oy: float -> Paper
        abstract translate: unit -> Vectorizer.Translation
        abstract translate: tx: float * ?ty: float -> Paper
        abstract update: unit -> Paper
        abstract removeTools: unit -> Paper
        abstract hideTools: unit -> Paper
        abstract showTools: unit -> Paper
        abstract pointerdblclick: evt: JQuery.Event -> unit
        abstract pointerclick: evt: JQuery.Event -> unit
        abstract contextmenu: evt: JQuery.Event -> unit
        abstract pointerdown: evt: JQuery.Event -> unit
        abstract pointermove: evt: JQuery.Event -> unit
        abstract pointerup: evt: JQuery.Event -> unit
        abstract mouseover: evt: JQuery.Event -> unit
        abstract mouseout: evt: JQuery.Event -> unit
        abstract mouseenter: evt: JQuery.Event -> unit
        abstract mouseleave: evt: JQuery.Event -> unit
        abstract mousewheel: evt: JQuery.Event -> unit
        abstract onevent: evt: JQuery.Event -> unit
        abstract onmagnet: evt: JQuery.Event -> unit
        abstract onlabel: evt: JQuery.Event -> unit
        abstract guard: evt: JQuery.Event * view: CellView -> bool
        abstract sortViews: unit -> unit
        abstract drawBackgroundImage: img: HTMLImageElement * opt: PaperDrawBackgroundImageOpt -> unit
        abstract createViewForModel: cell: Cell -> CellView
        abstract cloneOptions: unit -> Paper.Options
        abstract afterRenderViews: unit -> unit
        abstract asyncRenderViews: cells: ResizeArray<Cell> * ?opt: PaperAsyncRenderViewsOpt -> unit
        abstract beforeRenderViews: cells: ResizeArray<Cell> -> ResizeArray<Cell>
        abstract init: unit -> unit
        abstract onCellAdded: cell: Cell * graph: Graph * opt: PaperOnCellAddedOpt -> unit
        abstract onCellHighlight: cellView: CellView * magnetEl: SVGElement * ?opt: PaperOnCellHighlightOpt -> unit
        abstract onCellUnhighlight: cellView: CellView * magnetEl: SVGElement * ?opt: PaperOnCellUnhighlightOpt -> unit
        abstract onRemove: unit -> unit
        abstract removeView: cell: Cell -> CellView
        abstract removeViews: unit -> unit
        abstract renderView: cell: Cell -> CellView
        abstract resetViews: cellsCollection: ResizeArray<Cell> * opt: PaperResetViewsOpt -> unit
        abstract updateBackgroundColor: color: string -> unit
        abstract updateBackgroundImage: opt: PaperUpdateBackgroundImageOpt -> unit

    type [<AllowNullLiteral>] PaperDefineFilterFilter =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] PaperDefineMarkerMarker =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] PaperFindViewsInAreaOpt =
        abstract strict: bool option with get, set

    type [<AllowNullLiteral>] PaperDrawBackgroundImageOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] PaperAsyncRenderViewsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] PaperOnCellAddedOpt =
        abstract async: bool option with get, set
        abstract position: float option with get, set

    type [<AllowNullLiteral>] PaperOnCellHighlightOpt =
        abstract highlighter: Highlighters.HighlighterJSON option with get, set

    type [<AllowNullLiteral>] PaperOnCellUnhighlightOpt =
        abstract highlighter: Highlighters.HighlighterJSON option with get, set

    type [<AllowNullLiteral>] PaperResetViewsOpt =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] PaperUpdateBackgroundImageOpt =
        abstract position: obj option with get, set
        abstract size: obj option with get, set

    type [<AllowNullLiteral>] PaperStatic =
        [<Emit "new $0($1...)">] abstract Create: opt: Paper.Options -> Paper

    module ToolsView =

        type [<AllowNullLiteral>] Options =
            abstract tools: ResizeArray<Dia.ToolView> option with get, set
            abstract name: string option with get, set
            abstract relatedView: Dia.CellView option with get, set
            abstract ``component``: bool option with get, set

    type [<AllowNullLiteral>] ToolsView =
        inherit Mvc.View<obj>
        abstract options: ToolsView.Options with get, set
        abstract configure: ?opt: ToolsView.Options -> ToolsView
        abstract getName: unit -> string option
        abstract focusTool: tool: ToolView -> ToolsView
        abstract blurTool: tool: ToolView -> ToolsView
        abstract show: unit -> ToolsView
        abstract hide: unit -> ToolsView
        abstract mount: unit -> ToolsView
        abstract simulateRelatedView: el: SVGElement -> unit

    type [<AllowNullLiteral>] ToolsViewStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: ToolsView.Options -> ToolsView

    module ToolView =

        type [<AllowNullLiteral>] Options =
            abstract focusOpacity: float option with get, set

    type [<AllowNullLiteral>] ToolView =
        inherit Mvc.View<obj>
        abstract name: string option with get, set
        abstract parentView: ToolsView with get, set
        abstract relatedView: Dia.CellView with get, set
        abstract paper: Paper with get, set
        abstract configure: ?opt: ToolView.Options -> ToolView
        abstract show: unit -> unit
        abstract hide: unit -> unit
        abstract isVisible: unit -> bool
        abstract focus: unit -> unit
        abstract blur: unit -> unit
        abstract update: unit -> unit

    type [<AllowNullLiteral>] ToolViewStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: ToolView.Options -> ToolView

    type [<AllowNullLiteral>] TypeLiteral_12 =
        abstract shortLinkLength: float option with get, set
        abstract doubleLinkTools: bool option with get, set
        abstract longLinkLength: float option with get, set
        abstract linkToolsOffset: float option with get, set
        abstract doubleLinkToolsOffset: float option with get, set
        abstract sampleInterval: float option with get, set

    type [<AllowNullLiteral>] TypeLiteral_11 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module Shapes =
    let [<Import("basic","jointjs/shapes")>] basic: Basic.IExports = jsNative
    let [<Import("chess","jointjs/shapes")>] chess: Chess.IExports = jsNative
    let [<Import("devs","jointjs/shapes")>] devs: Devs.IExports = jsNative
    let [<Import("erd","jointjs/shapes")>] erd: Erd.IExports = jsNative
    let [<Import("fsa","jointjs/shapes")>] fsa: Fsa.IExports = jsNative
    let [<Import("logic","jointjs/shapes")>] logic: Logic.IExports = jsNative
    let [<Import("org","jointjs/shapes")>] org: Org.IExports = jsNative
    let [<Import("pn","jointjs/shapes")>] pn: Pn.IExports = jsNative
    let [<Import("standard","jointjs/shapes")>] standard: Standard.IExports = jsNative
    let [<Import("uml","jointjs/shapes")>] uml: Uml.IExports = jsNative

    module Standard =

        type [<AllowNullLiteral>] IExports =
            abstract Rectangle: RectangleStatic
            abstract Circle: CircleStatic
            abstract Ellipse: EllipseStatic
            abstract Path: PathStatic
            abstract Polygon: PolygonStatic
            abstract Polyline: PolylineStatic
            abstract Image: ImageStatic
            abstract BorderedImage: BorderedImageStatic
            abstract EmbeddedImage: EmbeddedImageStatic
            abstract InscribedImage: InscribedImageStatic
            abstract HeaderedRectangle: HeaderedRectangleStatic
            abstract Cylinder: CylinderStatic
            abstract TextBlock: TextBlockStatic
            abstract Link: LinkStatic
            abstract DoubleLink: DoubleLinkStatic
            abstract ShadowLink: ShadowLinkStatic

        type [<AllowNullLiteral>] RectangleSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGRectAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Rectangle =
            inherit Dia.Element

        type [<AllowNullLiteral>] RectangleStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<RectangleSelectors> * ?opt: Dia.Graph.Options -> Rectangle

        type [<AllowNullLiteral>] CircleSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGCircleAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Circle =
            inherit Dia.Element

        type [<AllowNullLiteral>] CircleStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<CircleSelectors> * ?opt: Dia.Graph.Options -> Circle

        type [<AllowNullLiteral>] EllipseSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGCircleAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Ellipse =
            inherit Dia.Element

        type [<AllowNullLiteral>] EllipseStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<EllipseSelectors> * ?opt: Dia.Graph.Options -> Ellipse

        type [<AllowNullLiteral>] PathSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGPathAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Path =
            inherit Dia.Element

        type [<AllowNullLiteral>] PathStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PathSelectors> * ?opt: Dia.Graph.Options -> Path

        type [<AllowNullLiteral>] PolygonSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGPolygonAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Polygon =
            inherit Dia.Element

        type [<AllowNullLiteral>] PolygonStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolygonSelectors> * ?opt: Dia.Graph.Options -> Polygon

        type [<AllowNullLiteral>] PolylineSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGPolylineAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Polyline =
            inherit Dia.Element

        type [<AllowNullLiteral>] PolylineStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolylineSelectors> * ?opt: Dia.Graph.Options -> Polyline

        type [<AllowNullLiteral>] ImageSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Image =
            inherit Dia.Element

        type [<AllowNullLiteral>] ImageStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<ImageSelectors> * ?opt: Dia.Graph.Options -> Image

        type [<AllowNullLiteral>] BorderedImageSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract border: Attributes.SVGRectAttributes option with get, set
            abstract background: Attributes.SVGRectAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] BorderedImage =
            inherit Dia.Element

        type [<AllowNullLiteral>] BorderedImageStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<BorderedImageSelectors> * ?opt: Dia.Graph.Options -> BorderedImage

        type [<AllowNullLiteral>] EmbeddedImageSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGRectAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] EmbeddedImage =
            inherit Dia.Element

        type [<AllowNullLiteral>] EmbeddedImageStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<EmbeddedImageSelectors> * ?opt: Dia.Graph.Options -> EmbeddedImage

        type [<AllowNullLiteral>] InscribedImageSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract border: Attributes.SVGEllipseAttributes option with get, set
            abstract background: Attributes.SVGEllipseAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set
            abstract label: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] InscribedImage =
            inherit Dia.Element

        type [<AllowNullLiteral>] InscribedImageStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<InscribedImageSelectors> * ?opt: Dia.Graph.Options -> InscribedImage

        type [<AllowNullLiteral>] HeaderedRectangleSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGRectAttributes option with get, set
            abstract header: Attributes.SVGRectAttributes option with get, set
            abstract headerText: Attributes.SVGTextAttributes option with get, set
            abstract bodyText: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] HeaderedRectangle =
            inherit Dia.Element

        type [<AllowNullLiteral>] HeaderedRectangleStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<HeaderedRectangleSelectors> * ?opt: Dia.Graph.Options -> HeaderedRectangle

        type [<AllowNullLiteral>] CylinderBodyAttributes =
            inherit Attributes.SVGPathAttributes
            abstract lateralArea: U2<string, float> option with get, set

        type [<AllowNullLiteral>] CylinderSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: CylinderBodyAttributes option with get, set
            abstract top: Attributes.SVGEllipseAttributes option with get, set

        type [<AllowNullLiteral>] Cylinder =
            inherit Dia.Element
            abstract topRy: unit -> U2<string, float>
            abstract topRy: t: U2<string, float> * ?opt: Dia.Cell.Options -> Cylinder

        type [<AllowNullLiteral>] CylinderStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<CylinderSelectors> * ?opt: Dia.Graph.Options -> Cylinder

        type [<AllowNullLiteral>] TextBlockSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract body: Attributes.SVGRectAttributes option with get, set
            abstract label: TypeLiteral_14 option with get, set

        type [<AllowNullLiteral>] TextBlock =
            inherit Dia.Element

        type [<AllowNullLiteral>] TextBlockStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<TextBlockSelectors> * ?opt: Dia.Graph.Options -> TextBlock

        type [<AllowNullLiteral>] LinkSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract line: Attributes.SVGPathAttributes option with get, set
            abstract wrapper: Attributes.SVGPathAttributes option with get, set

        type [<AllowNullLiteral>] Link =
            inherit Dia.Link

        type [<AllowNullLiteral>] LinkStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Link.GenericAttributes<LinkSelectors> * ?opt: Dia.Graph.Options -> Link

        type [<AllowNullLiteral>] DoubleLinkSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract line: Attributes.SVGPathAttributes option with get, set
            abstract outline: Attributes.SVGPathAttributes option with get, set

        type [<AllowNullLiteral>] DoubleLink =
            inherit Dia.Link

        type [<AllowNullLiteral>] DoubleLinkStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Link.GenericAttributes<DoubleLinkSelectors> * ?opt: Dia.Graph.Options -> DoubleLink

        type [<AllowNullLiteral>] ShadowLinkSelectors =
            abstract root: Attributes.SVGAttributes option with get, set
            abstract line: Attributes.SVGPathAttributes option with get, set
            abstract shadow: Attributes.SVGPathAttributes option with get, set

        type [<AllowNullLiteral>] ShadowLink =
            inherit Dia.Link

        type [<AllowNullLiteral>] ShadowLinkStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Link.GenericAttributes<ShadowLinkSelectors> * ?opt: Dia.Graph.Options -> ShadowLink

        type [<AllowNullLiteral>] TypeLiteral_14 =
            abstract text: string option with get, set
            abstract style: TypeLiteral_13 option with get, set
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] TypeLiteral_13 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] SVGTextSelector =
        inherit Dia.Cell.Selectors
        abstract text: Attributes.SVGTextAttributes option with get, set

    type [<AllowNullLiteral>] SVGRectSelector =
        inherit Dia.Cell.Selectors
        abstract rect: Attributes.SVGRectAttributes option with get, set

    type [<AllowNullLiteral>] SVGCircleSelector =
        inherit Dia.Cell.Selectors
        abstract circle: Attributes.SVGCircleAttributes option with get, set

    type [<AllowNullLiteral>] SVGEllipseSelector =
        inherit Dia.Cell.Selectors
        abstract ellipse: Attributes.SVGEllipseAttributes option with get, set

    type [<AllowNullLiteral>] SVGPolygonSelector =
        inherit Dia.Cell.Selectors
        abstract polygon: Attributes.SVGPolygonAttributes option with get, set

    type [<AllowNullLiteral>] SVGPolylineSelector =
        inherit Dia.Cell.Selectors
        abstract polyline: Attributes.SVGPolylineAttributes option with get, set

    type [<AllowNullLiteral>] SVGImageSelector =
        inherit Dia.Cell.Selectors
        abstract image: Attributes.SVGImageAttributes option with get, set

    type [<AllowNullLiteral>] SVGPathSelector =
        inherit Dia.Cell.Selectors
        abstract path: Attributes.SVGPathAttributes option with get, set

    module Basic =

        type [<AllowNullLiteral>] IExports =
            abstract Generic: GenericStatic
            abstract Text: TextStatic
            abstract Rect: RectStatic
            abstract Circle: CircleStatic
            abstract Ellipse: EllipseStatic
            abstract Polygon: PolygonStatic
            abstract Polyline: PolylineStatic
            abstract Image: ImageStatic
            abstract Path: PathStatic
            abstract Rhombus: RhombusStatic
            abstract TextBlock: TextBlockStatic

        type [<AllowNullLiteral>] Generic =
            inherit Dia.Element

        type [<AllowNullLiteral>] GenericStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Generic

        type [<AllowNullLiteral>] Text =
            inherit Generic

        type [<AllowNullLiteral>] TextStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<SVGTextSelector> * ?opt: TextStaticOpt -> Text

        type [<AllowNullLiteral>] TextStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] RectSelectors =
            inherit SVGTextSelector
            inherit SVGRectSelector

        type [<AllowNullLiteral>] Rect =
            inherit Generic

        type [<AllowNullLiteral>] RectStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<RectSelectors> * ?opt: RectStaticOpt -> Rect

        type [<AllowNullLiteral>] RectStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] CircleSelectors =
            inherit SVGTextSelector
            inherit SVGCircleSelector

        type [<AllowNullLiteral>] Circle =
            inherit Generic

        type [<AllowNullLiteral>] CircleStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<CircleSelectors> * ?opt: CircleStaticOpt -> Circle

        type [<AllowNullLiteral>] CircleStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] EllipseSelectors =
            inherit SVGTextSelector
            inherit SVGEllipseSelector

        type [<AllowNullLiteral>] Ellipse =
            inherit Generic

        type [<AllowNullLiteral>] EllipseStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<EllipseSelectors> * ?opt: EllipseStaticOpt -> Ellipse

        type [<AllowNullLiteral>] EllipseStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] PolygonSelectors =
            inherit SVGTextSelector
            inherit SVGPolygonSelector

        type [<AllowNullLiteral>] Polygon =
            inherit Generic

        type [<AllowNullLiteral>] PolygonStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolygonSelectors> * ?opt: PolygonStaticOpt -> Polygon

        type [<AllowNullLiteral>] PolygonStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] PolylineSelectors =
            inherit SVGTextSelector
            inherit SVGPolylineSelector

        type [<AllowNullLiteral>] Polyline =
            inherit Generic

        type [<AllowNullLiteral>] PolylineStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolylineSelectors> * ?opt: PolylineStaticOpt -> Polyline

        type [<AllowNullLiteral>] PolylineStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] ImageSelectors =
            inherit SVGTextSelector
            inherit SVGImageSelector

        type [<AllowNullLiteral>] Image =
            inherit Generic

        type [<AllowNullLiteral>] ImageStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<ImageSelectors> * ?opt: ImageStaticOpt -> Image

        type [<AllowNullLiteral>] ImageStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] PathSelectors =
            inherit SVGTextSelector
            inherit SVGPathSelector

        type [<AllowNullLiteral>] Path =
            inherit Generic

        type [<AllowNullLiteral>] PathStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PathSelectors> * ?opt: PathStaticOpt -> Path

        type [<AllowNullLiteral>] PathStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Rhombus =
            inherit Generic

        type [<AllowNullLiteral>] RhombusStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PathSelectors> * ?opt: RhombusStaticOpt -> Rhombus

        type [<AllowNullLiteral>] RhombusStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] TextBlockSelectors =
            inherit SVGTextSelector
            inherit SVGRectSelector
            abstract ``.content``: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] TextBlock =
            inherit Generic

        type [<AllowNullLiteral>] TextBlockStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<TextBlockSelectors> * ?opt: TextBlockStaticOpt -> TextBlock

        type [<AllowNullLiteral>] TextBlockStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    module Chess =

        type [<AllowNullLiteral>] IExports =
            abstract KingWhite: KingWhiteStatic
            abstract KingBlack: KingBlackStatic
            abstract QueenWhite: QueenWhiteStatic
            abstract QueenBlack: QueenBlackStatic
            abstract RookWhite: RookWhiteStatic
            abstract RookBlack: RookBlackStatic
            abstract BishopWhite: BishopWhiteStatic
            abstract BishopBlack: BishopBlackStatic
            abstract KnightWhite: KnightWhiteStatic
            abstract KnightBlack: KnightBlackStatic
            abstract PawnWhite: PawnWhiteStatic
            abstract PawnBlack: PawnBlackStatic

        type [<AllowNullLiteral>] KingWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] KingWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> KingWhite

        type [<AllowNullLiteral>] KingBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] KingBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> KingBlack

        type [<AllowNullLiteral>] QueenWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] QueenWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> QueenWhite

        type [<AllowNullLiteral>] QueenBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] QueenBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> QueenBlack

        type [<AllowNullLiteral>] RookWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] RookWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> RookWhite

        type [<AllowNullLiteral>] RookBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] RookBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> RookBlack

        type [<AllowNullLiteral>] BishopWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] BishopWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> BishopWhite

        type [<AllowNullLiteral>] BishopBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] BishopBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> BishopBlack

        type [<AllowNullLiteral>] KnightWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] KnightWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> KnightWhite

        type [<AllowNullLiteral>] KnightBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] KnightBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> KnightBlack

        type [<AllowNullLiteral>] PawnWhite =
            inherit Basic.Generic

        type [<AllowNullLiteral>] PawnWhiteStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> PawnWhite

        type [<AllowNullLiteral>] PawnBlack =
            inherit Basic.Generic

        type [<AllowNullLiteral>] PawnBlackStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> PawnBlack

    module Devs =

        type [<AllowNullLiteral>] IExports =
            abstract Model: ModelStatic
            abstract Coupled: CoupledStatic
            abstract Atomic: AtomicStatic
            abstract Link: LinkStatic

        type [<AllowNullLiteral>] ModelSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.label``: Attributes.SVGTextAttributes option with get, set
            abstract ``.body``: Attributes.SVGRectAttributes option with get, set

        type [<AllowNullLiteral>] ModelAttributes =
            inherit Dia.Element.GenericAttributes<ModelSelectors>
            abstract inPorts: ResizeArray<string> option with get, set
            abstract outPorts: ResizeArray<string> option with get, set

        type [<AllowNullLiteral>] Model =
            inherit Basic.Generic
            abstract changeInGroup: properties: obj option * ?opt: obj -> bool
            abstract changeOutGroup: properties: obj option * ?opt: obj -> bool
            abstract createPortItem: group: string * port: string -> obj option
            abstract createPortItems: group: string * ports: ResizeArray<string> -> ResizeArray<obj option>
            abstract addOutPort: port: string * ?opt: obj -> Model
            abstract addInPort: port: string * ?opt: obj -> Model
            abstract removeOutPort: port: string * ?opt: obj -> Model
            abstract removeInPort: port: string * ?opt: obj -> Model

        type [<AllowNullLiteral>] ModelStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ModelAttributes * ?opt: ModelStaticOpt -> Model

        type [<AllowNullLiteral>] ModelStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Coupled =
            inherit Model

        type [<AllowNullLiteral>] CoupledStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Coupled

        type [<AllowNullLiteral>] Atomic =
            inherit Model

        type [<AllowNullLiteral>] AtomicStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Atomic

        type [<AllowNullLiteral>] Link =
            inherit Dia.Link

        type [<AllowNullLiteral>] LinkStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Link

    module Erd =

        type [<AllowNullLiteral>] IExports =
            abstract Entity: EntityStatic
            abstract WeakEntity: WeakEntityStatic
            abstract Relationship: RelationshipStatic
            abstract IdentifyingRelationship: IdentifyingRelationshipStatic
            abstract Attribute: AttributeStatic
            abstract Multivalued: MultivaluedStatic
            abstract Derived: DerivedStatic
            abstract Key: KeyStatic
            abstract Normal: NormalStatic
            abstract ISA: ISAStatic
            abstract Line: LineStatic

        type [<AllowNullLiteral>] PolygonalSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.label``: Attributes.SVGPolygonAttributes option with get, set
            abstract ``.body``: Attributes.SVGPolygonAttributes option with get, set
            abstract text: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] EllipsoidSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.label``: Attributes.SVGEllipseAttributes option with get, set
            abstract ``.body``: Attributes.SVGEllipseAttributes option with get, set
            abstract text: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] Entity =
            inherit Basic.Generic

        type [<AllowNullLiteral>] EntityStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolygonalSelectors> * ?opt: EntityStaticOpt -> Entity

        type [<AllowNullLiteral>] EntityStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] WeakEntity =
            inherit Entity

        type [<AllowNullLiteral>] WeakEntityStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> WeakEntity

        type [<AllowNullLiteral>] Relationship =
            inherit Dia.Element

        type [<AllowNullLiteral>] RelationshipStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<PolygonalSelectors> * ?opt: RelationshipStaticOpt -> Relationship

        type [<AllowNullLiteral>] RelationshipStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] IdentifyingRelationship =
            inherit Relationship

        type [<AllowNullLiteral>] IdentifyingRelationshipStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> IdentifyingRelationship

        type [<AllowNullLiteral>] Attribute =
            inherit Dia.Element

        type [<AllowNullLiteral>] AttributeStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<EllipsoidSelectors> * ?opt: AttributeStaticOpt -> Attribute

        type [<AllowNullLiteral>] AttributeStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Multivalued =
            inherit Attribute

        type [<AllowNullLiteral>] MultivaluedStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Multivalued

        type [<AllowNullLiteral>] Derived =
            inherit Attribute

        type [<AllowNullLiteral>] DerivedStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Derived

        type [<AllowNullLiteral>] Key =
            inherit Attribute

        type [<AllowNullLiteral>] KeyStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Key

        type [<AllowNullLiteral>] Normal =
            inherit Attribute

        type [<AllowNullLiteral>] NormalStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Normal

        type [<AllowNullLiteral>] ISA =
            inherit Dia.Element

        type [<AllowNullLiteral>] ISAStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<Basic.PolygonSelectors> * ?opt: ISAStaticOpt -> ISA

        type [<AllowNullLiteral>] ISAStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Line =
            inherit Dia.Link
            abstract cardinality: value: U2<string, float> -> unit

        type [<AllowNullLiteral>] LineStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Line

    module Fsa =

        type [<AllowNullLiteral>] IExports =
            abstract State: StateStatic
            abstract StartState: StartStateStatic
            abstract EndState: EndStateStatic
            abstract Arrow: ArrowStatic

        type [<AllowNullLiteral>] State =
            inherit Basic.Circle

        type [<AllowNullLiteral>] StateStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> State

        type [<AllowNullLiteral>] StartState =
            inherit Dia.Element

        type [<AllowNullLiteral>] StartStateStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<SVGCircleSelector> * ?opt: StartStateStaticOpt -> StartState

        type [<AllowNullLiteral>] StartStateStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] CirculoidSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.outer``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.inner``: Attributes.SVGCircleAttributes option with get, set

        type [<AllowNullLiteral>] EndState =
            inherit Dia.Element

        type [<AllowNullLiteral>] EndStateStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<CirculoidSelectors> * ?opt: EndStateStaticOpt -> EndState

        type [<AllowNullLiteral>] EndStateStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Arrow =
            inherit Dia.Link

        type [<AllowNullLiteral>] ArrowStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Arrow

    module Logic =

        type [<AllowNullLiteral>] IExports =
            abstract Gate: GateStatic
            abstract IO: IOStatic
            abstract Input: InputStatic
            abstract Output: OutputStatic
            abstract Gate11: Gate11Static
            abstract Gate21: Gate21Static
            abstract Repeater: RepeaterStatic
            abstract Not: NotStatic
            abstract Or: OrStatic
            abstract And: AndStatic
            abstract Nor: NorStatic
            abstract Nand: NandStatic
            abstract Xor: XorStatic
            abstract Xnor: XnorStatic
            abstract Wire: WireStatic

        type [<AllowNullLiteral>] Gate =
            inherit Basic.Generic

        type [<AllowNullLiteral>] GateStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Gate

        type [<AllowNullLiteral>] GateSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.body``: Attributes.SVGRectAttributes option with get, set
            abstract ``.wire``: Attributes.SVGPathAttributes option with get, set
            abstract circle: Attributes.SVGCircleAttributes option with get, set
            abstract text: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] IO =
            inherit Gate

        type [<AllowNullLiteral>] IOStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<Basic.CircleSelectors> * ?opt: IOStaticOpt -> IO

        type [<AllowNullLiteral>] IOStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Input =
            inherit IO

        type [<AllowNullLiteral>] InputStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Input

        type [<AllowNullLiteral>] Output =
            inherit IO

        type [<AllowNullLiteral>] OutputStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Output

        type [<AllowNullLiteral>] Gate11Selectors =
            inherit Dia.Cell.Selectors
            abstract ``.input``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.output``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.body``: Attributes.SVGImageAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set

        type [<AllowNullLiteral>] Gate11 =
            inherit Gate

        type [<AllowNullLiteral>] Gate11Static =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<Gate11Selectors> * ?opt: Gate11StaticOpt -> Gate11

        type [<AllowNullLiteral>] Gate11StaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Gate21Selectors =
            inherit Dia.Cell.Selectors
            abstract ``.input``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.input1``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.input2``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.output``: Attributes.SVGCircleAttributes option with get, set
            abstract ``.body``: Attributes.SVGImageAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set

        type [<AllowNullLiteral>] Gate21 =
            inherit Gate

        type [<AllowNullLiteral>] Gate21Static =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<Gate21Selectors> * ?opt: Gate21StaticOpt -> Gate21

        type [<AllowNullLiteral>] Gate21StaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Repeater =
            inherit Gate11
            abstract operation: input: obj option -> obj option

        type [<AllowNullLiteral>] RepeaterStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Repeater

        type [<AllowNullLiteral>] Not =
            inherit Gate11
            abstract operation: input: obj option -> bool

        type [<AllowNullLiteral>] NotStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Not

        type [<AllowNullLiteral>] Or =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] OrStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Or

        type [<AllowNullLiteral>] And =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] AndStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> And

        type [<AllowNullLiteral>] Nor =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] NorStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Nor

        type [<AllowNullLiteral>] Nand =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] NandStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Nand

        type [<AllowNullLiteral>] Xor =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] XorStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Xor

        type [<AllowNullLiteral>] Xnor =
            inherit Gate21
            abstract operation: input1: obj option * input2: obj option -> bool

        type [<AllowNullLiteral>] XnorStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Xnor

        type [<AllowNullLiteral>] Wire =
            inherit Dia.Link

        type [<AllowNullLiteral>] WireStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Wire

    module Org =

        type [<AllowNullLiteral>] IExports =
            abstract Member: MemberStatic
            abstract Arrow: ArrowStatic

        type [<AllowNullLiteral>] MemberSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.card``: Attributes.SVGRectAttributes option with get, set
            abstract ``.rank``: Attributes.SVGTextAttributes option with get, set
            abstract ``.name``: Attributes.SVGTextAttributes option with get, set
            abstract image: Attributes.SVGImageAttributes option with get, set

        type [<AllowNullLiteral>] Member =
            inherit Dia.Element

        type [<AllowNullLiteral>] MemberStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<MemberSelectors> * ?opt: MemberStaticOpt -> Member

        type [<AllowNullLiteral>] MemberStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Arrow =
            inherit Dia.Link

        type [<AllowNullLiteral>] ArrowStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Arrow

    module Pn =

        type [<AllowNullLiteral>] IExports =
            abstract Place: PlaceStatic
            abstract PlaceView: PlaceViewStatic
            abstract Transition: TransitionStatic
            abstract Link: LinkStatic

        type [<AllowNullLiteral>] Place =
            inherit Basic.Generic

        type [<AllowNullLiteral>] PlaceStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.Attributes * ?opt: PlaceStaticOpt -> Place

        type [<AllowNullLiteral>] PlaceStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] PlaceView =
            inherit Dia.ElementView
            abstract renderTokens: unit -> unit

        type [<AllowNullLiteral>] PlaceViewStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> PlaceView

        type [<AllowNullLiteral>] Transition =
            inherit Basic.Generic

        type [<AllowNullLiteral>] TransitionStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<SVGRectSelector> * ?opt: TransitionStaticOpt -> Transition

        type [<AllowNullLiteral>] TransitionStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Link =
            inherit Dia.Link

        type [<AllowNullLiteral>] LinkStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Link

    module Uml =

        type [<AllowNullLiteral>] IExports =
            abstract Class: ClassStatic
            abstract ClassView: ClassViewStatic
            abstract Abstract: AbstractStatic
            abstract AbstractView: AbstractViewStatic
            abstract Interface: InterfaceStatic
            abstract InterfaceView: InterfaceViewStatic
            abstract Generalization: GeneralizationStatic
            abstract Implementation: ImplementationStatic
            abstract Aggregation: AggregationStatic
            abstract Composition: CompositionStatic
            abstract Association: AssociationStatic
            abstract State: StateStatic
            abstract StartState: StartStateStatic
            abstract EndState: EndStateStatic
            abstract Transition: TransitionStatic

        type [<AllowNullLiteral>] ClassAttributes =
            inherit Dia.Element.GenericAttributes<SVGRectSelector>
            abstract name: ResizeArray<string> with get, set
            abstract attributes: ResizeArray<string> with get, set
            abstract methods: ResizeArray<string> with get, set

        type [<AllowNullLiteral>] Class =
            inherit Basic.Generic
            abstract getClassName: unit -> ResizeArray<string>
            abstract updateRectangles: unit -> unit

        type [<AllowNullLiteral>] ClassStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ClassAttributes * ?opt: ClassStaticOpt -> Class

        type [<AllowNullLiteral>] ClassStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] ClassView =
            inherit Dia.ElementView

        type [<AllowNullLiteral>] ClassViewStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> ClassView

        type [<AllowNullLiteral>] Abstract =
            inherit Class

        type [<AllowNullLiteral>] AbstractStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ClassAttributes * ?opt: AbstractStaticOpt -> Abstract

        type [<AllowNullLiteral>] AbstractStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] AbstractView =
            inherit ClassView

        type [<AllowNullLiteral>] AbstractViewStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ClassAttributes * ?opt: AbstractViewStaticOpt -> AbstractView

        type [<AllowNullLiteral>] AbstractViewStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Interface =
            inherit Class

        type [<AllowNullLiteral>] InterfaceStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ClassAttributes * ?opt: InterfaceStaticOpt -> Interface

        type [<AllowNullLiteral>] InterfaceStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] InterfaceView =
            inherit ClassView

        type [<AllowNullLiteral>] InterfaceViewStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: ClassAttributes * ?opt: InterfaceViewStaticOpt -> InterfaceView

        type [<AllowNullLiteral>] InterfaceViewStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Generalization =
            inherit Dia.Link

        type [<AllowNullLiteral>] GeneralizationStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Generalization

        type [<AllowNullLiteral>] Implementation =
            inherit Dia.Link

        type [<AllowNullLiteral>] ImplementationStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Implementation

        type [<AllowNullLiteral>] Aggregation =
            inherit Dia.Link

        type [<AllowNullLiteral>] AggregationStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Aggregation

        type [<AllowNullLiteral>] Composition =
            inherit Dia.Link

        type [<AllowNullLiteral>] CompositionStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Composition

        type [<AllowNullLiteral>] Association =
            inherit Dia.Link

        type [<AllowNullLiteral>] AssociationStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Association

        type [<AllowNullLiteral>] StateSelectors =
            inherit Dia.Cell.Selectors
            abstract ``.uml-state-body``: Attributes.SVGRectAttributes option with get, set
            abstract ``.uml-state-separator``: Attributes.SVGPathAttributes option with get, set
            abstract ``.uml-state-name``: Attributes.SVGTextAttributes option with get, set
            abstract ``.uml-state-events``: Attributes.SVGTextAttributes option with get, set

        type [<AllowNullLiteral>] State =
            inherit Basic.Generic
            abstract updateName: unit -> unit
            abstract updateEvents: unit -> unit
            abstract updatePath: unit -> unit

        type [<AllowNullLiteral>] StateStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<StateSelectors> * ?opt: StateStaticOpt -> State

        type [<AllowNullLiteral>] StateStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] StartState =
            inherit Basic.Circle

        type [<AllowNullLiteral>] StartStateStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<Basic.CircleSelectors> * ?opt: StartStateStaticOpt -> StartState

        type [<AllowNullLiteral>] StartStateStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] EndStateSelectors =
            inherit Dia.Cell.Selectors
            abstract circle.outer: Attributes.SVGCircleAttributes option with get, set
            abstract circle.inner: Attributes.SVGCircleAttributes option with get, set

        type [<AllowNullLiteral>] EndState =
            inherit Basic.Generic

        type [<AllowNullLiteral>] EndStateStatic =
            [<Emit "new $0($1...)">] abstract Create: ?attributes: Dia.Element.GenericAttributes<EndStateSelectors> * ?opt: EndStateStaticOpt -> EndState

        type [<AllowNullLiteral>] EndStateStaticOpt =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

        type [<AllowNullLiteral>] Transition =
            inherit Dia.Link

        type [<AllowNullLiteral>] TransitionStatic =
            [<Emit "new $0($1...)">] abstract Create: unit -> Transition

module Util =
    let [<Import("filter","jointjs/util")>] filter: Filter.IExports = jsNative
    let [<Import("format","jointjs/util")>] format: Format.IExports = jsNative
    let [<Import("interpolate","jointjs/util")>] interpolate: Interpolate.IExports = jsNative
    let [<Import("timing","jointjs/util")>] timing: Timing.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract hashCode: str: string -> string
        abstract getByPath: ``object``: GetByPathObject * path: U2<string, ResizeArray<string>> * ?delim: string -> obj option
        abstract setByPath: ``object``: SetByPathObject * path: U2<string, ResizeArray<string>> * value: obj option * ?delim: string -> obj option
        abstract unsetByPath: ``object``: UnsetByPathObject * path: U2<string, ResizeArray<string>> * ?delim: string -> obj option
        abstract flattenObject: ``object``: FlattenObjectObject * ?delim: string * ?stop: (obj option -> bool) -> obj option
        abstract uuid: unit -> string
        abstract guid: ?obj: GuidObj -> string
        abstract toKebabCase: str: string -> string
        abstract normalizeEvent: evt: JQuery.Event -> JQuery.Event
        abstract nextFrame: callback: (unit -> unit) * ?context: NextFrameContext -> float
        abstract cancelFrame: requestId: float -> unit
        abstract shapePerimeterConnectionPoint: Dia.LinkView.GetConnectionPoint
        abstract isPercentage: ``val``: obj option -> bool
        abstract parseCssNumeric: ``val``: obj option * restrictUnits: U2<string, ResizeArray<string>> -> TypeLiteral_23 option
        abstract breakText: text: string * size: BreakTextSize * ?attrs: Attributes.NativeSVGAttributes * ?opt: BreakTextOpt -> string
        abstract sanitizeHTML: html: string -> string
        abstract downloadBlob: blob: Blob * fileName: string -> unit
        abstract downloadDataUri: dataUri: string * fileName: string -> unit
        abstract dataUriToBlob: dataUri: string -> Blob
        abstract imageToDataUri: url: string * callback: (Error option -> string -> unit) -> unit
        abstract getElementBBox: el: Element -> Dia.BBox
        abstract sortElements: elements: U3<ResizeArray<Element>, string, JQuery> * comparator: (Element -> Element -> float) -> ResizeArray<Element>
        abstract setAttributesBySelector: el: Element * attrs: SetAttributesBySelectorAttrs -> unit
        abstract normalizeSides: sides: Dia.Sides -> Dia.PaddingJSON
        abstract template: html: string -> (obj option -> string)
        abstract toggleFullScreen: ?el: Element -> unit
        abstract parseDOMJSON: json: Dia.MarkupJSON -> DOMJSONDocument
        abstract ``mixin``: destinationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract deepMixin: destinationObject: obj * sourceObject: obj * ?options: obj -> obj
        abstract assign: destinationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract supplement: destinationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract deepSupplement: destionationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract defaults: destinationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract defaultsDeep: destinationObject: obj * [<ParamArray>] sourceObjects: ResizeArray<obj> -> obj
        abstract invoke: collection: Collection * methodPath: PropertyPath * ?args: ResizeArray<obj option> -> ResizeArray<obj option>
        abstract invoke: collection: Collection * functionToInvokeForAll: IterateeFunction * ?args: ResizeArray<obj option> -> ResizeArray<obj option>
        abstract sortedIndex: sortedArray: ResizeArray<obj option> * valueToInsert: obj option * ?iteratee: Iteratee -> float
        abstract uniq: array: ResizeArray<obj option> * ?iteratee: Iteratee -> ResizeArray<obj option>
        abstract clone: value: 'T -> 'T
        abstract cloneDeep: value: 'T -> 'T
        abstract isEmpty: value: obj option -> bool
        abstract isEqual: value: obj option * otherValue: obj option -> bool
        abstract isFunction: value: obj option -> bool
        abstract isPlainObject: value: obj option -> bool
        abstract toArray: value: obj option -> ResizeArray<obj option>
        abstract debounce: func: Function * ?wait: float * ?options: obj -> Function
        abstract groupBy: collection: Collection * ?iteratee: Iteratee -> obj
        abstract sortBy: collection: Collection * iterateesArray: ResizeArray<Iteratee> -> ResizeArray<obj option>
        abstract flattenDeep: array: ResizeArray<obj option> -> ResizeArray<obj option>
        abstract without: array: ResizeArray<obj option> * [<ParamArray>] values: ResizeArray<obj option> -> ResizeArray<obj option>
        abstract difference: array: ResizeArray<obj option> * [<ParamArray>] excludedValuesArrays: ResizeArray<ResizeArray<obj option>> -> ResizeArray<obj option>
        abstract intersection: [<ParamArray>] arrays: ResizeArray<ResizeArray<obj option>> -> ResizeArray<obj option>
        abstract union: [<ParamArray>] arrays: ResizeArray<ResizeArray<obj option>> -> ResizeArray<obj option>
        abstract has: ``object``: obj * path: PropertyPath -> bool
        abstract result: ``object``: obj * propertyPath: PropertyPath * ?defaultValue: obj -> obj option
        abstract omit: ``object``: obj * [<ParamArray>] propertyPathsToOmit: ResizeArray<PropertyPath> -> obj
        abstract pick: ``object``: obj * [<ParamArray>] propertyPathsToPick: ResizeArray<PropertyPath> -> obj
        abstract bindAll: ``object``: obj * methodNames: ResizeArray<PropertyPath> -> obj
        abstract forIn: ``object``: obj * ?iteratee: Iteratee -> obj
        abstract camelCase: string: string -> string
        abstract uniqueId: ?prefix: string -> string
        abstract merge: destinationObject: obj * sourceObject: obj * ?customizer: CustomizerFunction -> obj
        abstract merge: destinationObject: obj * sourceObject1: obj * sourceObject2: obj * ?customizer: CustomizerFunction -> obj
        abstract merge: destinationObject: obj * sourceObject1: obj * sourceObject2: obj * sourceObject3: obj * ?customizer: CustomizerFunction -> obj
        abstract merge: destinationObject: obj * sourceObject1: obj * sourceObject2: obj * sourceObject3: obj * sourceObject4: obj * ?customizer: CustomizerFunction -> obj
        abstract merge: destinationObject: obj * [<ParamArray>] sourceObjectsOptionalFinalCustomizer: SourceObjectsOptionalFinalCustomizer -> obj
        abstract isBoolean: value: obj option -> bool
        abstract isObject: value: obj option -> bool
        abstract isNumber: value: obj option -> bool
        abstract isString: value: obj option -> bool
        abstract noop: unit -> unit

    type [<AllowNullLiteral>] GetByPathObject =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] SetByPathObject =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] UnsetByPathObject =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] FlattenObjectObject =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] GuidObj =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] NextFrameContext =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] BreakTextSize =
        abstract width: float with get, set
        abstract height: float option with get, set

    type [<AllowNullLiteral>] BreakTextOpt =
        abstract svgDocument: SVGElement option with get, set
        abstract separator: U2<string, obj option> option with get, set
        abstract eol: string option with get, set
        abstract ellipsis: U2<bool, string> option with get, set

    type [<AllowNullLiteral>] SetAttributesBySelectorAttrs =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: selector: string -> TypeLiteral_24 with get, set

    type [<AllowNullLiteral>] DOMJSONDocument =
        abstract fragment: DocumentFragment with get, set
        abstract selectors: TypeLiteral_25 with get, set
        abstract groupSelectors: TypeLiteral_26 with get, set

    module Timing =

        type [<AllowNullLiteral>] IExports =
            abstract linear: TimingFunction
            abstract quad: TimingFunction
            abstract cubic: TimingFunction
            abstract inout: TimingFunction
            abstract exponential: TimingFunction
            abstract bounce: TimingFunction
            abstract reverse: f: TimingFunction -> TimingFunction
            abstract reflect: f: TimingFunction -> TimingFunction
            abstract clamp: f: TimingFunction * ?min: float * ?max: float -> TimingFunction
            abstract back: ?s: float -> TimingFunction
            abstract elastic: ?x: float -> TimingFunction

        type [<AllowNullLiteral>] TimingFunction =
            [<Emit "$0($1...)">] abstract Invoke: time: float -> float

    module Interpolate =

        type [<AllowNullLiteral>] IExports =
            abstract number: InterpolateFunction<float>
            abstract ``object``: InterpolateFunction<TypeLiteral_15>
            abstract hexColor: InterpolateFunction<string>
            abstract unit: InterpolateFunction<string>

        type [<AllowNullLiteral>] InterpolateFunction<'T> =
            [<Emit "$0($1...)">] abstract Invoke: start: 'T * ``end``: 'T -> (float -> 'T)

        type [<AllowNullLiteral>] TypeLiteral_15 =
            [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    module Filter =

        type [<AllowNullLiteral>] IExports =
            abstract outline: FilterFunction<string>
            abstract highlight: FilterFunction<string>
            abstract blur: FilterFunction<string>
            abstract dropShadow: FilterFunction<string>
            abstract grayscale: FilterFunction<string>
            abstract sepia: FilterFunction<string>
            abstract saturate: FilterFunction<string>
            abstract hueRotate: FilterFunction<string>
            abstract invert: FilterFunction<string>
            abstract brightness: FilterFunction<string>
            abstract contrast: FilterFunction<string>

        type [<AllowNullLiteral>] FilterArgumentsMap =
            abstract outline: TypeLiteral_16 with get, set
            abstract highlight: TypeLiteral_17 with get, set
            abstract blur: TypeLiteral_18 with get, set
            abstract dropShadow: TypeLiteral_19 with get, set
            abstract grayscale: TypeLiteral_20 with get, set
            abstract sepia: TypeLiteral_20 with get, set
            abstract saturate: TypeLiteral_20 with get, set
            abstract hueRotate: TypeLiteral_21 with get, set
            abstract invert: TypeLiteral_20 with get, set
            abstract brightness: TypeLiteral_20 with get, set
            abstract contrast: TypeLiteral_20 with get, set

        type [<AllowNullLiteral>] FilterFunction<'K> =
            [<Emit "$0($1...)">] abstract Invoke: args: FilterArgumentsMap -> string

        type [<AllowNullLiteral>] TypeLiteral_20 =
            abstract amount: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_21 =
            abstract angle: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_17 =
            abstract color: string option with get, set
            abstract blur: float option with get, set
            abstract opacity: float option with get, set
            abstract width: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_16 =
            abstract color: string option with get, set
            abstract opacity: float option with get, set
            abstract margin: float option with get, set
            abstract width: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_19 =
            abstract dx: float option with get, set
            abstract dy: float option with get, set
            abstract opacity: float option with get, set
            abstract color: string option with get, set
            abstract blur: float option with get, set

        type [<AllowNullLiteral>] TypeLiteral_18 =
            abstract x: float option with get, set
            abstract y: float option with get, set

    module Format =

        type [<AllowNullLiteral>] IExports =
            abstract number: specifier: string * value: float * ?locale: NumberLocale -> string
            abstract string: str: string * value: string -> string
            abstract convert: ``type``: string * value: float * precision: float -> string
            abstract round: value: float * ?precision: float -> float
            abstract precision: value: float * precision: float -> float
            abstract prefix: value: float * precision: float -> TypeLiteral_22 option

        type [<AllowNullLiteral>] NumberLocale =
            abstract currency: string * string with get, set
            abstract decimal: string with get, set
            abstract thousands: string with get, set
            abstract grouping: ResizeArray<float> with get, set

        type [<AllowNullLiteral>] TypeLiteral_22 =
            abstract scale: (float -> float) with get, set
            abstract symbol: string with get, set

    type NotVoid =
        U0<> option

    type Collection =
        U2<obj, ResizeArray<obj option>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Collection =
        let ofObj v: Collection = v |> U2.Case1
        let isObj (v: Collection) = match v with U2.Case1 _ -> true | _ -> false
        let asObj (v: Collection) = match v with U2.Case1 o -> Some o | _ -> None
        let ofCase2 v: Collection = v |> U2.Case2
        let isCase2 (v: Collection) = match v with U2.Case2 _ -> true | _ -> false
        let asCase2 (v: Collection) = match v with U2.Case2 o -> Some o | _ -> None

    type PropertyPath =
        U2<string, ResizeArray<string>>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module PropertyPath =
        let ofString v: PropertyPath = v |> U2.Case1
        let isString (v: PropertyPath) = match v with U2.Case1 _ -> true | _ -> false
        let asString (v: PropertyPath) = match v with U2.Case1 o -> Some o | _ -> None
        let ofStringArray v: PropertyPath = v |> U2.Case2
        let isStringArray (v: PropertyPath) = match v with U2.Case2 _ -> true | _ -> false
        let asStringArray (v: PropertyPath) = match v with U2.Case2 o -> Some o | _ -> None

    type Iteratee =
        U2<IterateeFunction, IterateeShorthand>

    [<RequireQualifiedAccess; CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
    module Iteratee =
        let ofIterateeFunction v: Iteratee = v |> U2.Case1
        let isIterateeFunction (v: Iteratee) = match v with U2.Case1 _ -> true | _ -> false
        let asIterateeFunction (v: Iteratee) = match v with U2.Case1 o -> Some o | _ -> None
        let ofIterateeShorthand v: Iteratee = v |> U2.Case2
        let isIterateeShorthand (v: Iteratee) = match v with U2.Case2 _ -> true | _ -> false
        let asIterateeShorthand (v: Iteratee) = match v with U2.Case2 o -> Some o | _ -> None

    type [<AllowNullLiteral>] IterateeFunction =
        [<Emit "$0($1...)">] abstract Invoke: value: obj option -> NotVoid

    type IterateeShorthand =
        PropertyPath

    type SourceObjectsOptionalFinalCustomizer =
        Array<U2<obj, CustomizerFunction>>

    type [<AllowNullLiteral>] CustomizerFunction =
        [<Emit "$0($1...)">] abstract Invoke: objValue: obj option * srcValue: obj option * key: string * ``object``: obj option * source: obj option * stack: obj option -> NotVoid

    type [<AllowNullLiteral>] TypeLiteral_23 =
        abstract value: float with get, set
        abstract unit: string option with get, set

    type [<AllowNullLiteral>] TypeLiteral_24 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: attribute: string -> obj option with get, set

    type [<AllowNullLiteral>] TypeLiteral_26 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> ResizeArray<Element> with get, set

    type [<AllowNullLiteral>] TypeLiteral_25 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Element with get, set

module Env =

    type [<AllowNullLiteral>] IExports =
        abstract addTest: name: string * fn: (unit -> bool) -> unit
        abstract test: name: string -> bool

module Layout =
    let [<Import("DirectedGraph","jointjs/layout")>] directedGraph: DirectedGraph.IExports = jsNative

    module DirectedGraph =

        type [<AllowNullLiteral>] IExports =
            abstract layout: graph: U2<Dia.Graph, ResizeArray<Dia.Cell>> * ?opt: LayoutOptions -> G.Rect

        type [<AllowNullLiteral>] Edge =
            abstract minLen: float option with get, set
            abstract weight: float option with get, set
            abstract labelpos: U3<string, string, string> option with get, set
            abstract labeloffset: float option with get, set
            abstract width: float option with get, set
            abstract height: float option with get, set

        type [<AllowNullLiteral>] Node =
            abstract width: float option with get, set
            abstract height: float option with get, set

        type [<AllowNullLiteral>] LayoutOptions =
            abstract rankDir: U4<string, string, string, string> option with get, set
            abstract ranker: U3<string, string, string> option with get, set
            abstract nodeSep: float option with get, set
            abstract edgeSep: float option with get, set
            abstract rankSep: float option with get, set
            abstract marginX: float option with get, set
            abstract marginY: float option with get, set
            abstract resizeClusters: bool option with get, set
            abstract clusterPadding: Dia.Padding option with get, set
            abstract setPosition: (Dia.Element -> Dia.BBox -> unit) option with get, set
            abstract setVertices: U2<bool, (Dia.Link -> ResizeArray<Dia.Point> -> unit)> option with get, set
            abstract setLabels: U2<bool, (Dia.Link -> Dia.Point -> ResizeArray<Dia.Point> -> unit)> option with get, set
            abstract debugTiming: bool option with get, set
            abstract exportElement: (Dia.Element -> Node) option with get, set
            abstract exportLink: (Dia.Link -> Edge) option with get, set
            abstract setLinkVertices: bool option with get, set

module Mvc =

    type [<AllowNullLiteral>] IExports =
        abstract View: ViewStatic

    type [<AllowNullLiteral>] ViewOptions<'T> =
        inherit Backbone.ViewOptions<'T>
        abstract theme: string option with get, set

    type [<AllowNullLiteral>] viewEventData =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] View<'T> =
        inherit Backbone.View<'T>
        abstract theme: string with get, set
        abstract themeClassNamePrefix: string with get, set
        abstract defaultTheme: string with get, set
        abstract requireSetThemeOverride: bool with get, set
        abstract documentEvents: Backbone.EventsHash option with get, set
        abstract children: Dia.MarkupJSON option with get, set
        abstract setTheme: theme: string * ?opt: ViewSetThemeOpt -> View<'T>
        abstract getEventNamespace: unit -> string
        abstract delegateDocumentEvents: ?events: Backbone.EventsHash * ?data: viewEventData -> View<'T>
        abstract undelegateDocumentEvents: unit -> View<'T>
        abstract eventData: evt: JQuery.Event -> viewEventData
        abstract eventData: evt: JQuery.Event * data: viewEventData -> View<'T>
        abstract renderChildren: ?children: Dia.MarkupJSON -> View<'T>
        abstract findAttribute: attributeName: string * node: Element -> string option
        abstract init: unit -> unit
        abstract onRender: unit -> unit
        abstract onSetTheme: oldTheme: string * newTheme: string -> unit
        abstract onRemove: unit -> unit

    type [<AllowNullLiteral>] ViewSetThemeOpt =
        abstract ``override``: bool option with get, set

    type [<AllowNullLiteral>] ViewStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: ViewOptions<'T> -> View<'T>

module Routers =

    type [<AllowNullLiteral>] IExports =
        abstract manhattan: GenericRouter<string>
        abstract metro: GenericRouter<string>
        abstract normal: GenericRouter<string>
        abstract orthogonal: GenericRouter<string>
        abstract oneSide: GenericRouter<string>

    type [<AllowNullLiteral>] NormalRouterArguments =
        interface end

    type [<AllowNullLiteral>] ManhattanRouterArguments =
        abstract step: float option with get, set
        abstract padding: Dia.Sides option with get, set
        abstract maximumLoops: float option with get, set
        abstract maxAllowedDirectionChange: float option with get, set
        abstract perpendicular: bool option with get, set
        abstract excludeEnds: ResizeArray<Dia.LinkEnd> option with get, set
        abstract excludeTypes: ResizeArray<string> option with get, set
        abstract startDirections: ResizeArray<Dia.OrthogonalDirection> option with get, set
        abstract endDirections: ResizeArray<Dia.OrthogonalDirection> option with get, set

    type [<AllowNullLiteral>] OrthogonalRouterArguments =
        abstract elementPadding: float option with get, set
        abstract padding: Dia.Sides option with get, set

    type [<AllowNullLiteral>] OneSideRouterArguments =
        abstract side: Dia.OrthogonalDirection option with get, set
        abstract padding: Dia.Sides option with get, set

    type [<AllowNullLiteral>] RouterArgumentsMap =
        abstract normal: NormalRouterArguments with get, set
        abstract manhattan: ManhattanRouterArguments with get, set
        abstract metro: ManhattanRouterArguments with get, set
        abstract orthogonal: OrthogonalRouterArguments with get, set
        abstract oneSide: OneSideRouterArguments with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TypeLiteral_27 with get, set

    type RouterType =
        obj

    type GenericRouterArguments<'K> =
        RouterArgumentsMap

    type [<AllowNullLiteral>] GenericRouter<'K> =
        [<Emit "$0($1...)">] abstract Invoke: vertices: ResizeArray<Dia.Point> * ?args: GenericRouterArguments<'K> * ?linkView: Dia.LinkView -> ResizeArray<Dia.Point>

    type [<AllowNullLiteral>] GenericRouterJSON<'K> =
        abstract name: 'K with get, set
        abstract args: GenericRouterArguments<'K> option with get, set

    type RouterArguments =
        GenericRouterArguments<RouterType>

    type Router =
        GenericRouter<RouterType>

    type RouterJSON =
        GenericRouterJSON<RouterType>

    type [<AllowNullLiteral>] TypeLiteral_27 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module Connectors =

    type [<AllowNullLiteral>] IExports =
        abstract normal: GenericConnector<string>
        abstract rounded: GenericConnector<string>
        abstract smooth: GenericConnector<string>
        abstract jumpover: GenericConnector<string>

    type [<AllowNullLiteral>] NormalConnectorArguments =
        abstract raw: bool option with get, set

    type [<AllowNullLiteral>] RoundedConnectorArguments =
        abstract raw: bool option with get, set
        abstract radius: float option with get, set

    type [<AllowNullLiteral>] SmoothConnectorArguments =
        abstract raw: bool option with get, set

    type [<AllowNullLiteral>] JumpOverConnectorArguments =
        abstract raw: bool option with get, set
        abstract size: float option with get, set
        abstract jump: U3<string, string, string> option with get, set

    type [<AllowNullLiteral>] ConnectorArgumentsMap =
        abstract normal: NormalConnectorArguments with get, set
        abstract rounded: RoundedConnectorArguments with get, set
        abstract smooth: SmoothConnectorArguments with get, set
        abstract jumpover: JumpOverConnectorArguments with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TypeLiteral_28 with get, set

    type ConnectorType =
        obj

    type GenericConnectorArguments<'K> =
        ConnectorArgumentsMap

    type [<AllowNullLiteral>] GenericConnector<'K> =
        [<Emit "$0($1...)">] abstract Invoke: sourcePoint: Dia.Point * targetPoint: Dia.Point * routePoints: ResizeArray<Dia.Point> * ?args: GenericConnectorArguments<'K> -> U2<string, G.Path>

    type [<AllowNullLiteral>] GenericConnectorJSON<'K> =
        abstract name: 'K with get, set
        abstract args: GenericConnectorArguments<'K> option with get, set

    type ConnectorArguments =
        GenericConnectorArguments<ConnectorType>

    type Connector =
        GenericConnector<ConnectorType>

    type ConnectorJSON =
        GenericConnectorJSON<ConnectorType>

    type [<AllowNullLiteral>] TypeLiteral_28 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module Anchors =

    type [<AllowNullLiteral>] IExports =
        abstract center: GenericAnchor<string>
        abstract top: GenericAnchor<string>
        abstract bottom: GenericAnchor<string>
        abstract left: GenericAnchor<string>
        abstract right: GenericAnchor<string>
        abstract topLeft: GenericAnchor<string>
        abstract topRight: GenericAnchor<string>
        abstract bottomLeft: GenericAnchor<string>
        abstract bottomRight: GenericAnchor<string>
        abstract perpendicular: GenericAnchor<string>
        abstract midSide: GenericAnchor<string>

    type [<AllowNullLiteral>] RotateAnchorArguments =
        abstract rotate: bool option with get, set

    type [<AllowNullLiteral>] BBoxAnchorArguments =
        inherit RotateAnchorArguments
        abstract dx: U2<float, string> option with get, set
        abstract dy: U2<float, string> option with get, set

    type [<AllowNullLiteral>] PaddingAnchorArguments =
        abstract padding: float option with get, set

    type [<AllowNullLiteral>] MidSideAnchorArguments =
        inherit RotateAnchorArguments
        inherit PaddingAnchorArguments

    type [<AllowNullLiteral>] ModelCenterAnchorArguments =
        interface end

    type [<AllowNullLiteral>] AnchorArgumentsMap =
        abstract center: BBoxAnchorArguments with get, set
        abstract top: BBoxAnchorArguments with get, set
        abstract bottom: BBoxAnchorArguments with get, set
        abstract left: BBoxAnchorArguments with get, set
        abstract right: BBoxAnchorArguments with get, set
        abstract topLeft: BBoxAnchorArguments with get, set
        abstract topRight: BBoxAnchorArguments with get, set
        abstract bottomLeft: BBoxAnchorArguments with get, set
        abstract bottomRight: BBoxAnchorArguments with get, set
        abstract perpendicular: PaddingAnchorArguments with get, set
        abstract midSide: MidSideAnchorArguments with get, set
        abstract modelCenter: ModelCenterAnchorArguments with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TypeLiteral_29 with get, set

    type AnchorType =
        obj

    type GenericAnchorArguments<'K> =
        AnchorArgumentsMap

    type [<AllowNullLiteral>] GenericAnchor<'K> =
        [<Emit "$0($1...)">] abstract Invoke: endView: Dia.CellView * endMagnet: SVGElement * anchorReference: U2<G.Point, SVGElement> * opt: AnchorArgumentsMap -> G.Point

    type [<AllowNullLiteral>] GenericAnchorJSON<'K> =
        abstract name: 'K with get, set
        abstract args: AnchorArgumentsMap option with get, set

    type AnchorArguments =
        GenericAnchorArguments<AnchorType>

    type Anchor =
        GenericAnchor<AnchorType>

    type AnchorJSON =
        GenericAnchorJSON<AnchorType>

    type [<AllowNullLiteral>] TypeLiteral_29 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module ConnectionPoints =

    type [<AllowNullLiteral>] IExports =
        abstract anchor: GenericConnectionPoint<string>
        abstract bbox: GenericConnectionPoint<string>
        abstract rectangle: GenericConnectionPoint<string>
        abstract boundary: GenericConnectionPoint<string>

    type [<AllowNullLiteral>] DefaultConnectionPointArguments =
        abstract offset: float option with get, set

    type [<AllowNullLiteral>] StrokeConnectionPointArguments =
        inherit DefaultConnectionPointArguments
        abstract stroke: bool option with get, set

    type [<AllowNullLiteral>] BoundaryConnectionPointArguments =
        inherit StrokeConnectionPointArguments
        abstract selector: U2<Array<U2<string, float>>, string> option with get, set
        abstract precision: float option with get, set
        abstract extrapolate: bool option with get, set
        abstract sticky: bool option with get, set
        abstract insideout: bool option with get, set

    type [<AllowNullLiteral>] ConnectionPointArgumentsMap =
        abstract anchor: DefaultConnectionPointArguments with get, set
        abstract bbox: StrokeConnectionPointArguments with get, set
        abstract rectangle: StrokeConnectionPointArguments with get, set
        abstract boundary: BoundaryConnectionPointArguments with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TypeLiteral_30 with get, set

    type ConnectionPointType =
        obj

    type GenericConnectionPointArguments<'K> =
        ConnectionPointArgumentsMap

    type [<AllowNullLiteral>] GenericConnectionPoint<'K> =
        [<Emit "$0($1...)">] abstract Invoke: endPathSegmentLine: G.Line * endView: Dia.CellView * endMagnet: SVGElement * opt: ConnectionPointArgumentsMap -> G.Point

    type [<AllowNullLiteral>] GenericConnectionPointJSON<'K> =
        abstract name: 'K with get, set
        abstract args: ConnectionPointArgumentsMap option with get, set

    type ConnectionPointArguments =
        GenericConnectionPointArguments<ConnectionPointType>

    type ConnectionPoint =
        GenericConnectionPoint<ConnectionPointType>

    type ConnectionPointJSON =
        GenericConnectionPointJSON<ConnectionPointType>

    type [<AllowNullLiteral>] TypeLiteral_30 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module Highlighters =

    type [<AllowNullLiteral>] IExports =
        abstract addClass: GenericHighlighter<string>
        abstract opacity: GenericHighlighter<string>
        abstract stroke: GenericHighlighter<string>

    type [<AllowNullLiteral>] AddClassHighlighterArguments =
        abstract className: string option with get, set

    type [<AllowNullLiteral>] OpacityHighlighterArguments =
        interface end

    type [<AllowNullLiteral>] StrokeHighlighterArguments =
        abstract padding: float option with get, set
        abstract rx: float option with get, set
        abstract ry: float option with get, set
        abstract attrs: Attributes.NativeSVGAttributes option with get, set

    type [<AllowNullLiteral>] HighlighterArgumentsMap =
        abstract addClass: AddClassHighlighterArguments with get, set
        abstract opacity: OpacityHighlighterArguments with get, set
        abstract stroke: StrokeHighlighterArguments with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> TypeLiteral_31 with get, set

    type HighlighterType =
        obj

    type GenericHighlighterArguments<'K> =
        HighlighterArgumentsMap

    type [<AllowNullLiteral>] GenericHighlighter<'K> =
        abstract highlight: cellView: Dia.CellView * magnetEl: SVGElement * ?opt: GenericHighlighterArguments<'K> -> unit
        abstract unhighlight: cellView: Dia.CellView * magnetEl: SVGElement * ?opt: GenericHighlighterArguments<'K> -> unit

    type [<AllowNullLiteral>] GenericHighlighterJSON<'K> =
        abstract name: 'K with get, set
        abstract options: GenericHighlighterArguments<'K> option with get, set

    type HighlighterArguments =
        GenericHighlighterArguments<HighlighterType>

    type Highlighter =
        GenericHighlighter<HighlighterType>

    type HighlighterJSON =
        GenericHighlighterJSON<HighlighterType>

    type [<AllowNullLiteral>] TypeLiteral_31 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module ConnectionStrategies =

    type [<AllowNullLiteral>] IExports =
        abstract useDefaults: ConnectionStrategy
        abstract pinAbsolute: ConnectionStrategy
        abstract pinRelative: ConnectionStrategy

    type [<AllowNullLiteral>] ConnectionStrategy =
        [<Emit "$0($1...)">] abstract Invoke: endDefinition: Dia.Cell * endView: Dia.CellView * endMagnet: SVGElement * coords: Dia.Point -> Dia.Element

module Attributes =

    type [<AllowNullLiteral>] SVGCoreAttributes =
        abstract id: string option with get, set
        abstract xml:base: string option with get, set
        abstract xml:lang: string option with get, set
        abstract xml:space: string option with get, set
        abstract tabindex: float option with get, set

    type [<AllowNullLiteral>] SVGConditionalProcessingAttributes =
        abstract requiredExtensions: bool option with get, set
        abstract requiredFeatures: string option with get, set
        abstract systemLanguage: string option with get, set

    type [<AllowNullLiteral>] SVGXLinkAttributes =
        abstract xlink:href: string option with get, set
        abstract xlink:type: string option with get, set
        abstract xlink:role: string option with get, set
        abstract xlink:arcrole: string option with get, set
        abstract xlink:title: string option with get, set
        abstract xlink:show: string option with get, set
        abstract xlink:actuate: string option with get, set

    type [<AllowNullLiteral>] SVGPresentationAttributes =
        abstract ``alignment-baseline``: obj option with get, set
        abstract ``baseline-shift``: obj option with get, set
        abstract clip: obj option with get, set
        abstract ``clip-path``: obj option with get, set
        abstract ``clip-rule``: obj option with get, set
        abstract color: obj option with get, set
        abstract ``color-interpolation``: obj option with get, set
        abstract ``color-interpolation-filters``: obj option with get, set
        abstract ``color-profile``: obj option with get, set
        abstract ``color-rendering``: obj option with get, set
        abstract cursor: obj option with get, set
        abstract direction: obj option with get, set
        abstract display: obj option with get, set
        abstract ``dominant-baseline``: obj option with get, set
        abstract ``enable-background``: obj option with get, set
        abstract fill: obj option with get, set
        abstract ``fill-opacity``: obj option with get, set
        abstract ``fill-rule``: obj option with get, set
        abstract filter: obj option with get, set
        abstract ``flood-color``: obj option with get, set
        abstract ``flood-opacity``: obj option with get, set
        abstract ``font-family``: obj option with get, set
        abstract ``font-size``: obj option with get, set
        abstract ``font-size-adjust``: obj option with get, set
        abstract ``font-stretch``: obj option with get, set
        abstract ``font-style``: obj option with get, set
        abstract ``font-variant``: obj option with get, set
        abstract ``font-weight``: obj option with get, set
        abstract ``glyph-orientation-horizontal``: obj option with get, set
        abstract ``glyph-orientation-vertical``: obj option with get, set
        abstract ``image-rendering``: obj option with get, set
        abstract kerning: obj option with get, set
        abstract ``letter-spacing``: obj option with get, set
        abstract ``lighting-color``: obj option with get, set
        abstract ``marker-end``: obj option with get, set
        abstract ``marker-mid``: obj option with get, set
        abstract ``marker-start``: obj option with get, set
        abstract mask: obj option with get, set
        abstract opacity: obj option with get, set
        abstract overflow: obj option with get, set
        abstract ``pointer-events``: obj option with get, set
        abstract ``shape-rendering``: obj option with get, set
        abstract ``stop-color``: obj option with get, set
        abstract ``stop-opacity``: obj option with get, set
        abstract stroke: obj option with get, set
        abstract ``stroke-dasharray``: obj option with get, set
        abstract ``stroke-dashoffset``: obj option with get, set
        abstract ``stroke-linecap``: obj option with get, set
        abstract ``stroke-linejoin``: obj option with get, set
        abstract ``stroke-miterlimit``: obj option with get, set
        abstract ``stroke-opacity``: obj option with get, set
        abstract ``stroke-width``: obj option with get, set
        abstract ``text-anchor``: obj option with get, set
        abstract ``text-decoration``: obj option with get, set
        abstract ``text-rendering``: obj option with get, set
        abstract ``unicode-bidi``: obj option with get, set
        abstract visibility: obj option with get, set
        abstract ``word-spacing``: obj option with get, set
        abstract ``writing-mode``: obj option with get, set

    type [<AllowNullLiteral>] NativeSVGAttributes =
        inherit SVGCoreAttributes
        inherit SVGPresentationAttributes
        inherit SVGConditionalProcessingAttributes
        inherit SVGXLinkAttributes
        abstract ``class``: string option with get, set
        abstract style: obj option with get, set
        abstract transform: string option with get, set
        abstract externalResourcesRequired: bool option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] SVGAttributeTextWrap =
        abstract text: string option with get, set
        abstract width: U2<string, float> option with get, set
        abstract height: U2<string, float> option with get, set
        abstract ellipsis: U2<bool, string> option with get, set
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

    type [<AllowNullLiteral>] SVGAttributes =
        inherit NativeSVGAttributes
        abstract filter: U2<string, TypeLiteral_32> option with get, set
        abstract fill: U2<string, TypeLiteral_32> option with get, set
        abstract stroke: U2<string, TypeLiteral_32> option with get, set
        abstract sourceMarker: TypeLiteral_32 option with get, set
        abstract targetMarker: TypeLiteral_32 option with get, set
        abstract vertexMarker: TypeLiteral_32 option with get, set
        abstract text: string option with get, set
        abstract textWrap: SVGAttributeTextWrap option with get, set
        abstract lineHeight: U2<float, string> option with get, set
        abstract textPath: obj option with get, set
        abstract annotations: obj option with get, set
        abstract port: U2<string, TypeLiteral_32> option with get, set
        abstract style: TypeLiteral_32 option with get, set
        abstract html: string option with get, set
        abstract ref: string option with get, set
        abstract refX: U2<string, float> option with get, set
        abstract refY: U2<string, float> option with get, set
        abstract refX2: U2<string, float> option with get, set
        abstract refY2: U2<string, float> option with get, set
        abstract refDx: U2<string, float> option with get, set
        abstract refDy: U2<string, float> option with get, set
        abstract refWidth: U2<string, float> option with get, set
        abstract refHeight: U2<string, float> option with get, set
        abstract refRx: U2<string, float> option with get, set
        abstract refRy: U2<string, float> option with get, set
        abstract refR: U2<string, float> option with get, set
        abstract refRInscribed: U2<string, float> option with get, set
        abstract refRCircumscribed: U2<string, float> option with get, set
        abstract refCx: U2<string, float> option with get, set
        abstract refCy: U2<string, float> option with get, set
        abstract refD: string option with get, set
        abstract refDResetOffset: string option with get, set
        abstract refDKeepOffset: string option with get, set
        abstract refPoints: string option with get, set
        abstract refPointsResetOffset: string option with get, set
        abstract refPointsKeepOffset: string option with get, set
        abstract resetOffset: bool option with get, set
        abstract xAlignment: U4<string, string, float, string> option with get, set
        abstract yAlignment: U4<string, string, float, string> option with get, set
        abstract ``event``: string option with get, set
        abstract magnet: U2<bool, string> option with get, set
        abstract title: string option with get, set
        abstract textVerticalAnchor: U5<string, string, string, float, string> option with get, set
        abstract connection: bool option with get, set
        abstract atConnectionLength: float option with get, set
        abstract atConnectionLengthKeepGradient: float option with get, set
        abstract atConnectionLengthIgnoreGradient: float option with get, set
        abstract atConnectionRatio: float option with get, set
        abstract atConnectionRatioKeepGradient: float option with get, set
        abstract atConnectionRatioIgnoreGradient: float option with get, set
        abstract alignmentBaseline: obj option with get, set
        abstract baselineShift: obj option with get, set
        abstract clipPath: obj option with get, set
        abstract clipRule: obj option with get, set
        abstract colorInterpolation: obj option with get, set
        abstract colorInterpolationFilters: obj option with get, set
        abstract colorProfile: obj option with get, set
        abstract colorRendering: obj option with get, set
        abstract dominantBaseline: obj option with get, set
        abstract enableBackground: obj option with get, set
        abstract fillOpacity: obj option with get, set
        abstract fillRule: obj option with get, set
        abstract floodColor: obj option with get, set
        abstract floodOpacity: obj option with get, set
        abstract fontFamily: obj option with get, set
        abstract fontSize: obj option with get, set
        abstract fontSizeAdjust: obj option with get, set
        abstract fontStretch: obj option with get, set
        abstract fontStyle: obj option with get, set
        abstract fontVariant: obj option with get, set
        abstract fontWeight: obj option with get, set
        abstract glyphOrientationHorizontal: obj option with get, set
        abstract glyphOrientationVertical: obj option with get, set
        abstract imageRendering: obj option with get, set
        abstract letterSpacing: obj option with get, set
        abstract lightingColor: obj option with get, set
        abstract markerEnd: obj option with get, set
        abstract markerMid: obj option with get, set
        abstract markerStart: obj option with get, set
        abstract pointerEvents: obj option with get, set
        abstract shapeRendering: obj option with get, set
        abstract stopColor: obj option with get, set
        abstract stopOpacity: obj option with get, set
        abstract strokeDasharray: obj option with get, set
        abstract strokeDashoffset: obj option with get, set
        abstract strokeLinecap: obj option with get, set
        abstract strokeLinejoin: obj option with get, set
        abstract strokeMiterlimit: obj option with get, set
        abstract strokeOpacity: obj option with get, set
        abstract strokeWidth: obj option with get, set
        abstract textAnchor: obj option with get, set
        abstract textDecoration: obj option with get, set
        abstract textRendering: obj option with get, set
        abstract unicodeBidi: obj option with get, set
        abstract wordSpacing: obj option with get, set
        abstract writingMode: obj option with get, set
        abstract xlinkHref: string option with get, set
        abstract xlinkShow: string option with get, set
        abstract xlinkType: string option with get, set
        abstract xlinkRole: string option with get, set
        abstract xlinkArcrole: string option with get, set
        abstract xlinkTitle: string option with get, set
        abstract xlinkActuate: string option with get, set
        abstract xmlSpace: string option with get, set
        abstract xmlBase: string option with get, set
        abstract xmlLang: string option with get, set
        abstract ``ref-x``: U2<string, float> option with get, set
        abstract ``ref-y``: U2<string, float> option with get, set
        abstract ``ref-dx``: U2<string, float> option with get, set
        abstract ``ref-dy``: U2<string, float> option with get, set
        abstract ``ref-width``: U2<string, float> option with get, set
        abstract ``ref-height``: U2<string, float> option with get, set
        abstract ``x-alignment``: U4<string, string, float, string> option with get, set
        abstract ``y-alignment``: U4<string, string, float, string> option with get, set

    type [<AllowNullLiteral>] SVGTextAttributes =
        inherit SVGAttributes
        abstract x: U2<string, float> option with get, set
        abstract y: U2<string, float> option with get, set
        abstract dx: U2<string, float> option with get, set
        abstract dy: U2<string, float> option with get, set
        abstract rotate: string option with get, set
        abstract textAnchor: string option with get, set
        abstract textLength: float option with get, set
        abstract lengthAdjust: string option with get, set
        abstract ``text-anchor``: string option with get, set
        abstract ``text-lenght``: float option with get, set
        abstract ``length-adjust``: string option with get, set

    type [<AllowNullLiteral>] SVGRectAttributes =
        inherit SVGAttributes
        abstract x: U2<string, float> option with get, set
        abstract y: U2<string, float> option with get, set
        abstract width: U2<string, float> option with get, set
        abstract height: U2<string, float> option with get, set
        abstract ry: U2<string, float> option with get, set
        abstract rx: U2<string, float> option with get, set

    type [<AllowNullLiteral>] SVGCircleAttributes =
        inherit SVGAttributes
        abstract cx: U2<string, float> option with get, set
        abstract cy: U2<string, float> option with get, set
        abstract r: U2<string, float> option with get, set

    type [<AllowNullLiteral>] SVGEllipseAttributes =
        inherit SVGAttributes
        abstract cx: U2<string, float> option with get, set
        abstract cy: U2<string, float> option with get, set
        abstract rx: U2<string, float> option with get, set
        abstract ry: U2<string, float> option with get, set

    type [<AllowNullLiteral>] SVGPolygonAttributes =
        inherit SVGAttributes
        abstract points: string option with get, set

    type [<AllowNullLiteral>] SVGPolylineAttributes =
        inherit SVGAttributes
        abstract points: string option with get, set

    type [<AllowNullLiteral>] SVGImageAttributes =
        inherit SVGAttributes
        abstract x: U2<string, float> option with get, set
        abstract y: U2<string, float> option with get, set
        abstract width: U2<string, float> option with get, set
        abstract height: U2<string, float> option with get, set
        abstract preserveAspectRatio: string option with get, set

    type [<AllowNullLiteral>] SVGPathAttributes =
        inherit SVGAttributes
        abstract d: string option with get, set
        abstract pathLength: float option with get, set
        abstract ``path-length``: float option with get, set

    type [<AllowNullLiteral>] TypeLiteral_32 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module LinkTools =

    type [<AllowNullLiteral>] IExports =
        abstract Vertices: VerticesStatic
        abstract Segments: SegmentsStatic
        abstract Arrowhead: ArrowheadStatic
        abstract SourceArrowhead: SourceArrowheadStatic
        abstract TargetArrowhead: TargetArrowheadStatic
        abstract Anchor: AnchorStatic
        abstract SourceAnchor: SourceAnchorStatic
        abstract TargetAnchor: TargetAnchorStatic
        abstract Button: ButtonStatic
        abstract Remove: RemoveStatic
        abstract Boundary: BoundaryStatic

    type [<AllowNullLiteral>] AnchorCallback<'T> =
        [<Emit "$0($1...)">] abstract Invoke: coords: G.Point * view: Dia.CellView * magnet: SVGElement * ``type``: string * linkView: Dia.LinkView * toolView: Dia.ToolView -> 'T

    module Vertices =

        type [<AllowNullLiteral>] Options =
            inherit Dia.ToolView.Options
            abstract snapRadius: float option with get, set
            abstract redundancyRemoval: bool option with get, set
            abstract vertexAdding: bool option with get, set

    type [<AllowNullLiteral>] Vertices =
        inherit Dia.ToolView

    type [<AllowNullLiteral>] VerticesStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: Vertices.Options -> Vertices

    module Segments =

        type [<AllowNullLiteral>] Options =
            inherit Dia.ToolView.Options
            abstract snapRadius: float option with get, set
            abstract snapHandle: bool option with get, set
            abstract redundancyRemoval: bool option with get, set
            abstract segmentLengthThreshold: float option with get, set
            abstract anchor: AnchorCallback<Anchors.AnchorJSON> option with get, set

    type [<AllowNullLiteral>] Segments =
        inherit Dia.ToolView

    type [<AllowNullLiteral>] SegmentsStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: Segments.Options -> Segments

    type [<AllowNullLiteral>] Arrowhead =
        inherit Dia.ToolView
        abstract ratio: float with get, set
        abstract arrowheadType: string with get, set
        abstract onPointerDown: evt: JQuery.Event -> unit
        abstract onPointerMove: evt: JQuery.Event -> unit
        abstract onPointerUp: evt: JQuery.Event -> unit

    type [<AllowNullLiteral>] ArrowheadStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Arrowhead

    type [<AllowNullLiteral>] SourceArrowhead =
        inherit Arrowhead

    type [<AllowNullLiteral>] SourceArrowheadStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SourceArrowhead

    type [<AllowNullLiteral>] TargetArrowhead =
        inherit Arrowhead

    type [<AllowNullLiteral>] TargetArrowheadStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> TargetArrowhead

    module Anchor =

        type [<AllowNullLiteral>] Options =
            inherit Dia.ToolView.Options
            abstract snap: AnchorCallback<Dia.Point> option with get, set
            abstract anchor: AnchorCallback<Anchors.AnchorJSON> option with get, set
            abstract customAnchorAttributes: Attributes.NativeSVGAttributes option with get, set
            abstract defaultAnchorAttributes: Attributes.NativeSVGAttributes option with get, set
            abstract areaPadding: float option with get, set
            abstract snapRadius: float option with get, set
            abstract restrictArea: bool option with get, set
            abstract redundancyRemoval: bool option with get, set

    type [<AllowNullLiteral>] Anchor =
        inherit Dia.ToolView
        abstract ``type``: string with get, set

    type [<AllowNullLiteral>] AnchorStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: Anchor.Options -> Anchor

    type [<AllowNullLiteral>] SourceAnchor =
        inherit Anchor

    type [<AllowNullLiteral>] SourceAnchorStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> SourceAnchor

    type [<AllowNullLiteral>] TargetAnchor =
        inherit Anchor

    type [<AllowNullLiteral>] TargetAnchorStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> TargetAnchor

    module Button =

        type [<AllowNullLiteral>] ActionCallback =
            [<Emit "$0($1...)">] abstract Invoke: evt: JQuery.Event * view: Dia.LinkView -> unit

        type [<AllowNullLiteral>] Options =
            inherit Dia.ToolView.Options
            abstract distance: U2<float, string> option with get, set
            abstract offset: float option with get, set
            abstract rotate: bool option with get, set
            abstract action: ActionCallback option with get, set
            abstract markup: Dia.MarkupJSON option with get, set

    type [<AllowNullLiteral>] Button =
        inherit Dia.ToolView
        abstract onPointerDown: evt: JQuery.Event -> unit

    type [<AllowNullLiteral>] ButtonStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: Button.Options -> Button

    type [<AllowNullLiteral>] Remove =
        inherit Dia.ToolView

    type [<AllowNullLiteral>] RemoveStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Remove

    module Boundary =

        type [<AllowNullLiteral>] Options =
            inherit Dia.ToolView.Options
            abstract padding: float option with get, set

    type [<AllowNullLiteral>] Boundary =
        inherit Dia.ToolView

    type [<AllowNullLiteral>] BoundaryStatic =
        [<Emit "new $0($1...)">] abstract Create: ?opt: Boundary.Options -> Boundary
