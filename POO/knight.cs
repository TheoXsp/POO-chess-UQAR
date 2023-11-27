namespace POO; 

public class Knight : Piece {
    public Knight(Player owner, Position position) : base(owner, position, "N ") { }
    
    public override bool Move(Position position) {
        if (position.x == this.Pos.x + 2 && position.y == this.Pos.y + 1)
            return true;
        if (position.x == this.Pos.x + 2 && position.y == this.Pos.y - 1)
            return true;
        if (position.x == this.Pos.x - 2 && position.y == this.Pos.y + 1)
            return true;
        if (position.x == this.Pos.x - 2 && position.y == this.Pos.y - 1)
            return true;
        if (position.x == this.Pos.x + 1 && position.y == this.Pos.y + 2)
            return true;
        if (position.x == this.Pos.x + 1 && position.y == this.Pos.y - 2)
            return true;
        if (position.x == this.Pos.x - 1 && position.y == this.Pos.y + 2)
            return true;
        if (position.x == this.Pos.x - 1 && position.y == this.Pos.y - 2)
            return true;
        return false;
    }
}