using System.Text.Json;

namespace MazeAStar.Config
{
    public class GameConfig
    {
        public Position Player { get; set; } = new();
        public ObstacleConfig Obstacle { get; set; } = new();
        public EnemyConfig Enemy { get; set; } = new();
        public int GameTickDelayMs { get; set; }

        public static GameConfig Load(string path = "Config/gameconfig.json")
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, path);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"Config file '{fullPath}' not found.");

            string json = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<GameConfig>(json)
                   ?? throw new InvalidOperationException("Failed to parse config file.");
        }
    }

    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }
    }

    public class ObstacleConfig : Position
    {
        public char Symbol { get; set; }
    }

    public class EnemyConfig : Position
    {
        public char Symbol { get; set; }
    }
}
