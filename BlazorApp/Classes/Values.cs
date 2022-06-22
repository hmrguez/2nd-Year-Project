using Domino;

public class Value
{
    public string? Winnable { get; set; } = Utils.GetWinnables().FirstOrDefault();
    public string? Rounder { get; set; } = Utils.GetRounders().FirstOrDefault();
    public string? Shuffler{ get; set;} = Utils.GetShufflers().FirstOrDefault();
    public string? HandCounter{ get; set;} = Utils.GetHandCounters().FirstOrDefault();
    public string? Board{ get; set;} = Utils.GetBoards().FirstOrDefault();


    public Value(){

    }
    public Value(string winnable, string rounder, string shuffler, string handCounter, string board)
    {
        this.Winnable = winnable;
        this.Rounder = rounder;
        this.Shuffler = shuffler;
        this.HandCounter = handCounter;
        this.Board= board;
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