using System.Diagnostics;

namespace SplitBeam;

public class Timelines
{
    public int TimelineCount(List<string> rows, string input)
    {
        bool stopCheck = false;
        int timelines = 0;
        int startIndex = rows[0].IndexOf('S');
        List<(int, int)> optionRows = new List<(int, int)>();
        List<(int, int, int)> crTimes = new List<(int, int, int)>();
        int times = 1;
        int i = 1;
        while (i < rows.Count)
        {
            bool option = false;
            if (i == rows.Count - 1)
            {
                timelines++;
                stopCheck = false;
                if (optionRows.Count > 0)
                {
                    do
                    {
                        var (rowI, startI) = optionRows[0];
                        if (crTimes.Any(x => x.Item1 == rowI && x.Item2 == startI))
                        {
                            timelines += crTimes.Find(x => x.Item1 == rowI && x.Item2 == startI).Item3;
                            optionRows.RemoveAt(0);
                            (rowI, startI) = optionRows[0];
                            startIndex = startI;
                            i = rowI;
                            break;
                        }
                        else
                        {
                            startIndex = startI;
                            i = rowI;
                            option = true;
                            optionRows.RemoveAt(0);
                            for (int j = i; j < rows.Count; j++)
                            {
                                if (j == rows.Count - 1)
                                {
                                    if (!optionRows.Any()) break;
                                    timelines++;
                                    times++;
                                    (rowI, startI) = optionRows[0];
                                    startIndex = startI;
                                    j = rowI;
                                    if (optionRows[0].Item1 < rowI)
                                    {
                                        i = j;
                                        break;
                                    }
                                    option = true;
                                    optionRows.RemoveAt(0);
                                } 
                                string r = rows[j];
                                if (r[startIndex].Equals('^'))
                                {
                                    if (j < rows.Count - 1 && option == false) optionRows.Insert(0, (j, startIndex));
                                    startIndex += option ? 1 : -1;
                                }
                                option = false;
                            }
                           
                            if (!crTimes.Any(x => x.Item1 == rowI && x.Item2 == startI))
                            {
                                crTimes.Add((rowI, startI, times));
                            }
                            stopCheck = true;
                            times = 1;
                        }
                    } while (stopCheck == false && optionRows.Any());
                }
                else break;
            }
            string row = rows[i];
            if (row[startIndex].Equals('^'))
            {
                if (i < rows.Count - 1) optionRows.Insert(0, (i, startIndex));
                startIndex--;
            }
            i++;
        }
        return timelines;
    }
}