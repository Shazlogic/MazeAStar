namespace MazeAStar
{
    internal class Player : Unit
    {
        private char[,] _map;

        public Player(int startX, int startY, ConsoleRenderer renderer, char[,] map) : base(startX, startY, '@', renderer)
        {
            _map = map;
        }

        public override void Update()
        {
            ConsoleKeyInfo keyInfo;
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        TryMoveUp(_map);
                        break;
                    case ConsoleKey.DownArrow:
                        TryMoveDown(_map);
                        break;
                    case ConsoleKey.LeftArrow:
                        TryMoveLeft(_map);
                        break;
                    case ConsoleKey.RightArrow:
                        TryMoveRight(_map);
                        break;
                }
            }
        }
    }
}
