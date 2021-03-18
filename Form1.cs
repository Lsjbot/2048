using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    public partial class Form1 : Form
    {
        public bool gameinprogress = false;
        public int boardsize = 4;
        public int score = 0;
        public int[,] board;
        public int maxundo = 10;
        public int lastundo = 0;
        public int squaresize = 50;

        public Dictionary<int, int[,]> undodict = new Dictionary<int, int[,]>();
        public Dictionary<int, Color> colordict = new Dictionary<int, Color>();
        public Dictionary<int, Font> fontdict = new Dictionary<int, Font>();

        public Form1()
        {
            InitializeComponent();
            fill_colordict();
        }

        public void memo(string s)
        {
            richTextBox1.AppendText(s + "\n");
            richTextBox1.ScrollToCaret();
        }

        public void fill_colordict()
        {
            //colordict.Add(2, Color.Red);
            //colordict.Add(4, Color.OrangeRed);
            //colordict.Add(8, Color.Orange);
            //colordict.Add(16, Color.Yellow);
            //colordict.Add(32, Color.YellowGreen);
            //colordict.Add(64, Color.LightGreen);
            //colordict.Add(128, Color.Green);
            //colordict.Add(256, Color.Turquoise);
            //colordict.Add(512, Color.Blue);
            //colordict.Add(1024, Color.BlueViolet);
            //colordict.Add(2048, Color.Violet);
            //colordict.Add(4096, Color.Lavender);
            //colordict.Add(8192, Color.Magenta);
            //colordict.Add(16384, Color.Beige);
            //colordict.Add(32768, Color.Beige);
            //colordict.Add(65536, Color.Beige);
            //colordict.Add(131072, Color.Beige);
            //colordict.Add(262144, Color.Beige);
            //colordict.Add(524288, Color.Beige);
            //colordict.Add(1048576, Color.Beige);

            int k = 2;
            double h = 0;
            double s = 1;
            double l = 0.8;
            FontFamily ff = FontFamily.GenericSansSerif;
            for (int i=0;i<25;i++)
            {
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

                colordict.Add(k, HSL2RGB(h, s, l));
                k *= 2;
                h += 0.07;
                if ( h > 1)
                {
                    h = 0;
                    l -= 0.25;
                }
            }

        }

        // Given H,S,L in range of 0-1

        // Returns a Color (RGB struct) in range of 0-255

        public static Color HSL2RGB(double h, double sl, double l)
        //from https://geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;

            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            Color rgb = Color.FromArgb(Convert.ToByte(r * 255.0f), Convert.ToByte(g * 255.0f), Convert.ToByte(b * 255.0f));

            //rgb.R = Convert.ToByte(r * 255.0f);
            //rgb.G = Convert.ToByte(g * 255.0f);
            //rgb.B = Convert.ToByte(b * 255.0f);

            return rgb;
        }



        private void Quitbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private int getnewnumber(Random rnd)
        {
            //Random rnd = new Random();
            int r = rnd.Next(100);
            if (r <= HB2.Value)
                return 2;
            else if (r <= HB2.Value + HB4.Value)
                return 4;
            else
                return 8;
        }

        private int nempty()
        {
            int n = 0;
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board[i, j] == 0)
                        n++;
            return n;
        }

        private bool canmove()
        {
            if (nempty() > 0)
                return true;
            bool movefound = false;
            for (int i=0;i<boardsize;i++)
                for (int j = 0; j < boardsize - 1; j++)
                {
                    if (board[i,j+1] == board[i,j])
                    {
                        movefound = true;
                        break;
                    }
                    if ( i < boardsize-1)
                        if (board[i+1, j] == board[i, j])
                        {
                            movefound = true;
                            break;
                        }
                }
            return movefound;
        }

        private Tuple<int,int> getempty(Random rnd)
        {
            if (nempty() == 0)
                GameOver();
            //Random rnd = new Random();
            int i = 0;
            int j = 0;
            do
            {
                i = rnd.Next(boardsize);
                j = rnd.Next(boardsize);
            }
            while (board[i, j] > 0);
            memo("i,j = " + i + ", " + j);
            return new Tuple<int, int>( i, j );
        }

        private void placenewnumber(Random rnd)
        {
            int k = getnewnumber(rnd);
            Tuple<int, int> newpos = getempty(rnd);
            board[newpos.Item1, newpos.Item2] = k;
        }

        private void updategrid()
        {
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    if (board[i, j] > 0)
                    {
                        dg[i, j].Value = board[i, j].ToString();
                        dg[i, j].Style.BackColor = colordict[board[i, j]];
                        dg[i, j].Style.SelectionBackColor = colordict[board[i, j]];
                        dg[i, j].Style.Font = fontdict[board[i,j]];
                    }
                    else
                    {
                        dg[i, j].Value = "";
                        dg[i, j].Style.BackColor = Color.White;
                        dg[i, j].Style.SelectionBackColor = Color.White;
                    }
            dg.Refresh();

        }

        private void Playbutton_Click(object sender, EventArgs e)
        {
            gameinprogress = true;
            boardsize = TB_boardsize.Value;
            dg.ColumnCount = boardsize;
            dg.RowCount = boardsize;
            foreach (DataGridViewColumn c in dg.Columns)
                c.Width = squaresize;
            foreach (DataGridViewRow r in dg.Rows)
                r.Height = squaresize;
            board = new int[boardsize, boardsize];
            for (int i = 0; i < boardsize; i++)
                for (int j = 0; j < boardsize; j++)
                    board[i,j] = 0;
            Random rnd = new Random();
            placenewnumber(rnd);
            placenewnumber(rnd);
            score = 0;
            undodict.Clear();
            for (int i=0;i< maxundo;i++)
            {
                undodict.Add(i, (int[,])board.Clone());
            }

            updategrid();
            dg.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int k = e.KeyValue;
            memo(k + ":" + (char)k);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //char c = e.KeyChar;
            //memo("keypress:" + c);

        }

        private int getcellint(DataGridViewCell dc)
        {
            if ((string)dc.Value != "")
                return Convert.ToInt32(dc.Value.ToString());
            else
                return 0;
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int k = e.KeyValue;
            memo(k + ":" + (char)k);
            
            memo("Keycode:" + e.KeyCode.ToString());

            bool anymove = false;

            numberrowclass nrc = new numberrowclass(boardsize);
            switch (e.KeyCode)
            {
                case Keys.Down:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nrc.nr[i] = board[j, boardsize - 1 - i];
                        score += nrc.compress();
                        anymove = anymove || nrc.moved;
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.nr[i] > 0)
                                board[j, boardsize - 1 - i] = nrc.nr[i];
                            else
                                board[j, boardsize - 1 - i] = 0;
                        }
                    }
                    break;
                case Keys.Up:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nrc.nr[i] = board[j,i];
                        score += nrc.compress();
                        anymove = anymove || nrc.moved;
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.nr[i] > 0)
                                board[j,i] = nrc.nr[i];
                            else
                                board[j,i] = 0;
                        }
                    }
                    break;
                case Keys.Left:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nrc.nr[i] = board[i, j];
                        score += nrc.compress();
                        anymove = anymove || nrc.moved;
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.nr[i] > 0)
                                board[i, j] = nrc.nr[i];
                            else
                                board[i, j] = 0;
                        }
                    }
                    break;
                case Keys.Right:
                    for (int j = 0; j < boardsize; j++)
                    {
                        for (int i = 0; i < boardsize; i++)
                            nrc.nr[i] = board[boardsize - 1 - i, j];
                        score += nrc.compress();
                        anymove = anymove || nrc.moved;
                        for (int i = 0; i < boardsize; i++)
                        {
                            if (nrc.nr[i] > 0)
                                board[boardsize - 1 - i, j] = nrc.nr[i];
                            else
                                board[boardsize - 1 - i, j] = 0;
                        }
                    }
                    break;
            }

            if (anymove)
            {
                Random rnd = new Random();
                for (int i = 0; i < TB_newnumbers.Value; i++)
                    placenewnumber(rnd);
                scorelabel.Text = score.ToString();
                updategrid();
                lastundo++;
                if (lastundo == maxundo)
                    lastundo = 0;
                undodict[lastundo] = (int[,])board.Clone();

                if (!canmove())
                    GameOver();

            }
            else
                memo("No move");

        }

        private void GameOver()
        {
            gameinprogress = false;
            MessageBox.Show("Game over", "Game over", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

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

        private void Colortestbutton_Click(object sender, EventArgs e)
        {
            if (!gameinprogress)
                Playbutton_Click(null, null);

            int k = 2;
            for (int i=0;i< boardsize;i++)
                for (int j=0;j< boardsize;j++)
                {
                    if (colordict.ContainsKey(k))
                        board[i, j] = k;
                    k *= 2;
                }
            updategrid();
        }

        private void HB4_Scroll(object sender, ScrollEventArgs e)
        {
            HB2.Value = 100-HB4.Value-HB8.Value;
        }

        private void HB8_Scroll(object sender, ScrollEventArgs e)
        {
            HB2.Value = 100 - HB4.Value - HB8.Value;
        }

        private void HB2_Scroll(object sender, ScrollEventArgs e)
        {
            HB4.Value = 100 - HB2.Value - HB8.Value;
            if ( HB4.Value < 0)
            {
                HB4.Value = 0;
                HB8.Value = 100 - HB2.Value;
            }
        }
    }
}
