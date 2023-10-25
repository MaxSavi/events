using System;
using System.Threading;

namespace events1
{
    public class Timer
    {
        public event EventHandler Tick;

        public void Start()
        {
            while (true)
            {
                Thread.Sleep(1000); // = 1сек
                Tick?.Invoke(this, EventArgs.Empty); // Вызвать событие Tick
            }
        }
    }

    public class Clock
    {
        public Clock(Timer timer)
        {
            timer.Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            Console.WriteLine($"Текущее время: {DateTime.Now.ToLongTimeString()}");
        }
    }

    public class Counter
    {
        private int count;

        public Counter(Timer timer)
        {
            timer.Tick += OnTick;
        }

        private void OnTick(object sender, EventArgs e)
        {
            count++;
            if (count % 2 == 0)
            {
                Console.WriteLine($"Так: {count}");
            }
            else
            {
                Console.WriteLine($"Тик: {count}");
            }
            
        }
    }

    class Program
    {
        static void Main()
        {
            Timer timer = new Timer();
            Clock clock = new Clock(timer);
            Counter counter = new Counter(timer);

            timer.Start();
        }
    }
}
