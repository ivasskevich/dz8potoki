using System;
using System.IO;

public class ApplicationSettingsHelper
{
    private const string settingsFilePath = "config.txt";

    // Method to save settings to a file
    public void SaveSettings(string backgroundColor, string foregroundColor, string title, int width, int height)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(settingsFilePath))
            {
                writer.WriteLine(backgroundColor);
                writer.WriteLine(foregroundColor);
                writer.WriteLine(title);
                writer.WriteLine(width);
                writer.WriteLine(height);
            }
            Console.WriteLine("Settings saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error saving settings: " + ex.Message);
        }
    }

    // Method to load settings from a file
    public (string BackgroundColor, string ForegroundColor, string Title, int Width, int Height) LoadSettings()
    {
        try
        {
            using (StreamReader reader = new StreamReader(settingsFilePath))
            {
                string backgroundColor = reader.ReadLine();
                string foregroundColor = reader.ReadLine();
                string title = reader.ReadLine();
                int width = int.Parse(reader.ReadLine());
                int height = int.Parse(reader.ReadLine());

                Console.WriteLine("Settings loaded successfully.");
                return (backgroundColor, foregroundColor, title, width, height);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading settings: " + ex.Message);
            throw;
        }
    }
}
