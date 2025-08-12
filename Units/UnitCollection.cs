using System.Collections;

namespace MazeAStar.Units
{
    internal class UnitCollection : IEnumerable
    {
        private List<Unit> _units = new();

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
            for (int i = 0; i < _units.Count; i++)
            {
                yield return _units[i];
            }
        }
    }
}
