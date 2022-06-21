using Domino;

public class SemiSmartPlayer: IPlayer{
    public List<Piece> Hand { get; set; }
    public Piece Play(Board board){
        List<Piece> pieces = board.PiecesOnBoard;
        Dictionary<Piece,int> PieceScore = new Dictionary<Piece, int>();
        foreach (var item in Hand)
        {
            PieceScore.Add(item,0);
        }
        foreach (var item in pieces)
        {
            foreach (var item2 in Hand)
            {
                if(item.Match(item2.Left)) PieceScore[item2]+=1;
                if(item.Match(item2.Right)) PieceScore[item2]+=1;
            }
        }
        Piece x = PieceScore.MaxBy(x=>x.Value).Key;
        Hand.Remove(x);
        return x;
    }
}