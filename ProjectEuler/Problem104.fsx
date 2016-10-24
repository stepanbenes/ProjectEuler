// Pandigital Fibonacci ends

(*
The Fibonacci sequence is defined by the recurrence relation:

Fn = Fn−1 + Fn−2, where F1 = 1 and F2 = 1.
It turns out that F541, which contains 113 digits, is the first Fibonacci number for which the last nine digits are 1-9 pandigital (contain all the digits 1 to 9, but not necessarily in order). And F2749, which contains 575 digits, is the first Fibonacci number for which the first nine digits are 1-9 pandigital.

Given that Fk is the first Fibonacci number for which the first nine digits AND the last nine digits are 1-9 pandigital, find k. 
*)

#load "Common.fs"
open Common.BigInt

let isPandigital xs =
    let mask = xs |> Seq.fold (fun state x -> (1 <<< x) ||| state) 0
    mask = 0b111110

let isPandigitalAtBeginning x =
    if x >= 12345I then
        parseDecimalDigits x |> Seq.take 5 |> isPandigital
    else
        false

let isPandigitalAtEnd x =
    if x >= 12345I then
        parseDecimalDigitsReverse x |> Seq.take 5 |> isPandigital
    else
        false

let isPandigitalAtBothEnds x = (isPandigitalAtBeginning x) && (isPandigitalAtEnd x)

let index = (fibonacci |> Seq.findIndex isPandigitalAtBothEnds) + 1 // index is 1-based