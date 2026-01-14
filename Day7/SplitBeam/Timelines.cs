namespace SplitBeam;

public class Timelines
{
    public long TimelineCount(List<string> rows, string input)
    {
        long timelines = 0;
        int startIndex = rows[0].IndexOf('S');
        List<(int, int)> optionRows = new List<(int, int)>();
        int i = 1;
        while (i < rows.Count)
        {
            bool option = false;
            if (i == rows.Count - 1)
            {
                timelines++;
                if (optionRows.Count > 0)
                {
                    var (rowI, startI) = optionRows[0];
                    option = true;
                    startIndex = startI;
                    i = rowI;
                    optionRows.RemoveAt(0);
                    
                } else break;
            }
            string row = rows[i];
            if (row[startIndex].Equals('^'))
            {
                if (i < rows.Count - 1 && option == false) optionRows.Insert(0, (i, startIndex));
                startIndex += option ? 1 : -1;
            }
            i++;
        }
        return timelines;
    }
}