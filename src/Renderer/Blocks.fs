(*
    Module: Blocks
    Description: define different blocks and methods to interact with them
*)

module Blocks

type BuiltinBlockTypes = 
    | A

type BuiltinBlockMethods = 
    | Connect
    | Disconnect

type BuiltinBlockConnectionStatus = 
    | NotConnected
    | Connected

type BuildinBlockCoordinates = 
    | XCoordinate of int
    | YCoordinate of int

type BuiltinBlockInfo = {
    BlockType: BuiltinBlockTypes;
    ConnectionStatus: BuiltinBlockConnectionStatus;
    Coordinate: (B)
}

