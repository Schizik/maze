using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze
{
    public class init
    {
        public const int n = 29;
        public const int m = 119;
        static Random rnd = new Random();

        public static void Fill(char[,] a)
        {
            for(int vertical = 0; vertical < n; vertical++)
            {
                for(int horizontal = 0; horizontal < m; horizontal++)
                {
                    a[vertical, horizontal] = ' ';
                }
            }
            for (int vertical = 1; vertical < n-1; vertical++)
            {
                a[vertical, 0] = '│';
                a[vertical, m-1] = '│';
            }
            for (int horizontal = 1; horizontal < m-1; horizontal++)
            {
                a[0, horizontal] = '─';
                a[n-1, horizontal] = '─';
            }
            a[0, 0] = '┌';
            a[0, m-1] = '┐';
            a[n-1, 0] = '└';
            a[n-1, m-1] = '┘';
        }

        public static void View(char[,] a)
        {
            for(int vertical = 0; vertical < n; vertical++)
            {
                for(int horizontal = 0; horizontal < m; horizontal++)
                {
                    Console.Write(Convert.ToChar(a[vertical, horizontal]));
                }
                Console.WriteLine();
            }
        }

        public static void Genereate_lvl(char[,] a)
        {
            int i, count;
            char t = ' ';
            count = rnd.Next(20, 30);
            for(i = 0; i <= count; i++)
            {
                a[rnd.Next(1, n - 5), rnd.Next(1, m-1)] = '1';
            }
            count = rnd.Next(30, 40);
            for (i = 0; i <= count; i++)
            {
                a[rnd.Next(1, n-5), rnd.Next(1, m - 1)] = '2';
            }
            //count = rnd.Next(20, 60);
            //for (i = 0; i <= count; i++)
            //{
            //    a[rnd.Next(4, 25), rnd.Next(15, 100)] = '3';
            //}
            //count = rnd.Next(15, 20);
            //for (i = 0; i <= count; i++)
            //{
            //    a[rnd.Next(4, 25), rnd.Next(30, 100)] = '4';
            //}
            int startpoint = rnd.Next(1, n - 1);
            int endpiont = rnd.Next(1, n - 1);
            a[startpoint, 0] = 'S';
            a[endpiont, m-1] = 'E';
            i = 1;
            while(t == ' ')
            {                
                if (i == 25)
                {
                    break;
                }
                t = a[startpoint, i];
                i++;
            }
            a[startpoint, i] = '2';
            for (count=1;count<i;count++)
            {
                a[startpoint, count] = '#';
            }
            Make_Road(startpoint, i, a);
        }

        public static void Make_Road(int vertical, int horizontal, char[,] a)
        {
            int i = vertical, count;
            char t = ' ';
            if (a[vertical, horizontal] == '2')
            {
                if (a[vertical, horizontal-1] == '#')
                {
                    while (t == ' ')
                    {
                        i++;
                        if (i == (vertical+5))
                        {
                            a[i, horizontal] = '2';
                            break;
                        }
                        t = a[i, horizontal];
                    }
                    for (count = vertical+1; count < i; count++)
                    {
                        a[count, horizontal] = '#';
                    }
                }
            }

        }
    }
}
