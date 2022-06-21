namespace Domino;

public abstract class BasePlayer : IPlayer
{
    public List<Piece> Hand { get; protected set; }
    public abstract Piece Play(Board board);

    protected IEnumerable<Piece> GetPossiblePieces(Board board) => this.Hand.Where(piece => piece.CanPlay(board));

    public override string ToString() => GetType().Name;

}
