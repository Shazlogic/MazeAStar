using MazeAStar.Config;
using MazeAStar.Input;
using MazeAStar.Rendering;
using MazeAStar.Units;

namespace MazeAStar
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var config = GameConfig.Load();

            ConsoleRenderer renderer = new ConsoleRenderer();
            ConsoleInput input = new ConsoleInput();
            LevelsMenu levelsMenu = new LevelsMenu(input, renderer);
            levelsMenu.SetMenu();

            Player player = new Player(new Vector2(config.Player.X, config.Player.Y), renderer, input);
            VerticalObstacle obstacle = new VerticalObstacle(new Vector2(config.Obstacle.X, config.Obstacle.Y), config.Obstacle.Symbol, renderer);
            SmartEnemy enemy = new SmartEnemy(new Vector2(config.Enemy.X, config.Enemy.Y), config.Enemy.Symbol, renderer, player);
            List<Unit> units = new List<Unit> { player, obstacle, enemy };
            input.Esc += GameOver;

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
                if (unit == player) continue;

                if (player.Position.Equals(unit.Position))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
