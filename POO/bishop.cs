namespace POO; 

public class Bishop : Piece {
    public Bishop(Player owner, Position position) : base(owner, position, "B ") { }
    
    public override bool Move(Position position) {
        if (Math.Abs(position.x - this.Pos.x) != Math.Abs(position.y - this.Pos.y))
            return false;
        this.Pos = position;
        return true;
    }
}