using System.Numerics;
using TikTakNoMem;

PlayGame();

return;

void PlayGame()
{
    var myBoard = new Board(0,0);
    var botPlayer = new Bot();
    while (!myBoard.CheckWinO() && !myBoard.CheckWinX() && !myBoard.CheckFilled())
    {
        
        Console.WriteLine(myBoard.ToString());
        Console.WriteLine("Player Take Turn: ");
        var userInput = Console.ReadLine();
        int validInput = -9;
        while (true)
        {
            if (!int.TryParse(userInput, out var sq))
            {
                continue;
            }

            if (sq is < 9 and >= 0)
            {
                validInput = sq;
                break;
            }
        }
        myBoard = myBoard.PlayX(validInput);
        var nodes = 0;
        var botMove = botPlayer.GetBestMove(myBoard, false, ref nodes);
        if (!myBoard.ValidateMove(botMove))
        {
            Console.WriteLine("Bot tried to play an illegal move!");
            break;
        }

        myBoard = myBoard.PlayO(botMove);
        Console.WriteLine("bot played: " +  botMove);
    }

    Console.WriteLine(myBoard.ToString());
    if (myBoard.CheckWinO())
    {
        Console.WriteLine("O Wins the game!");
    } 
    else if (myBoard.CheckWinX())
    {
        Console.WriteLine("X Wins the game!");
    }
    else if (myBoard.CheckFilled())
    {
        Console.WriteLine("Cats game!");
    }
    else
    {
        Console.WriteLine("something went wrong");
    }
}