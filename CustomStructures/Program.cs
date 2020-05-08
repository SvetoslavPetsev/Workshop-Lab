namespace CustomStructures
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            //list example

            MyList<int> list = new MyList<int>();
            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            Console.WriteLine(list[0]);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine(list.RemoveAt(0));
            list.RemoveAt(5);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            Console.WriteLine(list.Contains(3));
            Console.WriteLine(list.Contains(322));

            list.Swap(2, 3);

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            list.Insert(1, 10000);

            Console.WriteLine(list[1]);

            Console.WriteLine(string.Join(", ", list));

            Console.WriteLine();
            
            //stack example

            MyStack<int> stack = new MyStack<int>();

            for (int i = 0; i < 9; i++)
            {
                stack.Push(i);
            }

            Console.WriteLine(stack.Peek());
            stack.Pop();
            Console.WriteLine(stack.Peek());

            Console.WriteLine();
            stack.ForEach(x => Console.WriteLine(x * 200));

            Console.WriteLine(string.Join(", ", stack));

            MyList<string> newList = new MyList<string> { "Ivan", "Pesho", "Zoro" };
        }
    }
}
