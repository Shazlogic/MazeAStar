using MazeAStar.Core;
using MazeAStar.Input;
using MazeAStar.Rendering;
using System.IO;
using System.Text.Json;

namespace MazeAStar.Config
{
    public class LevelsMenu
    {
        private Dictionary<string, char[,]> _levelMaps;
        private ConsoleInput _input;
        private ConsoleRenderer _renderer;

        public LevelsMenu(ConsoleInput input, ConsoleRenderer renderer)
        {
            _levelMaps = LoadLevelsFromJson("Config/levels.json");
            _input = input;
            _renderer = renderer;
        }

        public void SetMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите уровень:");

            foreach (var levelMap in _levelMaps)
            {
                Console.WriteLine(levelMap.Key);
            }

            string input = Console.ReadLine();
            if (_levelMaps.ContainsKey(input))
            {
                SetLevel(input);
            }
            else
            {
                SetMenu();
            }
        }

        public void SetLevel(string level)
        {
            Console.Clear();
            var map = ReverseMapRows(_levelMaps[level]);
            GameData.SetMap(map);
            InitializeMap(map, _renderer);
        }

        public static void InitializeMap(char[,] map, ConsoleRenderer renderer)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    renderer.SetPixel(y, x, map[y, x]);
                }
            }
        }

        private static Dictionary<string, char[,]> LoadLevelsFromJson(string filePath)
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, filePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Config file '{fullPath}' not found.");

            var json = File.ReadAllText(fullPath);
            var levelsData = JsonSerializer.Deserialize<LevelsData>(json)
                   ?? throw new InvalidOperationException("Failed to parse config file.");

            var levelMaps = new Dictionary<string, char[,]>();

            foreach (var level in levelsData.Levels)
            {
                int rows = level.Value.Length;
                int cols = level.Value[0].Length;
                char[,] map = new char[rows, cols];

                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        map[i, j] = level.Value[i][j];
                    }
                }

                levelMaps[level.Key] = map;
            }

            return levelMaps;
        }

        private static char[,] ReverseMapRows(char[,] map)
        {
            int rows = map.GetLength(0);
            int cols = map.GetLength(1);
            char[,] flipped = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    flipped[rows - 1 - i, j] = map[i, j];
                }
            }
            return flipped;
        }
    }

    public class LevelsData
    {
        public Dictionary<string, string[]> Levels { get; set; }
    }
}
