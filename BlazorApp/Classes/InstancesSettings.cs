using Domino;

public class InstancesSettings
{
    public InstancesSettings(Value values)
    {
        GetInstanceWinnable(values.Winnable, values);
        GetInstanceRounder(values.Rounder, values);
        GetInstanceShuffler(values.Shuffler, values);
        GetInstanceHandCounter(values.HandCounter, values);
        GetInstanceBoard(values.Board, values);
    }
    public IWinnable? Winnable{get; private set;}
    public IRounder? Rounder{get; private set;}
    public IShuffler? Shuffler{get; private set;}
    public IHandCounter? HandCounter{get; private set;}
    public Board? Board{get; private set;}

    private void GetInstanceWinnable(string winnable, Value value)
    {
        this.Winnable = winnable != string.Empty? value.GetWinnable() : new RegularWinnable();
    }
    private void GetInstanceRounder(string rounder, Value value)
    {
        this.Rounder = rounder != string.Empty? value.GetRounder() : new Clockwise();
    }
    private void GetInstanceShuffler(string shuffler, Value value)
    {
        this.Shuffler = shuffler != string.Empty? value.GetShuffler() : new RegularShuffler();
    }
    private void GetInstanceHandCounter(string handCounter, Value value)
    {
        this.HandCounter = handCounter != string.Empty? value.GetHandCounter() : new RegularHandCounter();
    }
    private void GetInstanceBoard(string board, Value value)
    {
        this.Board = board != string.Empty? value.GetBoard() : new RegularBoard(9);
    }
}