open System
let getNumber (charList : char list) =
    Int32.Parse <| String.Concat (Array.ofList charList)

let getOperation inputString =
    match Seq.toList inputString with
    | sign::number when sign = '+' -> (+) (getNumber number)
    | sign::number when sign = '-' -> (+) -(getNumber number)

let findRepeatingSequence operations = 
    let rec checkSequence state remainingOperations allOperations (sequences : Set<int>) =
        if sequences.Contains state then state
        else 
            let newState = List.head remainingOperations <| state
            let newSequences = Set.add state sequences
            let newRemainingOperations = 
                match List.tail remainingOperations with
                | [x] -> x::allOperations
                | x::xs -> x::xs
            checkSequence newState newRemainingOperations allOperations newSequences
    checkSequence 0 operations operations Set.empty
    
let result = 
    System.IO.File.ReadLines "Day1/input.txt"
        |> Seq.map getOperation
        |> List.ofSeq
        |> findRepeatingSequence

Console.Write result