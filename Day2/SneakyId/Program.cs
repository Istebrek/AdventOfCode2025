//Part 1: Add and read from file
string path = AppContext.BaseDirectory;
string allIds = File.ReadAllText(path + "../../../input.txt");

// Console.WriteLine(allIds);

//Part 2: Populate list with all ids.
List<string> idRanges = allIds.Split(',').ToList();
List<long> ids = new();

foreach (string idRange in idRanges)
{
    string[] range = idRange.Split('-');
    long rangeStart = Convert.ToInt64(range[0]); 
    long rangeEnd = Convert.ToInt64(range[1]);

    for (long i = rangeStart; i <= rangeEnd; i++) {
        ids.Add(i);
    }
}

//Step 3: Sort out invalid ids.
int invalidIdCount = 0;
List<long> invalidIds = new();

foreach (long id in ids)
{
    string idAsString = id.ToString();
    long indexes = idAsString.Length;
    int halfDigits = Convert.ToInt32(indexes/2);

    string repeatStart = idAsString.Substring(0, halfDigits);
    string repeatEnd = idAsString.Substring(halfDigits);
  
    bool leading0 = false;

    if(idAsString[0] == 0)
    {
        leading0 = true;
    }       

    if (repeatStart == repeatEnd || leading0 == true)
    {
        invalidIdCount++;
        invalidIds.Add(id);
    }
}

// Console.WriteLine(invalidIds[3]);
// Console.WriteLine(invalidIdCount);

//Step 4: Sum up the invalid Ids.
long sum = 0;

foreach (long id in invalidIds)
{
    sum += id;
}

//Step 5: Print out the answer.
Console.WriteLine(sum);

// foreach (long id in invalidIds)
// {
//     Console.WriteLine(id);
// }