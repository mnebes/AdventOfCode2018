open System
let getNumber (charList : char list) =
    Int32.Parse <| String.Concat (Array.ofList charList)

let getOperation inputString =
    match Seq.toList inputString with
    | sign::number when sign = '+' -> (+) (getNumber number)
    | sign::number when sign = '-' -> (+) (-(getNumber number))

let findRepeatingSequence operations =
    let rec checkSequence state remainingOperations (sequences : Set<int>) =
        if sequences.Contains state then state
        else
            let operation = List.head remainingOperations
            let newSequences = Set.add state sequences
            checkSequence (operation state) (List.append (List.tail remainingOperations) [ operation ]) newSequences
    checkSequence 0 operations Set.empty

let result =
    System.IO.File.ReadLines "Day1/input.txt"
        |> Seq.map getOperation
        |> List.ofSeq
        |> findRepeatingSequence

Console.Write result