public class RegularWinnable : IWinnable
{
    public bool Won { get; set; }
    public IHandCounter HandCounter { get; set; }
    public RegularWinnable(IHandCounter counter)
    {
        HandCounter = counter;
        Won = false;
    }
    public bool EndCondition(IGame game)
    {
        if (Utilities.IsBlocked(game)) return true;
        if (game.Rounds.Last().Player.Hand.Count == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
    public IPlayer Winner(IGame game)
    {
        if (Won) return game.Rounds.Last().Player;
        Dictionary<IPlayer, int> Scores = new();
        foreach (var item in game.Players)
        {
            Scores.Add(item, HandCounter.GetHandValue(item));
        }
        return Scores.MinBy(x => x.Value).Key;
    }
}
public class DropDoubleBlank : IWinnable
{
    public bool Won { get; set; }
    public IHandCounter HandCounter { get; set; }
    public DropDoubleBlank(IHandCounter counter)
    {
        HandCounter = counter;
        Won = false;
    }
    public bool EndCondition(IGame game)
    {
        if (Utilities.IsBlocked(game)) return true;
        if (game.Rounds.Last().Piece.Left == 0 && game.Rounds.Last().Piece.Right == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
    public IPlayer Winner(IGame game)
    {
        if (Won) return game.Rounds.Last().Player;
        Dictionary<IPlayer, int> Scores = new();
        foreach (var item in game.Players)
        {
            Scores.Add(item, HandCounter.GetHandValue(item));
        }
        return Scores.MinBy(x => x.Value).Key;
    }
}