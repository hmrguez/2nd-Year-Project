namespace Domino;

public class Settings
{
    public Settings(Board board, IWinnable winCondition, IRounder rounder, IShuffler shuffler, IHandCounter handCounter)
    {
        this.Board = board;
        this.WinCondition = winCondition;
        this.Rounder = rounder;
        this.Shuffler = shuffler;
        this.HandCounter = handCounter;
    }
    public Board Board { get; set;}
    public IWinnable WinCondition { get; }
    public IRounder Rounder { get; }
    public IShuffler Shuffler { get; }
    public IHandCounter HandCounter { get;}
}