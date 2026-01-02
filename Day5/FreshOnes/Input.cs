namespace FreshOnes;

public class Inputs
{
    public string Input(string input)
    {
        return File.ReadAllText(AppContext.BaseDirectory + $"../../../{input}.txt");
    }
}
