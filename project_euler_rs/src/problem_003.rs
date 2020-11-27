use crate::common::*;

// Largest prime factor

// The prime factors of 13195 are 5, 7, 13 and 29.
// What is the largest prime factor of the number 600851475143 ?

pub fn solve() -> Option<u64> {
    let number = 600_851_475_143_u64;
    let upper_limit = (number as f64).sqrt() as u64 + 1;
    for n in (2..upper_limit).rev() {
        if number % n == 0 && is_prime(n) {
            return Some(n);
        }
    }
    None
}
