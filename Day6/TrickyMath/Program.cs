string problems = File.ReadAllText(AppContext.BaseDirectory + "../../../input.txt");

List<string> allRows = problems.Split('\n').Select(x => x.Trim()).ToList();
List<string> oneRow = allRows[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
int problemCount = oneRow.Count;
int lastRow = allRows.Count;
List<string> actions = allRows[lastRow - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

List<int> allNumbers = new();
foreach (string numbers in allRows.SkipLast(1))
{
    List<string> everyNumber = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
    foreach (string number in everyNumber) allNumbers.Add(Convert.ToInt32(number));
}

long total = 0;
for (int i = 0; i < problemCount; i++)
{
    long subTotal = allNumbers[i];
    long sum = 0;
    string action = actions[i];
    if (action == "*")
    {
        for (int n = 1; n < allRows.Count - 1; n++)
        {
            int nextN = allNumbers[i + (problemCount * n)];
            sum = subTotal * nextN;
            subTotal = sum;
        }
        total += subTotal;
    }
    if (action == "+")
    {
        for (int n = 1; n < allRows.Count - 1; n++)
        {
            int nextN = allNumbers[i + (problemCount * n)];
            sum = subTotal + nextN;
            subTotal = sum;
        }
        total += subTotal;
    }
}

Console.WriteLine(total);