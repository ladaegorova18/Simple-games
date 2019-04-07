using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class Game
    {
        public int[,] Terraria { get; set; }
        private int[,] oldTerraria;
        public int Size { get; set; } = 50;

        public int Limit { get; set; } = 1300;

        public int Steps { get; set; } = 0;

        public Game()
        {
            Terraria = new int[Size, Size];
            var rnd = new Random();
            for (var counter = 0; counter < Limit; ++counter)
            {
                var isBacteria = rnd.Next(0, 2);
                if (isBacteria == 1)
                {
                    var i = rnd.Next(0, Size);
                    var j = rnd.Next(0, Size);
                    BornBacteria(i, j, Terraria);
                }
            }
        }

        public void Step()
        {
            var tempTerraria = CopyTerraria();
            oldTerraria = CopyTerraria(); // возможно, вместо двух хватит одной
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j))
                    {
                        if (CheckNeighboursForLivingBacteria(i, j))
                        {
                            KillBacteria(i, j, tempTerraria);
                        }
                    }
                    else if (CheckNeighboursForEmptyCell(i, j))
                    {
                        BornBacteria(i, j, tempTerraria); //может, не нужно столько функций
                    }
                }
            }
            Terraria = tempTerraria;
            ++Steps;
        }

        private int[,] CopyTerraria()
        {
            var tempTerraria = new int[Size, Size];
            for (int i = 0; i < Size; ++i)
            {
                for (int j = 0; j < Size; ++j)
                {
                    tempTerraria[i, j] = Terraria[i, j];
                }
            }
            return tempTerraria;
        }

        private bool CheckNeighboursForLivingBacteria(int i, int j) => CheckNeighBours(i, j) < 2 || CheckNeighBours(i, j) > 3;

        private bool CheckNeighboursForEmptyCell(int i, int j) => CheckNeighBours(i, j) == 3;

        private int CheckNeighBours(int i, int j)
        {
            var counter = 0;
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j) // переименовать i, j, k, m
                    {
                        continue;
                    }
                    if (ExistsBacteria(currentRow, currentColumn))
                    {
                        ++counter;
                    }
                }
            }
            return counter;
        }

        private bool OnTheEdge(int i, int j) => i < 0 || j < 0 || i == Size || j == Size;

        public bool ExistsBacteria(int i, int j)
        {
            if (!OnTheEdge(i, j))
            {
                return Terraria[i, j] == 1;
            }
            if (i < 0)
            {
                i = Size + i;
            }
            else if (i == Size)
            {
                i = 0;
            }
            if (j < 0)
            {
                j = Size + j;
            }
            else if (j == Size)
            {
                j = 0;
            }
            return Terraria[i, j] == 1; // тут можно лучше
        }

        private void KillBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 0;

        private void BornBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 1;

        public int[,] FindStableCells()
        {
            var stableCells = new int[Size, Size];
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (oldTerraria[i, j] == Terraria[i, j])
                    {
                        stableCells[i, j] = Terraria[i, j];
                    }
                    else
                    {
                        stableCells[i, j] = -1;
                    }
                }
            }
            return stableCells;
        }
    } // что-то здесь private, а что-то public
}
