(*
    Module: Blocks
    Description: define different blocks and methods to create and interact with them
*)

module Blocks

/// define the dimensions of the canvas
let canvasXMax = 10000;

let canvasYMax = 10000;

/// possible errors when creating or interacting with blocks
type BlockError = 
    | ``X coordinate is out of range`` of XCoordinate:int
    | ``Y coordinate is out of range`` of YCoordinate:int

/// built-in block types
type BuiltinBlockTypes = 
    | BlockA

/// pins on the blocks
type BuiltinBlockPin = 
    | PinA

/// connection detials
type ConnectionInfo = {
    BusWidth: int;
    SourceBlock: string;
    SourceBlockType: BuiltinBlockTypes;
    SourcePin: BuiltinBlockPin;
    SinkBlock: string;
    SinkBlockType: BuiltinBlockTypes;
    SinkPin: BuiltinBlockPin
}

/// the coordinates of the corners of the block
type BuildinBlockCoordinates = {
    TopLeftXCoordinate: int;
    ButtomLeftYCoordinate: int;
}

/// information of a block on the canvas
type BuiltinBlockInfo = {
    BlockType: BuiltinBlockTypes;
    ConnectionStatus: ConnectionInfo List;
    Coordinate: BuildinBlockCoordinates;
}

let checkBlockCenterWithinBorder (x:int) (y:int) = 
    match x, y with
    | a, _ when a > canvasXMax -> ``X coordinate is out of range`` (XCoordinate = a) |> Error
    | _, b when b > canvasYMax -> ``Y coordinate is out of range`` (YCoordinate = b) |> Error
    | c, d -> (c, d) |> Ok

let createBuiltinBlock (x:int) (y:int) (blockType:BuiltinBlockTypes) =
    match checkBlockCenterWithinBorder x y with
    | Ok (c, d) -> Ok {BlockType = blockType;
                       ConnectionStatus = [];
                       Coordinate = {TopLeftXCoordinate = c; ButtomLeftYCoordinate = d}}
    | Error e -> Error e

