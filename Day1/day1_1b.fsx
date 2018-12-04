open System
let (|Add|_|) (str: string) =
    if (str.StartsWith "+") then Some ((+) (Int32.Parse <| str.Substring 1))
    else None
let (|Subtract|_|) (str: string) =
    if (str.StartsWith "-") then Some ((+) -(Int32.Parse <| str.Substring 1))
    else None
let result = 
    System.IO.File.ReadLines "Day1/input.txt"
        |> Seq.map (fun line -> 
            match line with
            | Add op -> op
            | Subtract op -> op)
        |> Seq.fold (fun acc elem -> elem acc) 0

Console.Write result