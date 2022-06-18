using Domino;

public class Value
{
    public string? Winnable { get; set; } = Utils.GetWinnables().First().GetType().Name;
    public string? Rounder { get; set; } = Utils.GetRounders().First().GetType().Name;
    public string? Shuffler{get;set;} = Utils.GetShufflers().First().GetType().Name;
    public string? HandCounter{get;set;} = Utils.GetHandCounters().First().GetType().Name;
    public string? Board{get;set;} = Utils.GetBoards().First().GetType().Name;

    public void GetEmpty()
    {
        Winnable = string.Empty;
        Rounder = string.Empty;
        Shuffler = string.Empty;
        HandCounter = string.Empty;
        Board = string.Empty;
    } 
    public IWinnable? GetWinnable()
    {
        Type? t = typeof(IWinnable).Assembly.GetTypes().FirstOrDefault(p => p.Name == Winnable);
        return Activator.CreateInstance(t!) as IWinnable;
    }
    public IRounder? GetRounder()
    {
        Type? t = typeof(IRounder).Assembly.GetTypes().FirstOrDefault(p => p.Name == Rounder);
        return Activator.CreateInstance(t!) as IRounder;
    }
    public IShuffler? GetShuffler()
    {
        Type? t = typeof(IShuffler).Assembly.GetTypes().FirstOrDefault(p => p.Name == Shuffler);
        return Activator.CreateInstance(t!) as IShuffler;
    }
    public IHandCounter? GetHandCounter()
    {
        Type? t = typeof(IHandCounter).Assembly.GetTypes().FirstOrDefault(p => p.Name == HandCounter);
        return Activator.CreateInstance(t!) as IHandCounter;
    }
    public Board? GetBoard()
    {
        Type? t = typeof(Board).Assembly.GetTypes().FirstOrDefault(p => p.Name == Board);
        return Activator.CreateInstance(t!) as Board;
    }
    
}