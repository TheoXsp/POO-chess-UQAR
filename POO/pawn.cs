namespace POO; 

public class Pawn : Piece {
    public Pawn(Player owner, Position position) : base(owner, position, "P ") { }
    
    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        return true;
    }
    
    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (Owner.IsWhite) {
            if (target.y == this.Pos.y + 1)
                return true;
            if (target.y == this.Pos.y + 2 && this.Pos.y == 2)
                return true;
        }
        else {
            if (target.y == this.Pos.y - 1)
                return true;
            if (target.y == this.Pos.y - 2 && this.Pos.y == 7)
                return true;
        }
        return false;
    }
}