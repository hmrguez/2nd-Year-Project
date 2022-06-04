public static class Utilities
{
    public static bool IsBlocked(IGame game)
    {
        if (game.Rounds.Count > game.Players.Length)
        {
            for (int i = 0; i < game.Players.Length; i++)
            {
                if (game.Rounds[game.Rounds.Count - i] != null) break;
                if (i == game.Players.Length - 1) return true;
            }
        }
        return false;
    }
}