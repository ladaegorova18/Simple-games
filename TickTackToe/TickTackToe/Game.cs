namespace TickTackToe
{
    public class Game
    {
        private char[,] field = new char[3, 3];
        private const char tick = 'x';
        private const char tack = 'o';
        private char current;
        public bool End { get; private set; } = false;

        public Game(string mode)
        {
            if (mode == "single")
            {

            }

        }

        public void Move(int x, int y)
        {
            field[x, y] = current;
            if (CheckWin(current))
            {
                End = true;
            }
            current = Change();
        }

        private char Change()
        {
            if (current == tick)
            {
                return tack;
            }
            return tick;
        }  // смена по-умному

        public void Start()
        {

        } // выбрать, кто ходит первым

        private bool CheckWin(char player)
        {
            var win = true;
            for (var i = 0; i < 3; ++i)
            {
                for (var j = 1; j < 3; ++j)
                {
                    if (field[i, j] == player)
                    {
                        continue;
                    }
                    else
                    {
                        win = false;
                    }
                }
                if (win)
                {
                    return win;
                }
                win = true;
            }
            return false;
        } //aaaaaaaaaaaaaa

        public bool Free(int x, int y) => field[x, y] != ' ';
    }
}
