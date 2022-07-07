namespace Domino;

public class ValueSortedShuffler : IShuffler
{
    public void Shuffle(IPlayer[] players, Board board, int maxHandSize)
    {
        foreach (IPlayer player in players)
        {
            ShufflePlayer(player, board, maxHandSize);
        }
    }
    public void ShufflePlayer(IPlayer player, Board board, int maxHandSize)
    {
        board.Deck!.Sort(new SortedByValue());
        for (int i = 0; i < maxHandSize; i++)
        {
            player.Hand.Add(board.Deck[0]);
            board.Deck.RemoveAt(0);
        }
    }
}