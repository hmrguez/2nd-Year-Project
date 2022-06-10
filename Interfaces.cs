using System.Collections.Generic;
namespace Domino;

public class IGame
{
    public int MaxHandSize { get; }
    public List<Round> Rounds { get; set; }
    public IPlayer[] Players { get; }
    public Board Board { get; }
    public IWinnable WinCondition { get; }
    public IRounder Rounder { get; }
    public IShuffler Shuffler { get; }
    public IPlayer CurrentPlayer { get; set; }
    public IHandCounter HandCounter { get; set; }
    public IGame(int maxHandSize, IPlayer[] players, Board board, IWinnable winCondition, IRounder rounder, IShuffler shuffler, IHandCounter counter)
    {
        MaxHandSize = maxHandSize;
        Players = players;
        Board = board;
        WinCondition = winCondition;
        Rounder = rounder;
        Shuffler = shuffler;
        Rounds = new();
        CurrentPlayer = Players[0];
        HandCounter = counter;
    }
}
public interface IPlayer
{
    public List<Piece> Hand { get; }
    public Piece Play(Board board);
}
public abstract class Board
{
    public Table PiecesOnBoard { get; protected set; }
    public List<Piece> Deck { get; protected set; }
    protected abstract List<Piece> Generate(int maximumInput);
}
public abstract class Piece : IValuable
{
    public int Left { get; set; }
    public int Right { get; set; }

    ///<returns> True if this piece can fit in the board, false if can't </returns>
    public abstract bool CanPlay(Board board);

    ///<summary> Rotates the piece so their side values change position </summary>
    public Piece Rotate()
    {
        int c = Left;
        Left = Right;
        Right = c;
        return this;
    }

    ///<returns> The total value of the piece, the sum of the sides </returns>
    public int GetValue() => Left + Right;

    ///<returns> True if any side of this piece matches the int, false if doesn't </returns>
    public bool Match(int num) => (Left == num || Right == num) ? true : false;
    public override string ToString() => $"[{Left}|{Right}]";
}
public interface IRounder
{
    ///<returns> The next player that should play in the game </returns>
    public IPlayer NextPlayer(IGame game);
}
public interface IWinnable
{
    ///<summary> Determines if wether the game was won or wasn't (blocked generally) </summary>
    public bool Won { get; set; }

    ///<summary> Determines if this game has ended, changes the Won to true it was won </summary>
    ///<returns> True if the game has ended, false if it wasn't </returns>
    public bool EndCondition(IGame game);

    ///<returns> The Winner of the game </returns>
    public IPlayer Winner(IGame game);
}
public interface IShuffler
{
    ///<summary> Shuffles the pieces between all the players in the game </summary>
    public void Shuffle(IGame game);

    ///<summary> Shuffles the pieces to a single player </summary>
    public void ShufflePlayer(IPlayer player, IGame game);
}
public class Round
{

    ///<summary> The player who played in this round </summary>
    public IPlayer Player { get; set; }

    ///<summary> The piece played in this round </summary>
    public Piece Piece { get; set; }
    public Round(IPlayer player, Piece piece)
    {
        Player = player;
        Piece = piece;
    }
}
public interface IValuable
{
    int GetValue();
}
public interface IHandCounter
{

    ///<returns> The way the points are given to the player according to their hand </returns>
    int GetHandValue(IPlayer player);
}