// Largest prime factor

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?

let isPrime x =
    if x < 2L then
        false
    else
        let rec loop i d = 
            match d with
            | 1L -> true
            | _ -> if i % d = 0L then false else loop i (d - 1L)
        x |> float |> sqrt |> int64 |> loop x

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