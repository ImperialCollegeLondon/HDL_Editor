module BlockLayout

(*
The BlockLayout module implements the position description of the blocks on the canvas.
*)

/// define the dimensions of the canvas
let mutable canvasXMax = int64 1000
let mutable canvasXMin = int64 0
let mutable canvasYMax = int64 1000
let mutable canvasYMin = int64 0

let canvasExtraSpece = int64 10;

/// possible errors when creating or interacting with blocks
type BlockError = 
    | ``X Max coordinate is out of range`` of XMaxCoordinate:int64
    | ``Y Max coordinate is out of range`` of YMaxCoordinate:int64
    | ``Both Max coordinates are out of range`` of XMaxCoordinate:int64 * YMaxCoordinate:int64
    | ``X Min coordinate is out of range`` of XMinCoordinate:int64
    | ``Y Min coordinate is out of range`` of YMinCoordinate:int64
    | ``Both Min coordinates are out of range`` of XMinCoordinate:int64 * YMinCoordinate:int64

/// built-in block types
type BuiltinBlockTypes = 
    | BlockA

/// pins on the blocks
type BuiltinBlockPin = 
    | PinA

/// connection detials
type ConnectionInfo = {
    BusWidth: int;
    SourceBlock: string option;
    SourceBlockType: BuiltinBlockTypes option;
    SourcePin: BuiltinBlockPin option;
    SinkBlock: string option;
    SinkBlockType: BuiltinBlockTypes option;
    SinkPin: BuiltinBlockPin option
    }

/// the coordinates of the corners of the block
type BuildinBlockCoordinates = {
    XCoordinate: int64;
    YCoordinate: int64
    }

type BlockCorner = {
    TopLeft: BuildinBlockCoordinates
    ButtomLeft: BuildinBlockCoordinates
    TopRight: BuildinBlockCoordinates
    ButtomRight: BuildinBlockCoordinates
    }

/// information of a block on the canvas
type BuiltinBlockInfo = {
    BlockName: string;
    BlockType: BuiltinBlockTypes;
    BlockPins: BuiltinBlockPin List;
    ConnectionStatus: ConnectionInfo List option;
    CornerCoordinates: BlockCorner
    }

let getBuiltinBlockSize (blockType:BuiltinBlockTypes) = 
    match blockType with
    | BlockA -> int64 10, int64 10

let getBuiltinBlockPins (blockType:BuiltinBlockTypes) = 
    match blockType with
    | BlockA -> [PinA]

let checkBlockCornerWithinBorder (corners:BlockCorner) =   
    let checkOneCorner oneCorner = match (oneCorner.XCoordinate, oneCorner.YCoordinate) with
                                   | (a, b) when a > canvasXMax && b > canvasYMax -> ``Both Max coordinates are out of range`` (XMaxCoordinate = a, YMaxCoordinate = b) |> Error
                                   | (a, _) when a > canvasXMax -> ``X Max coordinate is out of range`` (XMaxCoordinate = a) |> Error
                                   | (_, b) when b > canvasYMax -> ``Y Max coordinate is out of range`` (YMaxCoordinate = b) |> Error
                                   | (a, b) when a < canvasXMin && b < canvasYMin -> ``Both Min coordinates are out of range`` (XMinCoordinate = a, YMinCoordinate = b) |> Error
                                   | (a, _) when a < canvasXMin -> ``X Min coordinate is out of range`` (XMinCoordinate = a) |> Error
                                   | (_, b) when b < canvasYMin -> ``Y Min coordinate is out of range`` (YMinCoordinate = b) |> Error
                                   | _, _ -> oneCorner |> Ok
    [corners.TopLeft; corners.ButtomLeft; corners.TopRight; corners.ButtomRight] |> List.map checkOneCorner

let resizeCanvasDimension (sizeError:BlockError) = 
    match sizeError with
    | ``X Max coordinate is out of range`` (XMaxCoordinate = x) -> canvasXMax <- x + canvasExtraSpece
    | ``Y Max coordinate is out of range`` (YMaxCoordinate = y) -> canvasYMax <- y + canvasExtraSpece
    | ``Both Max coordinates are out of range`` (XMaxCoordinate = x; YMaxCoordinate = y) -> canvasXMax <- x + canvasExtraSpece
                                                                                            canvasYMax <- y + canvasExtraSpece
    | ``X Min coordinate is out of range`` (XMinCoordinate = x) -> canvasXMin <- x - canvasExtraSpece
    | ``Y Min coordinate is out of range`` (YMinCoordinate = y) -> canvasYMin <- y - canvasExtraSpece
    | ``Both Min coordinates are out of range`` (XMinCoordinate = x; YMinCoordinate = y) -> canvasXMin <- x - canvasExtraSpece
                                                                                            canvasYMin <- y - canvasExtraSpece

let blockNameGenerator (blockType:BuiltinBlockTypes) = 
    "Block A"

let createBuiltinBlock (coordinate:BuildinBlockCoordinates) (blockType:BuiltinBlockTypes) =
    let height, width = getBuiltinBlockSize blockType
    let buildCoordinates x y = {XCoordinate = x; 
                                YCoordinate = y}
    let allCornerCoordinates = {TopLeft = coordinate;
                                ButtomLeft = buildCoordinates coordinate.XCoordinate (coordinate.YCoordinate - height);
                                TopRight = buildCoordinates (coordinate.XCoordinate + width) coordinate.YCoordinate;
                                ButtomRight = buildCoordinates (coordinate.XCoordinate + width) (coordinate.YCoordinate - height)
                               }
    let block = {BlockName = blockNameGenerator blockType;
                 BlockType = blockType;
                 BlockPins = getBuiltinBlockPins blockType;
                 ConnectionStatus = None;
                 CornerCoordinates = allCornerCoordinates}
    let findErrorInCheckingCorners corner = match corner with
                                            | Error e -> true
                                            | Ok _ -> false
    match checkBlockCornerWithinBorder allCornerCoordinates with
    | [Ok _; Ok _; Ok _; Ok _] -> block
    | lst -> match List.tryFind findErrorInCheckingCorners lst with
             | Some (Error e) -> resizeCanvasDimension e
                                 block
             | Some (Ok _) | None -> failwithf "should not happen. This case is covered the previous match statement"

