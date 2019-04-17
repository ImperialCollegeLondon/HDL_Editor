module Canvas

open Blocks

let mutable (blockStorage:BuiltinBlockInfo List) = [];

type CanvasBlockError =
    | ``The block is not found`` of BlockName:string

let addToBlockStorage (block:BuiltinBlockInfo) = 
    blockStorage <- List.append [block] blockStorage

let removeFromBlockStorage (block:BuiltinBlockInfo) = 
    let nameMatch blockItem = block.BlockName = blockItem.BlockName
    let rec removeFromBlockStorage' blockItem blockList (res:BuiltinBlockInfo List) = 
        match blockList with
        | a::b when a.BlockName = blockItem.BlockName -> List.append b res
        | a::b when a.BlockName <> blockItem.BlockName -> removeFromBlockStorage' blockItem b (a::res)
        | _ -> res
    match List.tryFind nameMatch blockStorage with
    | Some el -> blockStorage <-removeFromBlockStorage' el blockStorage []
    | None -> blockStorage <- blockStorage

let getBlockIndexInBlockStorage (block:BuiltinBlockInfo) = 
    let rec getBlockIndexInBlockStorage' blockList index = 
        match blockList with
        | a::b when a.BlockName = block.BlockName -> index |> Ok
        | a::b when a.BlockName <> block.BlockName -> getBlockIndexInBlockStorage' b (index+1)
        | _ -> ``The block is not found``(BlockName = block.BlockName) |> Error
    getBlockIndexInBlockStorage' blockStorage 0

let decreaseCanvasDimension = 
    let add a b = a + b;
    canvasXMax <- blockStorage 
                  |> List.map (fun el -> el.CornerCoordinates.TopRight.XCoordinate) 
                  |> List.max
                  |> add canvasExtraSpece
    canvasXMin <- blockStorage
                  |> List.map (fun el -> el.CornerCoordinates.ButtomLeft.XCoordinate)
                  |> List.min
                  |> add canvasExtraSpece
    canvasYMax <- blockStorage
                  |> List.map (fun el -> el.CornerCoordinates.TopRight.YCoordinate)
                  |> List.max
                  |> add canvasExtraSpece
    canvasYMin <- blockStorage
                  |> List.map (fun el -> el.CornerCoordinates.ButtomLeft.YCoordinate)
                  |> List.min
                  |> add canvasExtraSpece
 
let moveBlocks (block:BuiltinBlockInfo) (coordinate:BuildinBlockCoordinates) = 
    let blockIndex = getBlockIndexInBlockStorage block
    let updatedBlock = block.BlockType 
                       |> createBuiltinBlock coordinate
    blockStorage.[blockIndex] <- updatedBlock

