using System;

public class UserInterface
{
    // Method to choose color for text or background
    private string ChooseColor(string colorType)
    {
        Console.WriteLine($"Choose a color for {colorType}:");
        Console.WriteLine("1 - Black");
        Console.WriteLine("2 - Red");
        Console.WriteLine("3 - Green");
        Console.WriteLine("4 - Magenta");
        Console.WriteLine("5 - Blue");
        Console.WriteLine("6 - Cyan");
        Console.WriteLine("Enter the number of the color: ");
        return Console.ReadLine().ToLower();
    }

    // Method to parse the color input and return a ConsoleColor
    private ConsoleColor ParseColor(string color)
    {
        color = color.ToLower();
        switch (color)
        {
            case "1":
                return ConsoleColor.Black;
            case "2":
                return ConsoleColor.Red;
            case "3":
                return ConsoleColor.Green;
            case "4":
                return ConsoleColor.Magenta;
            case "5":
                return ConsoleColor.Blue;
            case "6":
                return ConsoleColor.Cyan;
            default:
                throw new ArgumentException("Invalid color choice.");
        }
    }

    // Method to set the foreground color based on user input
    public void SetForegroundColor()
    {
        while (true)
        {
            try
            {
                string colorChoice = ChooseColor("text");
                ApplyForegroundColor(ParseColor(colorChoice));
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to set the background color based on user input
    public void SetBackgroundColor()
    {
        while (true)
        {
            try
            {
                string colorChoice = ChooseColor("background");
                ApplyBackgroundColor(ParseColor(colorChoice));
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    // Method to set the console title based on user input
    public void SetTitle()
    {
        Console.WriteLine("Enter the window title: ");
        string title = Console.ReadLine();
        Console.Title = title;
    }

    // Method to set the console window size based on user input
    public void SetWindowSize()
    {
        while (true)
        {
            try
            {
                Console.WriteLine($"Enter window width (max: {Console.LargestWindowWidth}): ");
                int width = int.Parse(Console.ReadLine());

                Console.WriteLine($"Enter window height (max: {Console.LargestWindowHeight}): ");
                int height = int.Parse(Console.ReadLine());

                if (width <= 0 || height <= 0 || width > Console.LargestWindowWidth || height > Console.LargestWindowHeight)
                {
                    Console.WriteLine("Invalid window size. Please try again.");
                    continue;
                }

                Console.SetWindowSize(width, height);
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter numeric values.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error setting window size: " + ex.Message);
            }
        }
    }

    // Method to apply all console settings
    public void ApplySettings(string backgroundColor, string foregroundColor, string title, int width, int height)
    {
        try
        {
            ApplyBackgroundColor(ParseColor(backgroundColor));
            ApplyForegroundColor(ParseColor(foregroundColor));
            Console.Title = title;
            Console.SetWindowSize(width, height);
            Console.WriteLine("Settings applied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error applying settings: " + ex.Message);
        }
    }

    // Private method to apply background color
    private void ApplyBackgroundColor(ConsoleColor color)
    {
        Console.BackgroundColor = color;
        Console.Clear();
    }

    // Private method to apply foreground color
    private void ApplyForegroundColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
        Console.Clear();
    }
}
