(*
    Module: Blocks
    Description: define different blocks and methods to create and interact with them
*)

module Blocks

/// define the dimensions of the canvas
let mutable canvasXMax = 1000;

let mutable canvasYMax = 1000;

let canvasExtraSpece = 10;

/// possible errors when creating or interacting with blocks
type BlockError = 
    | ``X coordinate is out of range`` of XCoordinate:int
    | ``Y coordinate is out of range`` of YCoordinate:int
    | ``Both coordinates are out of range`` of XCoordinate:int * YCoordinate:int

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
    XCoordinate: int;
    YCoordinate: int
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
    ConnectionStatus: ConnectionInfo List option;
    CornerCoordinates: BlockCorner
}

let getBuiltinBlockSize (blockType:BuiltinBlockTypes) = 
    match blockType with
    | BlockA -> 10, 10

let checkBlockCornerWithinBorder (corners:BlockCorner) =   
    let checkOneCorner oneCorner = match (oneCorner.XCoordinate, oneCorner.YCoordinate) with
                                   | (a, b) when a > canvasXMax && b > canvasYMax -> ``Both coordinates are out of range`` (XCoordinate = a, YCoordinate = b) |> Error
                                   | a, _ when a > canvasXMax -> ``X coordinate is out of range`` (XCoordinate = a) |> Error
                                   | _, b when b > canvasYMax -> ``Y coordinate is out of range`` (YCoordinate = b) |> Error
                                   | _, _ -> oneCorner |> Ok
    [corners.TopLeft; corners.ButtomLeft; corners.TopRight; corners.ButtomRight] |> List.map checkOneCorner

let resizeCanvasDimension (sizeError:BlockError) = 
    match sizeError with
    | ``X coordinate is out of range``(XCoordinate = x) -> canvasXMax <- x + canvasExtraSpece
    | ``Y coordinate is out of range``(YCoordinate = y) -> canvasYMax <- y + canvasExtraSpece
    | ``Both coordinates are out of range``(XCoordinate = x; YCoordinate = y) -> canvasXMax <- (x + canvasExtraSpece)
                                                                                 canvasYMax <- (y + canvasExtraSpece)
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

