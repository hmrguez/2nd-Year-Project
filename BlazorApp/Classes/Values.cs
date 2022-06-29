using Domino;

public class Value
{
    public string? Winnable { get; set; } = Utils.GetWinnables().FirstOrDefault();
    public string? Rounder { get; set; } = Utils.GetRounders().FirstOrDefault();
    public string? Shuffler{ get; set;} = Utils.GetShufflers().FirstOrDefault();
    public string? HandCounter{ get; set;} = Utils.GetHandCounters().FirstOrDefault();
    public string? Board{ get; set;} = Utils.GetBoards().FirstOrDefault();
    public string[]? Players{ get; set;}
    public string Amount{ get; set;}="1";
    public string MaximumSize{get;set;}="9";
    public string MaxHandSize{get;set;}="10";
    public string AmountPlayers{get;set;}="4";


    public Value(){}
    public Value(string winnable, string rounder, string shuffler, string handCounter, string board, string amount, string maximumSize, string maxHandSize, string amountPlayers, string[] players)
    {
        this.Winnable = winnable;
        this.Rounder = rounder;
        this.Shuffler = shuffler;
        this.HandCounter = handCounter;
        this.Board= board;
        this.Amount = amount;
        this.MaximumSize = maximumSize;
        this.MaxHandSize =maxHandSize;
        this.AmountPlayers = amountPlayers;
        this.Players = players;
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
    public Board? GetBoard(int maximumSize)
    {
        Type? t = typeof(Board).Assembly.GetTypes().FirstOrDefault(p => p.Name == Board);
        
        return Activator.CreateInstance(t!, maximumSize) as Board;
    }
    public static IPlayer? GetPlayer(string player)
    {
        Type? t  = typeof(IPlayer).Assembly.GetTypes().FirstOrDefault(p => p.Name == player);
        return Activator.CreateInstance(t!) as IPlayer;
    }
    public int GetAmount()
    {
        return int.Parse(Amount);
    }
    public int GetMaximumSize()
    {
        return int.Parse(MaximumSize);
    }
    public int GetMaxHandSize()
    {
        return int.Parse(MaxHandSize);
    }
    public int GetAmountPlayers()
    {
        return int.Parse(AmountPlayers);
    }
    
}