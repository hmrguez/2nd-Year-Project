using Domino;

public class SettingsList
{

    public string[] Winnables { get; }
    public string[] Rounders { get; }
    public string[] Shufflers { get; }
    public string[] HandCounters { get; }
    public string[] Boards{get;}

    public SettingsList()
    {
        Winnables = Utils.GetWinnables();
        Rounders = Utils.GetRounders();
        Shufflers = Utils.GetShufflers();
        HandCounters = Utils.GetHandCounters();
        Boards = Utils.GetBoards();
    }
}