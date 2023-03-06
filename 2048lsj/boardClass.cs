using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    /// <summary>
    /// Class for the game board. Most of the actual game play takes place here. 
    /// </summary>
    class boardClass
    {
        private int[,] board;
        private int boardsize;
        private bool placefail = false; //becomes true if failing to place new number
        private int prob2; 
        private int prob4;


        /// <summary>
        /// The constructor takes four arguments specifying the parameters for game setup. 
        /// </summary>
        /// <param name="size">
        /// Board size.
        /// </param>
        /// <param name="startingboard">
        /// if null, then a new game with empty board is set up.
        /// if not null, an old game (provided in this argument) is restarted
        /// </param>
        /// <param name="HB2">
        /// When a new number is added to the board, that number is 2 with percentage-probability HB2.
        /// </param>
        /// <param name="HB4">
        /// When a new number is added to the board, that number is 4 with percentage-probability HB4.
        /// A new number may also be 8, with a probability that is the complement of HB2+HB4.
        /// </param>
        public boardClass(int size,int[,] startingboard, int HB2, int HB4)
        {
            boardsize = size;
            prob2 = HB2;
            prob4 = HB4;
            if (startingboard != null)
                board = (int[,])startingboard.Clone(); //note that this is the Array.Clone method, not the Clone method in this class
            else
            {
                board = new int[boardsize, boardsize];
                for (int i = 0; i < boardsize; i++)
                    for (int j = 0; j < boardsize; j++)
                        board[i, j] = 0;
                Random rnd = new Random();
                placenewnumber(rnd); //start with 2 numbers on otherwise empty board
                placenewnumber(rnd);
            }
        }

        /// <summary>
        /// Returns a copy of self. 
        /// </summary>
        public boardClass Clone()
        {
            return new boardClass(this.boardsize, this.board,prob2,prob4);
        }

        //public int[,] boardClone()
        //{
        //    return (int[,])board.Clone();
        //}

        /// <summary>
        /// Returns the number of empty squares on the board. 
        /// </summary>
        public int countFree()
        {
            int nfree = 0;
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board[i, j] == 0)
                        nfree++;
            return nfree;
        }

        /// <summary>
        /// Returns the largest contiguous area with empty squares on the board. 
        /// </summary>
        public int countLargestFree()
        {
            int nfree = 0;
            int[,] fb = new int[boardsize, boardsize];
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    fb[i, j] = 0;
            int n = 1;

            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board[i, j] == 0 && fb[i,j] == 0)
                    {
                        int nfill = fillAdjacent(i, j, fb, n);
                        if (nfill > nfree)
                            nfree = nfill;
                    }
            return nfree;
        }

        /// <summary>
        /// Returns the sum of the numbers around the board edges, with corners counting double. 
        /// </summary>
        public int countEdgeScore()
        {
            int escore = 0;
            for (int i=0;i<boardsize;i++)
            {
                escore += board[i, 0];
                escore += board[i, boardsize-1];
                escore += board[0,i];
                escore += board[boardsize - 1,i];
            }
            return escore;
        }

        private int fillAdjacent(int i, int j,int[,] fb, int n)
        {

            fb[i, j] = n;
            int nfill = 1;
            for (int u = -1; u <= 1; u++)
            {
                if (i+u >= 0 && i+u < boardsize)
                    for (int v = -1; v <= 1; v++)
                    {
                        if (j+v >= 0 && j+v < boardsize)
                        {
                            if (board[i+u,j+v] == 0 && fb[i+u,j+v] == 0)
                            {
                                nfill += fillAdjacent(i + u, j + v, fb, n);
                            }
                        }
                    }
            }

            return nfill;

        }


        /// <summary>
        /// Main game play method, invoked when the player (our autoplay) makes a move. 
        /// Returns a tuple where Item1 is the score of the move and Item2 indicates whether anything actually moved.
        /// </summary>
        ///<param name="key">
        ///The actual move, encoded as an arrow key
        ///</param>
        ///<param name="newnumbers">
        ///The number of new numbers to be added to the board after this move
        ///</param>
        public Tuple<int,bool> makeMove(Keys key,int newnumbers)
        {

            bool anymove = false;
            int score = 0;


            //numberRowClass nrc = new numberRowClass(boardsize);
            int[] nr = new int[boardsize];
            switch (key)
            {
                case Keys.Down:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nr[i] = board[j, boardsize - 1 - i];
                        numberRowClass nrc = new numberRowClass(boardsize, nr);
                        score += nrc.Compress();
                        anymove = anymove || nrc.Moved();
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.getNr(i) > 0)
                                board[j, boardsize - 1 - i] = nrc.getNr(i);
                            else
                                board[j, boardsize - 1 - i] = 0;
                        }
                    }
                    break;
                case Keys.Up:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nr[i] = board[j, i];
                        numberRowClass nrc = new numberRowClass(boardsize, nr);
                        score += nrc.Compress();
                        anymove = anymove || nrc.Moved();
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.getNr(i) > 0)
                                board[j, i] = nrc.getNr(i);
                            else
                                board[j, i] = 0;
                        }
                    }
                    break;
                case Keys.Left:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nr[i] = board[i, j];
                        numberRowClass nrc = new numberRowClass(boardsize, nr);
                        score += nrc.Compress();
                        anymove = anymove || nrc.Moved();
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.getNr(i) > 0)
                                board[i, j] = nrc.getNr(i);
                            else
                                board[i, j] = 0;
                        }
                    }
                    break;
                case Keys.Right:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nr[i] = board[boardsize - 1 - i, j];
                        numberRowClass nrc = new numberRowClass(boardsize, nr);
                        score += nrc.Compress();
                        anymove = anymove || nrc.Moved();
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.getNr(i) > 0)
                                board[boardsize - 1 - i, j] = nrc.getNr(i);
                            else
                                board[boardsize - 1 - i, j] = 0;
                        }
                    }
                    break;
            }

            if (anymove)
            {
                Random rnd = new Random();
                for (int i = 0; i < newnumbers; i++)
                {
                    if (!placenewnumber(rnd))
                    {
                        placefail = true;
                        break;
                    }
                }

            }

            return new Tuple<int,bool>(score,anymove);

        }
        /// <summary>
        /// Used for testing color schemes
        /// </summary>
        public void testPattern()
        {
            int k = 2;
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                {
                    //if (colordict.ContainsKey(k))
                    board[i, j] = k;
                    k *= 2;
                }
        }

        private int nEmpty()
        {
            int n = 0;
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board[i, j] == 0)
                        n++;
            return n;
        }
        /// <summary>
        /// Returns true if a move is possible, false otherwise (implies game over)
        /// </summary>
        /// <returns></returns>
        public bool canMove()
        {
            if (placefail)
                return false;
            if (nEmpty() > 0)
                return true;
            bool movefound = false;
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize - 1; j++)
                {
                    if (board[i, j + 1] == board[i, j])
                    {
                        movefound = true;
                        break;
                    }
                    if (board[j + 1,i] == board[j,i])
                    {
                        movefound = true;
                        break;
                    }
                    //if (i < boardsize - 1)
                    //    if (board[i + 1, j] == board[i, j])
                    //    {
                    //        movefound = true;
                    //        break;
                    //    }
                }
            return movefound;
        }

        public int maxValue()
        {
            int max = -1;
            foreach (int x in board)
                if (x > max)
                    max = x;
            return max;
        }
        private int getnewnumber(Random rnd)
        {
            //Random rnd = new Random();
            int r = rnd.Next(100);
            if (r <= prob2)
                return 2;
            else if (r <= prob2+prob4)
                return 4;
            else
                return 8;
        }

        private Tuple<int, int> getempty(Random rnd)
        {
            if (nEmpty() == 0)
                return null;
            //Random rnd = new Random();
            int i = 0;
            int j = 0;
            do
            {
                i = rnd.Next(boardsize);
                j = rnd.Next(boardsize);
            }
            while (board[i, j] > 0);
            //memo("i,j = " + i + ", " + j);
            return new Tuple<int, int>(i, j);
        }

        private bool placenewnumber(Random rnd)
        {
            int k = getnewnumber(rnd);
            Tuple<int, int> newpos = getempty(rnd);
            if (newpos == null)
                return false;
            board[newpos.Item1, newpos.Item2] = k;
            return true;
        }

        /// <summary>
        /// Get-method for getting the contents of a board square.
        /// </summary>
        /// <param name="i">First coordinate</param>
        /// <param name="j">Second coordinate</param>
        /// <returns></returns>
        public int getCell(int i,int j)
        {
            return board[i, j];
        }

    }
}
