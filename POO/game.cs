namespace POO; 

public class Game {
    private Dictionary<Position, Piece?> Board { get; } = new();
    private Stack<Movement> Movements { get; } = new();
    private bool Over { get; set; } = false;
    private Player Player1 { get; set; }
    private Player Player2 { get; set; }

    public Game() {
        InitPlayers();
        InitBoard();
    }
    
    private void InitPlayers() {
        Console.Write("Player 1 name: ");
        Player1 = new Player(Console.ReadLine()!);
        Console.Write("Player 2 name: ");
        Player2 = new Player(Console.ReadLine()!);
    }

    private void InitBoard() {
        for (var x = 'a'; x <= 'h'; x++) {
            Board[new Position(x, 2)] = new Pawn(Player1, new Position(x, 2));
            Board[new Position(x, 7)] = new Pawn(Player2, new Position(x, 7));
        }
        
        Board[new Position('a', 1)] = new Rook(Player1, new Position('a', 1));
        Board[new Position('h', 1)] = new Rook(Player1, new Position('h', 1));
        Board[new Position('a', 8)] = new Rook(Player2, new Position('a', 8));
        Board[new Position('h', 8)] = new Rook(Player2, new Position('h', 8));
        
        Board[new Position('b', 1)] = new Knight(Player1, new Position('b', 1));
        Board[new Position('g', 1)] = new Knight(Player1, new Position('g', 1));
        Board[new Position('b', 8)] = new Knight(Player2, new Position('b', 8));
        Board[new Position('g', 8)] = new Knight(Player2, new Position('g', 8));
        
        Board[new Position('c', 1)] = new Bishop(Player1, new Position('c', 1));
        Board[new Position('f', 1)] = new Bishop(Player1, new Position('f', 1));
        Board[new Position('c', 8)] = new Bishop(Player2, new Position('c', 8));
        Board[new Position('f', 8)] = new Bishop(Player2, new Position('f', 8));
        
        Board[new Position('d', 1)] = new Queen(Player1, new Position('d', 1));
        Board[new Position('d', 8)] = new Queen(Player2, new Position('d', 8));
        
        Board[new Position('e', 1)] = new King(Player1, new Position('e', 1));
        Board[new Position('e', 8)] = new King(Player2, new Position('e', 8));
        
        for (var x = 'a'; x <= 'h'; x++) {
            for (var y = 3; y <= 6; y++)
                Board[new Position(x, y)] = null;
        }
    }
    
    private void DisplayBoard() {
        Console.WriteLine("  a b c d e f g h");
        Console.WriteLine("  ---------------");
        for (var y = 8; y >= 1; y--) {
            Console.Write(y + "| ");
            for (var x = 'a'; x <= 'h'; x++) {
                var piece = Board[new Position(x, y)];
                if (piece == null)
                    Console.Write(". ");
                Console.Write(piece);
            }
            Console.WriteLine();
        }
    }

    private bool IsStringValid(string movement) {
        if (movement.Length != 4)
            return false;
        if (movement[0] < 'a' || movement[0] > 'h')
            return false;
        if (movement[1] < '1' || movement[1] > '8')
            return false;
        if (movement[2] < 'a' || movement[2] > 'h')
            return false;
        if (movement[3] < '1' || movement[3] > '8')
            return false;
        return true;
    }

    private void TakeTurn(Player player) {
        DisplayBoard();
        Console.WriteLine($"{player.Name}'s turn: ");
        var movement = Console.ReadLine();
        while (movement == null || !IsStringValid(movement)) {
            Console.WriteLine("Invalid movement. Try again: ");
            movement = Console.ReadLine();
        }
        var parsedMovement = new Movement(player,
            new Position(movement[0], int.Parse(movement[1].ToString())),
            new Position(movement[2], int.Parse(movement[3].ToString()))
        );
        // TODO: add logic
        
    }
    
    public void Run() {
        while (!Over) {
            TakeTurn(Player1);
            TakeTurn(Player2);
        }
    }
}