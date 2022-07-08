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
    
}