namespace POO; 

public class Position {
    public char x { get; set; }
    public int y { get; set; }
    
    public Position(char x, int y) {
        if (x < 'a' || x > 'h' || y < 1 || y > 8)
            throw new Exception("Invalid position");
        this.x = x;
        this.y = y;
    }
    
    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType()) {
            return false;
        }
        Position p = (Position)obj;
        return x == p.x && y == p.y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }

    public override string ToString()
    {
        return $"{x}{y}";
    }
}