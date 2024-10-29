using System;

class Program
{
    static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();
        ApplicationSettingsHelper settingsHelper = new ApplicationSettingsHelper();

        while (true)
        {
            try
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1 - Change console settings");
                Console.WriteLine("2 - Load settings from file");
                Console.WriteLine("3 - Exit");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ui.SetBackgroundColor();
                        ui.SetForegroundColor();
                        ui.SetTitle();
                        ui.SetWindowSize();

                        settingsHelper.SaveSettings(
                            Console.BackgroundColor.ToString(),
                            Console.ForegroundColor.ToString(),
                            Console.Title,
                            Console.WindowWidth,
                            Console.WindowHeight);
                        break;

                    case 2:
                        try
                        {
                            var settings = settingsHelper.LoadSettings();
                            ui.ApplySettings(
                                settings.BackgroundColor,
                                settings.ForegroundColor,
                                settings.Title,
                                settings.Width,
                                settings.Height);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error loading settings: " + ex.Message);
                        }
                        break;

                    case 3:
                        Console.WriteLine("Exiting program.");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a numeric value.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
