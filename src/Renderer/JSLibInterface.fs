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

type PaperDefaultConnectionPointArgs = 
    abstract sticky: bool option with get, set

type PaperDecaultConnectionPoint = 
    abstract name: string option with get, set
    abstract args: PaperDefaultConnectionPointArgs option with get, set


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

    
    
    