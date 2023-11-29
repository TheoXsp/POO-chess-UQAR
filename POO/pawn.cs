namespace POO; 

public class Pawn : Piece {
    public Pawn(Player owner, Position position) : base(owner, position, "P ") { }
    
    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        return true;
    }
    
    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (board[target] != null && board[target]?.Owner == this.Owner)
            return false;
        if (Owner.IsWhite) {
            if (target.x == this.Pos.x && target.y == this.Pos.y + 2 && this.Pos.y == 2 && board[target] == null)
                return true;
            if (target.x == this.Pos.x && target.y == this.Pos.y + 1 && board[target] == null)
                return true;
            if (target.y == this.Pos.y + 1 && Math.Abs(target.x - this.Pos.x) == 1)
                return board[target] != null && board[target]?.Owner != this.Owner;
        }
        else {
            if (target.x == this.Pos.x && target.y == this.Pos.y - 2 && this.Pos.y == 7 && board[target] == null)
                return true;
            if (target.x == this.Pos.x && target.y == this.Pos.y - 1 && board[target] == null)
                return true;
            if (target.y == this.Pos.y - 1 && Math.Abs(target.x - this.Pos.x) == 1)
                return board[target] != null && board[target]?.Owner != this.Owner;
        }
        return false;
    }
    
    public override Piece Copy() {
        return new Pawn(this.Owner, this.Pos);
    }
}