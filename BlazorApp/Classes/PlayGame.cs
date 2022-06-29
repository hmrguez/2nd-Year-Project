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
                if(game.Changes.Board.PiecesOnBoard!.Count() == 0)
                    game.Changes.Board.PiecesOnBoard!.Add(piece);
                    if (piece.Match(game.Changes.Board.PiecesOnBoard.Last().Right))
                {
                    if (piece.Left == game.Changes.Board.PiecesOnBoard.Last().Right)
                    {
                        game.Changes.Board.PiecesOnBoard.Add(piece);
                    }
                    else
                    {
                        game.Changes.Board.PiecesOnBoard.Add(piece.Rotate());
                    }
                }
                else if (piece.Match(game.Changes.Board.PiecesOnBoard.First().Left))
                {
                    if (piece.Right == game.Changes.Board.PiecesOnBoard.First().Left)
                    {
                        game.Changes.Board.PiecesOnBoard = game.Changes.Board.PiecesOnBoard.Prepend(piece).ToList();
                    }
                    else
                    {
                        game.Changes.Board.PiecesOnBoard = game.Changes.Board.PiecesOnBoard.Prepend(piece.Rotate()).ToList();
                    }
                }
            }
            game.Rounds.Add(new Round(game.CurrentPlayer, piece!));

        }while(!game.Changes.WinCondition.EndCondition(game));

        game.Winner = game.Changes.WinCondition.Winner(game);
    }


}