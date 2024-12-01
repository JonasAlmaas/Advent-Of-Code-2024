use std::fs;

fn main() {
    // let file_name = "day1.example";
    let file_name = "day1.input";

    let (mut left, mut right): (Vec<i32>, Vec<i32>) = fs::read_to_string(file_name)
        .unwrap()
        .lines()
        .filter_map(|line| line.split_once("   "))
        .filter_map(|(a, b)| {
            let parsed_a = a.parse::<i32>().ok();
            let parsed_b = b.parse::<i32>().ok();
            parsed_a.zip(parsed_b)
        })
        .unzip();

    left.sort();
    right.sort();

    let result: i32 = left
        .iter()
        .zip(right.iter())
        .map(|(a, b)| i32::abs(a - b))
        .sum();

    println!("{:?}", result);
}
