using FreshOnes;
string exampleInput = "example";
string input = "input";

Inputs inputs = new();
string entireExample = inputs.Input(exampleInput);
string entireInput = inputs.Input(input);

List<string> fullInput = entireExample.Split('\n').Select(x => x.Trim()).ToList();
// List<string> fullInput = entireInput.Split('\n').Select(x => x.Trim()).ToList();

Separated separated = new();
List<string> allRanges = separated.RangeList(fullInput);
List<string> allIds = separated.IdList(fullInput);

FreshOnesAnswer freshSum = new();
long answer = freshSum.TotalFreshIngredients(allRanges, allIds);

Console.WriteLine(answer);