
public class RegularPiece : Piece
{
    public RegularPiece(int left, int right)
    {
        Left = left;
        Right = right;
    }
    public override bool CanPlay(Board board) => Match(board.PiecesOnBoard.First().Left) || Match(board.PiecesOnBoard.Last().Right);
}
public class OnlyEvenDoublesPiece : Piece
{
    public OnlyEvenDoublesPiece(int left, int right)
    {
        Left = left;
        Right = right;
    }
    public override bool CanPlay(Board board)
    {
        var temp = new RegularPiece(Left,Right);
        if (Left == Right)
        {
            if (board.PiecesOnBoard.Count() % 2 == 0) return temp.CanPlay(board);
            return false;
        }
        return temp.CanPlay(board);
    }
}