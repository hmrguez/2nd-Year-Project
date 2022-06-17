namespace Domino;

public class RegularHandCounter : BaseHandCounter
{
    public override int GetHandValue(IPlayer player) => player.Hand.Sum(x => x.GetValue());
}