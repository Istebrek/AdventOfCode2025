using SplitBeam;

string splitters = File.ReadAllText(AppContext.BaseDirectory + "../../../input.txt");
List<string> rows = splitters.Split('\n').Select(x => x.Trim()).ToList();
splitters = splitters.Replace("\r\n", "");
int rowCount = rows.Count;

int splits = 0;
List<int> start = new();
start.Add(splitters.IndexOf('S'));
for (int i = 1; i < rows.Count; i++)
{
    string row = rows[i];
    int index = 0;
    if (row.Contains('^'))
    {
        for (int c = 0; c < row.Length; c++)
        {
            if (row[c] != '^') continue;
            index = c;
            if (start.Contains(index))
            {
                if (!start.Contains(index + 1) && index < row.Length) start.Add(index + 1);
                if (!start.Contains(index - 1) && index > 0) start.Add(index - 1);
                start.Remove(index);
                splits++;
            }
        }
    }
}

// Console.WriteLine(splits);

Timelines timelines = new();
Console.WriteLine(timelines.TimelineCount(rows));