using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ListImplementation
{

    public class _List<T>
    {
        private const int _defaultCapacity = 4;

        private T[] _items;
        private int _size;
        private int _version;

        static readonly T[] _emptyArray = new T[0];

        public _List()
        {
            _items = _emptyArray;
        }

        public _List(int capacity)
        {
            if (capacity < 0) throw new ArgumentOutOfRangeException();

            if (capacity == 0)
                _items = _emptyArray;
            else
                _items = new T[capacity];
        }

        public int Capacity
        {
            get
            {
                return _items.Length;
            }
            set
            {
                if (value < _size)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        T[] newItems = new T[value];
                        if (_size > 0)
                        {
                            Array.Copy(_items, 0, newItems, 0, _size);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = _emptyArray;
                    }
                }
            }
        }

        public int Count
        {
            get
            {
                return _size;
            }
        }

        public T this[int index]
        {
            get
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return _items[index];
            }

            set
            {
                if ((uint)index >= (uint)_size)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _items[index] = value;
                _version++;
            }
        }

        public void Add(T item)
        {
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            _items[_size++] = item;
            _version++;
        }

        public void Clear()
        {
            if (_size > 0)
            {
                Array.Clear(_items, 0, _size); // Don't need to doc this but we clear the elements so that the gc can reclaim the references.
                _size = 0;
            }
            _version++;
        }

        public bool Contains(T item)
        {
            if ((Object)item == null)
            {
                for (int i = 0; i < _size; i++)
                    if ((Object)_items[i] == null)
                        return true;
                return false;
            }
            else
            {
                EqualityComparer<T> c = EqualityComparer<T>.Default;
                for (int i = 0; i < _size; i++)
                {
                    if (c.Equals(_items[i], item)) return true;
                }
                return false;
            }
        }

        public void CopyTo(int[] array)
        {
            CopyTo(array, 0);
        }

        public void CopyTo(int index, int[] array, int arrayIndex, int count)
        {
            if (_size - index < count)
            {
                throw new ArgumentException();
            }

            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, index, array, arrayIndex, count);
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            // Delegate rest of error checking to Array.Copy.
            Array.Copy(_items, 0, array, arrayIndex, _size);
        }

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                int newCapacity = _items.Length == 0 ? _defaultCapacity : _items.Length * 2;
                // Allow the list to grow to maximum possible capacity (~2G elements) before encountering overflow.
                // Note that this check works even when _items.Length overflowed thanks to the (uint) cast
                if ((uint)newCapacity > 0X7FEFFFFF) newCapacity = 0x7FFFFFC7;
                if (newCapacity < min) newCapacity = min;
                Capacity = newCapacity;
            }
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(_items, item, 0, _size);
        }

        public int IndexOf(T item, int index)
        {
            if (index > _size)
                throw new ArgumentOutOfRangeException();
            return Array.IndexOf(_items, item, index, _size - index);
        }

        public int IndexOf(T item, int index, int count)
        {
            if (index > _size)
                throw new ArgumentOutOfRangeException();

            if (count < 0 || index > _size - count) throw new ArgumentOutOfRangeException();

            return Array.IndexOf(_items, item, index, count);
        }

        public void Insert(int index, T item)
        {
            // Note that insertions at the end are legal.
            if ((uint)index > (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_size == _items.Length) EnsureCapacity(_size + 1);
            if (index < _size)
            {
                Array.Copy(_items, index, _items, index + 1, _size - index);
            }
            _items[index] = item;
            _size++;
            _version++;
        }

        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                RemoveAt(index);
                return true;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new ArgumentOutOfRangeException();
            }
            _size--;
            if (index < _size)
            {
                Array.Copy(_items, index + 1, _items, index, _size - index);
            }
            _items[_size] = default(T);
            _version++;
        }

        public void RemoveRange(int index, int count)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (_size - index < count)
                throw new ArgumentException();

            if (count > 0)
            {
                int i = _size;
                _size -= count;
                if (index < _size)
                {
                    Array.Copy(_items, index + count, _items, index, _size - index);
                }
                Array.Clear(_items, _size, count);
                _version++;
            }
        }

        public class _ListEnumerator<T>
        {
            private T[] _items;
            private int _size;
            private int _count = 0;

            public _ListEnumerator(T[] items, int size)
            {
                _items = items;
                _size = size;
            }

            public object Current
            {
                get
                {
                    return _items[_count++];
                }
            }

            public bool MoveNext()
            {
                return _count < _size;
            }
        }

        public _ListEnumerator<T> GetEnumerator()
        {
            return new _ListEnumerator<T>(_items, _size);
        }
    }

    class Program
    {
        static void Main()
        {
            _List<int> myList = new _List<int>();
            myList.Add(11);
            myList.Add(22);
            myList.Add(33);
            myList.Add(44);
            myList.Add(55);
            myList.Add(66);
            myList.Add(77);
            myList.Add(88);
            myList.Add(99);

            foreach (int item in myList)
            {
                Console.Write($"{item} ");
            }

            Console.WriteLine("Our list");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int number = 222;
            if (!myList.Contains(number))
            {
                myList.Add(number);
            }
            Console.WriteLine($"The added value is {number}");
            Console.WriteLine("\n" + new string('-', 20));

            myList[9] = 111;


            int[] array = new int[12];
            myList.CopyTo(3, array, 0, 7);
            Console.WriteLine($"Array elements is: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            number = myList.IndexOf(22);
            Console.WriteLine($"The index of the first occurrence of a given value is {number}");

            number = myList.IndexOf(33, 1);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index is {number}");

            number = myList.IndexOf(111, 1, 8);
            Console.WriteLine($"The index of the first occurrence of a given value starting at the given index and up to count the number of given elements is {number}");

            myList.Remove(11);
            Console.WriteLine("After Remove");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.Insert(0, 11);
            Console.WriteLine("After Insert");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            int removingElement = myList[3];
            myList.RemoveAt(3);
            Console.WriteLine($"We are removed the element {removingElement}");
            Console.WriteLine("After RemoveAt");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.RemoveRange(0, 2);
            Console.WriteLine("After RemoveRange");
            for (int i = 0; i < myList.Count; i++)
            {
                Console.Write($"{myList[i]} ");
            }
            Console.WriteLine("\n" + new string('-', 20));

            myList.Clear();
            Console.WriteLine($"After Clear we have {myList.Count} elements");

            Console.ReadKey();
        }
    }
}
