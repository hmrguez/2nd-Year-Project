using Domino;


public static class MakingGame
{
    
    public static GameObject[] MakingGames(Value values, int amountPlays)
    {
        GameObject[] games = new GameObject[amountPlays];

        for (int i = 0; i < games.Length; i++)
        {
            Settings changes = new Settings(GetInstances.GetBoard(values.Board!)!, GetInstances.GetWinnable(values.Winnable!)!, 
                                                    GetInstances.GetRounder(values.Rounder!)!, GetInstances.GetShuffler(values.Shuffler!)!,
                                                    GetInstances.GetHandCounter(values.HandCounter!)!);
            games[i] = new GameObject(GetInstances.GetMaxHandSize(values.MaxHandSize), 
                                    values.Players!, changes,
                                    GetInstances.GetMaximumSize(values.MaximumSize));
        }

        return games;
    }
}