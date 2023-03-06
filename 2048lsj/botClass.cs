using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    /// <summary>
    /// Class for handling Autoplay, with various different algorithms.
    /// </summary>
    class botClass
    {
        private static List<Keys> arrows = new List<Keys>() { Keys.Up, Keys.Down, Keys.Left, Keys.Right };

        private string algorithm;

        /// <summary>
        /// The constructor take a string argument with the name of the algorithm. 
        /// Defaults to the "Greedy" algorithm if value is unrecognized.
        /// </summary>
        /// <param name="algo">
        /// Name of algorithm to be used.
        /// </param>
        /// <list type="table">
        /// <item>
        /// <term>Greedy</term>
        /// <description>
        /// Maximizes immediate score.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Max free squares</term>
        /// <description>
        /// Maximizes number of free squares on the board.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Max contiguous free</term>
        /// <description>
        /// Maximizes the size of the largest area with contiguous free squares on the board.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Large corners</term>
        /// <description>
        /// Maximizes the total square values around board edges, with double weight for corners.
        /// </description>
        /// </item>
        /// <item>
        /// <term>Random</term>
        /// <description>
        /// Makes random moves.
        /// </description>
        /// </item>
        /// </list>
        public botClass(string algo)
        {
            algorithm = algo;
        }

        /// <summary>
        /// Returns the appropriate move (encoded as an arrow key) for the given board
        /// and the chosen algorithm.
        /// </summary>
        public Keys getMove(boardClass board,int newnumbers)
        {
            switch (algorithm)
            {
                case "Max free squares":
                    return maxfreemove(board, newnumbers);
                case "Max contiguous free":
                    return maxcontfreemove(board, newnumbers);
                case "Large corners":
                    return edgescoremove(board, newnumbers);
                case "Random":
                    return randommove();
                case "Greedy":
                default:
                    return greedymove(board, newnumbers);
                    //break;
            }
        }

        private Keys greedymove(boardClass board, int newnumbers)
        {
            int bestscore = -1;
            Keys bestkey = Keys.Space;
            Random rnd = new Random();
            foreach (Keys kk in arrows)
            {
                boardClass bb = board.Clone();
                Tuple<int, bool> tt = bb.makeMove(kk, newnumbers);
                if (tt.Item2)
                {
                    if (tt.Item1 > bestscore || (tt.Item1 == bestscore && rnd.Next(2) == 1))
                    {
                        bestscore = tt.Item1;
                        bestkey = kk;
                    }
                }
            }
            return bestkey;
        }

        private Keys maxfreemove(boardClass board, int newnumbers)
        {
            int bestscore = -1;
            Keys bestkey = Keys.Space;
            Random rnd = new Random();
            foreach (Keys kk in arrows)
            {
                boardClass bb = board.Clone();
                Tuple<int, bool> tt = bb.makeMove(kk, newnumbers);
                if (tt.Item2)
                {
                    if (bb.countFree() > bestscore || (bb.countFree() == bestscore && rnd.Next(2) == 1))
                    {
                        bestscore = bb.countFree();
                        bestkey = kk;
                    }
                }
            }
            return bestkey;
        }
        private Keys maxcontfreemove(boardClass board, int newnumbers)
        {
            int bestscore = -1;
            Keys bestkey = Keys.Space;
            Random rnd = new Random();
            foreach (Keys kk in arrows)
            {
                boardClass bb = board.Clone();
                Tuple<int, bool> tt = bb.makeMove(kk, newnumbers);
                if (tt.Item2)
                {
                    if (bb.countLargestFree() > bestscore || (bb.countLargestFree() == bestscore && rnd.Next(2) == 1))
                    {
                        bestscore = bb.countLargestFree();
                        bestkey = kk;
                    }
                }
            }
            return bestkey;
        }
        private Keys edgescoremove(boardClass board, int newnumbers)
        {
            int bestscore = -1;
            Keys bestkey = Keys.Space;
            Random rnd = new Random();
            foreach (Keys kk in arrows)
            {
                boardClass bb = board.Clone();
                Tuple<int, bool> tt = bb.makeMove(kk, newnumbers);
                if (tt.Item2)
                {
                    if (bb.countEdgeScore() > bestscore || (bb.countEdgeScore() == bestscore && rnd.Next(2) == 1))
                    {
                        bestscore = bb.countEdgeScore();
                        bestkey = kk;
                    }
                }
            }
            return bestkey;
        }

        private Keys randommove()
        {
            Random rnd = new Random();
            return arrows[rnd.Next(4)];
        }
    }
}
