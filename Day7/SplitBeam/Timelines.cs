namespace SplitBeam;

public class Timelines
{
    public int TimelineCount(List<string> rows, string input)
    {
        int timelines = 0;
        int startIndex = rows[0].IndexOf('S');
        bool newPath = false;

        do
        {
            newPath = false;
            for (int i = 1; i < rows.Count; i++)
            {
                string row = rows[i];
                int rowL = row.Length;
                if (row.IndexOf('^') == startIndex)
                {
                    input = input.Substring(0, startIndex + (i-1) * rowL) + '|' + input.Substring(startIndex + (i-1) * rowL + 1);
                    if (startIndex >= 0 && startIndex < rowL && !row[startIndex + 1].Equals('|'))
                    {
                        input = input.Substring(0, startIndex + 1 + i * rowL) + '|' + input.Substring(startIndex + 2 + i * rowL);
                        newPath = true;
                    } else if (startIndex != 0 && startIndex <= rowL && !row[startIndex - 1].Equals('|'))
                    {
                        row = input.Substring(0, startIndex - 1 + i * rowL) + '|' + input.Substring(startIndex - 2 + i * rowL);
                        newPath = true;
                    } 
                }
            }
            if (newPath == true) timelines++;
        } while (newPath == true);

        return timelines;
    }

}
