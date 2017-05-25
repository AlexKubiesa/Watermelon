using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Watermelon.Utility
{
    class Bidictionary<T1, T2>
    {
        public Dictionary<T1, T2>.KeyCollection Keys
        {
            get { return _fdict.Keys; }
        }

        public Dictionary<T2, T1>.KeyCollection ReverseKeys
        {
            get { return _bdict.Keys; }
        }

        private Dictionary<T1, T2> _fdict;

        private Dictionary<T2, T1> _bdict;

        public Bidictionary()
        {
            _fdict = new Dictionary<T1, T2>();
            _bdict = new Dictionary<T2, T1>();
        }

        public void Add(T1 item1, T2 item2)
        {
            _fdict.Add(item1, item2);
            _bdict.Add(item2, item1);
        }

        public T2 Forward(T1 item1)
        {
            return _fdict[item1];
        }

        public T1 Reverse(T2 item2)
        {
            return _bdict[item2];
        }

        public void Remove(T1 item1)
        {
            var item2 = _fdict[item1];
            _fdict.Remove(item1);
            _bdict.Remove(item2);
        }

        public void RemoveReverse(T2 item2)
        {
            var item1 = _bdict[item2];
            _fdict.Remove(item1);
            _bdict.Remove(item2);
        }
    }
}
