using PaperLifter;

string path = AppContext.BaseDirectory;
string allRolls = File.ReadAllText(path + "../../../input.txt");

List<string> rolls = allRolls.Split('\n').Select(rolls => rolls.Trim()).ToList();
int row = rolls[0].Length;
int totalRows = rolls.Count();

allRolls = "";
foreach (string roll in rolls) allRolls += roll;

int accessSum = 0;
int rounds = 0;
int fullRound = 0;
Positions positions = new();
for (int i = 0; i < allRolls.Length; i++)
{
    char c = allRolls[i];
    int adjacents = 0;
    if (rounds == row) 
    {
        fullRound++;
        rounds = 0;
    }
    rounds++;

    if (c == '@')
    {
        if (i == fullRound * row) //if character is at a position on the left.
        {
            if (i < row) //if character is on the top row.
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.RightDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
            } else if (i >= (totalRows * row) - row) //if character is on the bottom row.
            {
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.RightUp(i, row, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
            } else
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.RightDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.RightUp(i, row, allRolls) == '@') adjacents++;
            }
        } else if (i == (row * (fullRound + 1)) - 1) //if character is at the right-most position.
        {
            if (i < row) //if character is on the top row.
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
            } else if (i >= (totalRows * row) - row) //if character is on the bottom row.
            {
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftUp(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
            } else
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftUp(i, row, allRolls) == '@') adjacents++;
            }
        } else //if character is not at the right-most or left-most position.
        {
            if (i < row) //if character is on the top row.
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftDown(i, row, allRolls) == '@') adjacents++;
                if (positions.RightDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
            } else if (i >= (totalRows * row) - row) //if character is on the bottom row.
            {
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftUp(i, row, allRolls) == '@') adjacents++;
                if (positions.RightUp(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
            } else // a middle position
            {
                if (positions.Down(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftDown(i, row, allRolls) == '@') adjacents++;
                if (positions.RightDown(i, row, allRolls) == '@') adjacents++;
                if (positions.Left(i, allRolls) == '@') adjacents++;
                if (positions.Right(i, allRolls) == '@') adjacents++;
                if (positions.Up(i, row, allRolls) == '@') adjacents++;
                if (positions.LeftUp(i, row, allRolls) == '@') adjacents++;
                if (positions.RightUp(i, row, allRolls) == '@') adjacents++;
            }
        }
        if (adjacents < 4) accessSum++;
    }
}
// Console.WriteLine(allRolls);
// Console.WriteLine(allRolls.Length);
// Console.WriteLine(positionsPerRow);
// Console.WriteLine(accessSum);

//PART 2
Repeat repeat = new ();
int sum2 = repeat.TotalRemovedRolls(positions, allRolls, row, totalRows);
Console.WriteLine(sum2);