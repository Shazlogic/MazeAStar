using MazeAStar.Config;
using MazeAStar.Core;
using MazeAStar.Input;
using MazeAStar.Rendering;
using MazeAStar.Units;
using System.Threading.Tasks;

namespace MazeAStar
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = GameConfig.Load();

            var renderer = new ConsoleRenderer();
            var input = new ConsoleInput();

            InitializeMap(GameData.GetInstance().GetMap(), renderer);

            var player = new Player(config.Player.X, config.Player.Y, renderer, input);
            var obstacle = new VerticalObstacle(config.Obstacle.X, config.Obstacle.Y, config.Obstacle.Symbol, renderer);
            var enemy = new SmartEnemy(config.Enemy.X, config.Enemy.Y, config.Enemy.Symbol, renderer, player);
            var units = new List<Unit> { player, obstacle, enemy };

            renderer.Render();

            while (true)
            {
                input.Update();
                UpdateUnits(units);
                renderer.Render();

                if (CheckCollisions(player, units))
                {
                    GameOver();
                }

                await Task.Delay(config.GameTickDelayMs);
            }
        }

        private static void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Environment.Exit(0);
        }

        private static void InitializeMap(char[,] map, ConsoleRenderer renderer)
        {
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    renderer.SetPixel(y, x, map[y, x]);
                }
            }
        }

        private static void UpdateUnits(IEnumerable<Unit> units)
        {
            foreach (var unit in units)
            {
                unit.Update();
            }
        }

        private static bool CheckCollisions(Player player, IEnumerable<Unit> units)
        {
            foreach (var unit in units)
            {
                if (unit != player && player.X == unit.X && player.Y == unit.Y)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
