string path = AppContext.BaseDirectory;
string allRolls = File.ReadAllText(path + "../../../example.txt");

Console.WriteLine(allRolls);