namespace Domino;

public class SortedByLeftShuffler : BaseShuffler
{
    public override void Shuffle(IPlayer[] players, Board board, int maxHandSize)
    {
        foreach (var item in players)
        {
            ShufflePlayer(item, board, maxHandSize);
        }
    }
    public override void ShufflePlayer(IPlayer player, Board board, int maxHandSize)
    {
        board.Deck!.Sort(new SortedByLeft());
        for (int i = 0; i < maxHandSize; i++)
        {
            player.Hand.Add(board.Deck[0]);
            board.Deck.RemoveAt(0);
        }
    }
}