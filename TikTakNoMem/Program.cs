using System;
using TikTakNoMem;

const int singlePlayer = 1;
const int multiPlayer = 2;
// BaselineMetrics.RunWithMetrics(PlayGame, "Warmup (1 game)");
// BaselineMetrics.RunWithMetrics(() =>
// {
//     for (var i = 0; i < 5; i++)
//     {
//         PlayGame();
//     }
// }, "baseline (5 game)");
PlayGame();
return;


void PlayGame()
{
    var menu = new StartMenu();
    menu.AskInstructions();

    do
    {
        if (menu.GetMode() == singlePlayer)
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

    } while (menu.playAgain);
}