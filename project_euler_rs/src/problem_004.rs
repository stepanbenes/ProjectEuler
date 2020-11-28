use std::iter;

// Largest palindrome product

// A palindromic number reads the same both ways. The largest palindrome made from the product of two 2-digit numbers is 9009 = 91 × 99.
// Find the largest palindrome made from the product of two 3-digit numbers.

pub fn solve() -> Option<i32> {
    for startPos in (100..=999)
        .rev()
        .chain(iter::repeat(100).take(999 - 100))
        .zip(iter::repeat(999).take(1000 - 100).chain((100..=998).rev()))
    {
        let (mut x, mut y) = startPos;
        while x <= y {
            let product = x * y;
            if is_palindrome_2(product) {
                println!("{} {}", x, y);
                return Some(product);
            }
            x += 1;
            y -= 1;
        }
    }
    None
}

fn is_palindrome(n: i32) -> bool {
    let mut digits = Vec::new();
    let mut div = n;
    while div > 0 {
        let rem = div % 10;
        digits.push(rem);
        div = div / 10;
    }
    for i in 0..digits.len() / 2 {
        if digits[i] != digits[digits.len() - i - 1] {
            return false;
        }
    }
    true
}

fn is_palindrome_2(n: i32) -> bool {
    let mut n_rev = 0;
    let mut div = n;
    while div > 0 {
        let rem = div % 10;
        n_rev *= 10;
        n_rev += rem;
        div = div / 10;
    }
    n == n_rev
}
