namespace POO; 

public class King : Piece {
    public King(Player owner, Position position) : base(owner, position, "K ") { }
    
    public override bool Move(Position position) {
        if (Math.Abs(position.x - this.Pos.x) > 1 || Math.Abs(position.y - this.Pos.y) > 1)
            return false;
        this.Pos = position;
        return true;
    }
}