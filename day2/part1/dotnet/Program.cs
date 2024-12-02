var fName = "input.txt";
// var fName = "example.txt";

var result = File.ReadAllLines(fName)
	.Select(l => l.Split(' ').Select(int.Parse).ToList())
	.Where(levels => {
		if (levels.Count < 2) {
			return true;
		}

		var isDesc = levels[0] > levels[1];
		for (var i=1; i<levels.Count; ++i) {
			if (Math.Abs(levels[i] - levels[i-1]) > 3
					|| levels[i] == levels[i-1]
					|| (isDesc && levels[i] > levels[i-1])
					|| (!isDesc && levels[i] < levels[i-1])) {
				return false;
			}
		}

		return true;
	})
	.Count();

Console.WriteLine(result);
