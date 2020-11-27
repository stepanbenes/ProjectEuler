mod common;
mod problem_001;
mod problem_002;

fn main() {
    println!("Problem 001: {}", problem_001::solve());
    println!("Problem 002 a: {}", problem_002::solve());
    println!("Problem 002 b: {}", problem_002::solve_iter());
}
