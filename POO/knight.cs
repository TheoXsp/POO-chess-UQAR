namespace POO; 

public class Knight : Piece {
    public Knight(Player owner, Position position) : base(owner, position, "N ") { }
    
    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        return true;
    }
    
    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (target.x == this.Pos.x + 2 && target.y == this.Pos.y + 1)
            return true;
        if (target.x == this.Pos.x + 2 && target.y == this.Pos.y - 1)
            return true;
        if (target.x == this.Pos.x - 2 && target.y == this.Pos.y + 1)
            return true;
        if (target.x == this.Pos.x - 2 && target.y == this.Pos.y - 1)
            return true;
        if (target.x == this.Pos.x + 1 && target.y == this.Pos.y + 2)
            return true;
        if (target.x == this.Pos.x + 1 && target.y == this.Pos.y - 2)
            return true;
        if (target.x == this.Pos.x - 1 && target.y == this.Pos.y + 2)
            return true;
        if (target.x == this.Pos.x - 1 && target.y == this.Pos.y - 2)
            return true;
        return false;
    }
}