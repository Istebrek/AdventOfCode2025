using FreshOnes;
string exampleInput = "example";
string input = "input";

Inputs inputs = new();
string entireExample = inputs.Input(exampleInput);
string entireInput = inputs.Input(input);

List<string> fullInput = entireExample.Split('\n').Select(x => x.Trim()).ToList();
// List<string> fullInput = entireInput.Split('\n').Select(x => x.Trim()).ToList();
int indexFrom = fullInput.FindIndex(x => x == "") + 1;

int freshCount = 0;
for (int i = indexFrom; i < fullInput.Count; i++)
{
    string id = fullInput[i];

    if (string.IsNullOrWhiteSpace(id)) continue;

    for (int j = 0; j < indexFrom - 1; j++)
    {
        string range = fullInput[j];
        List<string> ranges = range.Split("-").ToList();
        long start = Convert.ToInt64(ranges[0]);
        long end = Convert.ToInt64(ranges[1]);

        if (Convert.ToInt64(id) < start || Convert.ToInt64(id) > end) continue;
        if (Convert.ToInt64(id) >= start && Convert.ToInt64(id) <= end)
        {
            freshCount++;
            break;
        }

    }
}

Console.WriteLine(freshCount);