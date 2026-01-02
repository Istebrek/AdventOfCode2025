namespace FreshOnes;

public class Separated
{
    public List<string> RangeList(List<string> input)
    {
        List<string> allRanges = new();
        foreach (string range in input)
        {
            if (range.Equals("")) break;
            allRanges.Add(range);
        }
        return allRanges;
    }

    public List<string> IdList(List<string> input)
    {
        List<string> allIds = new();
        List<string> inputReverse = new();
        inputReverse = input.AsEnumerable().Reverse().ToList();
        foreach (string id in inputReverse)
        {
            if (id.Equals("")) break;
            allIds.Add(id);
        }
        return allIds;
    }
}
