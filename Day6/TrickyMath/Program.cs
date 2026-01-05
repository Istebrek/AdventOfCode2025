string problems = File.ReadAllText(AppContext.BaseDirectory + "../../../input.txt");

// List<string> allRows = problems.Split('\n').Select(x => x.Trim()).ToList();
// List<string> oneRow = allRows[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
// int problemCount = oneRow.Count;
// int lastRow = allRows.Count;
// List<string> actions = allRows[lastRow - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

// List<int> allNumbers = new();
// foreach (string numbers in allRows.SkipLast(1))
// {
//     List<string> everyNumber = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
//     foreach (string number in everyNumber) allNumbers.Add(Convert.ToInt32(number));
// }

// long total = 0;
// for (int i = 0; i < problemCount; i++)
// {
//     long subTotal = allNumbers[i];
//     long sum = 0;
//     string action = actions[i];
//     if (action == "*")
//     {
//         for (int n = 1; n < allRows.Count - 1; n++)
//         {
//             int nextN = allNumbers[i + (problemCount * n)];
//             sum = subTotal * nextN;
//             subTotal = sum;
//         }
//         total += subTotal;
//     }
//     if (action == "+")
//     {
//         for (int n = 1; n < allRows.Count - 1; n++)
//         {
//             int nextN = allNumbers[i + (problemCount * n)];
//             sum = subTotal + nextN;
//             subTotal = sum;
//         }
//         total += subTotal;
//     }
// }


//Part 2
// Console.WriteLine(problems);

List<string> theRows = problems.Split('\n').ToList();
List<string> symbols = theRows[theRows.Count - 1].Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
List<string> reverseSymbols = symbols.AsEnumerable().Reverse().ToList();

int symbol = 0;
long answer = 0;

List<string> theNumbers = new();
for (int j = theRows[0].Length - 1; j >= 0; j--)
{
    int blank = 0;
    string column = "";
    foreach (string row in theRows.SkipLast(1))
    {
        if (row[j] == ' ') blank++;
        if (blank == theRows.Count - 1) break;
        if (!row[j].Equals('\r' ) && !row[j].Equals(' ')) column += row[j] + "";
    }
    if (column != "") theNumbers.Add(column);
    if (blank == theRows.Count - 1 || j == 0)
    {
        long summed = 0;
        long sub = Convert.ToInt32(theNumbers[0]);
        if (reverseSymbols[symbol] == "*")
        {
            for (int k = 1; k < theNumbers.Count; k++)
            {
                summed = sub * Convert.ToInt32(theNumbers[k]);
                sub = summed;
            }       
        }
        if (reverseSymbols[symbol] == "+")
        {
            for (int k = 1; k < theNumbers.Count; k++)
            {
                summed = sub + Convert.ToInt32(theNumbers[k]);
                sub = summed;
            }
        }
        answer += sub;
        symbol++;
        theNumbers = new();            
    }
}

Console.WriteLine(answer);
