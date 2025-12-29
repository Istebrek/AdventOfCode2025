namespace BatteryBanks;

public class Answer
{
    public long ReturnJoltage(List<string> banks)
    {
        List<string> highestJolts = new();
        foreach (string bank in banks)
        {
            string bankJolt = "";
            int charCount = 0;
            int start2 = -1;
            for (int i = 9; i > 0; i--)
            {
                bool toBreak = false;
                for (int j = 0; j < bank.Length; j++)
                {
                    int on = bank.Length - 11;
                    if (j == on + charCount && (j != bank.Length - 1 || charCount != 11)) 
                    {
                        toBreak = true;
                        break;
                    }
                    char c = bank[j];
                    if (j <= start2)
                    {
                        continue;
                    }
                    if (i.ToString() == c.ToString())
                    {
                        bankJolt += c;
                        start2 = j;
                        charCount++;
                        i = 9;
                        if (charCount == 12)
                        {
                            highestJolts.Add(bankJolt);
                            Console.WriteLine(bankJolt);
                            toBreak = true;
                            break;
                        }
                        continue;
                    }
                    if (toBreak == true) break;
                }
                if (charCount == 12) break;
            }
        }

        long sum = 0;
        foreach (string jolts in highestJolts) sum += Convert.ToInt64(jolts);
        return sum;
    }
}
