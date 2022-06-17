using Domino;

public class Value
{
    public string? Winnable { get; set; }
    public string? Rounder { get; set; }
    public string? Shuffler{get;set;}
    public string? HandCounter{get;set;}
    public string? Board{get;set;}

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
        if (string.IsNullOrEmpty(Winnable))
            return default;
        return Utils.GetWinnables().FirstOrDefault(p => p.GetType().Name == Winnable);
    }
    public IRounder? GetRounder()
    {
        if (string.IsNullOrEmpty(Rounder))
            return default;
        return Utils.GetRounders().FirstOrDefault(p => p.GetType().Name == Rounder);
    }
    public IShuffler? GetShuffler()
    {
        if (string.IsNullOrEmpty(Shuffler))
            return default;
        return Utils.GetShufflers().FirstOrDefault(p => p.GetType().Name == Shuffler);
    }
    public IHandCounter? GetHandCounter()
    {
        if (string.IsNullOrEmpty(HandCounter))
            return default;
        return Utils.GetHandCounters().FirstOrDefault(p => p.GetType().Name == HandCounter);
    }
    public Board? GetBoard()
    {
        if (string.IsNullOrEmpty(Board))
            return default;
        return Utils.GetBoards().FirstOrDefault(p => p.GetType().Name == Board);
    }
    
}