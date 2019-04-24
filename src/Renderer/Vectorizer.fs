// ts2fable 0.0.0
module rec Vectorizer
open System
open Fable.Core
open Fable.Import.JS
open Fable.Import.Browser
open Geometry


type [<AllowNullLiteral>] IExports =
    abstract V: svg: U3<SVGElement, Vectorizer, string> * ?attrs: VAttrs * ?children: U4<Vectorizer, ResizeArray<Vectorizer>, SVGElement, ResizeArray<SVGElement>> -> Vectorizer
    abstract Vectorizer: VectorizerStatic

type [<AllowNullLiteral>] VAttrs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

module Vectorizer =

    type [<AllowNullLiteral>] RotateOptions =
        abstract absolute: bool option with get, set

    type [<AllowNullLiteral>] AnnotateStringOptions =
        abstract includeAnnotationIndices: bool option with get, set
        abstract offset: float option with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] TextVerticalAnchor =
        | Top
        | Bottom
        | Middle

    type [<AllowNullLiteral>] TextOptions =
        abstract eol: string option with get, set
        abstract x: U2<float, string> option with get, set
        abstract textVerticalAnchor: U3<TextVerticalAnchor, float, string> option with get, set
        abstract lineHeight: U2<float, string> option with get, set
        abstract textPath: U2<string, TypeLiteral_01> option with get, set
        abstract annotations: ResizeArray<TextAnnotation> option with get, set
        abstract includeAnnotationIndices: bool option with get, set

    type [<AllowNullLiteral>] GetBBoxOptions =
        abstract target: U2<SVGElement, Vectorizer> option with get, set
        abstract recursive: bool option with get, set

    type [<AllowNullLiteral>] TransformOptions =
        abstract absolute: bool option with get, set

    type [<AllowNullLiteral>] ParseXMLOptions =
        abstract async: bool option with get, set

    type [<AllowNullLiteral>] TextAnnotation =
        abstract start: float with get, set
        abstract ``end``: float with get, set
        abstract attrs: TypeLiteral_01 with get, set

    type [<AllowNullLiteral>] Matrix =
        abstract a: float with get, set
        abstract b: float with get, set
        abstract c: float with get, set
        abstract d: float with get, set
        abstract e: float with get, set
        abstract f: float with get, set

    type [<AllowNullLiteral>] Sample =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract distance: float with get, set

    type [<AllowNullLiteral>] DecomposedTransformation =
        abstract translateX: float with get, set
        abstract translateY: float with get, set
        abstract scaleX: float with get, set
        abstract scaleY: float with get, set
        abstract skewX: float with get, set
        abstract skewY: float with get, set
        abstract rotation: float with get, set

    type [<AllowNullLiteral>] RoundedRect =
        inherit G.PlainRect
        abstract rx: float option with get, set
        abstract ry: float option with get, set
        abstract ``top-rx``: float option with get, set
        abstract ``top-ry``: float option with get, set
        abstract ``bottom-rx``: float option with get, set
        abstract ``bottom-ry``: float option with get, set

    type [<AllowNullLiteral>] Rotation =
        abstract angle: float with get, set
        abstract cx: float option with get, set
        abstract cy: float option with get, set

    type [<AllowNullLiteral>] Translation =
        abstract tx: float with get, set
        abstract ty: float with get, set

    type [<AllowNullLiteral>] Scale =
        abstract sx: float with get, set
        abstract sy: float with get, set

    type [<AllowNullLiteral>] Transform =
        abstract value: string with get, set
        abstract translate: Translation with get, set
        abstract rotate: Rotation with get, set
        abstract scale: Scale with get, set

    type [<AllowNullLiteral>] QualifiedAttribute =
        abstract ns: string option with get, set
        abstract local: string with get, set

    type [<AllowNullLiteral>] TypeLiteral_01 =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] Vectorizer =
    abstract id: string with get, set
    abstract node: SVGElement with get, set
    abstract getTransformToElement: toElem: U2<SVGGElement, Vectorizer> -> SVGMatrix
    abstract transform: unit -> SVGMatrix
    abstract transform: matrix: U2<SVGMatrix, Vectorizer.Matrix> * ?opt: Vectorizer.TransformOptions -> Vectorizer
    abstract translate: unit -> Vectorizer.Translation
    abstract translate: tx: float * ?ty: float * ?opt: Vectorizer.TransformOptions -> Vectorizer
    abstract rotate: unit -> Vectorizer.Rotation
    abstract rotate: angle: float * ?cx: float * ?cy: float * ?opt: Vectorizer.RotateOptions -> Vectorizer
    abstract scale: unit -> Vectorizer.Scale
    abstract scale: sx: float * ?sy: float -> Vectorizer
    abstract bbox: ?withoutTransformations: bool * ?target: U2<SVGElement, Vectorizer> -> G.Rect
    abstract getBBox: ?opt: Vectorizer.GetBBoxOptions -> G.Rect
    abstract text: content: string * ?opt: Vectorizer.TextOptions -> Vectorizer
    abstract removeAttr: name: string -> Vectorizer
    abstract attr: unit -> VectorizerAttrReturn
    abstract attr: name: string -> string option
    abstract attr: name: string * value: obj option -> Vectorizer
    abstract attr: attrs: VectorizerAttrAttrs -> Vectorizer
    abstract normalizePath: unit -> Vectorizer
    abstract remove: unit -> Vectorizer
    abstract empty: unit -> Vectorizer
    abstract append: els: U4<Vectorizer, ResizeArray<Vectorizer>, SVGElement, ResizeArray<SVGElement>> -> Vectorizer
    abstract prepend: els: U4<Vectorizer, ResizeArray<Vectorizer>, SVGElement, ResizeArray<SVGElement>> -> Vectorizer
    abstract before: els: U4<Vectorizer, ResizeArray<Vectorizer>, SVGElement, ResizeArray<SVGElement>> -> Vectorizer
    abstract appendTo: el: U2<SVGElement, Vectorizer> -> Vectorizer
    abstract svg: unit -> Vectorizer
    abstract tagName: unit -> string
    abstract defs: unit -> Vectorizer option
    abstract clone: unit -> Vectorizer
    abstract findOne: selector: string -> Vectorizer option
    abstract find: selector: string -> ResizeArray<Vectorizer>
    abstract children: unit -> ResizeArray<Vectorizer>
    abstract index: unit -> float
    abstract findParentByClass: className: string * ?terminator: SVGElement -> Vectorizer option
    abstract contains: el: U2<SVGElement, Vectorizer> -> bool
    abstract toLocalPoint: x: float * y: float -> SVGPoint
    abstract translateCenterToPoint: p: G.PlainPoint -> Vectorizer
    abstract translateAndAutoOrient: position: G.PlainPoint * reference: G.PlainPoint * ?target: U2<SVGElement, Vectorizer> -> Vectorizer
    abstract animateAlongPath: attrs: VectorizerAnimateAlongPathAttrs * path: U2<SVGElement, Vectorizer> -> unit
    abstract hasClass: className: string -> bool
    abstract addClass: className: string -> Vectorizer
    abstract removeClass: className: string -> Vectorizer
    abstract toggleClass: className: string * ?switchArg: bool -> Vectorizer
    abstract sample: ?interval: float -> ResizeArray<Vectorizer.Sample>
    abstract convertToPath: unit -> Vectorizer
    abstract convertToPathData: unit -> string
    abstract findIntersection: ref: G.PlainPoint * target: U2<SVGElement, Vectorizer> -> G.PlainPoint option

