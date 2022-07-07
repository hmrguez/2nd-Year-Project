namespace Domino;

public class RegularShuffler : IShuffler
{
    public void Shuffle(IPlayer[] players, Board board, int maxHandSize)
    {
        foreach (var player in players) ShufflePlayer(player, board, maxHandSize);
    }
    public void ShufflePlayer(IPlayer player, Board board, int maxHandSize)
    {
        Random random = new();
        for (int i = 0; i < maxHandSize; i++)
        {
            int x = random.Next(board.Deck!.Count);
            Piece piece = board.Deck[x];
            player.Hand.Add(piece);
            board.Deck.Remove(piece);
        }
    }
}