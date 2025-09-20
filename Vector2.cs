namespace MazeAStar
{
    public struct Vector2
    {
        public int X;
        public int Y;

        public Vector2(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Vector2 position) return false;
            return X == position.X && Y == position.Y;
        }
    }
}
