namespace Domino;

public abstract class Board
{
    public int MaxInput { get; set; }
    public List<Piece> PiecesOnBoard { get;  set; }
    public List<Piece>? Deck { get; set; }
    public abstract List<Piece> Generate(int maximumInput);
    public override string ToString() => GetType().Name;
    public Board(){
        PiecesOnBoard = new();
    }
}