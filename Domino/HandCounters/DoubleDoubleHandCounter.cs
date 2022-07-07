namespace Domino;

public class DoubleDoubleHandCounter : IHandCounter
{
    public int GetHandValue(IPlayer player) => player.Hand.Sum(x => (x.Left == x.Right) ? x.GetValue() * 2 : x.GetValue());
}