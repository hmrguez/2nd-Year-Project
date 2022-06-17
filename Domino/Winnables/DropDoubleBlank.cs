namespace Domino;

public class DropDoubleBlank : BaseWinnable
{
    public DropDoubleBlank()
    {
        Won = false;
    }
    public override bool EndCondition(GameObject game)
    {
        if (Utils.IsBlocked(game)) return true;
        if (game.Rounds.Last().Piece.Left == 0 && game.Rounds.Last().Piece.Right == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
}