//Part 1: Add and read from file
string path = AppContext.BaseDirectory;
string allIds = File.ReadAllText(path + "../../../example.txt");

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
// int invalidIdCount = 0;
// List<long> invalidIds = new();

// foreach (long id in ids)
// {
//     string idAsString = id.ToString();
//     long indexes = idAsString.Length;
//     int halfDigits = Convert.ToInt32(indexes/2);

//     string repeatStart = idAsString.Substring(0, halfDigits);
//     string repeatEnd = idAsString.Substring(halfDigits);
  
//     bool leading0 = false;

//     if(idAsString[0] == 0)
//     {
//         leading0 = true;
//     }       

//     if (repeatStart == repeatEnd || leading0 == true)
//     {
//         invalidIdCount++;
//         invalidIds.Add(id);
//     }
// }

// Console.WriteLine(invalidIds[3]);
// Console.WriteLine(invalidIdCount);

//Step 4: Sum up the invalid Ids.
// long sum = 0;

// foreach (long id in invalidIds)
// {
//     sum += id;
// }

//Step 5: Print out the answer.
// Console.WriteLine(sum);

// foreach (long id in invalidIds)
// {
//     Console.WriteLine(id);
// }

//PART 2
int invalidIdCount2 = 0;
List<long> invalidIds2 = new();

foreach (long id in ids)
{
    string idAsString = id.ToString();
    long indexes = idAsString.Length;
    int halfDigits = Convert.ToInt32(indexes/2);
    int thirdDigits = Convert.ToInt32(indexes/3);
    int fifthDigits = Convert.ToInt32(indexes/5);

    bool isDivided3 = false;
    bool isDivided5 = false;

    // Dictionary<string, int> duplicates = findDuplicates(indexes, idAsString);

    string repeatStart = "";
    string repeatEnd = "";
    string repeatStart1 = "";
    string repeatMiddle = "";
    string repeatEnd1 = "";
    string repeatStart2 = "";
    string repeat2Start2 = "";
    string repeatMiddle2 = "";
    string repeat2End2 = "";
    string repeatEnd2 = "";

    repeatStart = idAsString.Substring(0, halfDigits);
    repeatEnd = idAsString.Substring(halfDigits);

    if (indexes % 3 == 0 && repeatStart != repeatEnd)
    {
        repeatStart1 = idAsString.Substring(0, thirdDigits);
        repeatMiddle = idAsString.Substring(thirdDigits, thirdDigits);
        repeatEnd1 = idAsString.Substring(thirdDigits*2, thirdDigits);
        isDivided3 = true;
    }
    
    if (indexes % 5 == 0 && repeatStart != repeatEnd)
    {
        repeatStart2 = idAsString.Substring(0, fifthDigits);
        repeat2Start2 = idAsString.Substring(fifthDigits, fifthDigits);
        repeatMiddle2 = idAsString.Substring(fifthDigits*2, fifthDigits);
        repeat2End2 = idAsString.Substring(fifthDigits*3, fifthDigits);
        repeatEnd2 = idAsString.Substring(fifthDigits*4, fifthDigits);
        
        isDivided5 = true;
    }

    int repeatedNumber = 0;      
    bool leading0 = false;

    if(idAsString[0] == 0)
    {
        leading0 = true;
    }   

    // string findPattern = "";
    // int patternFrequency = 0;
    // foreach (var duplicate in duplicates)
    // {
    //     findPattern = duplicate.Key;
    //     patternFrequency = duplicate.Value;

    // }

    for (int i = 0; i < indexes; i++)
    {
        string currentNumber = idAsString[i] + "";

        for (int j = i + 1; j < indexes; j++)
        {
            string nextNumber = idAsString[j] + "";
            if (currentNumber != nextNumber)
            {
                repeatedNumber++;
            }
        }
    }
    if (repeatStart == repeatEnd || repeatedNumber == 0 || leading0 == true
        || (repeatStart1 == repeatMiddle && repeatStart1 == repeatEnd1 && isDivided3 == true)
        || (repeatStart2 == repeat2Start2 && repeatStart2 == repeatMiddle2 && repeatStart2 == repeat2End2 && repeatStart2 == repeatEnd2 && isDivided5 == true))
    {
        invalidIdCount2++;
        invalidIds2.Add(id);
    }
}

// Console.WriteLine(invalidIdCount2);
// foreach (int id in invalidIds2)
//     Console.WriteLine(id);


// Dictionary<string, int> findDuplicates(long length, string stringedId)
// {
//     int stringGuide = 0;
//     Dictionary<string, int> substrings = new();

//     for (int i = 2; i <= length/2; i++)
//     {
//         stringGuide = Convert.ToInt32(length)/i;
//         substrings.Add(stringedId.Substring(0, stringGuide), stringGuide);
//     }
//     return substrings;
// }

long sum = 0;

foreach (long id in invalidIds2)
{
    sum += id;
}

Console.WriteLine(sum);