module Common

let rec parseDecimalDigits n =
     seq {
         if n > 0 then
            let d = n % 10
            yield d;
            yield! parseDecimalDigits (n / 10)
     }

//let test = 987654321 |> parseDecimalDigits |> Seq.toList