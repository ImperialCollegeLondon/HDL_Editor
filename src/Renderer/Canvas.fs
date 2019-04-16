module Canvas

open Blocks

let mutable (blockStorage:BuiltinBlockInfo List) = [];

let addToBlockStorage (block:BuiltinBlockInfo) = 
    blockStorage <- List.append [block] blockStorage

let removeFromBlockStorage (block:BuiltinBlockInfo) = 
    let nameMatch blockItem = block.BlockName = blockItem.BlockName
    match List.tryFind nameMatch blockStorage with
    | Some el -> 
    | None -> blockStorage <- blockStorage
