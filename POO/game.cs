namespace POO; 

public class Game {
    private Dictionary<Position, Piece?> Board { get; } = new();
    private Queue<Movement> Movements { get; } = new();
    private bool Over { get; set; } = false;
    private Player Player1 { get; set; }
    private Player Player2 { get; set; }

    public Game() {
        InitPlayers();
        InitBoard();
    }
    
    private void InitPlayers() {
        Console.Write("Player 1 name: ");
        Player1 = new Player(Console.ReadLine()!, true);
        Console.Write("Player 2 name: ");
        Player2 = new Player(Console.ReadLine()!, false);
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
        Console.WriteLine("   a b c d e f g h");
        Console.WriteLine("  ----------------");
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

    private bool TakeTurn(Player player) {
        Console.WriteLine($"{player.Name}'s turn: ");
        var movement = Console.ReadLine();
        if (movement == null || !IsStringValid(movement)) {
            Console.WriteLine("Invalid format or out of bounds");
            return false;
        }
        var parsedMovement = new Movement(player,
            new Position(movement[0], int.Parse(movement[1].ToString())),
            new Position(movement[2], int.Parse(movement[3].ToString()))
        );
        if (Board[parsedMovement.CurrentPos] == null) {
            Console.WriteLine("There's no piece there");
            return false;
        }
        if (Board[parsedMovement.CurrentPos]?.Owner != player) {
            Console.WriteLine("You don't own that piece");
            return false;
        }
        if (Board[parsedMovement.NewPos]?.Owner == player) {
            Console.WriteLine("A piece of yours is already there");
            return false;
        }
        if (!Board[parsedMovement.CurrentPos]?.CanMove(parsedMovement.NewPos, Board) ?? false) {
            Console.WriteLine("Invalid movement, this piece can't do that");
            return false;
        }
        if (IsCheckSimulate(player, parsedMovement)) {
            Console.WriteLine("Invalid movement, you can't put yourself in check");
            return false;
        }
        Board[parsedMovement.CurrentPos].Pos = parsedMovement.NewPos;
        Board[parsedMovement.NewPos] = Board[parsedMovement.CurrentPos];
        Board[parsedMovement.CurrentPos] = null;
        Movements.Enqueue(parsedMovement);
        return true;
    }
    
    private List<Piece> GetPieces(Player player, Dictionary<Position, Piece?> board) {
        var pieces = new List<Piece>();
        for (var x = 'a'; x <= 'h'; x++) {
            for (var y = 1; y <= 8; y++) {
                var piece = Board[new Position(x, y)];
                if (piece == null)
                    continue;
                if (piece.Owner == player)
                    pieces.Add(piece);
            }
        }
        return pieces;
    }

    private List<Movement> GetLegalMoves(Player player) {
        var legalMoves = new List<Movement>();
        
        foreach (var piece in GetPieces(player, Board)) {
            for (var x = 'a'; x <= 'h'; x++) {
                for (var y = 1; y <= 8; y++) {
                    var movement = new Movement(player, piece.Pos, new Position(x, y));
                    if (piece.CanMove(movement.NewPos, Board) && !IsCheckSimulate(player, movement))
                        legalMoves.Add(movement);
                }
            }
        }
        return legalMoves;
    }

    private bool IsCheckmate(Player player) {
        if (!player.IsCheck)
            return false;
        if (GetLegalMoves(player).Count > 0)
            return false;
        return true;
    }
    
    private bool IsStalemate(Player player) {
        if (player.IsCheck)
            return false;
        if (GetLegalMoves(player).Count > 0)
            return false;
        return true;
    }

    private void CheckPromotions()
    {
        foreach (var piece in GetPieces(Player1, Board)) {
            if (piece is Pawn && piece.Pos.y == 8)
                Board[piece.Pos] = new Queen(Player1, piece.Pos);
        }
        foreach (var piece in GetPieces(Player2, Board)) {
            if (piece is Pawn && piece.Pos.y == 1)
                Board[piece.Pos] = new Queen(Player2, piece.Pos);
        }
    }

    private Dictionary<Position, Piece?> CreateVirtualBoard(Movement move) {
        var virtualBoard = new Dictionary<Position, Piece?>(Board);
        virtualBoard[move.NewPos] = virtualBoard[move.CurrentPos];
        virtualBoard[move.CurrentPos] = null;
        return virtualBoard;
    }

    private bool IsCheckSimulate(Player player, Movement move) {
        var virtualBoard = CreateVirtualBoard(move);
        var oppPieces = (player == Player1) ? GetPieces(Player2, virtualBoard) : GetPieces(Player1, virtualBoard);
        var playerPieces = (player == Player1) ? GetPieces(Player1, virtualBoard) : GetPieces(Player2, virtualBoard);
        var playerKing = playerPieces.Find(piece => piece is King);
        
        foreach (var piece in oppPieces) {
            if (piece.CanMove(playerKing.Pos, Board))
                return true;
        }
        return false;
    }
    
    private void CheckChecking(Player player)
    {
        var oppPieces = (player == Player1) ? GetPieces(Player2, Board) : GetPieces(Player1, Board);
        var playerPieces = (player == Player1) ? GetPieces(Player1, Board) : GetPieces(Player2, Board);
        var playerKing = playerPieces.Find(piece => piece is King);
        
        foreach (var piece in oppPieces) {
            if (piece.CanMove(playerKing.Pos, Board)) {
                Console.WriteLine($"{player.Name}'s king is check.");
                player.IsCheck = true;
                return;
            }
        }
        player.IsCheck = false;
    }

    private void Turn(Player player) {
        DisplayBoard();
        CheckPromotions();
        CheckChecking(player);
        if (IsCheckmate(player)) {
            Over = true;
            Console.WriteLine(player == Player1
                ? $"Checkmate. {Player2.Name} wins!"
                : $"Checkmate. {Player1.Name} wins!");
            return;
        }
        if (IsStalemate(player)) {
            Over = true;
            Console.WriteLine("Stalemate.");
            return;
        }
        while (!TakeTurn(player)) continue;
    }

    public void Run() {
        while (!Over) {
            Turn(Player1);
            if (Over)
                break;
            Turn(Player2);
        }
        Console.Write("Type 'y' to save the movements history to a file: ");
        if (Console.ReadLine() == "y")
            WriteMovementsToFile();
    }

    private void WriteMovementsToFile() {
        var file = new StreamWriter("movements.txt");
        foreach (var movement in Movements)
            file.WriteLine($"{movement.Player.Name}: {movement.CurrentPos}->{movement.NewPos}");
        file.Close();
    }
}