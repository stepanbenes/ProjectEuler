pub struct Fibonacci {
    current: u32,
    next: u32,
}

pub fn fibonacci() -> Fibonacci {
    Fibonacci {
        current: 0,
        next: 1,
    }
}

impl Iterator for Fibonacci {
    type Item = u32;
    fn next(&mut self) -> Option<u32> {
        let temp = self.next;
        self.next = self.current + self.next;
        self.current = temp;
        Some(self.current)
    }
}

pub fn is_prime(n: u64) -> bool {
    for i in (2..n).rev() {
        if n % i == 0 {
            return false;
        }
    }
    true
}
