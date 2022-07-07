using Domino;

public class Value
{
    public string? Winnable { get; set; } = Utils.GetWinnables().FirstOrDefault();
    public string? Rounder { get; set; } = Utils.GetRounders().FirstOrDefault(); 
    public string? Shuffler{ get; set;} = Utils.GetShufflers().FirstOrDefault();
    public string? HandCounter{ get; set;} = Utils.GetHandCounters().FirstOrDefault();
    public string? Board{ get; set;} = Utils.GetBoards().FirstOrDefault();
    public IPlayer[]? Players{get;set;}
    public string Amount{ get; set;}="1";
    public string MaximumSize{get;set;}="9";
    public string MaxHandSize{get;set;}="10";
    public string AmountPlayers{get;set;}="4";
    public string? Player1Mode{ get; set; } = Utils.GetPlayers().FirstOrDefault();
    public string? Player1Name{ get; set; }
    public string? Player2Mode{ get; set; } = Utils.GetPlayers().FirstOrDefault();
    public string? Player2Name{ get; set; }
    public string? Player3Mode{ get; set; } = Utils.GetPlayers().FirstOrDefault();
    public string? Player3Name{ get; set; }
    public string? Player4Mode{ get; set; } = Utils.GetPlayers().FirstOrDefault();
    public string? Player4Name{ get; set; }


    public Value(){}
    public Value(string winnable, string rounder, string shuffler, string handCounter, string board, string amount, string maximumSize, string maxHandSize, string amountPlayers, IPlayer[] players)
    {
        this.Winnable = winnable;
        this.Rounder = rounder;
        this.Shuffler = shuffler;
        this.HandCounter = handCounter;
        this.Board= board;
        this.Amount = amount;
        this.MaximumSize = maximumSize;
        this.MaxHandSize = maxHandSize;
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
    public Board? GetBoard()
    {
        Type? t = typeof(Board).Assembly.GetTypes().FirstOrDefault(p => p.Name == Board);
        
        return Activator.CreateInstance(t!) as Board;
    }
    public IPlayer? GetPlayer(string player, string name)
    {
        Type? t = typeof(IPlayer).Assembly.GetTypes().FirstOrDefault(p => p.Name == player);
        return Activator.CreateInstance(t!, name) as IPlayer;
    }
    public IPlayer[] GetPlayers(int amount)
    {
        IPlayer[] source = new IPlayer[]{GetPlayer(Player1Mode!, Player1Name!)!, 
                                        GetPlayer(Player2Mode!, Player2Name!)!, 
                                        GetPlayer(Player3Mode!, Player3Name!)!, 
                                        GetPlayer(Player4Mode!, Player4Name!)!};

        IPlayer[] players = new IPlayer[amount];

        Array.Copy(source, players, players.Length);

        return players;
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