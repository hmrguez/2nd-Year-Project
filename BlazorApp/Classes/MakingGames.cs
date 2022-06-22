using Domino;


public static class MakingGame
{
    
    public static GameObject[] MakingGames(Value values, int times)
    {
        GameObject[] games = new GameObject[times];

        for (int i = 0; i < games.Length; i++)
        {
            ChangedThings changes = new ChangedThings(values.GetBoard()!, values.GetWinnable()!, values.GetRounder()!, 
                                                    values.GetShuffler()!, values.GetHandCounter()!);
            games[i] = new GameObject(10, Utils.GetPlayers(), changes);
        }

        return games;
    }
}