using System.Numerics;
using TikTakNoMem;
// 511 BOARD FILLED;
PlayGame();
return;
var myBoard = new Board(0,0);
//Console.WriteLine(myBoard.ToString());
//return;
myBoard = myBoard.PlayX(1);
myBoard = myBoard.PlayX(7);
bool valid = myBoard.ValidateMove(1);
bool validO = myBoard.ValidateMove(8);
var boardXs = Convert.ToString(myBoard.X, 2).PadLeft(9, '0');
var boardOs = Convert.ToString(myBoard.O, 2).PadLeft(9, '0');

//at some point make it print in rows like the board bit by bit
ushort ex = 0b_100_000_101;
ushort oh = 0b_001_101_000;
var boardastical = new Board(ex, oh);
Console.WriteLine(boardastical.ToString());
Console.WriteLine();
Bot boty = new Bot(false);
var eval = boty.MiniMax(boardastical, true);
Console.WriteLine(eval);
return;

void PlayGame()
{
    var myBoard = new Board(0,0);
    var botPlayer = new Bot(false);
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
        var botMove = botPlayer.GetBestMove(myBoard, false);
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

void OldPlayGame()
{
    var menu = new StartMenu();
    StartMenu.AskInstructions();

    do
    {
        if (menu.IsSinglePlayer)
        {
            var player = new Player();

            while (!player.GameOver)
            {
                Console.Write("Player One Take Your turn: ");
                player.TakeTurn('X');
                player.PrintBoard();
                player.CheckForp1Win();
                player.CheckForp2Win();
                player.CheckForTie();
                if (player.GameOver) break;
                Console.WriteLine("AI's turn: ");
                player.AiTakeTurn('O');
                player.PrintBoard();
                player.CheckForp1Win();
                player.CheckForp2Win();
                player.CheckForTie();
            }

            menu.Replay();
        }
        else
        {
            //do nothing for now cuz i aint dealin with this
        }

    } while (menu.playAgain);
}