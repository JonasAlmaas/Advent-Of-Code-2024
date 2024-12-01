var fName = "input.txt";
// var fName = "example.txt";

var (left, right) = File.ReadAllLines(fName)
	.Select(l => l.Split("   "))
	.Select(split => (int.Parse(split[0]), int.Parse(split[1])))
	.Aggregate(
		(left: new List<int>(), right: new Dictionary<int, int>()),
		(acc, pair) => {
			acc.left.Add(pair.Item1);
			if (!acc.right.TryAdd(pair.Item2, 1)) {
				acc.right[pair.Item2] += 1;
			}
			return acc;
		});

var result = left
	.Select(r => r * right.GetValueOrDefault(r))
	.Sum();

Console.WriteLine(result);
