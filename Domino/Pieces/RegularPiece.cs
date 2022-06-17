namespace Domino;

public class RegularPiece : Piece
{
    public RegularPiece(int left, int right)
    {
        Left = left;
        Right = right;
    }
    public override bool CanPlay(Board board){
        if(board.PiecesOnBoard.Count() == 0)
            return true;
        return Match(board.PiecesOnBoard.First().Left) || Match(board.PiecesOnBoard.Last().Right);
    }
}