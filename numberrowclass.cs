using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048lsj
{
    class numberrowclass
    {
        public int[] nr;
        int n;
        public bool moved = false;

        public numberrowclass(int npar)
        {
            nr = new int[npar];
            n = npar;
        }

        public bool packleft()
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

        public int compress()
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
    }
}
