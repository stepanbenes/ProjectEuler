// Largest prime factor

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?

#load "Common.fs"
open Common.Int64

let rec nextPrime x =
    let next = x + 1L
    if isPrime next then
        next
    else
        nextPrime next

let rec largestPrimeFactor x soFar =
    let next = nextPrime soFar
    match x % next with
    | 0L -> 
        let rest = x / next
        match next < rest with
        | true -> largestPrimeFactor rest next
        | false -> next
    | _ -> largestPrimeFactor x next

let number = 600851475143L
//let rootedNumber = number |> float |> sqrt |> int64        
               
let result = largestPrimeFactor number 1L