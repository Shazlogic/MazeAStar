using MazeAStar.Rendering;

namespace MazeAStar.Units
{
    internal class VerticalObstacle : Unit
    {
        private bool _obstacleDownDir = true;

        public VerticalObstacle(Vector2 startPosition, char symbol, ConsoleRenderer renderer) :
            base(startPosition, symbol, renderer)
        {
        }

        public override void Update()
        {
            if (_obstacleDownDir)
            {
                if (!TryMoveDown())
                    _obstacleDownDir = false;
            }
            else
            {
                if (!TryMoveUp())
                    _obstacleDownDir = true;
            }
        }
    }
}
