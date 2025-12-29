using BatteryBanks;
//Step 1: Add input and read it.
string path = AppContext.BaseDirectory;
string allBanks = File.ReadAllText(path + "../../../input.txt");

//Step 2: Separate each bank and add them to a list.
List<string> banks = allBanks.Split('\n').Select(bank => bank.Trim()).ToList();

//Step 3: Loop through the list and find the highest joltage batteries in each bank.
List<string> highestJolts = new();

foreach (string bank in banks)
{
    string bankJolt = "";
    int charCount = 0;
    int start2 = 0;
    for (int i = 9; i > 0; i--)
    {
        for (int j = 0; j < bank.Length; j++)
        {
            char c = bank[j];
            if (j <= start2 && charCount == 1)
            {
                continue;
            }
            if (i.ToString() == c.ToString())
            {
                if (charCount == 0 && j == bank.Length-1)
                {
                    break;
                }
                bankJolt += c;
                start2 = j;
                charCount++;
                if (charCount == 1) i = 9;
                if (charCount == 2) 
                {
                    highestJolts.Add(bankJolt);
                    break;
                }
                continue;                
            }
        }
        if (charCount == 2) break;
    }
}

// int sum = 0;
// foreach (string jolt in highestJolts) sum += Convert.ToInt32(jolt);
// Console.WriteLine(sum);

Answer answerInstance = new Answer();
long answer = answerInstance.ReturnJoltage(banks);
Console.WriteLine(answer);

