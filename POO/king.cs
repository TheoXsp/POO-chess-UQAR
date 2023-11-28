namespace POO; 

public class King : Piece {
    public King(Player owner, Position position) : base(owner, position, "K ") { }
    
    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        return true;
    }
    
    public override bool CanMove(Position position, Dictionary<Position, Piece?> board) {
        if (Math.Abs(position.x - this.Pos.x) > 1 || Math.Abs(position.y - this.Pos.y) > 1)
            return false;
        return true;
    }
}