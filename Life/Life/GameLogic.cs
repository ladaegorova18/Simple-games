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
        public int Size { get; set; } = 50;

        public int Limit { get; set; } = 1300;

        public GameLogic()
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
            if (j + 1 < Size && ExistsBacteria(i, j + 1)) //ввести бы бесконечное поле
            {
                ++counter; // это явно может быть лучше
            }
            return counter;
        }

        public bool ExistsBacteria(int i, int j) => Terraria[i, j] == 1;

        private void KillBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 0;

        private void BornBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 1;
    }
}
