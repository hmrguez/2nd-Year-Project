namespace Domino;

public class PlayGame
{
    public void PlaySingleGame(GameObject game)
    {
        game.Changes.Shuffler.Shuffle(game.Players, game.Changes.Board, game.MaxHandSize);

        do
        {
            game.CurrentPlayer = game.Changes.Rounder.NextPlayer(game);

            Piece? piece = game.CurrentPlayer.Play(game.Changes.Board);

            if(piece != null)
            {
                if(game.Changes.Board.PiecesOnBoard.Count() == 0)
                    game.Changes.Board.PiecesOnBoard.AddLast(piece);
                else if(MatchingLast(game.Changes.Board.PiecesOnBoard.Last(), piece))
                    game.Changes.Board.PiecesOnBoard.AddLast(piece);
                else if(MatchingFirst(game.Changes.Board.PiecesOnBoard.First(), piece))
                    game.Changes.Board.PiecesOnBoard.AddFirst(piece);

            }
            game.Rounds.Add(new Round(game.CurrentPlayer, piece));

        }while(game.Changes.WinCondition.EndCondition(game));

        game.Winner = game.Changes.WinCondition.Winner(game);
    }
    private bool MatchingFirst(Piece first, Piece toCheck){
        if(first.Left == toCheck.Left)
        {
            toCheck.Rotate();
            return true;
        }
        else if(first.Left == toCheck.Right)
        {
            return true;
        }
        else
            return false;
    }
    private bool MatchingLast(Piece last, Piece toCheck){
        if(last.Right == toCheck.Left)
        {
            return true;
        }
        else if(last.Right == toCheck.Right)
        {
            toCheck.Rotate();
            return true;
        }
        else
            return false;
    }


}