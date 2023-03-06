using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    public partial class Form1 : Form
    {
        private bool gameinprogress = false;
        private bool keypress = false;
        private int boardsize = 4;
        private int score = 0;
        private int maxundo = 10;
        private int lastundo = 0;
        private int squaresize = 50;
        private int newnumbers;
        private bool got2048;

        private boardClass board;

        private Dictionary<int, boardClass> undodict = new Dictionary<int, boardClass>();
        private colorSchemeClass colorScheme;
        private Dictionary<int, Font> fontdict = new Dictionary<int, Font>();

        public Form1()
        {
            InitializeComponent();
            LBcolor.Items.Add("Default");
            LBcolor.Items.Add("Red");
            LBcolor.Items.Add("Green");
            LBcolor.Items.Add("Blue");
            LBcolor.Items.Add("Classic");
            LBcolor.SelectedItem = "Default";

            LBautoplay.Items.Add("Greedy");
            LBautoplay.Items.Add("Max free squares");
            LBautoplay.Items.Add("Max contiguous free");
            LBautoplay.Items.Add("Large corners");
            LBautoplay.Items.Add("Random");
            LBautoplay.SelectedItem = "Greedy";


            fill_fontdict();
            newnumbers = TB_newnumbers.Value;
        }

        /// <summary>
        /// Display a message that doesn't warrant a MessageBox. Pseudo-Console output for a WinForms app.
        /// </summary>
        /// <param name="s">Message</param>
        private void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        /// <summary>
        /// Fill the dictionary specifying what fonts to use for different board squares
        /// </summary>
        private void fill_fontdict()
        {

            int k = 2;
            FontFamily ff = FontFamily.GenericSansSerif;
            for (int i=0;i<30;i++)
            { 
                //different font size depending on # of digits
                if (k < 10)
                    fontdict.Add(k, new Font(ff, 18));
                else if (k < 100)
                    fontdict.Add(k, new Font(ff, 15));
                else if (k < 1000)
                    fontdict.Add(k, new Font(ff, 11));
                else if (k < 10000)
                    fontdict.Add(k, new Font(ff, 9));
                else if (k < 1000000)
                    fontdict.Add(k, new Font(ff, 8));
                else if (k < 10000000)
                    fontdict.Add(k, new Font(ff, 7));
                else
                    fontdict.Add(k, new Font(ff, 6));
                k *= 2;

            }

        }

        /// <summary>
        /// Returns the font to be used for a board square with value k.
        /// Defaults to smallest size if k out of range.
        /// </summary>
        /// <param name="k">board value</param>
        /// <returns></returns>
        private Font getFont(int k)
        {
            if (fontdict.ContainsKey(k))
                return fontdict[k];
            else
                return fontdict.Last().Value; //new Font(FontFamily.GenericSansSerif, 6);
        }

        /// <summary>
        /// Exit and close.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Display the board on screen.
        /// </summary>
        private void updategrid()
        {
            if (board == null)
                return;

            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board.getCell(i, j) > 0)
                    {
                        int num = board.getCell(i, j);
                        dg[i, j].Value = num.ToString();
                        dg[i, j].Style.BackColor = colorScheme.getColor(num);
                        dg[i, j].Style.SelectionBackColor = colorScheme.getColor(num);
                        dg[i, j].Style.Font = getFont(num);
                        dg[i, j].Style.ForeColor = colorScheme.getTextColor(num);
                    }
                    else
                    {
                        dg[i, j].Value = "";
                        dg[i, j].Style.BackColor = Color.White;
                        dg[i, j].Style.SelectionBackColor = Color.White;
                    }
            dg.Refresh();

        }

        /// <summary>
        /// Start a new game. Check first if any ongoing game is to be discarded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Playbutton_Click(object sender, EventArgs e)
        {
            if (gameinprogress)
            {
                DialogResult dr = MessageBox.Show("Do you want to discard the current game?","New game", MessageBoxButtons.OKCancel);
                if (dr != DialogResult.OK)
                    return;
            }

            newGame();
        }

        /// <summary>
        /// Set up a new game.
        /// </summary>
        private void newGame()
        {
            gameinprogress = true;
            got2048 = false;
            boardsize = TB_boardsize.Value;
            dg.ColumnCount = boardsize;
            dg.RowCount = boardsize;
            foreach (DataGridViewColumn c in dg.Columns)
                c.Width = squaresize;
            foreach (DataGridViewRow r in dg.Rows)
                r.Height = squaresize;
            dg.Width = boardsize * squaresize + 10;
            dg.Height = boardsize * squaresize + 10;
            board = new boardClass(boardsize, null, HB2.Value, HB4.Value);
            score = 0;
            undodict.Clear();
            for (int i = 0; i < maxundo; i++)
            {
                undodict.Add(i, board.Clone());
            }


            updategrid();
            dg.Focus();

        }

        /// <summary>
        /// (not used)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            keypress = true;
            //int k = e.KeyValue;
            //memo(k + ":" + (char)k);
        }

        /// <summary>
        /// (not used)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char c = e.KeyChar;
            //memo("keypress:" + c);

        }
        /// <summary>
        /// (not used)
        /// </summary>
        private int getcellint(DataGridViewCell dc)
        {
            if ((string)dc.Value != "")
                return Convert.ToInt32(dc.Value.ToString());
            else
                return 0;
        }

        /// <summary>
        /// Handle the event when the user makes a move by pressing a key.
        /// This is the key handling routine that's actually used in the game, never mind the fossils above.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            keypress = true;
            int k = e.KeyValue;
            memo(k + ":" + (char)k);
            
            memo("Keycode:" + e.KeyCode.ToString());

            makeMove(e.KeyCode);
        }
        /// <summary>
        /// Make a move in the game, either user move or autoplay move.
        /// </summary>
        /// <param name="kk">Move encoded as arrow key</param>
        private void makeMove(Keys kk)
        {

            Tuple<int, bool> moveresult = board.makeMove(kk, newnumbers);

            score += moveresult.Item1;

            if (moveresult.Item2)
            {
                scorelabel.Text = score.ToString();
                scorelabel.Refresh();
                updategrid();
                lastundo++;
                if (lastundo == maxundo)
                    lastundo = 0;
                undodict[lastundo] = board.Clone();
            }
            else
                memo("No move");

            if (!board.canMove())
                GameOver();

            if (!got2048)
            {
                if (board.maxValue() == 2048)
                {
                    got2048 = true;
                    MessageBox.Show("2048 achieved!", "2048 achieved!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        /// <summary>
        /// Handles the end of a game.
        /// </summary>
        private void GameOver()
        {
            updategrid();
            gameinprogress = false;
            SystemSounds.Beep.Play();
            MessageBox.Show("Game over", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// Undo the most recent game move. 
        /// Can be called repeatedly, but only maxundo old positions are stored, after that it will loop.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Undobutton_Click(object sender, EventArgs e)
        {
            lastundo--;
            if (lastundo < 0)
                lastundo = maxundo - 1;
            board = undodict[lastundo];
            updategrid();
            dg.Focus();
        }

        private void TB_boardsize_Scroll(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Test the chosen color scheme
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Colortestbutton_Click(object sender, EventArgs e)
        {
            //if (!gameinprogress)
                Playbutton_Click(null, null);

            board.testPattern();
            updategrid();
        }

        /// <summary>
        /// HB2, HB4, HB8 should always sum to 100. When one of them is changed, the others are recalculated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HB4_Scroll(object sender, ScrollEventArgs e)
        {
            HB2.Value = 100-HB4.Value-HB8.Value;
        }

        /// <summary>
        /// HB2, HB4, HB8 should always sum to 100. When one of them is changed, the others are recalculated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HB8_Scroll(object sender, ScrollEventArgs e)
        {
            HB2.Value = 100 - HB4.Value - HB8.Value;
        }

        /// <summary>
        /// HB2, HB4, HB8 should always sum to 100. When one of them is changed, the others are recalculated.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HB2_Scroll(object sender, ScrollEventArgs e)
        {
            HB4.Value = 100 - HB2.Value - HB8.Value;
            if ( HB4.Value < 0)
            {
                HB4.Value = 0;
                HB8.Value = 100 - HB2.Value;
            }
        }

        /// <summary>
        /// Set color scheme to be used. Can be called in the middle of a game.
        /// </summary>
        private void setColorScheme()
        {
            string cs = "Default";
            if (LBcolor.SelectedItem != null)
                cs = LBcolor.SelectedItem.ToString();
            colorScheme = new colorSchemeClass(cs);
        }

        /// <summary>
        /// Handle color-scheme listbox events
        /// </summary>

        private void LBcolor_SelectedIndexChanged(object sender, EventArgs e)
        {
            setColorScheme();
            updategrid();
            dg.Focus();
        }

        /// <summary>
        /// Main autoplay method, using botClass to make moves.
        /// For each time you press the autoplay button, 100 moves are made.
        /// </summary>
        private void botLoop()
        {
            string algo = "Greedy";
            if (LBautoplay.SelectedItem != null)
                algo = LBautoplay.SelectedItem.ToString();
            botClass bot = new botClass(algo);

            int maxloop = 100;
            int loop = 0;
            while (gameinprogress && !keypress && loop < maxloop)
            {
                Keys kk = bot.getMove(board, newnumbers);
                makeMove(kk);
                loop++;
                Thread.Sleep(200); //pause for 200 ms between moves
            }
            updategrid();
            dg.Focus();
            memo("Done " + loop + " loops in Autoplay. Press <Autoplay> again to continue.");
        }

        /// <summary>
        /// Set up for autoplay. Can either continue an ongoing game or start a new one.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void botButton_Click(object sender, EventArgs e)
        {
            
            if (!gameinprogress)
                newGame();

            keypress = false;
            //Thread botThread = new Thread(botLoop);
            //botThread.Start();
            botLoop();

        }

        private void TB_newnumbers_Scroll(object sender, EventArgs e)
        {
            newnumbers = TB_newnumbers.Value;
        }
    }
}
