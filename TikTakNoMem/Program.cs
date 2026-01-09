using System.Numerics;
using TikTakNoMem;
// 511 BOARD FILLED;

var myBoard = new Board(0,0);
Console.WriteLine(myBoard.ToString());
return;
myBoard = myBoard.PlayX(1);
myBoard = myBoard.PlayX(7);
bool valid = myBoard.ValidateMove(1);
bool validO = myBoard.ValidateMove(8);
var boardXs = Convert.ToString(myBoard.X, 2).PadLeft(9, '0');
var boardOs = Convert.ToString(myBoard.O, 2).PadLeft(9, '0');

//at some point make it print in rows like the board bit by bit
ushort ex = 0b_100_000_101;
ushort oh = 0b_000_101_000;
var boardastical = new Board(ex, oh);
Bot boty = new Bot(false);
var eval = boty.SearchMove(boardastical, false);
Console.WriteLine(eval);
return;

var boardState = ~(boardastical.O | boardastical.X);
var setBit = BitOperations.TrailingZeroCount(boardState);
//playmove for set bit square. return evaluation
var bitToggleMask = 1 << setBit;
var postLoopBoard = boardState ^ bitToggleMask; //figure out next possible parent move

var boardStateToWrite = Convert.ToString(boardState, 2).PadLeft(9, '0');
var postLoopBoardToWrite = Convert.ToString(postLoopBoard, 2).PadLeft(9, '0');
var postLoopSetBit = BitOperations.TrailingZeroCount(postLoopBoard);

Console.WriteLine(boardStateToWrite);
Console.WriteLine(setBit);
Console.WriteLine(postLoopBoardToWrite);
Console.WriteLine(postLoopSetBit);

return;
ushort biny = 0b_0001_0000_0000_1000;
Console.WriteLine(BitOperations.LeadingZeroCount(biny));
Console.WriteLine();
Console.WriteLine("X");
Console.WriteLine(boardXs);
Console.WriteLine(myBoard.X);
Console.WriteLine("O");
Console.WriteLine(boardOs);
Console.WriteLine(myBoard.O);

Console.WriteLine("shouldnt be valid");
Console.WriteLine(valid);
Console.WriteLine("should be valid");
Console.WriteLine(validO);
return;

BaselineMetrics.RunWithMetrics(() =>
{
    Console.WriteLine("NineSlot");
}, "warmup (JIT) 1 just write line");
BaselineMetrics.RunWithMetrics(() =>
{
    for (var i = 0; i < 10; i++)
    {
        Console.WriteLine("NineSlot");
    }
}, "baseline (10 times) just write line");
PlayGame();
return;

void PlayGame()
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
