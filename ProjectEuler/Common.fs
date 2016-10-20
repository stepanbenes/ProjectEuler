module Common

let rec parseDecimalDigits n =
     seq {
         if n > 0 then
            yield! parseDecimalDigits (n / 10)
            yield n % 10;
     }

//let test = 987654321 |> parseDecimalDigits |> Seq.toList

let isPrime x =
    if x < 2L then
        false
    else
        let rec loop i d = 
            match d with
            | 1L -> true
            | _ -> if i % d = 0L then false else loop i (d - 1L)
        x |> float |> sqrt |> int64 |> loop x