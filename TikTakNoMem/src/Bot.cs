using System.Numerics;

namespace TikTakNoMem;

public readonly struct Bot
{
    /// <summary>
    /// evaluates the position of a given board
    /// </summary>
    /// <param name="board">The Board to evaluate</param>
    /// <param name="xTurn">whether its x's turn to play</param>
    /// <returns>+1 if you win, -1 if you lose, 0 if the position is a draw, 2 if the game is not yet over</returns>
    private static int EvaluateBoard(in Board board, bool xTurn)
    {
        switch (xTurn)
        {
            case true when board.CheckWinX():
            case false when board.CheckWinO():
                return 1;
            case true when board.CheckWinO():
            case false when board.CheckWinX():
                return -1;
            default:
                {
                    return board.CheckFilled() ? 0 : 2;
                }
        }
    }

    public static int GetBestMove(in Board board, bool xTurn, ref int nodes)
    {
        int bestScore = xTurn ? -2222 : +2222;
        var state = ~(board.X | board.O);
        int sq = BitOperations.TrailingZeroCount(state);
        int bestSq = sq;
        while (sq < 9)
        {
            var score = xTurn ? MiniMax(board.PlayX(sq), false, ref nodes) : -MiniMax(board.PlayO(sq), true, ref nodes);
            if (score > bestScore)
            {
                bestScore = score;
                bestSq = sq;
            }
            state = ~(~(state) | (1 << sq));
            sq = BitOperations.TrailingZeroCount(state);
        }

        return bestSq;
    }

    private static int MiniMax(in Board board, bool xTurn, ref int nodes)
    {
        nodes++;
        var evaluation = EvaluateBoard(board, xTurn);
        if (evaluation != 2)
        {
            return evaluation;
        }

        int bestScore = xTurn ? -2222 : +2222;
        var state = ~(board.X | board.O);
        int sq = BitOperations.TrailingZeroCount(state);
        while (sq < 9)
        {
            var score = xTurn ? MiniMax(board.PlayX(sq), false, ref nodes) : -MiniMax(board.PlayO(sq), true, ref nodes);
            if (score > bestScore)
            {
                bestScore = score;
            }
            state = ~(~(state) | (1 << sq));
            sq = BitOperations.TrailingZeroCount(state);
        }

        return bestScore;
    }
}