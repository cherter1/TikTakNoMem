using System;

namespace TikTakNoMem;

internal class Player : GameManager
{
    private bool _aiPlayed;
    private string _turnKey = string.Empty;
    private bool _turnTaken;


    public void TakeTurn(char ox)
    {
        while (!_turnTaken)
            try
            {
                _turnKey = Console.ReadLine();

                if (_turnKey == "TL")
                {
                    if (BoardSymbols[0, 0] == ' ')
                    {
                        BoardSymbols[0, 0] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "TM")
                {
                    if (BoardSymbols[0, 1] == ' ')
                    {
                        BoardSymbols[0, 1] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "TR")
                {
                    if (BoardSymbols[0, 2] == ' ')
                    {
                        BoardSymbols[0, 2] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "ML")
                {
                    if (BoardSymbols[1, 0] == ' ')
                    {
                        BoardSymbols[1, 0] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "C")
                {
                    if (BoardSymbols[1, 1] == ' ')
                    {
                        BoardSymbols[1, 1] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "MR")
                {
                    if (BoardSymbols[1, 2] == ' ')
                    {
                        BoardSymbols[1, 2] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "BL")
                {
                    if (BoardSymbols[2, 0] == ' ')
                    {
                        BoardSymbols[2, 0] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "BM")
                {
                    if (BoardSymbols[2, 1] == ' ')
                    {
                        BoardSymbols[2, 1] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (_turnKey == "BR")
                {
                    if (BoardSymbols[2, 2] == ' ')
                    {
                        BoardSymbols[2, 2] = ox;
                        _turnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid turn key try again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid turn key try again");
            }

        _turnTaken = false;
    }

    public void AiTakeTurn(char op)
    {
        var rnd = new Random();
        var r = rnd.Next(1, 10);
        while (!_aiPlayed)
            if (r == 1)
            {
                if (BoardSymbols[0, 0] == ' ')
                {
                    BoardSymbols[0, 0] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 2)
            {
                if (BoardSymbols[0, 1] == ' ')
                {
                    BoardSymbols[0, 1] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 3)
            {
                if (BoardSymbols[0, 2] == ' ')
                {
                    BoardSymbols[0, 2] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 4)
            {
                if (BoardSymbols[1, 0] == ' ')
                {
                    BoardSymbols[1, 0] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 5)
            {
                if (BoardSymbols[1, 1] == ' ')
                {
                    BoardSymbols[1, 1] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 6)
            {
                if (BoardSymbols[1, 2] == ' ')
                {
                    BoardSymbols[1, 2] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 7)
            {
                if (BoardSymbols[2, 0] == ' ')
                {
                    BoardSymbols[2, 0] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 8)
            {
                if (BoardSymbols[2, 1] == ' ')
                {
                    BoardSymbols[2, 1] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }
            else if (r == 9)
            {
                if (BoardSymbols[2, 2] == ' ')
                {
                    BoardSymbols[2, 2] = op;
                    _aiPlayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }

        _aiPlayed = false;
    }
}