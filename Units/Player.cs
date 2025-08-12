using MazeAStar.Input;
using MazeAStar.Rendering;

namespace MazeAStar.Units
{
    internal class Player : Unit
    {
        public Player(int startX, int startY, ConsoleRenderer renderer, IMoveInput input) : base(startX, startY, '@', renderer)
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
