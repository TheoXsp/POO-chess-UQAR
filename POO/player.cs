namespace POO; 

public class Player {
    public string Name { get; }
    public bool IsCheck { get; set; }
    
    public Player(string name) {
        this.Name = name;
        this.IsCheck = false;
    }
}