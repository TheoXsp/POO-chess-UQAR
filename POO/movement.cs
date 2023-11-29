namespace POO; 

public class Movement {
    public Player Player { get; set; }
    public Position CurrentPos { get; set; }
    public Position NewPos { get; set; }
    
    public Movement(Player player, Position currentPos, Position newPos) {
        this.Player = player;
        this.CurrentPos = currentPos;
        this.NewPos = newPos;
    }
    
    public override string ToString() {
        return $"{Player.Name}: {CurrentPos}->{NewPos}";
    }
}