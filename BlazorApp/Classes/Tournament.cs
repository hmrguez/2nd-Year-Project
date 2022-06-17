using Domino;


public class TournamentClass
{
    public GameObject[] Games{ get; private set;}
    public TournamentClass(GameObject[] games)
    {
        Games = games;
    }
    public static bool IsTournament(string tournamnet){
        if(string.IsNullOrEmpty(tournamnet))
            return false;
        else
            return true;
    }
    public void PlayTournament(PlayGame single)
    {
        int count = 0;
        while (count < Games.Length)
        {
            single.PlaySingleGame(Games[count++]);
        }
    }
}