type [<AllowNullLiteral>] VectorizerAttrReturn =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] VectorizerAttrAttrs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] VectorizerAnimateAlongPathAttrs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] VectorizerStatic =
    [<Emit "new $0($1...)">] abstract Create: el: U2<string, SVGElement> * ?attrs: VectorizerStaticAttrs * ?children: U4<Vectorizer, ResizeArray<Vectorizer>, SVGElement, ResizeArray<SVGElement>> -> Vectorizer
    abstract createSVGDocument: content: string -> Document
    abstract uniqueId: unit -> string
    abstract ensureId: node: U2<SVGElement, Vectorizer> -> string
    abstract sanitizeText: text: string -> string
    abstract isUndefined: value: obj option -> bool
    abstract isString: value: obj option -> bool
    abstract isObject: value: obj option -> bool
    abstract isArray: value: obj option -> bool
    abstract parseXML: data: string * ?opt: Vectorizer.ParseXMLOptions -> XMLDocument
    abstract qualifyAttr: name: string -> Vectorizer.QualifiedAttribute
    abstract transformStringToMatrix: transform: string -> SVGMatrix
    abstract matrixToTransformString: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> string
    abstract parseTransformString: transform: string -> Vectorizer.Transform
    abstract deltaTransformPoint: matrix: U2<SVGMatrix, Vectorizer.Matrix> * point: U2<SVGPoint, G.PlainPoint> -> G.PlainPoint
    abstract decomposeMatrix: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> Vectorizer.DecomposedTransformation
    abstract matrixToScale: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> Vectorizer.Scale
    abstract matrixToRotate: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> Vectorizer.Rotation
    abstract matrixToTranslate: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> Vectorizer.Translation
    abstract isV: value: obj option -> bool
    abstract isVElement: value: obj option -> bool
    abstract isSVGGraphicsElement: value: obj option -> bool
    abstract createSVGMatrix: matrix: U2<SVGMatrix, Vectorizer.Matrix> -> SVGMatrix
    abstract createSVGTransform: ?matrix: U2<SVGMatrix, Vectorizer.Matrix> -> SVGTransform
    abstract createSVGPoint: x: float * y: float -> SVGPoint
    abstract transformRect: r: G.PlainRect * matrix: SVGMatrix -> G.Rect
    abstract transformPoint: p: G.PlainPoint * matrix: SVGMatrix -> G.Point
    abstract transformLine: p: G.Line * matrix: SVGMatrix -> G.Line
    abstract transformPolyline: p: U2<G.Polyline, ResizeArray<G.PlainPoint>> * matrix: SVGMatrix -> G.Polyline
    abstract styleToObject: styleString: string -> VectorizerStaticStyleToObjectReturn
    abstract createSlicePathData: innerRadius: float * outRadius: float * startAngle: float * endAngle: float -> string
    abstract mergeAttrs: a: obj option * b: obj option -> obj option
    abstract annotateString: t: string * annotations: ResizeArray<Vectorizer.TextAnnotation> * ?opt: Vectorizer.AnnotateStringOptions -> Array<U2<string, TypeLiteral_02>>
    abstract findAnnotationsAtIndex: annotations: ResizeArray<Vectorizer.TextAnnotation> * index: float -> ResizeArray<Vectorizer.TextAnnotation>
    abstract findAnnotationsBetweenIndexes: annotations: ResizeArray<Vectorizer.TextAnnotation> * start: float * ``end``: float -> ResizeArray<Vectorizer.TextAnnotation>
    abstract shiftAnnotations: annotations: ResizeArray<Vectorizer.TextAnnotation> * index: float * offset: float -> ResizeArray<Vectorizer.TextAnnotation>
    abstract convertLineToPathData: line: U3<string, SVGElement, Vectorizer> -> string
    abstract convertPolygonToPathData: line: U3<string, SVGElement, Vectorizer> -> string
    abstract convertPolylineToPathData: line: U3<string, SVGElement, Vectorizer> -> string
    abstract svgPointsToPath: points: U2<ResizeArray<G.PlainPoint>, ResizeArray<SVGPoint>> -> string
    abstract getPointsFromSvgNode: node: U2<SVGElement, Vectorizer> -> ResizeArray<SVGPoint>
    abstract convertCircleToPathData: circle: U3<string, SVGElement, Vectorizer> -> string
    abstract convertEllipseToPathData: ellipse: U3<string, SVGElement, Vectorizer> -> string
    abstract convertRectToPathData: rect: U3<string, SVGElement, Vectorizer> -> string
    abstract rectToPath: r: Vectorizer.RoundedRect -> string
    abstract normalizePathData: path: string -> string
    abstract toNode: el: U3<SVGElement, Vectorizer, ResizeArray<SVGElement>> -> SVGElement

type [<AllowNullLiteral>] VectorizerStaticAttrs =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set

type [<AllowNullLiteral>] VectorizerStaticStyleToObjectReturn =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> string with get, set

type [<AllowNullLiteral>] TypeLiteral_02 =
    [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> obj option with get, set
