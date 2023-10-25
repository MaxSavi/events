//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.Generic;

//namespace events3
//{
//    public class Button
//    {
//        private string text;

//        public string Text
//        {
//            get { return text; }
//            set
//            {
//                if (text != value)
//                {
//                    text = value;
//                    OnClick(EventArgs.Empty);
//                }
//            }
//        }

//        private List<EventHandler> clickHandlers = new List<EventHandler>();

//        public event EventHandler Click
//        {
//            add
//            {
//                if (clickHandlers.Count < 3 && !clickHandlers.Contains(value))
//                {
//                    clickHandlers.Add(value);
//                }
//            }
//            remove
//            {
//                clickHandlers.Remove(value);
//            }
//        }

//        public void AddClickHandler(EventHandler handler)
//        {
//            Click += handler;
//        }

//        public void RemoveClickHandler(EventHandler handler)
//        {
//            Click -= handler;
//        }

//        protected virtual void OnClick(EventArgs e)
//        {
//            foreach (var handler in clickHandlers)
//            {
//                handler(this, e);
//            }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            Button button = new Button();

//            EventHandler handler1 = (sender, e) => Console.WriteLine("Handler 1: Button clicked.");
//            EventHandler handler2 = (sender, e) => Console.WriteLine("Handler 2: Button clicked.");
//            EventHandler handler3 = (sender, e) => Console.WriteLine("Handler 3: Button clicked.");
//            EventHandler handler4 = (sender, e) => Console.WriteLine("Handler 4: Button clicked");

//            button.AddClickHandler(handler1);
//            button.AddClickHandler(handler2);
//            button.AddClickHandler(handler3);
//            button.AddClickHandler(handler4); // This handler won't be added.

//            button.Text = "Click me";

//            button.RemoveClickHandler(handler1);

//            button.Text = "Click me again";

//            Console.ReadKey(); // Для ожидания нажатия клавиши перед завершением приложения
//        }
//    }
//}
