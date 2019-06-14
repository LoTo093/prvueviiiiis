using UnityEngine;
using System.Collections;

namespace Tuple
{

    public class Tuple<T>
    {
        T first;
        public T Item1
        {
            get { return first; }
            set { first = value; }
        }
    }

    public class Tuple<T, U> : Tuple<T>
    {
        U second
        {
            get { return second; }
            set { second = value; }
        }
        public U Item2;
    }

    public class Tuple<T, U, V> : Tuple<T, U>
    {
        V third;
        public V Item3
        {
            get { return third; }
            set { third = value; }
        }
    }

    public class Tuple<T, U, V, W> : Tuple<T, U, V>
    {
        W fourth;
        public W Item4
        {
            get { return fourth; }
            set { fourth = value; }
        }
    }

    //...

}
