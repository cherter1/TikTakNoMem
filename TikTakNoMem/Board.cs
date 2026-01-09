namespace TikTakNoMem;

public readonly struct Board(ushort x, ushort o)
{
    public readonly ushort X = x;
    public readonly ushort O = o;

    //win masks
    const ushort maskW0 = 0b_111_000_000;
    const ushort maskW1 = 0b_000_111_000;
    const ushort maskW2 = 0b_000_000_111;
    const ushort maskW3 = 0b_100_010_001;
    const ushort maskW4 = 0b_001_010_100;
    const ushort maskW5 = 0b_100_100_100;
    const ushort maskW6 = 0b_010_010_010;
    const ushort maskW7 = 0b_001_001_001;

    public Board PlayX(int sq)
    {
        var exes = (ushort)(X | (1 << sq));
        var nBoard = new Board(exes, O);
        return nBoard;
    }

    public bool ValidateMove(int sq)
    {
        if (sq > 8 || sq < 0)
        {
            return false;
        }

        var occupiedMask = X | O;
        if ((occupiedMask & (256 >> sq)) != 0)
        {
            return false;
        }

        return true;
    }

    public Board PlayO(int sq)
    {
        var ohs = (ushort)(O | (1 << sq));
        var nBoard = new Board(X, ohs);
        return nBoard;
    }

    public bool CheckWinX()
    {
        var dubski =
            (X & maskW0) == maskW0
            || (X & maskW1) == maskW1
            || (X & maskW2) == maskW2
            || (X & maskW3) == maskW3
            || (X & maskW4) == maskW4
            || (X & maskW5) == maskW5
            || (X & maskW6) == maskW6
            || (X & maskW7) == maskW7;

        return dubski;
    }

    public bool CheckWinO()
    {
        var dubski =
            (O & maskW0) == maskW0
            || (O & maskW1) == maskW1
            || (O & maskW2) == maskW2
            || (O & maskW3) == maskW3
            || (O & maskW4) == maskW4
            || (O & maskW5) == maskW5
            || (O & maskW6) == maskW6
            || (O & maskW7) == maskW7;

        return dubski;
    }

    public bool CheckFilled()
    {
        return (X | O) == 511;
    }

    public override string ToString()
    {
        Span<char> boardBuffer = stackalloc char[9];
        for (int i = 0; i < 9; i++)
        {
            var currBit = 1 << i;
            var modX = X & currBit;
            var modO = O & currBit;
            if (modX != currBit && modO != currBit)
            {
                boardBuffer[i] = ' ';
                continue;
            }
            
            if (modX == currBit)
            {
                boardBuffer[i] = 'X';
                continue;
            }

            if (modO == currBit)
            {
                boardBuffer[i] = 'O';
                continue;
            }
            
        }

        return $"{boardBuffer[8]} | {boardBuffer[7]} | {boardBuffer[6]}\n--|---|--\n{boardBuffer[5]} | {boardBuffer[4]} | {boardBuffer[3]}\n--|---|--\n{boardBuffer[2]} | {boardBuffer[1]} | {boardBuffer[0]}";
    }
}