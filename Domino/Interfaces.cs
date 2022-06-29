namespace Domino;

public interface IPlayer
{
    public List<Piece> Hand { get; }
    public Piece Play(Board board);
}

public interface IRounder
{
    ///<returns> The next player that should play in the game </returns>
    public IPlayer NextPlayer(GameObject game);
}
public interface IWinnable
{
    ///<summary> Determines if wether the game was won or wasn't (blocked generally) </summary>
    public bool Won { get; }

    ///<summary> Determines if this game has ended, changes the Won to true it was won </summary>
    ///<returns> True if the game has ended, false if it wasn't </returns>
    public bool EndCondition(GameObject game);

    ///<returns> The Winner of the game </returns>
    public IPlayer Winner(GameObject game);
}
public interface IShuffler
{
    ///<summary> Shuffles the pieces between all the players in the game </summary>
    public void Shuffle(IPlayer[] players, Board board, int maxHandSize);

    ///<summary> Shuffles the pieces to a single player </summary>
    public void ShufflePlayer(IPlayer player, Board board, int maxHandSize);
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
public interface IHandCounter
{

    ///<returns> The way the points are given to the player according to their hand </returns>
    int GetHandValue(IPlayer player);
}