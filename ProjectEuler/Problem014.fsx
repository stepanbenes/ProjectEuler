// Longest Collatz sequence

(*
The following iterative sequence is defined for the set of positive integers:

n → n/2 (n is even)
n → 3n + 1 (n is odd)

Using the rule above and starting with 13, we generate the following sequence:

13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

Which starting number, under one million, produces the longest chain?

NOTE: Once the chain starts the terms are allowed to go above one million.
*)

let collatz start = 
    if start < 1L then failwith "Only positive integers please!"
    let rec loop n = 
        seq {
            yield n;
            if n > 1L then
                let next = if n % 2L = 0L then n / 2L else 3L * n + 1L
                yield! loop next
        }
    loop start

let longestCollatzSequenceStart stop =
    seq { 1L .. stop } |> Seq.map (fun x -> (x, x |> collatz |> Seq.length) ) |> Seq.maxBy snd

let result = longestCollatzSequenceStart 999999L