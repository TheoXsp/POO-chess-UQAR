namespace POO; 

public class Rook : Piece {
    public Rook(Player owner, Position position) : base(owner, position, "R ") { }
    
    public override bool Move(Position position) {
        if (position.x != this.Pos.x && position.y != this.Pos.y)
            return false;
        this.Pos = position;
        return true;
    }
}