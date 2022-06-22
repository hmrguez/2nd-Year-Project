namespace Domino;

public class PlayerRandom : BasePlayer
{

    public PlayerRandom()
    {
        Hand = new();
    }
    public override Piece Play(Board board)
    {
        Random random = new Random();
        var possiblePieces = GetPossiblePieces(board);
        
        if(possiblePieces.Any()){
            Piece piece;

            int number = random.Next(0, possiblePieces.Count()-1);
            piece = possiblePieces.ElementAt(number);

            this.Hand.Remove(piece);

            return piece;
        }
        return null!;
    }
    
}