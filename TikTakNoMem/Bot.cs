using System.Numerics;

namespace TikTakNoMem;

public struct Bot(bool isX)
{
    private bool IsX = isX;
    private bool IsO = !isX;

    public int SearchMove(Board board, bool xTurn)
    {
        var boardState = ~(board.O | board.X);
        var sq = BitOperations.TrailingZeroCount(boardState);
        var branchEval = -2;

        while (sq < 9)
        {
            //playmove for set bit square. return evaluation
            board = xTurn ? board.PlayX(sq) : board.PlayO(sq);
            Console.WriteLine(board);
            if (board.CheckFilled())
            {
                if (board.CheckWinX())
                {
                    if (IsX)
                    {
                        branchEval = 1;
                    }

                    branchEval = -1;
                }
                else if (board.CheckWinO())
                {
                    if (IsX)
                    {
                        branchEval = -1;
                    }
                    
                    branchEval = 1;
                }
                else
                {
                    branchEval = 0;
                }
            }

            var bitToggleMask = 1 << sq;
            boardState ^= bitToggleMask; //figure out next possible parent move
            sq = BitOperations.TrailingZeroCount(boardState);
            var returnedEval= SearchMove(board, !xTurn);
            branchEval = returnedEval >= branchEval ? returnedEval : branchEval;
        }

        return branchEval;

    }

    public void miniMax()
    {

        
    }
}