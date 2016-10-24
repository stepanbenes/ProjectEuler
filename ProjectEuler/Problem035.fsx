// Circular primes

(*
The number, 197, is called a circular prime because all rotations of the digits: 197, 971, and 719, are themselves prime.
There are thirteen such primes below 100: 2, 3, 5, 7, 11, 13, 17, 31, 37, 71, 73, 79, and 97.
How many circular primes are there below one million?
*)

#load "Common.fs"

let composeNumberFromDigits (digits:int[]) offset =
    let mutable number = 0
    for i in 0 .. digits.Length - 1 do 
        let digit = digits.[(i + offset) % digits.Length]
        number <- number * 10 + digit
    number

let isCircularPrime x =
    if Common.Int64.isPrime (int64 x) then
        let digits = x |> Common.Int.parseDecimalDigits |> Seq.toArray
        seq { 1 .. digits.Length - 1 } |> Seq.map (composeNumberFromDigits digits) |> Seq.forall (int64 >> Common.Int64.isPrime)
    else
        false

let count = seq { 1 .. 999999 } |> Seq.filter isCircularPrime |> Seq.length