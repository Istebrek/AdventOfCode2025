namespace SplitBeam;

public class Timelines
{
    public int TimelineCount(List<string> rows, string input)
    {
        int timelines = 0;
        bool newPath = false;
        bool right = true; 

        do
        {
            int startIndex = rows[0].IndexOf('S');
            newPath = false;
            for (int i = 1; i < rows.Count; i++)
            {
                string row = rows[i];
                int rowL = row.Length;
                if (row[startIndex].Equals('.')) input = input.Substring(0, startIndex + i * rowL) + '|' + input.Substring(startIndex + i * rowL + 1);
                if (row[startIndex].Equals('^'))
                {
                    if (right == true && startIndex >= 0 && startIndex < rowL)
                    {
                        if (!input[startIndex+1 + (i+1) * rowL].Equals('|')) newPath = true;
                        input = input.Substring(0, startIndex + 1 + i * rowL) + '|' + input.Substring(startIndex + 2 + i * rowL);
                        startIndex += 1;
                    } else if (right == false && startIndex > 0 && startIndex <= rowL)
                    {
                        if (!input[startIndex-1 + (i+1) * rowL].Equals('|')) newPath = true;
                        input = input.Substring(0, startIndex - 1 + i * rowL) + '|' + input.Substring(startIndex + i * rowL);
                        startIndex -= 1;
                    } 
                }
            }
            right = (right == true) ? false : true;
            if (newPath == true) timelines++;
        } while (newPath == true);

        return timelines;
    }

}
