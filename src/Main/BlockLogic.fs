(*
The block model is divided into two layers: the logical layer and the layout layer.

The logic layer is responsible for describing the blocks and the connections among the the blocks.

The layout layer is responsible for describing the positions of the connections and the blocks on the canvas.

The BlockLogic module implements the logic layer of the block mode.
*)

module BlockLogic

/// ports on the blocks
type BuiltinBlockPort = 
    | SingleBit

/// built-in block types
type BuiltinBlockTypes = 
    | BlockA

/// connection detials
type ConnectionInfo = {
    BusWidth: int;
    SourceBlock: string option;
    SourceBlockType: BuiltinBlockTypes option;
    SourcePin: BuiltinBlockPort option;
    SinkBlock: string option;
    SinkBlockType: BuiltinBlockTypes option;
    SinkPin: BuiltinBlockPort option
    }

/// information of a block on the canvas
type BuiltinBlockInfo = {
    BlockName: string;
    BlockType: BuiltinBlockTypes;
    BlockPorts: BuiltinBlockPort List;
    ConnectionStatus: ConnectionInfo List option;
    }

let getBuiltinBlockSize (blockType:BuiltinBlockTypes) = 
    match blockType with
    | BlockA -> int64 10, int64 10

let getBuiltinBlockPins (blockType:BuiltinBlockTypes) = 
    match blockType with
    | BlockA -> [PortA]


let blockNameGenerator (blockType:BuiltinBlockTypes) = 
    "Block A"
