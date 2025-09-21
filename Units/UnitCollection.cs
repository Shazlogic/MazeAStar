using System.Collections;

namespace MazeAStar.Units
{
    internal class UnitCollection : IEnumerable
    {
        private HashSet<Unit> _units = new();

        public void Add(Unit unit)
        {
            _units.Add(unit);
        }

        public void Remove(Unit unit)
        {
            _units.Remove(unit);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (Unit unit in _units)
            {
                yield return unit;
            }
        }
    }
}
