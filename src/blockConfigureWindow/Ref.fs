module Ref

/// input types
type UserInputType = 
    | BlockName
    | InputNumber
    | OutputNumber

/// block name
let mutable blockName : string option = option.None

/// number of inputs
let mutable inputNumber : int option = option.None

/// number of outputs
let mutable outputNumber : int option = option.None
