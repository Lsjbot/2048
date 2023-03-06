using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    /// <summary>
    /// Class for processing a single row or column on the board. 
    /// </summary>
    class numberRowClass
    {
        private int[] nr;
        int n;
        private bool moved = false;

        /// <summary>
        /// The constructor takes two arguments specifying the row/column to be processed. 
        /// </summary>
        /// <param name="npar">
        /// Number of elements in row/column.
        /// </param>
        /// <param name="nrpar">
        /// Actual elements in row/column, as a single int vector.
        /// Index 0 is at the board edge towards which the row/column should be compressed.
        /// </param>
        public numberRowClass(int npar, int[] nrpar)
        {
            nr = nrpar;
            n = npar;
        }

        /// <summary>
        /// Tells whether anything actually happened in the most recent Compress() call. 
        /// </summary>
        public bool Moved()
        {
            return moved;
        }

        private bool packleft()
        {
            //pack left:
            int k = 0;
            bool mv = false;
            for (int i = 0; i < n; i++)
            {
                if (nr[i] > 0)
                {
                    nr[k] = nr[i];
                    if (k != i)
                        mv = true;
                    k++;
                }
            }
            for (int i = k; i < n; i++)
                nr[i] = 0;

            return mv;
        }

        /// <summary>
        /// Compress the row/column towards the lower-index end of the vector.
        /// Numbers are merged according to the rules of the game.
        /// </summary>
        public int Compress()
        {
            bool empty = true;
            moved = false;
            for (int i = 0; i < n; i++)
                if (nr[i] > 0)
                    empty = false;
            if (empty)
                return 0;

            int score = 0;

            moved = moved || packleft();

            //add pairs:
            for (int i=0;i<n-1;i++)
            {
                if (nr[i] > 0)
                    if (nr[i + 1] == nr[i])
                    {
                        nr[i] = 2 * nr[i];
                        score += nr[i];
                        nr[i + 1] = 0;
                        moved = true;
                        packleft();
                    }
            }

            moved = moved || packleft();

            return score;
        }

        /// <summary>
        /// Get-function for the result vector. 
        /// </summary>
        public int getNr(int i)
        {
            if (i < 0)
                return 0;
            if (i >= n)
                return 0;
            return nr[i];
        }
    }
}
