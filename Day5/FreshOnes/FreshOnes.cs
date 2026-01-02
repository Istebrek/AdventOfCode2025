namespace FreshOnes;

public class FreshOnesAnswer
{
    public long TotalFreshIngredients(List<string> ranges, List<string> ids)
    {
        long freshCount = 0;
        List<long> freshIds = new();

        foreach (string range in ranges)
        {
            List<string> splitRange = range.Split('-').ToList();
            long idSum = Convert.ToInt64(splitRange[1]) - Convert.ToInt64(splitRange[0]) + 1;
            for (int i = 0; i < idSum; i++)
            {
                freshIds.Add(Convert.ToInt64(splitRange[0]) + i);
            }
        }

        foreach (string id in ids)
        {
            if (freshIds.Contains(Convert.ToInt64(id)))
            {
                freshCount ++;
            }
        }



        return freshCount;
    }

}
