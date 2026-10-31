using C_sharp_practicum.Common;

using System;

namespace C_sharp_practicum.Tasks.Level2
{
    public class Task19_MyStackAndQueue : ITask
    {
        public string Title => "Свой стек/очередь на массиве";
        public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";
        public string[] Requirements => new[] { "Методы Push/Pop/Peek, Enqueue/Dequeue/Peek", "Обработка пустой коллекции" };

        public void Run()
        {
            var stack = new MyStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Console.WriteLine($"Стек: Pop = {stack.Pop()}, Peek = {stack.Peek()}, Count = {stack.Count}");
            stack.Pop();
            stack.Pop();
            Console.WriteLine($"Стек пуст: {stack.IsEmpty}");

            var queue = new MyQueue<string>();
            queue.Enqueue("A");
            queue.Enqueue("B");
            queue.Enqueue("C");
            Console.WriteLine($"Очередь: Dequeue = {queue.Dequeue()}, Peek = {queue.Peek()}, Count = {queue.Count}");
        }
    }

    public class MyStack<T>
    {
        private T[] _items = new T[4];
        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;

        public void Push(T item)
        {
            if (Count == _items.Length)
                Array.Resize(ref _items, _items.Length * 2);
            _items[Count++] = item;
        }

        public T Pop()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return _items[--Count];
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Стек пуст");
            return _items[Count - 1];
        }
    }

    public class MyQueue<T>
    {
        private T[] _items = new T[4];
        private int _head = 0;
        private int _tail = 0;
        public int Count => _tail - _head;
        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            if (_tail == _items.Length)
            {
                if (_head > 0)
                {
                    Array.Copy(_items, _head, _items, 0, Count);
                    _tail -= _head;
                    _head = 0;
                }
                else
                {
                    Array.Resize(ref _items, _items.Length * 2);
                }
            }
            _items[_tail++] = item;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
            return _items[_head++];
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Очередь пуста");
            return _items[_head];
        }
    }
}