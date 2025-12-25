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
        if (instructions.Count() == 4176 && c == input.Last())
        {
            instructions.Add(instruction);
        }
    }
}

//Ensure you get the instructions as expected in the text file, then comment it out.
// int i = 1;
// foreach (string s in instructions)
// {
//     Console.Write($"Instruction number {i}: {s}");
//     i++;    
// }

//Index 104 expects instruction R427.
// Console.WriteLine(instructions[104]);

//Index 4176 expects L34 and is the last instruction.
// Console.WriteLine(instructions[4176]);

//Expects 4177 instructions.
// Console.WriteLine(instructions.Count());

//Step 4: Iterate through the list of instructions and turn the dial.
int start = 50;
List<int> landsOn = new();

foreach (string s in instructions)
{
    if (s.Contains('R'))
    {
        string n = s.Substring(1);
        int num = Convert.ToInt32(n);
        int index = start+num;
        if (index <= 99)
        {
            start = index;
            landsOn.Add(start);
        }
        if (index > 99)
        {
            while (index > 99)
            {
                start = index -= 100;
            }   
            landsOn.Add(start);
        }

    }
    if (s.Contains('L'))
    {
        string n = s.Substring(1);
        int num = Convert.ToInt32(n);
        int index = start-num;
        if (index >= 0)
        {
            start = index;
            landsOn.Add(start);
        }
        if (index < 0) 
        {
            while (index < 0)
            {
                start = index += 100;
            }
            landsOn.Add(start);
        }
    }
}

//Ensure you get correct value, then comment it out. Below index expects value 28.
// Console.WriteLine(landsOn[6]);

// foreach (int test in landsOn)
// {
//     Console.WriteLine(test);
// }

//Ensure all rotations are accounted for, then comment it out. Below count should be 4177.
Console.WriteLine(landsOn.Count());

//Step 5: Sum the times the dial lands on 0.
int zeroes = 0;
foreach (int n in landsOn)
{
    if (n == 0)
    {
        zeroes++;
    }
}

Console.WriteLine(zeroes);