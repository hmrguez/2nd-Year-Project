namespace Domino;

public class RegularHandCounter : IHandCounter
{
    public int GetHandValue(IPlayer player) => player.Hand.Sum(x => x.GetValue());
}