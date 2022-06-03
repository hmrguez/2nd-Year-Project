public class RegularShuffler : IShuffler{
    public void Shuffle(IGame game){
        foreach (var item in game.Players)
        {
            ShufflePlayer(item,game);
        }
    }
    public void ShufflePlayer(IPlayer player, IGame game){
        Random random = new();
        for (int i = 0; i < game.MaxHandSize; i++)
        {
            int x = random.Next(game.Board.Deck.Count);
            Piece piece = game.Board.Deck[x];
            player.Hand.Add(piece);
            game.Board.Deck.Remove(piece);
        }
    }
}
public class SortedShuffler: IShuffler{
    public void Shuffle ( IGame game){
        foreach (var item in game.Players)
        {
            ShufflePlayer(item,game);
        }
    }
    public void ShufflePlayer(IPlayer player, IGame game){
        game.Board.Deck.Sort(new SortedByLeft());
        for (int i = 0; i < game.MaxHandSize; i++)
        {
            player.Hand.Add(game.Board.Deck[0]);
            game.Board.Deck.RemoveAt(0);
        }
    }
}