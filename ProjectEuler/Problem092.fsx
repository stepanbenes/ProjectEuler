// Square digit chains

(*
A number chain is created by continuously adding the square of the digits in a number to form a new number until it has been seen before.

For example,

44 → 32 → 13 → 10 → 1 → 1
85 → 89 → 145 → 42 → 20 → 4 → 16 → 37 → 58 → 89

Therefore any chain that arrives at 1 or 89 will become stuck in an endless loop. What is most amazing is that EVERY starting number will eventually arrive at 1 or 89.

How many starting numbers below ten million will arrive at 89?
*)

#load "Common.fs"
open Common

let sumSquaresOfDecimalDigits n = n |> parseDecimalDigits |> Seq.map (fun x -> x * x) |> Seq.sum

let rec squareDigitChainEndsWith89 start =
    let sum = sumSquaresOfDecimalDigits start
    match sum with
    | 1 -> false
    | 89 -> true
    | _ -> sum |> squareDigitChainEndsWith89

let count = seq { 1 .. 9999999 } |> Seq.filter squareDigitChainEndsWith89 |> Seq.length
