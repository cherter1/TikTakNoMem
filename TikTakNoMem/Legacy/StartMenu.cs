using System;

namespace TikTakNoMem;

internal struct StartMenu
{
    public bool playAgain;
    private char goAgain;
    private readonly bool HasChosen;
    public bool IsSinglePlayer;
    private bool triedAgain;

    public StartMenu()
    {
        Console.WriteLine("    WELCOME TO TICKTACKTOE    ");
        Console.WriteLine();
        Console.WriteLine("Would You like to play singleplayer or multiplayer?");
        Console.WriteLine("1. Singleplayer");
        Console.WriteLine("2. Multiplayer");

        while (HasChosen == false)
            try
            {
                int gameMode = Console.ReadKey(true).KeyChar;

                if (gameMode == 0x31)
                {
                    Console.WriteLine("You have chosen singleplayer.");
                    HasChosen = true;
                    IsSinglePlayer = true;
                }
                else if (gameMode == 0x32)
                {
                    Console.WriteLine("You have chosen multiplayer");
                    HasChosen = true;
                }
                else
                {
                    Console.WriteLine("Please choose 1. or 2.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please choose 1. or 2.");
            }
    }

    private static void GiveInstructions()
    {
        Console.WriteLine("                             HOW TO PLAY    ");
        Console.WriteLine();
        Console.WriteLine("    TYPE THE KEY CORRESPONDING TO THE BOX THAT YOU WANT TO MARK    ");
        Console.WriteLine("TL = TOP LEFT");
        Console.WriteLine("TM = TOP MIDDLE");
        Console.WriteLine("TR = TOP RIGHT");
        Console.WriteLine("ML = MIDDLE LEFT");
        Console.WriteLine("C = CENTER");
        Console.WriteLine("MR = MIDDLE RIGHT");
        Console.WriteLine("BL = BOTTOM LEFT");
        Console.WriteLine("BM = BOTTOM MIDDLE");
        Console.WriteLine("BR = BOTTOM RIGHT");
        Console.WriteLine();
    }

    public static void AskInstructions()
    {
        var wantInstructions = false;
        Console.WriteLine("Do You need instructions.");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        while (!wantInstructions)
        {
            var instructionIndicator = Console.ReadKey(true).KeyChar;

            if (instructionIndicator == 0x31) // hex ascii code for 1
            {
                GiveInstructions();
                wantInstructions = true;
            }
            else if (instructionIndicator == 0x32) // hex ascii code for 2
            {
                wantInstructions = true;
            }
            else
            {
                Console.WriteLine("Please choose 1. or 2.");
            }
        }
    }

    public void Replay()
    {
        Console.WriteLine("Do you want to play again:");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");

        while (!triedAgain)
        {
            goAgain = Console.ReadKey().KeyChar;

            if (goAgain == 0x31) // hex ascii code for 1
            {
                triedAgain = true;
                playAgain = true;
            }
            else if (goAgain == 0x32) // hex ascii code for 2
            {
                triedAgain = true;
                playAgain = false;
            }
            else
            {
                Console.WriteLine("Please choose 1. or 2.");
            }
        }
        triedAgain = false;
    }
}