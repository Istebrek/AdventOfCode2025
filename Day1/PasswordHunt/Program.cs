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
int dial = 50;
List<int> landsOn = new();

// foreach (string s in instructions)
// {
//     if (s.Contains('R'))
//     {
//         string n = s.Substring(1);
//         int num = Convert.ToInt32(n);
//         int index = dial+num;
//         if (index <= 99)
//         {
//             dial = index;
//             landsOn.Add(dial);
//         }
//         if (index > 99)
//         {
//             while (index > 99)
//             {
//                 dial = index -= 100;
//             }   
//             landsOn.Add(dial);
//         }

//     }
//     if (s.Contains('L'))
//     {
//         string n = s.Substring(1);
//         int num = Convert.ToInt32(n);
//         int index = dial-num;
//         if (index >= 0)
//         {
//             dial = index;
//             landsOn.Add(dial);
//         }
//         if (index < 0) 
//         {
//             while (index < 0)
//             {
//                 dial = index += 100;
//             }
//             landsOn.Add(dial);
//         }
//     }
// }


/* PART 2 */
// int zero = 0;
// foreach (string s in instructions)
// {
//     if (s.Contains('R'))
//     {
//         string n = s.Substring(1);
//         int num = Convert.ToInt32(n);
//         int index = dial+num;
//         if (index == 0) zero++;
//         if (index <= 99)
//         {
//             dial = index;
//             landsOn.Add(dial);
//         }
//         while (index > 99)
//         {
//             dial = index -= 100;
//             landsOn.Add(dial);
//             zero++;
//         }
//     }
//     if (s.Contains('L'))
//     {
//         string n = s.Substring(1);
//         int num = Convert.ToInt32(n);
//         int index = dial-num;

//         if (index == 0) zero++;            
//         if (index >= 0)
//         {
//             dial = index;
//             landsOn.Add(dial);
//         }
//         while (index < 0)
//         {
//             dial = index += 100;
//             landsOn.Add(dial);
//             zero++;
//         }
//     }
// }
// Console.WriteLine($"{zero}");
// int j = 0;

// Console.WriteLine("- The dial starts by pointing at 50.");
// foreach (int rotation in landsOn)
// {
//     Console.WriteLine($"- The dial is rotated {instructions[j]} to point at {rotation}");
//     j++;
// }

//Ensure you get correct value, then comment it out. Below index expects value 28.
// Console.WriteLine(landsOn[6]);

// foreach (int test in landsOn)
// {
//     Console.WriteLine(test);
// }

//Ensure all rotations are accounted for, then comment it out. Below count should be 4177.
// Console.WriteLine(landsOn.Count());

//Step 5: Sum the times the dial lands on 0.
// int zeroes = 0;
// foreach (int n in landsOn)
// {
//     if (n == 0)
//     {
//         zeroes++;
//     }
// }

//Test against submission at the official site, should be 982.
// Console.WriteLine(zeroes);


//PART 2:
// int zero = 0;
// int k = 0;
// Console.WriteLine($"Dial starts by pointing at {dial}.");

// foreach (string rotation in instructions)
// {
//     k = 0;
//     if (rotation.Contains('R'))
//     {
//         int rotationNumber = Convert.ToInt32(rotation.Substring(1));
//         int sum = dial + rotationNumber;

//         if (sum <= 99) 
//         {
//             dial = sum;
//             landsOn.Add(dial);
//             Console.WriteLine($"Dial is rotated {rotation} and points at {dial}.");
//         }
//         if (sum > 99)
//         {
//             while (sum > 99)
//             {
//                 dial = sum -= 100;
//                 landsOn.Add(dial);
//                 zero++;
//                 k++;
//             }            
//             Console.WriteLine($"Dial is rotated {rotation} and points at {dial}; it points at 0 {k} times.");
//         }
//     }

//     if (rotation.Contains('L'))
//     {
//         // Console.WriteLine($"Dial points at {dial}.");

//         int rotationNumber = Convert.ToInt32(rotation.Substring(1));
//         int sum = dial - rotationNumber;

//         if (sum >= 0) 
//         {
//             dial = sum;
//             landsOn.Add(dial);
//             Console.WriteLine($"Dial is rotated {rotation} and points at {dial}.");
//         }
//         if (sum < 0 && dial != 0)
//         {
//             while (sum < 0)
//             {
//                 dial = sum += 100;
//                 landsOn.Add(dial);
//                 zero++;
//                 k++;
//             }
//             Console.WriteLine($"Dial is rotated {rotation} and points at {dial}; it points at 0 {k} times.");
//         }
//         if (dial == 0)
//         {
//             dial = sum +=100;
//             landsOn.Add(dial);
//         }
//     }
// }

// Console.WriteLine(zero);

//PART 2 attempt 3
int answer = 0;

foreach (string rotation in instructions)
{
    int turns = Convert.ToInt32(rotation.Substring(1));
    for (int i = 0; i < turns; i++)
    {
        if (rotation.Contains('R'))
        {
            dial -= 1;
        }
        if (rotation.Contains('L'))
        {
            dial += 1;
        }
        if ((dial % 100) == 0)
        {
            answer++;
        }
    }
}

Console.WriteLine(answer);