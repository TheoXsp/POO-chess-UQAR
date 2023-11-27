namespace POO; 

public class Pawn : Piece {
    public Pawn(Player owner, Position position) : base(owner, position, "P ") { }
    
    public override bool Move(Position position) {
        if (position.x != this.Pos.x)
            return false;
        if (position.y == this.Pos.y + 1)
            return true;
        if (position.y == this.Pos.y + 2 && this.Pos.y == 1)
            return true;
        return false;
    }
}