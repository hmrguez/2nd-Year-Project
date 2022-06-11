namespace Domino;
public class RegularHandCounter : IHandCounter
{
    public int GetHandValue(IPlayer player) => player.Hand.Sum(x => x.GetValue());
    public override string ToString()
    {
        return "Regular";
    }
}
public class DoubleDoubleHandCounter : IHandCounter
{
    public override string ToString()
    {
        return "Double-double";
    }
    public int GetHandValue(IPlayer player) => player.Hand.Sum(x => (x.Left == x.Right) ? x.GetValue() * 2 : x.GetValue());
}