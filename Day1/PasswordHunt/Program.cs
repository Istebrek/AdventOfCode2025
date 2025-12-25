//Step 1: Save input as text file and add to project.

//Step 2: Find file path and read it.
string path = AppContext.BaseDirectory;
string input = File.ReadAllText(path + "../../../input.txt");

//Step 3: Ensure input variable reads what you expect, then comment it out.
// Console.WriteLine(input);

//Alternative ways to get path:
// string path = Environment.CurrentDirectory;
// string path = Directory.GetCurrentDirectory();
// string path = AppDomain.CurrentDomain.BaseDirectory;

//Find file path by finding the current path.
// Unhandled exception. System.IO.FileNotFoundException: Could not find file 'C:\Users\User\repos\AdventOfCode2025\Day1\PasswordHunt\bin\Debug\net9.0\input.txt'.


