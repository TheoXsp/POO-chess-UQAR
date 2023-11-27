namespace POO; 

public class Rook : Piece {
    public Rook(Player owner, Position position) : base(owner, position, "R ") { }

    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        if (target.x == Pos.x) {
            var minY = Math.Min(target.y, Pos.y);
            var maxY = Math.Max(target.y, Pos.y);
                
            for (var y = minY + 1; y < maxY; y++)
                if (board[new Position(Pos.x, y)] != null)
                    return false;
        }
        else {
            var minX = (char)Math.Min(target.x, Pos.x);
            var maxX = (char)Math.Max(target.x, Pos.x);
                
            for (var x = (char)(minX + 1); x < maxX; x++)
                if (board[new Position(x, Pos.y)] != null)
                    return false;
        }
        return true;
    }

    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (!IsAccessible(target, board))
            return false;
        if (target.x != Pos.x && target.y != Pos.y)
            return false;
        return true;
    }
}