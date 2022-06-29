using Domino;

public class SemiSmartPlayer: BasePlayer
{
    public override Piece Play(Board board){
        List<Piece> pieces = board.PiecesOnBoard!;
        Dictionary<Piece,int> PieceScore = new Dictionary<Piece, int>();
        foreach (var piece in GetPossiblePieces(board))
        {
            PieceScore.Add(piece,0);
        }
        foreach (var piece in pieces)
        {
            foreach (var pieceOnHand in GetPossiblePieces(board))
            {
                if(piece.Match(pieceOnHand.Left)) PieceScore[pieceOnHand]+=1;
                if(piece.Match(pieceOnHand.Right)) PieceScore[pieceOnHand]+=1;
            }
        }
        Piece x = PieceScore.MaxBy(x=>x.Value).Key;
        Hand.Remove(x);
        return x;
    }
    public SemiSmartPlayer(){
        Hand = new();
    }
}