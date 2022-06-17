namespace Domino;

public class DoubleDoubleHandCounter : BaseHandCounter
{
    public override int GetHandValue(IPlayer player) => player.Hand.Sum(x => (x.Left == x.Right) ? x.GetValue() * 2 : x.GetValue());
}