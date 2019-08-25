using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TICTacToe
{
    // YM: you need to add some test.. at least for the gameIsEnd and for checking the input
    class TICTacToe
    {
        public const int Size = 3; // YM: const is ALL CAPITAL LETTER
        private int[,] board;
        public TICTacToe()//opens new board //YM: you dont need that message...
        {
            board = new int[Size, Size];
            InitialiseBoard();
        }
        public void StartGame()
        {
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
        // YM: you dont need to initialize. 
        // read this: https://stackoverflow.com/questions/22218066/how-to-assign-0-to-whole-array
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
        
        // YM: https://www.google.com/search?q=DRY+prenciple&oq=DRY+prenciple&aqs=chrome..69i57j0l5.5944j1j7&sourceid=chrome&ie=UTF-8
        // you are writing A LOT of duplicate code!
        private bool Win()// checks if someone won. if so, prints the winning player
        {
            int sumOfSomething = 0; //YM: very bad name
            for (int i = 0; i < board.GetLength(0); i++)
            {
                sumOfSomething = SumColumn(i);
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
