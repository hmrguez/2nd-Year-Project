using Domino;


public static class MakingGame
{
    
    public static GameObject[] MakingGames(Value values, int amountPlays)
    {
        GameObject[] games = new GameObject[amountPlays];

        for (int i = 0; i < games.Length; i++)
        {
            Settings changes = new Settings(values.GetBoard()!, values.GetWinnable()!, values.GetRounder()!, 
                                                    values.GetShuffler()!, values.GetHandCounter()!);
            games[i] = new GameObject(values.GetMaxHandSize(), 
                                    values.Players!, 
                                    changes, 
                                    values.GetMaximumSize());
        }

        return games;
    }
}