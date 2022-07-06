namespace Domino;

public abstract class BasePlayer : IPlayer
{
    public List<Piece> Hand { get; set; }
    public abstract Piece Play(Board board);
    public string Name { get; set; }

    protected IEnumerable<Piece> GetPossiblePieces(Board board) => this.Hand.Where(piece => piece.CanPlay(board));

    public override string ToString() => GetType().Name;

    public BasePlayer(){
        Hand = new();
        Name = "";
    }
}
