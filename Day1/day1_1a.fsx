open System
let getNumber (charList : char list) =
    Int32.Parse <| String.Concat (Array.ofList charList)

let getOperation inputString =
    match Seq.toList inputString with
    | sign::number when sign = '+' -> (+) (getNumber number)
    | sign::number when sign = '-' -> (+) -(getNumber number)

let result = 
    System.IO.File.ReadLines "Day1/input.txt"
        |> Seq.map getOperation
        |> Seq.fold (fun acc operation -> operation acc) 0

Console.Write result