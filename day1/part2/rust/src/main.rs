use std::{collections::HashMap, fs};

fn main() {
    // let file_name = "day1.example";
    let file_name = "day1.input";

    let (left, right): (Vec<i32>, Vec<i32>) = fs::read_to_string(file_name)
        .unwrap()
        .lines()
        .filter_map(|line| line.split_once("   "))
        .filter_map(|(a, b)| {
            let parsed_a = a.parse::<i32>().ok();
            let parsed_b = b.parse::<i32>().ok();
            parsed_a.zip(parsed_b)
        })
        .unzip();

    let mut count_map = HashMap::new();
    for b in right {
        *count_map.entry(b).or_insert(0) += 1;
    }

    let result: i32 = left
        .iter()
        .map(|v| v * count_map.get(v).unwrap_or(&0))
        .sum();

    println!("{:?}", result);
}
