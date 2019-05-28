(*
    The code in the file implements the canvas model that describes the positioning of the blocks and the connections.

    The canvas model layer updates when saving the block design file.

    The approach to do saving by clearing all the storage, then parse the components.
*)
module CanvasModel

open BlockLogic

/// describe the position and the dimension of a block on the canvas
type BlockPosition =
    {
        BlockInfo: BlockInfo;
        BlockPosition: int * int;
        BlockDimension: int * int;
    }

/// describe the position and the dimension of a connection on the canvas
type ConnectionPosition = 
    {
        ConnectionInfo: ConnectionInfo;
        ConnectionVertices: int * int List
    }

