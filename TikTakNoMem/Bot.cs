using System.Numerics;

namespace TikTakNoMem;

public struct Bot(bool isX)
{
    private bool IsX = isX;
    private bool IsO = !isX;

    public void SearchMove(Board board)
    {
        var availBoardSquares = (ushort)~(board.X | board.O);
        BitOperations.TrailingZeroCount(availBoardSquares);

        Console.WriteLine();
    }


}
