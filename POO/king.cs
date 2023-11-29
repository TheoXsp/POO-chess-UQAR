namespace POO; 

public class King : Piece {
    public King(Player owner, Position position) : base(owner, position, "K ") { }
    
    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        return true;
    }
    
    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (Math.Abs(target.x - this.Pos.x) > 1 || Math.Abs(target.y - this.Pos.y) > 1)
            return false;
        if (board[target] != null && board[target]?.Owner == this.Owner)
            return false;
        return true;
    }
    
    public override Piece Copy() {
        return new King(this.Owner, this.Pos);
    }
}