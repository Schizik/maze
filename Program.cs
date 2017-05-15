using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] maze = new char[init.n, init.m];
            while (true)
            {                
                init.Fill(maze);
                init.Genereate_lvl(maze);
                init.View(maze);
                Console.Read();
                Console.Clear();
            }
        }
    }
}
