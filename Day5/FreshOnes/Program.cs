using FreshOnes;
string exampleInput = "example";
string input = "input";

Inputs inputs = new();
string entireExample = inputs.Input(exampleInput);
string entireInput = inputs.Input(input);

// List<string> fullInput = entireExample.Split('\n').Select(x => x.Trim()).ToList();
List<string> fullInput = entireInput.Split('\n').Select(x => x.Trim()).ToList();
int indexFrom = fullInput.FindIndex(x => x == "") + 1;

// int freshCount = 0;
// for (int i = indexFrom; i < fullInput.Count; i++)
// {
//     string id = fullInput[i];

//     if (string.IsNullOrWhiteSpace(id)) continue;

//     for (int j = 0; j < indexFrom - 1; j++)
//     {
//         string range = fullInput[j];
//         List<string> ranges = range.Split("-").ToList();
//         long start = Convert.ToInt64(ranges[0]);
//         long end = Convert.ToInt64(ranges[1]);

//         if (Convert.ToInt64(id) < start || Convert.ToInt64(id) > end) continue;
//         if (Convert.ToInt64(id) >= start && Convert.ToInt64(id) <= end)
//         {
//             freshCount++;
//             break;
//         }

//     }
// }

// Console.WriteLine(freshCount);

//PART 2
List<(long start, long end)> ranges = new();

for (int i = 0; i < indexFrom - 1; i++)
{
    var parts = fullInput[i].Split('-');
    long start = long.Parse(parts[0]);
    long end = long.Parse(parts[1]);
    ranges.Add((start, end));
}

ranges.Sort((a, b) => a.start.CompareTo(b.start));

long freshIdCount = 0;
long thisStart = ranges[0].start;
long thisEnd = ranges[0].end;

foreach (var (start, end) in ranges.Skip(1))
{
    if (start <= thisEnd + 1) thisEnd = Math.Max(thisEnd, end);
    else
    {
        freshIdCount += thisEnd - thisStart + 1;
        thisStart = start;
        thisEnd = end;
    }
}
freshIdCount += thisEnd - thisStart + 1;

Console.WriteLine(freshIdCount);
