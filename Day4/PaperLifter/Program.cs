string path = AppContext.BaseDirectory;
string allRolls = File.ReadAllText(path + "../../../example.txt");

List<string> rolls = allRolls.Split('\n').Select(rolls => rolls.Trim()).ToList();
int positionsPerRow = rolls[0].Length;

allRolls = "";
foreach (string roll in rolls) allRolls += roll;

int accessSum = 0;
int rounds = 0;
for (int i = 0; i < allRolls.Length; i++)
{
    char c = allRolls[i];
    int adjacents = 0;
    rounds++;

    if (c == '@')
    {
        if (i > positionsPerRow)
        {
            if (allRolls[i - positionsPerRow] == '@') adjacents++;
        }
        if (i != rounds * positionsPerRow)
        {
            if (allRolls[i - 1] == '@' && i > 0) adjacents++;
            if (i < positionsPerRow)
            {
                if (allRolls[i + positionsPerRow - 1] == '@') adjacents++;                
            }
            if (i > positionsPerRow)
            {
                if (allRolls[i - positionsPerRow - 1] == '@') adjacents++;
            }
        }
        if (i != rounds * positionsPerRow - 1)
        {
            if (allRolls[i + 1] == '@' && i < allRolls.Length) adjacents++;
            if (i < positionsPerRow)
            {
                if (allRolls[i + positionsPerRow + 1] == '@') adjacents++;
            }
            if (i > positionsPerRow)
            {
                if (allRolls[i - positionsPerRow + 1] == '@') adjacents++;
            }
        }
        if (i < positionsPerRow)
        {
            if (allRolls[i + positionsPerRow] == '@') adjacents++;
        }
        if (adjacents < 4) accessSum++;
    }
}
// Console.WriteLine(allRolls);
// Console.WriteLine(allRolls.Length);
// Console.WriteLine(positionsPerRow);
Console.WriteLine(accessSum);