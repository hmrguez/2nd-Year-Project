

public class PlayerRandom : IPlayer
{
    public List<Piece> Hand { get; private set;}
    public PlayerRandom(List<Piece> hand)
    {
        this.Hand = hand;
    }

    public Piece Play(Board board)
    {
        Random random = new Random();
        List<Piece> possiblePieces = GetPossiblePieces(board);
        Piece piece;

        int number = random.Next(0, possiblePieces.Count());
        piece = possiblePieces[number];
        
        RemovePiece(piece);

        return piece;
    }
    private List<Piece> GetPossiblePieces(Board board)
    {
        return new List<Piece>(this.Hand.Where(piece => piece.CanPlay(board)));
    }
    private void RemovePiece(Piece piece){
        this.Hand.Remove(piece);
        this.Hand = new List<Piece>(this.Hand);
    }
}
public class PlayerMostValue : IPlayer
{
    public List<Piece> Hand { get ; private set; }
    private IComparer<Piece>? _comparer;
    public PlayerMostValue(List<Piece> hand, IComparer<Piece> comparer)
    {
        this.Hand = hand;
        this._comparer = comparer;
    }
    public Piece Play(Board board)
    {
        Piece? piece = this.Hand.Where(pieces=>pieces.CanPlay(board))
                                .OrderByDescending(pieces=> pieces, this._comparer)
                                .FirstOrDefault();
        return piece;
    }
    private List<Piece> GetPossiblePieces(Board board)
    {
        return new List<Piece>(this.Hand.Where(piece => piece.CanPlay(board)));
    }
    private void RemovePiece(Piece piece){
        this.Hand.Remove(piece);
        this.Hand = new List<Piece>(this.Hand);
    }
}
public class PlayerRanValue : IPlayer
{
    
    public List<Piece> Hand { get ; private set ; }
    private IPlayer _mode;
    public PlayerRanValue(List<Piece> hand, IComparer<Piece> comparer)
    {
        this.Hand = hand;
        this._mode = new PlayerMostValue(hand, comparer);
    }

    public Piece Play(Board board)
    {
        ChangingMind(board);
        return this._mode.Play(board);
    }
    private void ChangingMind(Board board)
    {
        //Idea pobre por poner algo
        if(board.PiecesOnBoard.Count() == 10)
        {
            this._mode = new PlayerRandom(this.Hand);
        }
    }
     private List<Piece> GetPossiblePieces(Board board)
    {
        return new List<Piece>(this.Hand.Where(piece => piece.CanPlay(board)));
    }
    private void RemovePiece(Piece piece){
        this.Hand.Remove(piece);
        this.Hand = new List<Piece>(this.Hand);
    }
}
