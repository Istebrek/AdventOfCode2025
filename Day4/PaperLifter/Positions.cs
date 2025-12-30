namespace PaperLifter;

public class Positions
{
    public char LeftUp(int i, int row, string allRolls)
    {
        return allRolls[i - row - 1];        
    }
    public char Up(int i, int row, string allRolls)
    {
        return allRolls[i - row];        
    }
    public char RightUp(int i, int row, string allRolls)
    {
        return allRolls[i - row + 1];    
    }
    public char Left(int i, string allRolls)
    {
        return allRolls[i - 1];        
    }
    public char Right(int i, string allRolls)
    {
        return allRolls[i + 1];        
    }
    public char LeftDown(int i, int row, string allRolls)
    {
        return allRolls[i + row - 1];        
    }
    public char Down(int i, int row, string allRolls)
    {
        return allRolls[i + row];        
    }
    public char RightDown(int i, int row, string allRolls)
    {
        return allRolls[i + row + 1];        
    }
}
