namespace POO; 

public abstract class Piece {
    public Position Pos { get; set; }
    private string CharRepresentation { get; }
    public Player Owner { get; }
    
    protected Piece(Player owner, Position position, string charRepresentation) {
        Pos = position;
        CharRepresentation = charRepresentation;
        Owner = owner;
    }
    
    public override string ToString() {
        return CharRepresentation;
    }

    protected abstract bool IsAccessible(Position target, Dictionary<Position, Piece?> board);
    public abstract bool CanMove(Position target, Dictionary<Position, Piece?> board);
    public abstract Piece Copy();
}