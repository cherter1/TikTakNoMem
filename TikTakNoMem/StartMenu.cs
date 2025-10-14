using System;

namespace TikTakNoMem;

internal class StartMenu
{
    private readonly int GameMode;
    private char goAgain;
    private readonly bool HasChosen;
    public bool playAgain;
    public bool SinglePlayer;
    private bool triedAgain;

    public StartMenu()
    {
        Console.WriteLine("    WELCOME TO TICKTACKTOE    ");
        Console.WriteLine();
        Console.WriteLine("Would You like to play singleplayer or multiplayer?");
        Console.WriteLine("1. SinglePlayer");
        Console.WriteLine("2. Multiplayer");

        while (HasChosen == false)
            try
            {
                GameMode = Convert.ToInt32(Console.ReadLine());

                if (GameMode == 1)
                {
                    Console.WriteLine("You have chosen singleplayer.");
                    HasChosen = true;
                    SinglePlayer = true;
                }
                else if (GameMode == 2)
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

    public void GiveInstructions()
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

    public void AskInstructions()
    {
        var wantInstructions = false;
        Console.WriteLine("Do You need instructions.");
        char[] yesOption =
        [
            '1', '.', ' ', 'Y', 'e', 's'
        ];
        Console.WriteLine(yesOption);
        char[] noOption =
        [
            '1', '.', ' ', 'N', 'o'
        ];
        Console.WriteLine(noOption);
        while (!wantInstructions)
            try
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
            catch (Exception ex)
            {
                Console.WriteLine("Please choose 1. or 2.");
            }
    }

    public int GetMode()
    {
        return SinglePlayer ? 1 : 2;
    }

    public void Replay()
    {
        char[] askToPlayAgain =
        [
            'D', 'o', ' ', 'y', 'o', 'u', ' ', 'w', 'a', 'n', 't', ' ', 't', 'o', ' ', 'p', 'l', 'a', 'y', ' ', 'a',
            'g', 'a', 'i', 'n', ':'
        ];
        Console.WriteLine(askToPlayAgain);
        char[] yesOption =
        [
            '1', '.', ' ', 'Y', 'e', 's'
        ];
        Console.WriteLine(yesOption);
        char[] noOption =
        [
            '1', '.', ' ', 'N', 'o'
        ];
        Console.WriteLine(noOption);
        while (!triedAgain)
            try
            {
                goAgain = Console.ReadKey().KeyChar;

                if (goAgain == 0x31)
                {
                    triedAgain = true;
                    playAgain = true;
                }
                else if (goAgain == 0x32)
                {
                    triedAgain = true;
                    playAgain = false;
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

        triedAgain = false;
    }
}