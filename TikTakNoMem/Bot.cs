using System.Numerics;

namespace TikTakNoMem;

public struct Bot(bool isX)
{
    private bool IsX = isX;
    private bool IsO = !isX;

    public void SearchMove(Board board)
    {
        var boardState = ~(board.O | board.X);
        var sq = BitOperations.TrailingZeroCount(boardState);

        var count = 0;

        while (sq < 9)
        {
            //playmove for set bit square. return evaluation
            var bitToggleMask = 1 << sq;
            boardState ^= bitToggleMask; //figure out next possible parent move
            sq = BitOperations.TrailingZeroCount(boardState);
            count++;
        }

        Console.WriteLine($"loop ran {count} times");
    }
}
