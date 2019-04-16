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

        /// <summary>
        /// Game constructor creates the array and randomly fills it by alive cells 
        /// </summary>
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

        /// <summary>
        /// Makes a game step - checks game rules for every cell on field and does the action
        /// </summary>
        public void Step()
        {
            var tempTerraria = CopyTerraria();
            tempTerraria = MakeOneStep(tempTerraria);
            Terraria = tempTerraria;
            ++Steps;
        }

        private int[,] MakeOneStep(int[,] tempTerraria)
        {
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j, Terraria))
                    {
                        if (CheckNeighboursForLivingBacteria(i, j))
                        {
                            KillBacteria(i, j, tempTerraria);
                        }
                    }
                    else if (CheckNeighboursForEmptyCell(i, j))
                    {
                        BornBacteria(i, j, tempTerraria);
                    }
                }
            }
            return tempTerraria;
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

        private bool CheckNeighboursForLivingBacteria(int i, int j) => CountNeighbours(i, j) < 2 || CountNeighbours(i, j) > 3;

        private bool CheckNeighboursForEmptyCell(int i, int j) => CountNeighbours(i, j) == 3;

        private int CountNeighbours(int i, int j)
        {
            var counter = 0;
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    if (ExistsBacteria(currentRow, currentColumn, Terraria))
                    {
                        ++counter;
                    }
                }
            }
            return counter;
        }

        private bool OnTheEdge(int i, int j) => i < 0 || j < 0 || i >= Size || j >= Size;

        public bool ExistsBacteria(int i, int j, int[,] terraria)
        {
            if (!OnTheEdge(i, j))
            {
                return terraria[i, j] == 1;
            }
            if (i < 0)
            {
                i = Size + i;
            }
            else if (i >= Size)
            {
                i = 0;
            }
            if (j < 0)
            {
                j = Size + j;
            }
            else if (j >= Size)
            {
                j = 0;
            }
            return terraria[i, j] == 1; // тут можно лучше
        }

        private void KillBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 0;

        private void BornBacteria(int i, int j, int[,] terraria) => terraria[i, j] = 1;

        public int CountCells()
        {
            var count = 0;
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (Terraria[i, j] == 1)
                    {
                        ++count;
                    }
                }
            }
            return count; // что-то здесь private, а что-то public
        }

        public int[,] FindStableCells()
        {
            var stableTerraria = new int[Size, Size];
            var oneStepTerraria = CopyTerraria();
            oneStepTerraria = MakeOneStep(oneStepTerraria);
            var fiveStepTerraria = FourStepsTerraria();
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j, Terraria) && Terraria[i, j] == fiveStepTerraria[i, j] && ExistsBacteria(i, j, oneStepTerraria))
                    {
                        if (IsPattern(i, j, fiveStepTerraria))
                        {
                            stableTerraria[i, j] = 1;
                        }
                    }
                }
            }
            stableTerraria = RemoveLonelyCells(stableTerraria);
            stableTerraria = IsFlasher(stableTerraria);
            return stableTerraria;
        }

        private int[,] RemoveLonelyCells(int [,] stableTerraria)
        {
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j, Terraria) && CountFourStepsTerraria(i, j, stableTerraria) == 0)
                    {
                        stableTerraria[i, j] = 0;
                    }
                }
            }
            return stableTerraria;
        }

        private bool IsPattern(int i, int j, int[,] fiveStepsForvardTerraria) => IsSquare(i, j, fiveStepsForvardTerraria);

        private int[,] IsFlasher(int[,] stableTerraria)
        {
            var fiveTerr = FourStepsTerraria();
            var isFlasher = true;
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (CountNeighbours(i, j) == 2)
                    {
                        for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
                        {
                            for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                            {
                                if (currentRow == i && currentColumn == j)
                                {
                                    continue;
                                }
                                if (ExistsBacteria(currentRow, currentColumn, Terraria) && CountNeighbours(currentRow, currentColumn) != 1)
                                {
                                    isFlasher = false;
                                }
                            }
                        }
                        if (ExistsBacteria(i, j, fiveTerr))
                        {
                            var counter = 0;
                            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
                            {
                                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                                {
                                    if (currentRow == i && currentColumn == j)
                                    {
                                        continue;
                                    }
                                    if (ExistsBacteria(currentRow, currentColumn, Terraria) && CountNeighbours(currentRow, currentColumn) != 1)
                                    {
                                        ++counter;
                                    }
                                }
                            }
                            if (counter != 2)
                            {
                                isFlasher = false;
                            }
                        }
                        else
                        {
                            isFlasher = false;
                        }
                    }
                    if (isFlasher)
                    {
                        stableTerraria[i, j] = 1;
                        for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
                        {
                            for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                            {
                                if (currentRow == i && currentColumn == j)
                                {
                                    continue;
                                }
                                if (ExistsBacteria(currentRow, currentColumn, Terraria) && (!OnTheEdge(currentRow, currentColumn)))
                                {
                                    stableTerraria[currentRow, currentColumn] = 1;
                                }
                            }
                        }
                    }
                }
            }
            return stableTerraria;
        }

        private bool IsSquare(int i, int j, int[,] fiveStepsForvardTerraria)
        {
            var neighbours = CountNeighbours(i, j);
            if (neighbours == 3)
            {
                if (StableNeighbours(i, j, fiveStepsForvardTerraria, neighbours))
                {
                    return true;
                }
            }
            return false;
        }

        private bool StableNeighbours(int i, int j, int[,] fiveStepsForvardTerraria, int neighbours)
        {
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    if (ExistsBacteria(currentRow, currentColumn, Terraria))
                    {
                        if (!ExistsBacteria(currentRow, currentColumn, fiveStepsForvardTerraria))
                        {
                            return false;
                        }
                    }
                }
            }
            if (CountFourStepsTerraria(i, j, fiveStepsForvardTerraria) != neighbours)
            {
                return false;
            }
            return true;
        }

        private int[,] FourStepsTerraria()
        {
            var tempTerraria = CopyTerraria();
            for (var i = 0; i < 4; ++i)
            {
                tempTerraria = MakeOneStep(tempTerraria);
            }
            return tempTerraria;
        }

        private int CountFourStepsTerraria(int i, int j, int[,] terraria)
        {
            var counter = 0;
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    if (ExistsBacteria(currentRow, currentColumn, terraria))
                    {
                        ++counter;
                    }
                }
            }
            return counter;
        }

        private (int, int) FindNeighbour(int i, int j, int[,] terraria)
        {
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    if (ExistsBacteria(currentRow, currentColumn, terraria))
                    {
                        return (currentRow, currentColumn);
                    }
                }
            }
            return (0, 0);
        }
    } 
}
