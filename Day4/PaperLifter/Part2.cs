namespace PaperLifter;

public class Repeat
{
    public int TotalRemovedRolls(Positions positions, string allRolls, int row, int totalRows)
    {
        int round = 0;
        int sum = 0;
        int accessSum = 0;
        bool isZero = false;
        positions = new();

        while (isZero == false)
        {
            sum += accessSum;
            accessSum = 0;
            int rounds = 0;
            int fullRound = 0;
            List<int> accessedRolls = new ();
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
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                        }
                        else if (i >= (totalRows * row) - row) //if character is on the bottom row.
                        {
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightUp(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                        }
                        else
                        {
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightUp(i, row, allRolls) == '@') {adjacents++;}
                        }
                    }
                    else if (i == (row * (fullRound + 1)) - 1) //if character is at the right-most position.
                    {
                        if (i < row) //if character is on the top row.
                        {
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                        }
                        else if (i >= (totalRows * row) - row) //if character is on the bottom row.
                        {
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftUp(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                        }
                        else
                        {
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftUp(i, row, allRolls) == '@') {adjacents++;}
                        }
                    }
                    else //if character is not at the right-most or left-most position.
                    {
                        if (i < row) //if character is on the top row.
                        {
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                        }
                        else if (i >= (totalRows * row) - row) //if character is on the bottom row.
                        {
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftUp(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightUp(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                        }
                        else // a middle position
                        {
                            if (positions.Down(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightDown(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.Left(i, allRolls) == '@') {adjacents++;}
                            if (positions.Right(i, allRolls) == '@') {adjacents++;}
                            if (positions.Up(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.LeftUp(i, row, allRolls) == '@') {adjacents++;}
                            if (positions.RightUp(i, row, allRolls) == '@') {adjacents++;}
                        }
                    }
                    if (adjacents < 4) 
                    {
                        accessSum++;
                        accessedRolls.Add(i);
                    }
                }
            }
            foreach (int i in accessedRolls)
            {
                string newC = allRolls.Substring(i, 1);
                newC = ".";
                string preString = allRolls.Substring(0, i);
                string postString = allRolls.Substring(i + 1);
                allRolls = preString + newC + postString;
                round++;                
                // File.AppendAllText(AppContext.BaseDirectory + $"../../../example{round}.txt", allRolls);
            }
            if (accessSum == 0) isZero = true;

            // Console.WriteLine($"Round {rounds} has access to {accessSum} paper rolls");
        }
        return sum;
    }

}
