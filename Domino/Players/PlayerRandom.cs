namespace Domino;

public class PlayerRandom : IPlayer
{
    public List<Piece> Hand { get; set; }

    public PlayerRandom()
    {
        Hand = new();
    }
    public Piece Play(Board board)
    {
        Random random = new Random();
        var possiblePieces = Hand.Where(x=>x.CanPlay(board));
        
        if(possiblePieces.Any()){
            Piece piece;

            int number = random.Next(0, possiblePieces.Count()-1);
            piece = possiblePieces.ElementAt(number);

            this.Hand.Remove(piece);

            return piece;
        }
        return null;
    }
    
}