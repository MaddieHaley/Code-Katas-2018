using System.Collections;
using System.Collections.Generic;

namespace Day_1
{
    public class SortedMap<T1, T2> : IEnumerable<KeyValuePair<T1, T2>>
    {
        private readonly SortedDictionary<T1, T2> _forward = new SortedDictionary<T1, T2>();
        private readonly SortedDictionary<T2, T1> _reverse = new SortedDictionary<T2, T1>();

        public SortedMap()
        {
            Forward = _forward;
            Reverse = _reverse;
        }

        public SortedDictionary<T1, T2> Forward { get; }
        public SortedDictionary<T2, T1> Reverse { get; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            return _forward.GetEnumerator();
        }

        public void Add(T1 t1, T2 t2)
        {
            _forward.Add(t1, t2);
            _reverse.Add(t2, t1);
        }

        public int Count()
        {
            return _forward.Count;
        }

        
    }
}