using System.Numerics;

namespace TikTakNoMem;

public readonly struct Bot(bool isX)
{
    const int TABLE_SIZE  = 19683 * 2;

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

    public int GetBestMove(in Board board, bool xTurn)
    {
        int bestScore;
        int bestSq;

        if (xTurn)
        {
            bestScore = -2222;
            var state = ~(board.X | board.O);
            int sq = BitOperations.TrailingZeroCount(state);
            bestSq = sq;
            while (sq < 9)
            {
                var score = MiniMax(board.PlayX(sq), false);
                if (score > bestScore)
                {
                    bestScore = score;
                    bestSq = sq;
                }
                state = ~(~(state) | (1 << sq));
                sq = BitOperations.TrailingZeroCount(state);
            }
        }
        else
        {
            bestScore = +2222;
            var state = ~(board.X | board.O);
            int sq = BitOperations.TrailingZeroCount(state);
            bestSq = sq;
            while (sq < 9)
            {
                var score = MiniMax(board.PlayO(sq), true);
                if (score < bestScore)
                {
                    bestScore = score;
                    bestSq = sq;
                }
                state = ~(~(state) | (1 << sq));
                sq = BitOperations.TrailingZeroCount(state);
            }
        }

        return bestSq;
    }

    public int MiniMax(in Board board, bool xTurn)
    {
        int bestScore;
        var evaluation = EvaluateBoard(board);
        if (evaluation != 2)
        {
            return evaluation;
        }

        if (xTurn)
        {
            bestScore = -2222;
            var state = ~(board.X | board.O);
            int sq = BitOperations.TrailingZeroCount(state);
            while (sq < 9)
            {
                var score = MiniMax(board.PlayX(sq), false);
                if (score > bestScore)
                {
                    bestScore = score;
                }
                state = ~(~(state) | (1 << sq));
                sq = BitOperations.TrailingZeroCount(state);
            }
        }
        else
        {
            bestScore = +2222;
            var state = ~(board.X | board.O);
            int sq = BitOperations.TrailingZeroCount(state);
            while (sq < 9)
            {
                var score = MiniMax(board.PlayO(sq), true);
                if (score < bestScore)
                {
                    bestScore = score;
                }
                state = ~(~(state) | (1 << sq));
                sq = BitOperations.TrailingZeroCount(state);
            }
        }

        return bestScore;
    }
}