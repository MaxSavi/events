using System;
using System.Collections.Generic;

public class Button
{
    private string text;

    public string Text
    {
        get { return text; }
        set
        {
            if (text != value)
            {
                text = value;
                OnClick(EventArgs.Empty);
            }
        }
    }

    private List<EventHandler> clickHandlers = new List<EventHandler>();

    public event EventHandler Click
    {
        add
        {
            if (clickHandlers.Count < 3 && !clickHandlers.Contains(value))
            {
                clickHandlers.Add(value);
            }
        }
        remove
        {
            clickHandlers.Remove(value);
        }
    }

    protected virtual void OnClick(EventArgs e)
    {
        foreach (var handler in clickHandlers)
        {
            handler(this, e);
        }
    }

    public void AddClick(EventHandler handler)
    {
        Click += handler;
    }

    public void RemoveClick(EventHandler handler)
    {
        Click -= handler;
    }

    public void DisplayText()
    {
        Console.WriteLine($"Текст кнопки: {Text}");
    }

    public void ChangeTextColor(string color)
    {
        switch (color)
        {
            case "r":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Цвет текста кнопки изменен на красный: {Text}");
                Console.ResetColor();
                break;
            case "y":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Цвет текста кнопки изменен на желтый: {Text}");
                Console.ResetColor();
                break;
            case "b":
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Цвет текста кнопки изменен на синий: {Text}");
                Console.ResetColor();
                break;
            default:
                Console.WriteLine("Цвет кнопки не изменен");
                break;
        }

        
    }
}

class Program
{
    static void Main()
    {
        Button button = new Button();

        EventHandler handler1 = (sender, e) => Console.WriteLine("Подписка 1: Кнопка нажата.");
        EventHandler handler2 = (sender, e) => Console.WriteLine("Подписка 2: Кнопка нажата.");
        EventHandler handler3 = (sender, e) => Console.WriteLine("Подписка 3: Кнопка нажата.");
        EventHandler handler4 = (sender, e) => Console.WriteLine("Подписка 4: Кнопка нажата."); // Этот обработчик не будет добавлен.

        button.AddClick(handler1);
        button.AddClick(handler2);
        button.AddClick(handler3);
        button.AddClick(handler4); // Этот обработчик не будет добавлен.

        button.Text = "Click me";

        button.DisplayText();
        button.ChangeTextColor("r");

        button.RemoveClick(handler1);

        button.Text = "Click me again";

        button.DisplayText();
        button.ChangeTextColor("b");

        Console.ReadKey(); 
    }
}
