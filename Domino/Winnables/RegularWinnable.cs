namespace Domino;

public class RegularWinnable : BaseWinnable
{
    public RegularWinnable()
    {
        Won = false;
    }
    public override bool EndCondition(GameObject game)
    {
        if(Utils.IsBlocked(game)) return true;
        if (game.Rounds.Last().Player.Hand.Count() == 0)
        {
            Won = true;
            return true;
        }
        return false;
    }
}