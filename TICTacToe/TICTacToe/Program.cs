using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TICTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TICTacToe ttt = new TICTacToe();
            ttt.StartGame();
            Console.ReadLine();
        }
    }
}
