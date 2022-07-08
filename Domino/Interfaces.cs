namespace Domino;

public interface IPlayer
{
    public List<Piece> Hand { get; set; }
    public string Name { get; set; }
    public Piece Play(Board board);
    public void ResetHand(){
        Hand = new();
    }
}

public interface IRounder
{
    ///<returns> El siguiente jugador que debe jugar </returns>
    public IPlayer NextPlayer(GameObject game);
}
public interface IWinnable
{
    ///<summary> Determina si el juego fue ganado o no </summary>
    public bool Won { get; }

    ///<summary> Determina si el juego terminó, debería cambiarse el Won a true si se ganó, y no cambiarse si no </summary>
    ///<returns> True si el juego terminó o false si no</returns>
    public bool EndCondition(GameObject game);

    ///<returns> El ganador del juego </returns>
    public IPlayer Winner(GameObject game);
}
public interface IShuffler
{
    ///<summary> Reparte las fichas entre todos los jugadores del partido </summary>
    public void Shuffle(IPlayer[] players, Board board, int maxHandSize);

    ///<summary> reparte las fichas a los jugadores del partido </summary>
    public void ShufflePlayer(IPlayer player, Board board, int maxHandSize);
}
public class Round
{

    ///<summary> El jugador que jugó </summary>
    public IPlayer Player { get; set; }

    ///<summary> La ficha que se jugó </summary>
    public Piece Piece { get; set; }
    public Round(IPlayer player, Piece piece)
    {
        Player = player;
        Piece = piece;
    }
}
public interface IHandCounter
{

    ///<returns> La manera que se dan los puntos de la mano </returns>
    int GetHandValue(IPlayer player);
}