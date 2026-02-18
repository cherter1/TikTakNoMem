using System.Numerics;

namespace TikTakNoMem;

public readonly struct Bot
{
    /// <summary>
    /// evaluates the position of a given board
    /// </summary>
    /// <param name="board">The Board to evaluate</param>
    /// <returns>+1 if you win, -1 if you lose, 0 if the position is a draw, 2 if the game is not yet over</returns>
    public int EvaluateBoard(in Board board)
    {
        bool xWin = board.CheckWinX();
        if (xWin) return 1;
        
        bool oWin = board.CheckWinO();
        if (oWin) return -1;

        bool isFilled = board.CheckFilled();
        return isFilled ? 0 : 2;
    }

    public int GetBestMove(in Board board, bool xTurn, ref int nodes)
    {
        int bestScore = -2222;
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

    public int MiniMax(in Board board, bool xTurn, ref int nodes)
    {
        nodes++;
        var evaluation = EvaluateBoard(board);
        if (evaluation != 2)
        {
            return evaluation;
        }

        int bestScore = -2222; //MIN
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