public class RegularHandCounter: IHandCounter{
    public int GetHandValue(IPlayer player){
        int cost = 0;
        foreach (var item in player.Hand)
        {
            cost+=item.GetValue();
        }
        return cost;
    }
}
public class DoubleDoubleHandCounter : IHandCounter{
    public int GetHandValue(IPlayer player){
        int cost = 0;
        foreach (var item in player.Hand)
        {
            if(item.Left==item.Right) cost+=item.GetValue()*2;
            else cost+=item.GetValue();
        }
        return cost;
    }
}