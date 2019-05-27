(*
The block model is divided into two layers: the logical layer and the layout layer.

The logic layer is responsible for describing the blocks and the connections among the the blocks.

The layout layer is responsible for describing the positions of the connections and the blocks on the canvas.

The BlockLogic module implements the logic layer of the block mode.
*)

module BlockLogic

/// ports are either inputs or outputs
type PortFunctionType = 
    | Input
    | Output

/// ports on the blocks
type BlockPort = 
    {
        Width: int;
        Name: string;
        Type: PortFunctionType
    }

/// block types
type BlockType = 
    | Register
    | AndGate
    | OrGate
    | NotGate

/// describe the connections
type Connection = 
    {
        SourcePort: BlockPort;
        SinkPort: BlockPort;
    }

/// block description
type BlockInfo = 
    {
        BlockName: string;
        Type: BlockType;
        Port: BlockPort List;
    }

/// connections are always described from the source to the sink to avoid repetition
type ConnectionInfo = 
    {
        ConnectionName: string option;
        SourceBlock: BlockInfo;
        SourcePort: BlockPort;
        SinkBlock: BlockInfo;
        SinkPin: BlockPort
    }

/// helper function for removing element from a list
let removeFromList checkFunction list = 
    let rec removeFromList' lst processed = 
        match lst with
        | h::t when checkFunction h -> t
        | h::t -> removeFromList' t (h::processed)
        | _ -> processed
    removeFromList' list []

/// helper function for updating a list
let updateList checkFunction list el = 
    let rec updateList' lst processed = 
        match lst with
        | h::t when checkFunction h -> el::t
        | h::t -> updateList' t (h::processed)
        | _ -> processed
    updateList' list []
    
/// block storage
let mutable (blockStorage : BlockInfo List) = []

/// operations on the connection storage
type UpdateBlockStorageMode = 
    | AddNewBlock of NewBlock : BlockInfo
    | DeleteOneBlock of Block : BlockInfo
    | DeleteAllBlocks

/// helper function for updating the block storage
let updateBlockStorage (mode : UpdateBlockStorageMode) = 
    match mode with
    | AddNewBlock newBlock
        -> blockStorage <- blockStorage |> List.append [newBlock]
    | DeleteOneBlock block
        -> let checkFunction el = 
                el = block
           blockStorage <- removeFromList checkFunction blockStorage
    | DeleteAllBlocks
        -> blockStorage <- []

/// connection storage
let mutable (connectionStorage : ConnectionInfo List) = []

/// operations on the connection storage
type UpdateConnectionStorageMode = 
    | AddNewConnection of NewConnection : ConnectionInfo
    | DeleteOneConnection of Connection : ConnectionInfo
    | UpdateOneConnection of Connection : ConnectionInfo * UpdatedConnection : ConnectionInfo
    | DeleteAllConnections

/// helper function for updating the connection storage
let updateConnectionStorage (mode : UpdateConnectionStorageMode) =
    match mode with
    | AddNewConnection newConnection 
        -> connectionStorage <- connectionStorage |> List.append [newConnection]
    | DeleteOneConnection connection 
        -> let checkFunction el =
                el = connection
           connectionStorage <- removeFromList checkFunction connectionStorage
    | UpdateOneConnection (connection, newConnection) 
        -> let checkFunction el = 
                el = connection
           connectionStorage <- updateList checkFunction connectionStorage newConnection
    | DeleteAllConnections
        -> connectionStorage <- []
