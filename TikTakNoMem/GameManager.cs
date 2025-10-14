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
        if (BoardSymbols[0, 0] == 'X' && BoardSymbols[0, 1] == 'X' && BoardSymbols[0, 2] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //top across
        else if (BoardSymbols[1, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[1, 2] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //middle across
        else if (BoardSymbols[2, 0] == 'X' && BoardSymbols[2, 1] == 'X' && BoardSymbols[2, 2] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //bottom across
        else if (BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 0] == 'X' && BoardSymbols[2, 0] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //left down
        else if (BoardSymbols[0, 1] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 1] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //middle down
        else if (BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 2] == 'X' && BoardSymbols[2, 2] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //left down
        else if (BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 2] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //left start diag
        else if (BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 0] == 'X')
        {
            GameOver = true;
            Console.WriteLine("Player One Wins!!");
        } //right start diag
    }

    public void CheckForp2Win()
    {
        if (BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //top across//
        else if (BoardSymbols[1, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[1, 2] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //middle across//
        else if (BoardSymbols[2, 0] == 'O' && BoardSymbols[2, 1] == 'O' && BoardSymbols[2, 2] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //bottom across//
        else if (BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //left down//
        else if (BoardSymbols[0, 1] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 1] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //middle down//
        else if (BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 2] == 'O' && BoardSymbols[2, 2] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //left down//
        else if (BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 2] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //left start diag//
        else if (BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 0] == 'O')
        {
            GameOver = true;
            Console.WriteLine("Player Two Wins!!");
        } //right start diag//
    }

    public void CheckForTie()
    {
        if (BoardSymbols[0, 0] != ' ' && BoardSymbols[0, 1] != ' ' && BoardSymbols[0, 2] != ' ' &&
            BoardSymbols[1, 0] != ' ' && BoardSymbols[1, 1] != ' ' && BoardSymbols[1, 2] != ' ' &&
            BoardSymbols[2, 0] != ' ' && BoardSymbols[2, 1] != ' ' && BoardSymbols[2, 2] != ' ')
            if (!(BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O') &&
                !(BoardSymbols[1, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[1, 2] == 'O') &&
                !(BoardSymbols[2, 0] == 'O' && BoardSymbols[2, 1] == 'O' && BoardSymbols[2, 2] == 'O') &&
                !(BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 0] == 'O' && BoardSymbols[2, 0] == 'O') &&
                !(BoardSymbols[0, 1] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 1] == 'O') &&
                !(BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 2] == 'O' && BoardSymbols[2, 2] == 'O') &&
                !(BoardSymbols[0, 0] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 2] == 'O') &&
                !(BoardSymbols[0, 2] == 'O' && BoardSymbols[1, 1] == 'O' && BoardSymbols[2, 0] == 'O'))
                if (!(BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 0] == 'X' && BoardSymbols[2, 0] == 'X') &&
                    !(BoardSymbols[1, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[1, 2] == 'X') &&
                    !(BoardSymbols[2, 0] == 'X' && BoardSymbols[2, 1] == 'X' && BoardSymbols[2, 2] == 'X') &&
                    !(BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 0] == 'X' && BoardSymbols[2, 0] == 'X') &&
                    !(BoardSymbols[0, 1] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 1] == 'X') &&
                    !(BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 2] == 'X' && BoardSymbols[2, 2] == 'X') &&
                    !(BoardSymbols[0, 0] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 2] == 'X') &&
                    !(BoardSymbols[0, 2] == 'X' && BoardSymbols[1, 1] == 'X' && BoardSymbols[2, 0] == 'X'))
                {
                    Console.WriteLine("Cats Game!!");
                    GameOver = true;
                }
    }
}