namespace TikTakNoMem;

internal readonly struct Board(ushort x, ushort o)
{
    readonly ushort X = x;
    readonly ushort O = o;

    //win masks
    const ushort maskW0 = 0b_111_000_000;
    const ushort maskW1 = 0b_000_111_000;
    const ushort maskW2 = 0b_000_000_111;
    const ushort maskW3 = 0b_100_010_001;
    const ushort maskW4 = 0b_001_010_100;
    const ushort maskW5 = 0b_100_100_100;
    const ushort maskW6 = 0b_010_010_010;
    const ushort maskW7 = 0b_001_001_001;


    public Board PlayX()
    {
        return default;
    }

    public Board PlayO()
    {

        return default;
    }

    public bool CheckwinX()
    {
        var dubski = (X & maskW0) == maskW0 ||
            (X & maskW1) == maskW1 ||
            (X & maskW2) == maskW2 ||
            (X & maskW3) == maskW3 ||
            (X & maskW4) == maskW4 ||
            (X & maskW5) == maskW5 ||
            (X & maskW6) == maskW6 ||
            (X & maskW7) == maskW7;

        return dubski;
    }

    public bool CheckWin0()
    {
        var dubski = (O & maskW0) == maskW0 ||
            (O & maskW1) == maskW1 ||
            (O & maskW2) == maskW2 ||
            (O & maskW3) == maskW3 ||
            (O & maskW4) == maskW4 ||
            (O & maskW5) == maskW5 ||
            (O & maskW6) == maskW6 ||
            (O & maskW7) == maskW7;

        return dubski;
    }

    public bool CheckFilled()
    {
        return (X | O) == 511;
    }
}
