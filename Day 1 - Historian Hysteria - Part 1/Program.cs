var fName = "input.txt";
// var fName = "example.txt";

var (list1, list2) = File.ReadAllLines(fName)
	.Select(l => l.Split("   "))
	.Select(split => (int.Parse(split[0]), int.Parse(split[1])))
	.Aggregate(
		(l1: new List<int>(), l2: new List<int>()),
		(acc, pair) => {
			acc.l1.Add(pair.Item1);
			acc.l2.Add(pair.Item2);
			return acc;
		});

var result = list1.Order()
	.Zip(list2.Order(), (a, b) => Math.Abs(a - b))
	.Sum();

Console.WriteLine(result);
