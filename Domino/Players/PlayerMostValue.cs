namespace Domino;

public class PlayerMostValue : BasePlayer
{
    public PlayerMostValue()
    {
        Hand = new();
    }
    public override Piece Play(Board board)
    {
        Piece? piece = GetPossiblePieces(board).OrderByDescending(x=>x.GetValue()).FirstOrDefault();
        this.Hand.Remove(piece);
        return piece!;
    }
}