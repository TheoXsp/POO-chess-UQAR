namespace POO; 

public class Bishop : Piece {
    public Bishop(Player owner, Position position) : base(owner, position, "B ") { }

    protected override bool IsAccessible(Position target, Dictionary<Position, Piece?> board) {
        var xDirection = target.x > Pos.x ? 1 : -1;
        var yDirection = target.y > Pos.y ? 1 : -1;

        var xCurrent = (char)(Pos.x + xDirection);
        var yCurrent = Pos.y + yDirection;
        
        while (xCurrent != target.x && yCurrent != target.y) {
            if (xCurrent < 'a' || xCurrent > 'h' || yCurrent < 1 || yCurrent > 8) {
                return false;
            }
            if (board[new Position(xCurrent, yCurrent)] != null) {
                return false;
            }
            xCurrent = (char)(xCurrent + xDirection);
            yCurrent += yDirection;
        }
        return true;
    }

    public override bool CanMove(Position target, Dictionary<Position, Piece?> board) {
        if (!IsAccessible(target, board))
            return false;
        if (Math.Abs(target.x - this.Pos.x) != Math.Abs(target.y - this.Pos.y))
            return false;
        return true;
    }
}