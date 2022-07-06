using Domino;


public static class MakingGame
{
    
    public static GameObject[] MakingGames(Value values, int times)
    {
        GameObject[] games = new GameObject[times];

        for (int i = 0; i < games.Length; i++)
        {
            Settings changes = new Settings(values.GetBoard()!, values.GetWinnable()!, values.GetRounder()!, 
                                                    values.GetShuffler()!, values.GetHandCounter()!);
            games[i] = new GameObject(values.GetMaxHandSize(), MakingGame.MakingPlayers(values.Players!, values.GetAmountPlayers()), changes, values.GetMaximumSize());
        }

        return games;
    }
    public static IPlayer[] MakingPlayers(string[] players, int amount){
        string[] playersInstances = Utils.GetPlayers();
        List<IPlayer> listPlayers= new List<IPlayer>();
        for (int i = 0; i < players.Length; i++)
        {
            listPlayers.Add(Value.GetPlayer(players[i])!);
            amount--;
        }
        int count = 0;
        while (amount-- > 0)
        {
            if(players.Contains(playersInstances[count]))
            {
                listPlayers.Add(Value.GetPlayer(players[count])!);
            }
            count++;
        }
        return listPlayers.ToArray();
    }
}