namespace MazeAStar.Core
{
    public class GameData
    {
        private static GameData _instance;
        private static char[,] _map;

        private GameData() { }

        public static GameData GetInstance()
        {
            if (_instance == null)
                _instance = new GameData();

            return _instance;
        }

        public static void SetMap(char[,] map)
        {
            _map = map;
        }

        public char[,] GetMap()
        {
            if (_map == null)
            {
                Console.WriteLine("Карта не установлена");
                return null;
            }

            return _map;
        }
    }
}
