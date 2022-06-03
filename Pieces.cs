public class RegularPiece : Piece
{
    public RegularPiece(int left, int right){
        Left = left;
        Right = right;
    }
    public override bool CanPlay(Board board)
    {
        return Match(board.PiecesOnBoard.First().Left) || Match(board.PiecesOnBoard.Last().Right);
    }
    public override string ToString()
    {
        return $"[{this.Left}|{this.Right}]";
    }
    public override RegularPiece Rotate()
    {
        int c = Left;
        Left = Right;
        Right = c;
        return this;
    }
    public override int GetValue(){
        return Left+Right;
    }
}