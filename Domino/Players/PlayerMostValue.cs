namespace Domino;

public class PlayerMostValue : BasePlayer
{
    private IComparer<Piece>? _comparer;
    public PlayerMostValue(IComparer<Piece> comparer)
    {
        this.Hand = new HandPieces<Piece>();
        this._comparer = comparer;
    }
    public override Piece Play(Board board)
    {
        Piece? piece = this.Hand.Where(pieces => pieces.CanPlay(board))
                                .OrderByDescending(pieces => pieces, this._comparer)
                                .FirstOrDefault();
        return piece!;
    }
}