namespace Domino;

public class RegularWinnable : IWinnable
{
    public bool Won { get; set; }
    public RegularWinnable()
    {
        Won = false;
    }
    public bool EndCondition(IGame game)
    {
        if (Utils.IsBlocked(game)) return true;
        if (game.Rounds.Last().Player.Hand.Count == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
    public IPlayer Winner(IGame game) => Won ? game.Rounds.Last().Player : Utils.StandardCounter(game, game.HandCounter);
    public override string ToString()
    {
        return "Standard";
    }
}
public class DropDoubleBlank : IWinnable
{
    public bool Won { get; set; }
    public DropDoubleBlank()
    {
        Won = false;
    }
    public bool EndCondition(IGame game)
    {
        if (Utils.IsBlocked(game)) return true;
        if (game.Rounds.Last().Piece.Left == 0 && game.Rounds.Last().Piece.Right == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
    public IPlayer Winner(IGame game) => Won ? game.Rounds.Last().Player : Utils.StandardCounter(game, game.HandCounter);
    public override string ToString()
    {
        return "Drop Double Blank";
    }
}