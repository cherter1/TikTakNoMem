using System;
using TikTakNoMem;

const int singlePlayer = 1;
const int multiPlayer = 2;
byte BoardRowOne = 0b_00_11_01_11;
byte BoardRowTwo = 0b_00_00_00_01;
byte BoardRowTre = 0b_00_01_01_01;
bool NineSlot = false;
//Console.WriteLine("orig");
//BoardRowOne = Convert.ToByte(BoardRowOne << 2); // shift left 00_11_11_00
checkDiagWin(BoardRowOne, BoardRowTwo, BoardRowTre);
//BoardRowOne = Convert.ToByte(BoardRowOne >> 2); // shift right 00_00_00_11
//byte testBoardRow = 0b_11_11_10_11;
//byte middleVal = testBoardRow;
//middleVal <<= 4;
//middleVal >>= 6;
//var binaryString = Convert.ToString(middleVal, 2).PadLeft(8, '0');
//Console.WriteLine(binaryString);
// BaselineMetrics.RunWithMetrics();
// BaselineMetrics.RunWithMetrics(() =>
// {
//     for (var i = 0; i < 5; i++)
//     {
//         PlayGame();
//     }
// }, "baseline (5 game)");
//PlayGame();
return;

void checkDiagWin(byte topRow, byte middleRow, byte bottomRow)
{
    byte topLeft = topRow;
    topLeft >>= 4;
    byte middleVal = middleRow;
    middleVal <<= 4;
    middleVal >>= 6;
    byte bottomRight = bottomRow;
    bottomRight <<= 6;
    bottomRight >>= 6;
    var diagByte = (byte)(topLeft & middleVal & bottomRight);
    if (topLeft == 0b11 && middleVal == 0b11 && bottomRight == 0b11)
    {
        Console.WriteLine("X WINNER");
    }
    else if (topLeft == 0b01 && middleVal == 0b01 && bottomRight == 0b01)
    {
        Console.WriteLine("O WINNER");
    }
    else
    {
        Console.WriteLine("NO WINNER YET ON FIRST DIAG");
    }
}
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