using Domino;


public static class MakingGame
{
    
    public static GameObject[] MakingGames(ChangedThings changes, int times = 1)
    {
        GameObject[] games = new GameObject[times];

        for (int i = 0; i < games.Length; i++)
        {
            games[i] = new GameObject(10, Utils.GetPlayers(), changes);
        }

        return games;
    }
}