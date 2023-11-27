namespace POO; 

public class Player {
    public string Name { get; }
    public bool IsWhite { get; }
    public bool IsCheck { get; set; }
    
    public Player(string name, bool white) {
        Name = name;
        IsWhite = white;
        IsCheck = false;
    }
}