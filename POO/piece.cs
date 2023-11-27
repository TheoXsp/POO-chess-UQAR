namespace POO; 

public abstract class Piece {
    protected Position Pos { get; set; }
    private string CharRepresentation { get; set; }
    public Player Owner { get; }
    
    protected Piece(Player owner, Position position, string charRepresentation) {
        this.Pos = position;
        this.CharRepresentation = charRepresentation;
        Owner = owner;
    }
    
    public Position GetPosition() {
        return this.Pos;
    }
    
    public override string ToString() {
        return CharRepresentation;
    }

    public abstract bool Move(Position position);
}