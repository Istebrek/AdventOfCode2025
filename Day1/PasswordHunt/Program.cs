//Step 1: Save input as text file and add to project.

//Step 2: Find file path and read it.
string path = AppContext.BaseDirectory;
string input = File.ReadAllText(path + "../../../input.txt");

//Ensure input variable reads what you expect, then comment it out.
// Console.WriteLine(input);

//Alternative ways to get path:
// string path = Environment.CurrentDirectory;
// string path = Directory.GetCurrentDirectory();
// string path = AppDomain.CurrentDomain.BaseDirectory;

//Find file path by finding the current path.
// Unhandled exception. System.IO.FileNotFoundException: Could not find file 'C:\Users\User\repos\AdventOfCode2025\Day1\PasswordHunt\bin\Debug\net9.0\input.txt'.

//Step 3: Loop through the input and separate them into a list of instructions.
char letter;
char number;
string instruction = "";
List<string> instructions = new();

foreach (char c in input)
{
    if (c == 'L' || c == 'R')
    {
        if (instruction.Contains('L') || instruction.Contains('R'))
        {
            instructions.Add(instruction);
        }
        letter = c;
        instruction = c.ToString();
    } else
    {
        number = c;
        instruction += c.ToString();
    }
}

//Ensure you get the instructions as expected in the text file, then comment it out. Index 104 expects instruction R427.
Console.WriteLine(instructions[4176]);    
// int i = 1;
// if (i < 10)
// {
//     foreach (string s in instructions)
//     {
//         Console.Write($"Instruction number {i}: {s}");
//         i++;    
        
//     }
// }




const int start = 50;