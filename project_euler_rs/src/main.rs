mod common;
mod problem_001;
mod problem_002;
mod problem_003;
mod problem_004;
mod problem_008;

fn main() {
    println!("Problem 001: {}", problem_001::solve());
    println!("Problem 002 a: {}", problem_002::solve());
    println!("Problem 002 b: {}", problem_002::solve_iter());
    println!("Problem 003: {:?}", problem_003::solve());
    println!("Problem 004: {:?}", problem_004::solve());
    println!("Problem 008: {}", problem_008::solve());
}
