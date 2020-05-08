namespace CustomStructures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class MyStack<T> : IEnumerable<T>
    {
        private int capacity;
        private T[] data;
        public MyStack() : this(4)
        {
        }
        public MyStack(int capacity)
        {
            this.capacity = capacity;
            this.data = new T[capacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        public void Push(T element)
        {
            if (this.Count == this.data.Length)
            {
                Resize();
            }
            this.data[this.Count] = element;
            this.Count++;
        }

        public T Pop()
        {
            this.isValid();
            T number = this.data[Count - 1];
            this.Count--;
            return number;
        }

        private void isValid()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty.");
            }
        }

        public T Peek()
        {
            this.isValid();
            return this.data[Count - 1];
        }

        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.data[i]);
            }
        }

        public void Clear()
        {
            this.data = new T[this.capacity];
            this.Count = 0;
        }

        private void Resize()
        {
            T[] newData = new T[this.data.Length * 2];
            for (int i = 0; i < this.data.Length; i++)
            {
                newData[i] = this.data[i];
            }
            this.data = newData;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
