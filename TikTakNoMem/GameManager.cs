using System;

namespace TikTakNoMem;

internal class GameManager
{
    public char[,] BoardSymbols = new char[3, 3]
    {
        { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' }
    };

    public bool GameOver;
    private string TurnKey;

    public void PrintBoard()
    {
        Console.WriteLine("   |   |   ");
        Console.WriteLine(" " + BoardSymbols[0, 0] + " | " + BoardSymbols[0, 1] + " | " + BoardSymbols[0, 2] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + BoardSymbols[1, 0] + " | " + BoardSymbols[1, 1] + " | " + BoardSymbols[1, 2] + " ");
        Console.WriteLine("---|---|---");
        Console.WriteLine(" " + BoardSymbols[2, 0] + " | " + BoardSymbols[2, 1] + " | " + BoardSymbols[2, 2] + " ");
        Console.WriteLine("   |   |   ");
    }

    public void CheckForp1Win()
    {
        if ((BoardSymbols[0, 0] != 'X' || BoardSymbols[0, 1] != 'X' || BoardSymbols[0, 2] != 'X') &&
            (BoardSymbols[1, 0] != 'X' || BoardSymbols[1, 1] != 'X' || BoardSymbols[1, 2] != 'X') &&
            (BoardSymbols[2, 0] != 'X' || BoardSymbols[2, 1] != 'X' || BoardSymbols[2, 2] != 'X') &&
            (BoardSymbols[0, 0] != 'X' || BoardSymbols[1, 0] != 'X' || BoardSymbols[2, 0] != 'X') &&
            (BoardSymbols[0, 1] != 'X' || BoardSymbols[1, 1] != 'X' || BoardSymbols[2, 1] != 'X') &&
            (BoardSymbols[0, 2] != 'X' || BoardSymbols[1, 2] != 'X' || BoardSymbols[2, 2] != 'X') &&
            (BoardSymbols[0, 0] != 'X' || BoardSymbols[1, 1] != 'X' || BoardSymbols[2, 2] != 'X') &&
            (BoardSymbols[0, 2] != 'X' || BoardSymbols[1, 1] != 'X' || BoardSymbols[2, 0] != 'X')) 
            return;
        GameOver = true;
        Console.WriteLine("Player One Wins!!");
    }

    public void CheckForp2Win()
    {
        if ((BoardSymbols[0, 0] != 'O' || BoardSymbols[1, 0] != 'O' || BoardSymbols[2, 0] != 'O') &&
            (BoardSymbols[1, 0] != 'O' || BoardSymbols[1, 1] != 'O' || BoardSymbols[1, 2] != 'O') &&
            (BoardSymbols[2, 0] != 'O' || BoardSymbols[2, 1] != 'O' || BoardSymbols[2, 2] != 'O') &&
            (BoardSymbols[0, 0] != 'O' || BoardSymbols[1, 0] != 'O' || BoardSymbols[2, 0] != 'O') &&
            (BoardSymbols[0, 1] != 'O' || BoardSymbols[1, 1] != 'O' || BoardSymbols[2, 1] != 'O') &&
            (BoardSymbols[0, 2] != 'O' || BoardSymbols[1, 2] != 'O' || BoardSymbols[2, 2] != 'O') &&
            (BoardSymbols[0, 0] != 'O' || BoardSymbols[1, 1] != 'O' || BoardSymbols[2, 2] != 'O') &&
            (BoardSymbols[0, 2] != 'O' || BoardSymbols[1, 1] != 'O' || BoardSymbols[2, 0] != 'O')) 
            return;
        GameOver = true;
        Console.WriteLine("Player Two Wins!!");
    }

    public void CheckForTie()
    {
        if (BoardSymbols[0, 0] == ' ' || BoardSymbols[0, 1] == ' ' || BoardSymbols[0, 2] == ' ' ||
            BoardSymbols[1, 0] == ' ' || BoardSymbols[1, 1] == ' ' || BoardSymbols[1, 2] == ' ' ||
            BoardSymbols[2, 0] == ' ' || BoardSymbols[2, 1] == ' ' || BoardSymbols[2, 2] == ' ') 
            return;
        
        if (BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O' ||
            BoardSymbols[1, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[1, 2] == 'O' ||
            BoardSymbols[2, 0] == 'O' && BoardSymbols[2, 1] == 'O' && BoardSymbols[2, 2] == 'O' ||
            BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O' ||
            BoardSymbols[0, 1] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 1] == 'O' ||
            BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 2] == 'O' && BoardSymbols[2, 2] == 'O' ||
            BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 2] == 'O' ||
            BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 0] == 'O') 
            return;
        
        if (BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 0] == 'X' && BoardSymbols[2, 0] == 'X' ||
            BoardSymbols[1, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[1, 2] == 'X' ||
            BoardSymbols[2, 0] == 'X' && BoardSymbols[2, 1] == 'X' && BoardSymbols[2, 2] == 'X' ||
            BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 0] == 'X' && BoardSymbols[2, 0] == 'X' ||
            BoardSymbols[0, 1] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 1] == 'X' ||
            BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 2] == 'X' && BoardSymbols[2, 2] == 'X' ||
            BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 2] == 'X' ||
            BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 0] == 'X') 
            return;
        
        Console.WriteLine("Cats Game!!");
        GameOver = true;
    }
}