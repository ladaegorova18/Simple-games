using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    public class GameLogic
    {
        public int[,] Terraria { get; set; }
        public int Size { get; set; } = 20;

        public int Limit { get; set; } = 100;

        public GameLogic()
        {
            Terraria = new int[Size, Size];
            var counter = 0;
            var rnd = new Random();
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    var isBacteria = rnd.Next(0, 4);
                    if (isBacteria == 1 && counter < Limit)
                    {
                        BornBacteria(i, j);
                        ++counter;
                        if (counter >= Limit)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public void Step()
        {
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j))
                    {
                        if (CheckNeighboursForLivingBacteria(i, j))
                        {
                            KillBacteria(i, j);
                        }
                    }
                    else if (CheckNeighboursForEmptyCell(i, j))
                    {
                        BornBacteria(i, j); //может, не нужно столько функций
                    }
                }
            }
        }

        private bool CheckNeighboursForLivingBacteria(int i, int j) => CheckNeighBours(i, j) < 3 || CheckNeighBours(i, j) > 4;

        private bool CheckNeighboursForEmptyCell(int i, int j) => CheckNeighBours(i, j) > 2;

        private int CheckNeighBours(int i, int j)
        {
            var counter = 0;
            for (var k = -1; k < 2; ++k)
            {
                if (i - 1 > 0 && j + k > 0 && j + k < Size && (ExistsBacteria(i - 1, j + k)))
                {
                    ++counter;
                }

                if (j + k > 0 && j + k < Size && i + 1 < Size && ExistsBacteria(i + 1, j + k))
                {
                    ++counter;
                }
            }
            if (j - 1 > 0 && ExistsBacteria(i, j - 1))
            {
                ++counter;
            }
            if (j + 1 < Size && ExistsBacteria(i, j + 1))
            {
                ++counter; // это явно может быть лучше
            }
            return counter;
        }

        public bool ExistsBacteria(int i, int j) => Terraria[i, j] == 1;

        private void KillBacteria(int i, int j) => Terraria[i, j] = 0;

        private void BornBacteria(int i, int j) => Terraria[i, j] = 1;
    }
}
