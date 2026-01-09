namespace TikTakNoMem;

public readonly struct Board(ushort x, ushort o)
{
    public readonly ushort X = x;
    public readonly ushort O = o;

    //win masks
    const ushort MaskW0 = 0b_111_000_000;
    const ushort MaskW1 = 0b_000_111_000;
    const ushort MaskW2 = 0b_000_000_111;
    const ushort MaskW3 = 0b_100_010_001;
    const ushort MaskW4 = 0b_001_010_100;
    const ushort MaskW5 = 0b_100_100_100;
    const ushort MaskW6 = 0b_010_010_010;
    const ushort MaskW7 = 0b_001_001_001;

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
            (X & MaskW0) == MaskW0
            || (X & MaskW1) == MaskW1
            || (X & MaskW2) == MaskW2
            || (X & MaskW3) == MaskW3
            || (X & MaskW4) == MaskW4
            || (X & MaskW5) == MaskW5
            || (X & MaskW6) == MaskW6
            || (X & MaskW7) == MaskW7;

        return dubski;
    }

    public bool CheckWinO()
    {
        var dubski =
            (O & MaskW0) == MaskW0
            || (O & MaskW1) == MaskW1
            || (O & MaskW2) == MaskW2
            || (O & MaskW3) == MaskW3
            || (O & MaskW4) == MaskW4
            || (O & MaskW5) == MaskW5
            || (O & MaskW6) == MaskW6
            || (O & MaskW7) == MaskW7;

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