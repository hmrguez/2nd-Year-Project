using Domino;

public class SettingsList
{

    public string[] Winnables { get; }
    public string[] Rounders { get; }
    public string[] Shufflers { get; }
    public string[] HandCounters { get; }
    public string[] Boards{get;}
    public string[] Players{get;}

    public SettingsList()
    {
        Winnables = Utils.GetT(typeof(IWinnable));
        Rounders = Utils.GetT(typeof(IRounder));
        Shufflers = Utils.GetT(typeof(IShuffler));
        HandCounters = Utils.GetT(typeof(IHandCounter));
        Boards = Utils.GetT(typeof(Board));
        Players = Utils.GetT(typeof(IPlayer));
    }
}