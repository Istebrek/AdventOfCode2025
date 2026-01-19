using System.Diagnostics;

namespace SplitBeam;

public class Timelines
{
    public long TimelineCount(List<string> rows)
    {
        long timelines = 0;
        List<(int, long)> colTimes = [(rows[0].IndexOf('S'), 1)];
        for (int i = 1; i < rows.Count; i++)
        {
            string row = rows[i];
            if (!row.Contains('^')) continue;
            string tot = colTimes.Count.ToString();
            for (int j = 0; j < Convert.ToInt32(tot); j++)
            {
                var (col, times) = colTimes[0];
                long newT = times;
                if (row.ElementAt(col).Equals('^'))
                {
                    colTimes.RemoveAt(0);
                    if (colTimes.Any(x => x.Item1 == col - 1))
                    {
                        long t = colTimes.Find(x => x.Item1 == col - 1).Item2;
                        newT = newT += t;
                        long remove = colTimes.Find(x => x.Item1 == col - 1).Item2;
                        colTimes.Remove((col - 1, remove));
                        colTimes.Add((col-1, newT));
                    } else colTimes.Add((col-1, times));
                    if (colTimes.Any(x => x.Item1 == col + 1))
                    {
                        long t = colTimes.Find(x => x.Item1 == col + 1).Item2;
                        newT = times += t;
                        long remove = colTimes.Find(x => x.Item1 == col + 1).Item2;
                        colTimes.Remove((col + 1, remove));
                        colTimes.Add((col+1, newT));
                    } else colTimes.Add((col+1, times));
                } else
                {
                    colTimes.RemoveAt(0);
                    colTimes.Add((col, times));
                }
            }
        }
        foreach (var (col, times) in colTimes)
        {
            timelines += times;
        }
        return timelines;
    }
}