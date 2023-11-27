namespace POO; 

public class Queen : Piece {
    public Queen(Player owner, Position position) : base(owner, position, "Q ") { }
    
    public override bool Move(Position position) {
        if (position.x != this.Pos.x && position.y != this.Pos.y)
            return false;
        if (Math.Abs(position.x - this.Pos.x) != Math.Abs(position.y - this.Pos.y))
            return false;
        this.Pos = position;
        return true;
    }
}