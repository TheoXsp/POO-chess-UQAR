namespace POO; 

public class Queen : Piece {
    public Queen(Player owner, Position position) : base(owner, position, "Q ") { }

    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        var xDiff = Math.Abs(target.x - Pos.x);
        var yDiff = Math.Abs(target.y - Pos.y);
        if (xDiff == yDiff) {
            var xDirection = target.x > Pos.x ? 1 : -1;
            var yDirection = target.y > Pos.y ? 1 : -1;
            var xCurrent = (char)(Pos.x + xDirection);
            var yCurrent = Pos.y + yDirection;
            
            while (xCurrent != target.x && yCurrent != target.y) {
                if (board[new Position(xCurrent, yCurrent)] != null)
                    return false;

                xCurrent = (char)(xCurrent + xDirection);
                yCurrent += yDirection;
            }
        }
        else {
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
        }
        return true;
    }
    
    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (!IsAccessible(target, board))
            return false;
        if (target.x != this.Pos.x && target.y != this.Pos.y && Math.Abs(target.x - this.Pos.x) != Math.Abs(target.y - this.Pos.y))
            return false;
        return true;
    }
}