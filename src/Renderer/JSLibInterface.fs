(*
    The module is the bindings for the JointJS JavaScript library.
*)
module JSLibInterface

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import.Browser
open System

let joint : obj = importAll "jointjs"

///////////////////////////////////////////
///                                     ///
///      For configuring the paper      ///
///                                     ///
///////////////////////////////////////////

type PaperBackgroundColor = 
    abstract color: string option with get, set

type PaperSettings = 
    abstract el: HTMLElement option with get, set
    abstract model: obj option with get, set
    abstract width: int option with get, set
    abstract height: int option with get, set
    abstract gridSize: int option with get, set
    abstract drawGrid: bool option with get, set
    abstract background: PaperBackgroundColor option with get, set

/// generate the PaperSettings using parameters of different types
let generatePaperSettings el model width height gridSize drawGrid backgroundColor =
    let paperBackgroundColor = createEmpty<PaperBackgroundColor>
    paperBackgroundColor.color <- Some backgroundColor

    let paperSettings = createEmpty<PaperSettings>
    paperSettings.el <- Some el
    paperSettings.model <- Some model
    paperSettings.width <- Some width
    paperSettings.height <- Some height
    paperSettings.gridSize <- Some gridSize
    paperSettings.drawGrid <- Some drawGrid
    paperSettings.background <- Some paperBackgroundColor

    paperSettings

type PaperDefaultConnectionPointArgs = 
    abstract sticky: bool option with get, set

type PaperDecaultConnectionPoint = 
    abstract name: string option with get, set
    abstract args: PaperDefaultConnectionPointArgs option with get, set

/// generate the PaperDecaultConnectionPoint using parameters of different types
let generatePaperDecaultConnectionPoint name defaultConnectionPoint = 
    let paperDefaultConnectionPointArgs = createEmpty<PaperDefaultConnectionPointArgs>
    paperDefaultConnectionPointArgs.sticky <- Some defaultConnectionPoint

    let paperDecaultConnectionPoint = createEmpty<PaperDecaultConnectionPoint>
    paperDecaultConnectionPoint.name <- Some name
    paperDecaultConnectionPoint.args <- Some paperDefaultConnectionPointArgs

    paperDecaultConnectionPoint


///////////////////////////////////////////////
///                                         ///
///      For configuring the rectangle      ///
///                                         ///
///////////////////////////////////////////////

type RectangleBody = 
    abstract fill: string option with get, set

type RectangleLabel = 
    abstract text: string option with get, set
    abstract fill: string option with get, set
    abstract textAnchor: string option with get, set
    abstract textVerticalAnchor: string option with get, set

type RectangleAttr = 
    abstract body: RectangleBody option with get, set
    abstract label: RectangleLabel option with get, set

/// generate the RectangleAttr from parameters of different types
let generateRectangleAttr bodyFill labelText labelFill labelTextAnchor labelTextVerticalAnchor = 
    let body = createEmpty<RectangleBody>
    body.fill <- Some bodyFill

    let label = createEmpty<RectangleLabel>
    label.text <- Some labelText
    label.fill <- Some labelFill
    label.textAnchor <- Some labelTextAnchor
    label.textVerticalAnchor <- Some labelTextVerticalAnchor

    let attr = createEmpty<RectangleAttr>
    attr.body <- Some body
    attr.label <- Some label

    attr


////////////////////////////////////////////
///                                      ///
///      For configuring the anchor      ///
///                                      ///
////////////////////////////////////////////

type AnchorName = 
    abstract name: string option with get, set

type AnchorArgs = 
    abstract rotate: bool option with get, set
    abstract dx: U2<int, string> option with get, set
    abstract dy: U2<int, string> option with get,set

type Anchor = 
    abstract anchor: AnchorName option with get, set
    abstract args: AnchorArgs option with get, set

/// generate the Anchor from parameters of different types
let generateAnchor name rotate dx dy = 
    let anchorName = createEmpty<AnchorName>
    anchorName.name <- Some name

    let anchorArgs = createEmpty<AnchorArgs>
    anchorArgs.rotate <- Some rotate
    anchorArgs.dx <- Some dx
    anchorArgs.dy <- Some dy

    let anchor = createEmpty<Anchor>
    anchor.anchor <- Some anchorName
    anchor.args <- Some anchorArgs

    anchor


