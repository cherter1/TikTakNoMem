using TikTakNoMem;

//var b = new Board(0b_110_000_001,0b_000_011_010);
//Console.WriteLine(b.ToString());
PlayGame();

return;

void PlayGame()
{
    var myBoard = new Board(0,0);
    //var myBoard = new Board(0b_110_000_101,0b_001_011_010);
    //var myBoard = new Board(0b_001_100_001,0b_000_011_010);

    var myBot = new Bot();
    while (!myBoard.CheckWinO() && !myBoard.CheckWinX() && !myBoard.CheckFilled())
    {
        
        Console.WriteLine(myBoard.ToString());
        Console.WriteLine("Player Take Turn: ");
        var userInput = Console.ReadLine();
        int validInput;
        while (true)
        {
            if (!int.TryParse(userInput, out var sq))
            {
                continue;
            }

            if (sq is >= 9 or < 0)
            {
                continue;
            }

            validInput = sq;
            break;
        }
        myBoard = myBoard.PlayX(validInput);
        if (myBoard.CheckFilled() || myBoard.CheckWinX())
        {
            break;
        }
        var nodes = 0;
        var botMove = myBot.GetBestMove(myBoard, false, ref nodes);
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