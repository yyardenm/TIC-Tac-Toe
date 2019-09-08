using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//CR - you still have a lot of places when you have "consoel.Readline" or "console.Writeline"
// not only in the print board function (at least in 10 places more"
// lets say ME (Yarden), will handle the UI ond yoy will handle all the logic.
// to do that (beacuse we are very far away from each other), we need to define an -Interface-:
// the interface is how we will connected. for example - I need a 
// * function from you that will show me the correct user
// * I will implementing the game - so I will give you i,j and you perform the action - if the move is Invalid you will return me false
//
// what else do we need to add to the interface
// to do that - think in all the place you have interaction with the user (read, write) 
// and as a baseline think which function you need to do for that


namespace TICTacToe
{
    class TICTacToe
    {
        public const int Size = 3;
        private int[,] board;
        public TICTacToe()//opens new board
        {
            board = new int[Size, Size];
            InitialiseBoard();
        }
        public void StartGame()
        {
            //CR - I think all this initialization ned to be in initialize function - and call this function from here/
            // this is because if you want to restart the game - it will be easier
            char player = '1';
            int x;
            int y;
            int movesCount = 0;
            while (movesCount < 5 || GameOn())
            {
                PrintBoard();
                Console.WriteLine("it's player " + player + "'s turn. enter the x and y you want to place ");
                x = int.Parse(Console.ReadLine());
                y = int.Parse(Console.ReadLine());
                while (x < 0 || x >= board.GetLength(0) || y < 0 || y > board.GetLength(1) || board[x, y] == 1 || board[x, y] == -1)
                {
                    Console.WriteLine("you've entered wrong coordinate. please enter coordinate within the board's border, and with nothing on them");
                    x = int.Parse(Console.ReadLine());
                    y = int.Parse(Console.ReadLine());
                }
                if (player == '1')
                    board[x, y] = 1;
                else
                {
                    board[x, y] = -1;
                }
                if (player == '1')
                    player = '2';
                else
                    player = '1';

                movesCount++;

            }
        }
        private void InitialiseBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = 0;
                }
            }
        }
        


        
        private void PrintBoard()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        Console.Write(" - ");
                    }
                    else if (board[i, j] == 1)
                    {
                        Console.Write(" x ");
                    }
                    else
                    {
                        Console.Write(" o ");
                    }
                }
                Console.WriteLine();
            }
        }

        private bool GameOn()
        {

            if (Win())
                return false;
            if (BoardIsFull())
            {
                PrintBoard();
                Console.WriteLine("draw!");
                return false;
            }
            return true;
        }
        public bool BoardIsFull()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (board[i, j] == 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private bool Win()// checks if someone won. if so, prints the winning player
        {
            int sumOfSomething = 0; //CR - bad name
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sumOfSomething = SumColumn(i);
                //CR - too much duplicate code. all this ifs returning to many times
                if (sumOfSomething == 3)
                {
                    PrintBoard();
                    Console.WriteLine("player 1 won!");
                    return true;
                }
                if (sumOfSomething == -3)
                {
                    PrintBoard();
                    Console.WriteLine("player 2 won!");
                    return true;
                }
            }

            for (int i = 0; i < board.GetLength(1); i++)
            {
                sumOfSomething = SumRow(i);
                if (sumOfSomething == 3)
                {
                    PrintBoard();
                    Console.WriteLine("player 1 won!");
                    return true;
                }
                if (sumOfSomething == -3)
                {
                    PrintBoard();
                    Console.WriteLine("player 2 won!");
                    return true;
                }
            }
            sumOfSomething = FirstSlantSum();
            if (sumOfSomething == 3)
            {
                PrintBoard();
                Console.WriteLine("player 1 won!");
                return true;
            }
            if (sumOfSomething == -3)
            {
                PrintBoard();
                Console.WriteLine("player 2 won!");
                return true;
            }
            sumOfSomething = SecondSlantSum();
            if (sumOfSomething == 3)
            {
                PrintBoard();
                Console.WriteLine("player 1 won!");
                return true;
            }
            if (sumOfSomething == -3)
            {
                PrintBoard();
                Console.WriteLine("player 2 won!");
                return true;
            }

            return false;
        }

        //CR - this and SumColumn same function, why not creating 1 function with 1 variable - row or column?
        private int SumRow(int row)// returns the row's sum
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[i, row];
            }
            return sum;
        }
        private int SumColumn(int column)// returns the column's sum
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(1); i++)
            {
                sum += board[column, i];
            }
            return sum;
        }

        private int FirstSlantSum()
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[i, i];
            }
            return sum;
        }
        private int SecondSlantSum()
        {
            int sum = 0;
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sum += board[board.GetLength(0) - 1 - i, i];
            }
            return sum;
        }
    }
}