//////////////////////////////////////////////////////
///                                                ///
///      For configuring the connection point      ///
///                                                ///
//////////////////////////////////////////////////////

type ConnectionPointArgs = 
    abstract offset: int option with get, set

type ConnectionPoint = 
    abstract name: string option with get, set
    abstract args: ConnectionPointArgs option with get, set

/// generate the ConnectionPoint from parameters of different types
let generateConnectionPoint offset name = 
    let connectionPointArgs = createEmpty<ConnectionPointArgs>
    connectionPointArgs.offset <- Some offset

    let connectionPoint = createEmpty<ConnectionPoint>
    connectionPoint.name <- Some name
    connectionPoint.args <- Some connectionPointArgs

    connectionPoint
    

/////////////////////////////////////////////
///                                      ///
///      For configuring the router      ///
///                                      ///
////////////////////////////////////////////

[<StringEnum>]
type Router = 
    | [<CompiledName("manhattan")>] Manhattan
    | [<CompiledName("metro")>] Metro
    | [<CompiledName("normal")>] Normal
    | [<CompiledName("orthogonal")>] Orthogonal
    | [<CompiledName("oneside")>] OneSide


///////////////////////////////////////////
///                                    ///
///      For defining new element      ///
///                                    ///
//////////////////////////////////////////

type NewElementConfig = 
    abstract attr: obj option with get, set   

type Markup = 
    abstract tagName: string option with get, set
    abstract selector: string option with get, set

type MarkupArray = 
    abstract markup: Markup array option with get, set

/// generate the MarkupArray from parameters of different types
let generateMarkupArray (argsArray:string array) = 
    let length = argsArray.Length / 2 - 1

    let markups = [| for i in 0 .. length -> createEmpty<Markup>|]
    [ 0 .. length] 
    |> List.map (fun index -> markups.[index].tagName <- Some argsArray.[index*2]
                              markups.[index].selector <- Some argsArray.[index*2 + 1])
    |> ignore

    let markupArray = createEmpty<MarkupArray>
    markupArray.markup <- Some markups

    markupArray

    
//////////////////////////////////////////////////
///                                            ///
///      Bindings for the JointJS library      ///
///                                            ///
//////////////////////////////////////////////////
    
/// import the JointJS library
[<Emit("joint.version")>]
let jointVersion : string = jsNative

/// the interface to use JointJS APIs
/// need the :> operator to use the interface
type JointJS = 
    abstract member GraphInit: unit -> obj
    abstract member PaperInit: PaperSettings -> obj
    abstract member RectangleInit: unit -> obj
    abstract member LinkInit: unit -> obj
    abstract member Position: x:int -> y:int -> el:obj -> obj
    abstract member Clone: el:obj -> obj
    abstract member Resize: x:int -> y:int -> el:obj -> obj
    abstract member Attr: config:obj -> el:obj -> obj
    abstract member AttrBySelector: selector:string -> content:string -> el:obj -> obj
    abstract member AddTo: graph:obj -> el:obj -> obj
    abstract member Translate: x:int -> y:int -> el:obj -> obj
    abstract member Source: link:obj -> el:obj -> obj
    abstract member Target: link:obj -> el:obj -> obj
    abstract member Router: link:obj -> routerType:Router -> obj
    abstract member Define: name:string -> config:NewElementConfig -> markupList:MarkupArray -> obj

/// the interface JointJS needs to be explicitly implemented
/// do not forget to :> the createElement interface implementation
type createElement() = 
    interface JointJS with
        member __.GraphInit () = createNew joint?dia?Graph ()
        member __.PaperInit paperConfig = createNew joint?dia?Paper (paperConfig)
        member __.RectangleInit () = createNew joint?shapes?standard?Rectangle ()
        member __.LinkInit () = createNew joint?shapes?standard?Link ()
        member __.Position x y el = el?position(x, y)
        member __.Clone el = el?clone()
        member __.Resize x y el = el?resize(x, y)
        member __.Attr config el = el?attr(config)
        member __.AttrBySelector selector content el = el?attr(selector, content)
        member __.AddTo graph el = el?addTo(graph)
        member __.Translate x y el = el?translate(x, y)
        member __.Source link el = link?source(el)
        member __.Target link el = link?target(el)
        member __.Router link routerType = link?router(routerType)
        member __.Define name config markupList = joint?dia?Element?define(name, config, markupList)

    
    
    