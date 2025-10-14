namespace TikTakNoMem;

internal class Player : GameManager
{
    private bool aiplayed;
    private string TurnKey;
    private bool TurnTaken;


    public void TakeTurn(char ox)
    {
        while (!TurnTaken)
            try
            {
                TurnKey = Console.ReadLine();

                if (TurnKey == "TL")
                {
                    if (BoardSymbols[0, 0] == ' ')
                    {
                        BoardSymbols[0, 0] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "TM")
                {
                    if (BoardSymbols[0, 1] == ' ')
                    {
                        BoardSymbols[0, 1] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "TR")
                {
                    if (BoardSymbols[0, 2] == ' ')
                    {
                        BoardSymbols[0, 2] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "ML")
                {
                    if (BoardSymbols[1, 0] == ' ')
                    {
                        BoardSymbols[1, 0] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "C")
                {
                    if (BoardSymbols[1, 1] == ' ')
                    {
                        BoardSymbols[1, 1] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "MR")
                {
                    if (BoardSymbols[1, 2] == ' ')
                    {
                        BoardSymbols[1, 2] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "BL")
                {
                    if (BoardSymbols[2, 0] == ' ')
                    {
                        BoardSymbols[2, 0] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "BM")
                {
                    if (BoardSymbols[2, 1] == ' ')
                    {
                        BoardSymbols[2, 1] = ox;
                        TurnTaken = true;
                    }
                    else
                    {
                        Console.WriteLine("That Spot is Taken");
                    }
                }
                else if (TurnKey == "BR")
                {
                    if (BoardSymbols[2, 2] == ' ')
                    {
                        BoardSymbols[2, 2] = ox;
                        TurnTaken = true;
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

        TurnTaken = false;
    }

    public void AiTakeTurn(char op)
    {
        var rnd = new Random();
        var r = rnd.Next(1, 10);
        while (!aiplayed)
            if (r == 1)
            {
                if (BoardSymbols[0, 0] == ' ')
                {
                    BoardSymbols[0, 0] = op;
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
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
                    aiplayed = true;
                }
                else
                {
                    r = rnd.Next(1, 10);
                }
            }

        aiplayed = false;
    }
}