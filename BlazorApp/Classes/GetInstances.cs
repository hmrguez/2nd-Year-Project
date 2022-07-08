using Domino;

public static class GetInstances
{
    public static IWinnable? GetWinnable(string winnable)
    {
        Type? t = typeof(IWinnable).Assembly.GetTypes().FirstOrDefault(p => p.Name == winnable);
        return Activator.CreateInstance(t!) as IWinnable;
    }
    public static IRounder? GetRounder(string rounder)
    {
        Type? t = typeof(IRounder).Assembly.GetTypes().FirstOrDefault(p => p.Name == rounder);
        return Activator.CreateInstance(t!) as IRounder;
    }
    public static IShuffler? GetShuffler(string shuffler)
    {
        Type? t = typeof(IShuffler).Assembly.GetTypes().FirstOrDefault(p => p.Name == shuffler);
        return Activator.CreateInstance(t!) as IShuffler;
    }
    public static IHandCounter? GetHandCounter(string handCounter)
    {
        Type? t = typeof(IHandCounter).Assembly.GetTypes().FirstOrDefault(p => p.Name == handCounter);
        return Activator.CreateInstance(t!) as IHandCounter;
    }
    public static Board? GetBoard(string board)
    {
        Type? t = typeof(Board).Assembly.GetTypes().FirstOrDefault(p => p.Name == board);
        
        return Activator.CreateInstance(t!) as Board;
    }
    public static IPlayer? GetPlayer(string player, string name)
    {
        Type? t = typeof(IPlayer).Assembly.GetTypes().FirstOrDefault(p => p.Name == player);
        return Activator.CreateInstance(t!, name) as IPlayer;
    }
    public static int GetAmount(string amount)
    {
        return int.Parse(amount);
    }
    public static int GetMaximumSize(string maxSize)
    {
        return int.Parse(maxSize);
    }
    public static int GetMaxHandSize(string maxHandSize)
    {
        return int.Parse(maxHandSize);
    }
    public static int GetAmountPlayers(string amountPlayers)
    {
        return int.Parse(amountPlayers);
    }
    public static IPlayer[] GetPlayers(int amount, string player1Mode, string player2Mode, string player3Mode, string player4Mode, string player1Name, string player2Name, string player3Name, string player4Name)
    {
        IPlayer[] source = new IPlayer[]{GetPlayer(player1Mode, player1Name)!, 
                                        GetPlayer(player2Mode, player2Name)!, 
                                        GetPlayer(player3Mode, player3Name)!, 
                                        GetPlayer(player4Mode, player4Name)!};

        IPlayer[] players = new IPlayer[amount];

        Array.Copy(source, players, players.Length);

        CheckEqualsNames(players);
        
        return players;
    }

    private static void CheckEqualsNames(IPlayer[] players)
    {
        for (int i = 0; i < players.Length; i++)
        {
            for (int j = i+1; j < players.Length; j++)
            {
                if(players[i].Name == players[j].Name)
                {
                    players[j].Name = players[j].Name + "1";
                }
            }
        }
    }
}