namespace CustomStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class MyList<T> : IEnumerable<T>
    {
        private int capacity;
        private T[] data;

        public MyList() : this(4)
        {
        }

        public MyList(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
        }

        public int Count { get; private set; }

        public void Add(T element)
        {
            this.NeedResize();
            this.data[Count] = element;
            this.Count++;
        }

        private void NeedResize()
        {
            if (this.Count == this.data.Length)
            {
                this.Resize();
            }
        }

        private void Resize()
        {
            int newCapacity = this.data.Length * 2;
            T[] newData = new T[newCapacity];
            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;
        }

        public T RemoveAt(int index)
        {
            this.ValidateIndex(index);
            T result = this.data[index];
            for (int i = 0; i < this.Count - 1; i++)
            {
                if (i >= index)
                {
                    this.data[i] = this.data[i + 1];
                }
            }
            
            this.Count--;
            return result;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            T temp = this.data[firstIndex];
            this.data[firstIndex] = this.data[secondIndex];
            this.data[secondIndex] = temp;
        }
        public void Clear()
        {
            this.Count = 0;
            this.data = new T[capacity];
        }

        public T this[int index] //indeksator da vzeme list[3] = 2
        {
            get 
            {
                this.ValidateIndex(index);
                return this.data[index];
            }
            set 
            {
                this.ValidateIndex(index);
                this.data[index] = value;
            }
        }
        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                var massage = this.Count == 0
                    ? "The list is empty"
                    : $"The list has {this.Count} elements";

                throw new Exception($"Index out of exception. {massage}");
            }
        }

        public void Insert(int index, T element)
        {
            this.ValidateIndex(index);
            this.NeedResize();

            for (int i = this.Count ; i >= 0 ; i--)
            {
                if (i < index)
                {
                    this.data[i] = this.data[i];
                }
                else if (i == index)
                {
                    this.data[i] = element;
                    this.Count++;
                }
                else
                {
                    this.data[i] = this.data[i - 1];
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
