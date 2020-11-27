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
