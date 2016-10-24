// Bouncy numbers

(*
Working from left-to-right if no digit is exceeded by the digit to its left it is called an increasing number; for example, 134468.
Similarly if no digit is exceeded by the digit to its right it is called a decreasing number; for example, 66420.
We shall call a positive integer that is neither increasing nor decreasing a "bouncy" number; for example, 155349.
Clearly there cannot be any bouncy numbers below one-hundred, but just over half of the numbers below one-thousand (525) are bouncy. In fact, the least number for which the proportion of bouncy numbers first reaches 50% is 538.
Surprisingly, bouncy numbers become more and more common and by the time we reach 21780 the proportion of bouncy numbers is equal to 90%.
Find the least number for which the proportion of bouncy numbers is exactly 99%.
*)

#load "Common.fs"
open Common.Int

let isIncreasing xs =
    match xs with
    | first :: rest -> 
        let rec checkIncreasing pivot xs =
            match xs with
            | head :: tail -> 
                if pivot <= head then
                    checkIncreasing head tail
                else
                    false
            | [] -> true
        checkIncreasing first rest
    | [] -> true

let isDecreasing xs =
    match xs with
    | first :: rest -> 
        let rec checkDecreasing pivot xs =
            match xs with
            | head :: tail -> 
                if pivot >= head then
                    checkDecreasing head tail
                else
                    false
            | [] -> true
        checkDecreasing first rest
    | [] -> true

let isBouncyNumber n =
    let digits = parseDecimalDigits n |> Seq.toList
    not (isIncreasing digits) && not (isDecreasing digits)

let rec infiniteSequence start = seq { yield start; yield! infiniteSequence (start + 1) }

let rec bouncyCountSequence x bouncyCountSoFar =
    seq {
        let bouncyCount = bouncyCountSoFar + if isBouncyNumber x then 1 else 0
        yield (x, bouncyCount);
        yield! bouncyCountSequence (x + 1) bouncyCount
    }

let findFirst proportionPercent =
    bouncyCountSequence 1 0 |> Seq.find (fun (x, bouncyCount) -> bouncyCount * 100 / x >= proportionPercent)

findFirst 99