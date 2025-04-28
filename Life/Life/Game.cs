using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Life
{
    /// <summary>
    /// Game class: main logic of Life game
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Terraria: two-dimensional array of "bacteria"
        /// </summary>
        public int[,] Terraria { get; set; }

        /// <summary>
        /// Size of terraria
        /// </summary>
        public int Size { get; private set; } = 50;

        /// <summary>
        /// Maximal count of bacteria
        /// </summary>
        public int Limit { get; set; } = 400;

        /// <summary>
        /// Count of game steps
        /// </summary>
        public int Steps { get; private set; } = 0;

        /// <summary>
        /// Game constructor creates the array and randomly fills it by alive cells 
        /// </summary>
        public Game()
        {
            Terraria = new int[Size, Size];
            var rnd = new Random();
            for (var counter = 0; counter < Limit; ++counter)
            {
                var i = rnd.Next(0, Size);
                var j = rnd.Next(0, Size);
                while (Terraria[i, j] == 1)
                {
                    i = rnd.Next(0, Size);
                    j = rnd.Next(0, Size);
                }
                BornBacteria(i, j, Terraria);
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

        private (int, int) OnTheEdge(int i, int j)
        {
            if (i < 0)
            {
                i += Size;
            }
            else if (i >= Size)
            {
                i = 0;
            }
            if (j < 0)
            {
                j += Size;
            }
            else if (j >= Size)
            {
                j = 0;
            }
            return (i, j);
        }


        public bool ExistsBacteria(int i, int j, int[,] terraria)
        {
            (i, j) = OnTheEdge(i, j);
            return terraria[i, j] == 1;
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
                    if (ExistsBacteria(i, j, Terraria))
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

        /// <summary>
        /// Tryes to find patterns in terraria
        /// </summary>
        /// <returns> Terraria with patterns </returns>
        public int[,] FindStableCells()
        {
            var stableTerraria = new int[Size, Size];
            var fourStepTerraria = FourStepsTerraria();
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j, Terraria) && Terraria[i, j] == fourStepTerraria[i, j])
                    {
                        if (CountNeighbours(i, j) == 2 && NeighboursInFourStepsTerraria(i, j, fourStepTerraria) == 2 && !StableNeighbours(i, j, fourStepTerraria))
                        {
                            stableTerraria = FindFlashers(stableTerraria, i, j);
                        }
                        else if (StableNeighbours(i, j, fourStepTerraria))
                        {
                            stableTerraria[i, j] = 1;
                        }
                    }
                }
            }
            //stableTerraria = RemoveLonelyCells(stableTerraria);
            return stableTerraria;
        }

        private int[,] FindFlashers(int[,] stableTerraria, int i, int j)
        {
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    var (currentR, currentC) = OnTheEdge(currentRow, currentColumn);
                    if (CountNeighbours(currentR, currentC) == 1 && ExistsBacteria(currentR, currentC, Terraria))
                    {
                        stableTerraria[currentR, currentC] = 1;
                        stableTerraria[i, j] = 1;
                    }
                }
            }
            return stableTerraria;
        }

        private bool Flasher(int[,] stableTerraria, int i, int j)
        {
            var fourStep = FourStepsTerraria();
            if (CountNeighbours(i, j) == 2 && NeighboursInFourStepsTerraria(i, j, fourStep) == 2 && !StableNeighbours(i, j, fourStep))
            {
                for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
                {
                    for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                    {
                        if (currentRow == i && currentColumn == j)
                        {
                            continue;
                        }
                        var (currentR, currentC) = OnTheEdge(currentRow, currentColumn);
                        if (CountNeighbours(currentR, currentC) == 1 && ExistsBacteria(currentR, currentC, Terraria))
                        {
                            return true;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        private bool StableNeighbours(int i, int j, int[,] terraria)
        {
            if (CountNeighbours(i, j) == 0)
            {
                return false;
            }
            for (var currentRow = i - 1; currentRow <= i + 1; ++currentRow)
            {
                for (var currentColumn = j - 1; currentColumn <= j + 1; ++currentColumn)
                {
                    if (currentRow == i && currentColumn == j)
                    {
                        continue;
                    }
                    var (currentR, currentC) = OnTheEdge(currentRow, currentColumn);
                    if (Terraria[currentR, currentC] != terraria[currentR, currentC])
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private int[,] RemoveLonelyCells(int[,] terraria)
        {
            var fourSteps = FourStepsTerraria();
            for (var i = 0; i < Size; ++i)
            {
                for (var j = 0; j < Size; ++j)
                {
                    if (ExistsBacteria(i, j, terraria) && !Flasher(terraria, i, j) && CountNeighbours(i, j) <= 1)
                    {
                        terraria[i, j] = 0;
                    }
                }
            }
            return terraria;
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

        private int NeighboursInFourStepsTerraria(int i, int j, int[,] terraria)
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
                    var (correctRow, correctColumn) = OnTheEdge(currentRow, currentColumn);
                    if (ExistsBacteria(correctRow, correctColumn, terraria))
                    {
                        ++counter;
                    }
                }
            }
            return counter;
        }
    } 
}
