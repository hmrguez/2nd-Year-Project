namespace Domino;

public abstract class Board
{
    public List<Piece> PiecesOnBoard { get;  set; }

    ///<summary>Las fichas que no se han jugado o repartido estan aqui</summary>
    public List<Piece>? Deck { get; set; }

    ///<summary>Genera las posibles fichas. Se llama en GameObject cuando se crea un nuevo juego y se resetea</summary>
    ///<param name="maximumInput">EL doble máximo a alcanzar por las fichas</param>
    public abstract List<Piece> Generate(int maximumInput);
    public override string ToString() => GetType().Name;
    public Board(){
        PiecesOnBoard = new();
    }
}