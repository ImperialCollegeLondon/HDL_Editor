// ts2fable 0.0.0
module rec Geometry
open System
open Fable.Core
open Fable.Import.JS

let [<Import("g","jointjs")>] g: G.IExports = jsNative

module G =
    let [<Import("bezier","jointjs/g")>] bezier: Bezier.IExports = jsNative
    let [<Import("scale","jointjs/g")>] scale: Scale.IExports = jsNative

    type [<AllowNullLiteral>] IExports =
        abstract normalizeAngle: angle: float -> float
        abstract snapToGrid: ``val``: float * gridSize: float -> float
        abstract toDeg: rad: float -> float
        abstract toRad: deg: float * ?over360: bool -> float
        abstract Curve: CurveStatic
        abstract Ellipse: EllipseStatic
        abstract Line: LineStatic
        abstract Path: PathStatic
        abstract Point: PointStatic
        abstract Polyline: PolylineStatic
        abstract Rect: RectStatic

    type [<AllowNullLiteral>] PlainPoint =
        abstract x: float with get, set
        abstract y: float with get, set

    type [<AllowNullLiteral>] PlainRect =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract width: float with get, set
        abstract height: float with get, set

    type [<AllowNullLiteral>] Scale =
        abstract sx: float with get, set
        abstract sy: float with get, set

    type [<AllowNullLiteral>] PrecisionOpt =
        abstract precision: float option with get, set

    type [<AllowNullLiteral>] SubdivisionsOpt =
        inherit PrecisionOpt
        abstract subdivisions: ResizeArray<Curve> option with get, set

    type [<AllowNullLiteral>] SegmentSubdivisionsOpt =
        inherit PrecisionOpt
        abstract segmentSubdivisions: ResizeArray<ResizeArray<Curve>> option with get, set

    type [<AllowNullLiteral>] PathT =
        abstract segmentIndex: float with get, set
        abstract value: float with get, set

    type [<AllowNullLiteral>] Segment =
        abstract ``type``: SegmentType with get, set
        abstract isSegment: bool with get, set
        abstract isSubpathStart: bool with get, set
        abstract isVisible: bool with get, set
        abstract nextSegment: Segment option with get, set
        abstract previousSegment: Segment option with get, set
        abstract subpathStartSegment: Segment option with get, set
        abstract start: U2<Point, obj> option with get, set
        abstract ``end``: Point option with get, set
        abstract bbox: unit -> Rect option
        abstract clone: unit -> Segment
        abstract closestPoint: p: Point * ?opt: SubdivisionsOpt -> Point
        abstract closestPointLength: p: Point * ?opt: SubdivisionsOpt -> float
        abstract closestPointNormalizedLength: p: Point * ?opt: SubdivisionsOpt -> float
        abstract closestPointT: p: Point -> float
        abstract closestPointTangent: p: Point -> Line option
        abstract equals: segment: Segment -> bool
        abstract getSubdivisions: unit -> ResizeArray<Curve>
        abstract isDifferentiable: unit -> bool
        abstract length: unit -> float
        abstract lengthAtT: t: float * ?opt: PrecisionOpt -> float
        abstract pointAt: ratio: float -> Point
        abstract pointAtLength: length: float -> Point
        abstract pointAtT: t: float -> Point
        abstract scale: sx: float * sy: float * ?origin: PlainPoint -> Segment
        abstract tangentAt: ratio: float -> Line option
        abstract tangentAtLength: length: float -> Line option
        abstract tangentAtT: t: float -> Line option
        abstract translate: ?tx: float * ?ty: float -> Segment
        abstract translate: tx: PlainPoint -> Segment
        abstract serialize: unit -> string
        abstract toString: unit -> string

    type [<AllowNullLiteral>] SegmentTypes =
        [<Emit "$0[$1]{{=$2}}">] abstract Item: key: string -> Segment with get, set

    type [<StringEnum>] [<RequireQualifiedAccess>] CardinalDirection =
        | [<CompiledName "NE">] NE
        | [<CompiledName "E">] E
        | [<CompiledName "SE">] SE
        | [<CompiledName "S">] S
        | [<CompiledName "SW">] SW
        | [<CompiledName "W">] W
        | [<CompiledName "NW">] NW
        | [<CompiledName "N">] N

    type [<StringEnum>] [<RequireQualifiedAccess>] RectangleSide =
        | Left
        | Right
        | Top
        | Bottom

    type [<StringEnum>] [<RequireQualifiedAccess>] SegmentType =
        | [<CompiledName "L">] L
        | [<CompiledName "C">] C
        | [<CompiledName "M">] M
        | [<CompiledName "Z">] Z

    type [<AllowNullLiteral>] Curve =
        abstract start: Point with get, set
        abstract controlPoint1: Point with get, set
        abstract controlPoint2: Point with get, set
        abstract ``end``: Point with get, set
        abstract bbox: unit -> Rect
        abstract clone: unit -> Curve
        abstract closestPoint: p: PlainPoint * ?opt: SubdivisionsOpt -> Point
        abstract closestPointLength: p: PlainPoint * ?opt: SubdivisionsOpt -> float
        abstract closestPointNormalizedLength: p: PlainPoint * ?opt: SubdivisionsOpt -> float
        abstract closestPointT: p: PlainPoint * ?opt: SubdivisionsOpt -> float
        abstract closestPointTangent: p: PlainPoint * ?opt: SubdivisionsOpt -> Line option
        abstract divide: t: float -> Curve * Curve
        abstract endpointDistance: unit -> float
        abstract equals: c: Curve -> bool
        abstract getSkeletonPoints: t: float -> Point * Point * Point * Point * Point
        abstract getSubdivisions: ?opt: PrecisionOpt -> ResizeArray<Curve>
        abstract isDifferentiable: unit -> bool
        abstract length: ?opt: SubdivisionsOpt -> float
        abstract lengthAtT: t: float * ?opt: PrecisionOpt -> float
        abstract pointAt: ratio: float * ?opt: SubdivisionsOpt -> Point
        abstract pointAtLength: length: float * ?opt: SubdivisionsOpt -> Point
        abstract pointAtT: t: float -> Point
        abstract scale: sx: float * sy: float * ?origin: U2<PlainPoint, string> -> Curve
        abstract tangentAt: ratio: float * ?opt: SubdivisionsOpt -> Line option
        abstract tangentAtLength: length: float * ?opt: SubdivisionsOpt -> Line option
        abstract tangentAtT: t: float -> Line option
        abstract tAt: ratio: float * ?opt: SubdivisionsOpt -> float
        abstract tAtLength: length: float * ?opt: SubdivisionsOpt -> float
        abstract translate: ?tx: float * ?ty: float -> Curve
        abstract translate: tx: PlainPoint -> Curve
        abstract toPoints: ?opt: SubdivisionsOpt -> ResizeArray<Point>
        abstract toPolyline: ?opt: SubdivisionsOpt -> Polyline
        abstract toString: unit -> string

    type [<AllowNullLiteral>] CurveStatic =
        [<Emit "new $0($1...)">] abstract Create: p1: U2<PlainPoint, string> * p2: U2<PlainPoint, string> * p3: U2<PlainPoint, string> * p4: U2<PlainPoint, string> -> Curve
        [<Emit "new $0($1...)">] abstract Create: curve: Curve -> Curve
        abstract throughPoints: points: ResizeArray<PlainPoint> -> ResizeArray<Curve>

    type [<AllowNullLiteral>] Ellipse =
        abstract x: float with get, set
        abstract y: float with get, set
        abstract a: float with get, set
        abstract b: float with get, set
        abstract bbox: unit -> Rect
        abstract center: unit -> Point
        abstract clone: unit -> Ellipse
        abstract containsPoint: p: PlainPoint -> bool
        abstract equals: ellipse: Ellipse -> bool
        abstract inflate: ?dx: float * ?dy: float -> Ellipse
        abstract intersectionWithLine: l: Line -> ResizeArray<Point> option
        abstract intersectionWithLineFromCenterToPoint: p: PlainPoint * ?angle: float -> Point
        abstract normalizedDistance: point: PlainPoint -> float
        abstract tangentTheta: p: PlainPoint -> float
        abstract toString: unit -> string

    type [<AllowNullLiteral>] EllipseStatic =
        [<Emit "new $0($1...)">] abstract Create: center: U2<PlainPoint, string> * a: float * b: float -> Ellipse
        [<Emit "new $0($1...)">] abstract Create: ellipse: Ellipse -> Ellipse
        abstract fromRect: rect: PlainRect -> Ellipse

    type [<AllowNullLiteral>] Line =
        abstract start: Point with get, set
        abstract ``end``: Point with get, set
        abstract bbox: unit -> Rect
        abstract bearing: unit -> CardinalDirection
        abstract clone: unit -> Line
        abstract closestPoint: p: U2<PlainPoint, string> -> Point
        abstract closestPointLength: p: U2<PlainPoint, string> -> float
        abstract closestPointNormalizedLength: p: U2<PlainPoint, string> -> float
        abstract closestPointTangent: p: U2<PlainPoint, string> -> Line option
        abstract equals: line: Line -> bool
        abstract intersect: line: Line -> Point option
        abstract intersect: rect: Rect -> ResizeArray<Point> option
        abstract intersect: ellipse: Ellipse -> ResizeArray<Point> option
        abstract intersect: polyline: Polyline -> ResizeArray<Point> option
        abstract intersect: path: Path * ?opt: SegmentSubdivisionsOpt -> ResizeArray<Point> option
        abstract intersectionWithLine: l: Line -> ResizeArray<Point> option
        abstract isDifferentiable: unit -> bool
        abstract length: unit -> float
        abstract midpoint: unit -> Point
        abstract pointAt: t: float -> Point
        abstract pointAtLength: length: float -> Point
        abstract pointOffset: p: U2<PlainPoint, string> -> float
        abstract rotate: origin: PlainPoint * angle: float -> Line
        abstract round: ?precision: float -> Line
        abstract scale: sx: float * sy: float * ?origin: PlainPoint -> Line
        abstract setLength: length: float -> Line
        abstract squaredLength: unit -> float
        abstract tangentAt: t: float -> Line option
        abstract tangentAtLength: length: float -> Line option
        abstract translate: ?tx: float * ?ty: float -> Line
        abstract translate: tx: PlainPoint -> Line
        abstract vector: unit -> Point
        abstract toString: unit -> string

    type [<AllowNullLiteral>] LineStatic =
        [<Emit "new $0($1...)">] abstract Create: p1: U2<PlainPoint, string> * p2: U2<PlainPoint, string> -> Line
        [<Emit "new $0($1...)">] abstract Create: line: Line -> Line
        [<Emit "new $0($1...)">] abstract Create: unit -> Line

    type [<AllowNullLiteral>] Path =
        abstract segments: ResizeArray<Segment> with get, set
        abstract start: Point option with get, set
        abstract ``end``: Point option with get, set
        abstract appendSegment: segment: Segment -> unit
        abstract appendSegment: segments: ResizeArray<Segment> -> unit
        abstract bbox: unit -> Rect option
        abstract clone: unit -> Path
        abstract closestPoint: p: Point * ?opt: SegmentSubdivisionsOpt -> Point option
        abstract closestPointLength: p: Point * ?opt: SegmentSubdivisionsOpt -> float
        abstract closestPointNormalizedLength: p: Point * ?opt: SegmentSubdivisionsOpt -> float
        abstract closestPointTangent: p: Point * ?opt: SegmentSubdivisionsOpt -> Line option
        abstract equals: p: Path -> bool
        abstract getSegment: index: float -> Segment option
        abstract getSegmentSubdivisions: ?opt: PrecisionOpt -> ResizeArray<ResizeArray<Curve>>
        abstract insertSegment: index: float * segment: Segment -> unit
        abstract insertSegment: index: float * segments: ResizeArray<Segment> -> unit
        abstract intersectionWithLine: l: Line * ?opt: SegmentSubdivisionsOpt -> ResizeArray<Point> option
        abstract isDifferentiable: unit -> bool
        abstract isValid: unit -> bool
        abstract length: ?opt: SegmentSubdivisionsOpt -> float
        abstract pointAt: ratio: float * ?opt: SegmentSubdivisionsOpt -> Point option
        abstract pointAtLength: length: float * ?opt: SegmentSubdivisionsOpt -> Point option
        abstract removeSegment: index: float -> unit
        abstract replaceSegment: index: float * segment: Segment -> unit
        abstract replaceSegment: index: float * segments: ResizeArray<Segment> -> unit
        abstract scale: sx: float * sy: float * ?origin: U2<PlainPoint, string> -> Path
        abstract segmentAt: ratio: float * ?opt: SegmentSubdivisionsOpt -> Segment option
        abstract segmentAtLength: length: float * ?opt: SegmentSubdivisionsOpt -> Segment option
        abstract segmentIndexAt: ratio: float * ?opt: SegmentSubdivisionsOpt -> float option
        abstract segmentIndexAtLength: length: float * ?opt: SegmentSubdivisionsOpt -> float option
        abstract tangentAt: ratio: float * ?opt: SegmentSubdivisionsOpt -> Line option
        abstract tangentAtLength: length: float * ?opt: SegmentSubdivisionsOpt -> Line option
        abstract toPoints: ?opt: SegmentSubdivisionsOpt -> ResizeArray<ResizeArray<Point>> option
        abstract toPolylines: ?opt: SegmentSubdivisionsOpt -> ResizeArray<Polyline> option
        abstract translate: ?tx: float * ?ty: float -> Path
        abstract translate: tx: PlainPoint -> Path
        abstract serialize: unit -> string
        abstract toString: unit -> string

    type [<AllowNullLiteral>] PathStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Path
        [<Emit "new $0($1...)">] abstract Create: pathData: string -> Path
        [<Emit "new $0($1...)">] abstract Create: segments: ResizeArray<Segment> -> Path
        [<Emit "new $0($1...)">] abstract Create: objects: ResizeArray<U2<Line, Curve>> -> Path
        [<Emit "new $0($1...)">] abstract Create: segment: Segment -> Path
        [<Emit "new $0($1...)">] abstract Create: line: Line -> Path
        [<Emit "new $0($1...)">] abstract Create: curve: Curve -> Path
        [<Emit "new $0($1...)">] abstract Create: polyline: Polyline -> Path
        abstract createSegment: ``type``: SegmentType * [<ParamArray>] args: ResizeArray<obj option> -> Segment
        abstract parse: pathData: string -> Path
        abstract segmentTypes: SegmentTypes with get, set
        abstract isDataSupported: pathData: string -> bool

    type [<AllowNullLiteral>] Point =
        inherit PlainPoint
        abstract x: float with get, set
        abstract y: float with get, set
        abstract adhereToRect: r: Rect -> Point
        abstract angleBetween: p1: PlainPoint * p2: PlainPoint -> float
        abstract bearing: p: Point -> CardinalDirection
        abstract changeInAngle: dx: float * dy: float * ref: U2<PlainPoint, string> -> float
        abstract clone: unit -> Point
        abstract cross: p1: PlainPoint * p2: PlainPoint -> float
        abstract difference: ?dx: float * ?dy: float -> Point
        abstract difference: p: PlainPoint -> Point
        abstract distance: p: U2<PlainPoint, string> -> float
        abstract dot: p: PlainPoint -> float
        abstract equals: p: Point -> bool
        abstract lerp: p: Point * t: float -> Point
        abstract magnitude: unit -> float
        abstract manhattanDistance: p: PlainPoint -> float
        abstract move: ref: U2<PlainPoint, string> * distance: float -> Point
        abstract normalize: length: float -> Point
        abstract offset: ?dx: float * ?dy: float -> Point
        abstract offset: p: PlainPoint -> Point
        abstract reflection: ref: U2<PlainPoint, string> -> Point
        abstract rotate: origin: U2<PlainPoint, string> * angle: float -> Point
        abstract round: ?precision: float -> Point
        abstract scale: sx: float * sy: float * ?origin: U2<PlainPoint, string> -> Point
        abstract snapToGrid: gx: float * ?gy: float -> Point
        abstract squaredDistance: p: U2<PlainPoint, string> -> float
        abstract theta: p: U2<PlainPoint, string> -> float
        abstract toJSON: unit -> PlainPoint
        abstract toPolar: ?origin: U2<PlainPoint, string> -> Point
        abstract toString: unit -> string
        abstract translate: ?tx: float * ?ty: float -> Point
        abstract translate: tx: PlainPoint -> Point
        abstract update: ?x: float * ?y: float -> Point
        abstract vectorAngle: p: PlainPoint -> float

    type [<AllowNullLiteral>] PointStatic =
        [<Emit "new $0($1...)">] abstract Create: ?x: float * ?y: float -> Point
        [<Emit "new $0($1...)">] abstract Create: p: U2<PlainPoint, string> -> Point
        abstract fromPolar: distance: float * angle: float * ?origin: U2<PlainPoint, string> -> Point
        abstract random: x1: float * x2: float * y1: float * y2: float -> Point

    type [<AllowNullLiteral>] Polyline =
        abstract points: ResizeArray<Point> with get, set
        abstract start: Point option with get, set
        abstract ``end``: Point option with get, set
        abstract bbox: unit -> Rect option
        abstract clone: unit -> Polyline
        abstract closestPoint: p: U2<PlainPoint, string> -> Point option
        abstract closestPointLength: p: U2<PlainPoint, string> -> float
        abstract closestPointNormalizedLength: p: U2<PlainPoint, string> -> float
        abstract closestPointTangent: p: U2<PlainPoint, string> -> Line option
        abstract convexHull: unit -> Polyline
        abstract equals: p: Polyline -> bool
        abstract isDifferentiable: unit -> bool
        abstract intersectionWithLine: l: Line -> ResizeArray<Point> option
        abstract length: unit -> float
        abstract pointAt: ratio: float -> Point option
        abstract pointAtLength: length: float -> Point option
        abstract scale: sx: float * sy: float * ?origin: U2<PlainPoint, string> -> Polyline
        abstract tangentAt: ratio: float -> Line option
        abstract tangentAtLength: length: float -> Line option
        abstract translate: ?tx: float * ?ty: float -> Polyline
        abstract translate: tx: PlainPoint -> Polyline
        abstract serialize: unit -> string
        abstract toString: unit -> string

    type [<AllowNullLiteral>] PolylineStatic =
        [<Emit "new $0($1...)">] abstract Create: unit -> Polyline
        [<Emit "new $0($1...)">] abstract Create: svgString: string -> Polyline
        [<Emit "new $0($1...)">] abstract Create: points: ResizeArray<Point> -> Polyline
        abstract parse: svgString: string -> Polyline

    type [<AllowNullLiteral>] Rect =
        inherit PlainRect
        abstract x: float with get, set
        abstract y: float with get, set
        abstract width: float with get, set
        abstract height: float with get, set
        abstract bbox: ?angle: float -> Rect
        abstract bottomLeft: unit -> Point
        abstract bottomLine: unit -> Line
        abstract bottomMiddle: unit -> Point
        abstract bottomRight: unit -> Point
        abstract center: unit -> Point
        abstract clone: unit -> Rect
        abstract containsPoint: p: U2<PlainPoint, string> -> bool
        abstract containsRect: r: PlainRect -> bool
        abstract corner: unit -> Point
        abstract equals: r: PlainRect -> bool
        abstract inflate: ?dx: float * ?dy: float -> Rect
        abstract intersect: r: Rect -> Rect option
        abstract intersectionWithLine: l: Line -> ResizeArray<Point> option
        abstract intersectionWithLineFromCenterToPoint: p: U2<PlainPoint, string> * ?angle: float -> Point
        abstract leftLine: unit -> Line
        abstract leftMiddle: unit -> Point
        abstract maxRectScaleToFit: rect: PlainRect * ?origin: PlainPoint -> Scale
        abstract maxRectUniformScaleToFit: rect: PlainRect * ?origin: PlainPoint -> float
        abstract moveAndExpand: r: PlainRect -> Rect
        abstract normalize: unit -> Rect
        abstract offset: ?dx: float * ?dy: float -> Rect
        abstract offset: p: PlainPoint -> Rect
        abstract origin: unit -> Point
        abstract pointNearestToPoint: point: U2<PlainPoint, string> -> Point
        abstract rightLine: unit -> Line
        abstract rightMiddle: unit -> Point
        abstract round: ?precision: float -> Rect
        abstract scale: sx: float * sy: float * ?origin: U2<PlainPoint, string> -> Rect
        abstract sideNearestToPoint: point: U2<PlainPoint, string> -> RectangleSide
        abstract snapToGrid: gx: float * ?gy: float -> Rect
        abstract topLeft: unit -> Point
        abstract topLine: unit -> Line
        abstract topMiddle: unit -> Point
        abstract topRight: unit -> Point
        abstract translate: ?tx: float * ?ty: float -> Rect
        abstract translate: tx: PlainPoint -> Rect
        abstract toJSON: unit -> PlainRect
        abstract toString: unit -> string
        abstract union: rect: PlainRect -> Rect

    type [<AllowNullLiteral>] RectStatic =
        [<Emit "new $0($1...)">] abstract Create: ?x: float * ?y: float * ?width: float * ?height: float -> Rect
        [<Emit "new $0($1...)">] abstract Create: r: PlainRect -> Rect
        abstract fromEllipse: e: Ellipse -> Rect

    module Bezier =

        type [<AllowNullLiteral>] IExports =
            abstract curveThroughPoints: points: U2<ResizeArray<PlainPoint>, ResizeArray<Point>> -> ResizeArray<string>
            abstract getCurveControlPoints: points: U2<ResizeArray<PlainPoint>, ResizeArray<Point>> -> ResizeArray<Point> * ResizeArray<Point>
            abstract getCurveDivider: p0: U2<string, PlainPoint> * p1: U2<string, PlainPoint> * p2: U2<string, PlainPoint> * p3: U2<string, PlainPoint> -> (float -> IBezierCurve * IBezierCurve)
            abstract getFirectControlPoints: rhs: ResizeArray<float> -> ResizeArray<float>
            abstract getInversionSolver: p0: PlainPoint * p1: PlainPoint * p2: PlainPoint * p3: PlainPoint -> (PlainPoint -> float)

        type [<AllowNullLiteral>] IBezierCurve =
            abstract p0: Point with get, set
            abstract p1: Point with get, set
            abstract p2: Point with get, set
            abstract p3: Point with get, set

    module Scale =

        type [<AllowNullLiteral>] IExports =
            abstract linear: domain: float * float * range: float * float * value: float -> float
