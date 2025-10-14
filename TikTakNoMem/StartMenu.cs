namespace TikTakNoMem;

internal class StartMenu
{
    private readonly int GameMode;
    private int goAgain;
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
        var WantInstructions = false;
        Console.WriteLine("Do You need instructions.");
        Console.WriteLine("1. yes");
        Console.WriteLine("2. no");
        while (!WantInstructions)
            try
            {
                var Instructions = Convert.ToInt32(Console.ReadLine());

                if (Instructions == 1)
                {
                    GiveInstructions();
                    WantInstructions = true;
                }
                else if (Instructions == 2)
                {
                    WantInstructions = true;
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
        if (SinglePlayer) return 1;

        return 2;
    }

    public void Replay()
    {
        Console.WriteLine("Do you want to play again:");
        Console.WriteLine("1. Yes");
        Console.WriteLine("2. No");
        while (!triedAgain)
            try
            {
                goAgain = Convert.ToInt32(Console.ReadLine());

                if (goAgain == 1)
                {
                    triedAgain = true;
                    playAgain = true;
                }
                else if (goAgain == 2)
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