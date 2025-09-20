using MazeAStar.Config;

namespace MazeAStar.Core
{
    public class Node
    {
        public Vector2 Position;
        public int Cost = 10;
        public int Estimate;
        public int Value;
        public Node? Parent;

        public Node(Vector2 position)
        {
            Position = position;
        }

        public void CalculateEstimate(Vector2 targetPosition)
        {
            Estimate = Math.Abs(Position.X - targetPosition.X) + Math.Abs(Position.Y - targetPosition.Y);
        }

        public void CalculateValue()
        {
            Value = Cost + Estimate;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Node node) return false;
            return Position.Equals(node.Position);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Position.X, Position.Y);
        }
    }
}
