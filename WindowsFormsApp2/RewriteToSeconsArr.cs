using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    static class RewriteToSeconsArr
    {
        public static void Checkking(int[,] miniMash, ref int[,] mapTemp, int x, int y)
        {
            int count = -1;
            Lifeless life = new Lifeless();
            Dead dead = new Dead();
            for (int i = 0; i < 3; i++)
            {
                for (int k = 0; k < 3; k++)
                {
                    if (miniMash[i, k] == life.Lifeless)
                    {
                        count++;
                    }
                }
            }

            if (count == 3)
            {
                Random rnd = new Random();
                int r = rnd.Next(3);
                int r2 = rnd.Next(3);
                do
                {
                    r = rnd.Next(3);
                    r2 = rnd.Next(3);
                    if (miniMash[r, r2] == dead.Dead)
                    {
                        miniMash[r, r2] = life.Lifeless;
                        break;
                    }
                } while (true);
            }
            if (count < 2 || count > 3)
            {
                miniMash[1, 1] = dead.Dead;
            }
            mapTemp[x - 1, y - 1] = miniMash[0, 0]; mapTemp[x, y - 1] = miniMash[0, 1]; mapTemp[x + 1, y - 1] = miniMash[0, 2];
            mapTemp[x - 1, y] = miniMash[1, 0]; mapTemp[x, y] = miniMash[1, 1]; mapTemp[x + 1, y] = miniMash[1, 2];
            mapTemp[x - 1, y + 1] = miniMash[2, 0]; mapTemp[x, y + 1] = miniMash[2, 1]; mapTemp[x + 1, y + 1] = miniMash[2, 2];
        }
    }
}
