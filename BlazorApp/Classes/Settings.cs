using Domino;

public class SettingsList
{

    public IWinnable[] Winnables { get; }
    public IRounder[] Rounders { get; }
    public IShuffler[] Shufflers { get; }
    public IHandCounter[] HandCounters { get; }
    public Board[] Boards{get;}

    public SettingsList()
    {
        Winnables = Utils.GetWinnables();
        Rounders = Utils.GetRounders();
        Shufflers = Utils.GetShufflers();
        HandCounters = Utils.GetHandCounters();
        Boards = Utils.GetBoards();
    }
}