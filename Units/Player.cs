using MazeAStar.Input;
using MazeAStar.Rendering;

namespace MazeAStar.Units
{
    internal class Player : Unit
    {
        public Player(Vector2 startPosition, ConsoleRenderer renderer, IMoveInput input) : base(startPosition, '@', renderer)
        {
            input.MoveUp += () => TryMoveUp();
            input.MoveDown += () => TryMoveDown();
            input.MoveLeft += () => TryMoveLeft();
            input.MoveRight += () => TryMoveRight();
        }

        public override void Update()
        {
        }
    }
}
