public class RegularHandCounter : IHandCounter
{
    public int GetHandValue(IPlayer player)
    {
        int cost = 0;
        foreach (var item in player.Hand) cost += item.GetValue();
        return cost;
    }
}
public class DoubleDoubleHandCounter : IHandCounter
{
    public int GetHandValue(IPlayer player)
    {
        int cost = 0;
        foreach (var item in player.Hand) cost+= (item.Left == item.Right) ? item.GetValue() * 2 : cost += item.GetValue();
        return cost;
    }
}