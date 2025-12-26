//Part 1: Add and read from file

string path = AppContext.BaseDirectory;
string allIds = File.ReadAllText(path + "../../../input.txt");

Console.WriteLine(allIds);