namespace Domino;

public class RegularPiece : Piece
{
    public RegularPiece(int left, int right)
    {
        Left = left;
        Right = right;
    }
    public override bool CanPlay(Board board){
        if(board.PiecesOnBoard!.Count() == 0)
            return true;
        return MatchLeft(board.PiecesOnBoard.First().Left) || MatchRight(board.PiecesOnBoard.First().Left) || MatchRight(board.PiecesOnBoard.Last().Right) || MatchLeft(board.PiecesOnBoard.Last().Right);
    }
    public override bool MatchRight(int num) => Right == num;
    public override bool MatchLeft(int num) => Left == num; 
}