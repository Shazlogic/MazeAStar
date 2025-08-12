using MazeAStar.Core;
using MazeAStar.Rendering;

namespace MazeAStar.Units
{
    public abstract class Unit
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        private char _symbol;
        private ConsoleRenderer _renderer;

        public Unit(int startX, int startY, char symbol, ConsoleRenderer renderer)
        {
            X = startX;
            Y = startY;
            _symbol = symbol;
            _renderer = renderer;

            _renderer.SetPixel(X, Y, _symbol);
        }

        public virtual bool TryMoveLeft()
        {
            return TryChangePosition(X - 1, Y);
        }

        public virtual bool TryMoveRight()
        {
            return TryChangePosition(X + 1, Y);
        }

        public virtual bool TryMoveUp()
        {
            return TryChangePosition(X, Y - 1);
        }

        public virtual bool TryMoveDown()
        {
            return TryChangePosition(X, Y + 1);
        }

        protected virtual bool TryChangePosition(int newX, int newY)
        {
            if (GameData.GetInstance().GetMap()[newX, newY] == '#')
                return false;

            _renderer.SetPixel(X, Y, ' ');
            X = newX;
            Y = newY;
            _renderer.SetPixel(X, Y, _symbol);

            return true;
        }

        public abstract void Update();
    }
}
