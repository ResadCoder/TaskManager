namespace TaskManagmentConsoleApp.Extensions;

public static class Helper
{
    public static int GetValidInteger( string title, int min = 1,int max = int.MaxValue)
    {
        
        int number;
        Console.Write(title+": ");

        while (!int.TryParse(Console.ReadLine(), out number) || number < min || number > max)
        {
            Console.WriteLine("Please enter a valid integer.");
            Console.Write(title+": ");
        }
        return number;
    }
    
    
    
    public static string? GetValidString(string title,bool hasDigitsOrSymbols = false)
    {
        Console.Write(title + ": ");
        string? validString = Console.ReadLine();
        
        while (string.IsNullOrWhiteSpace(validString) || (validString.Any(char.IsNumber) && hasDigitsOrSymbols == false))
        {
            Helper.GetValidColor("Please enter a valid string.", ConsoleColor.Red);
            Console.Write(title + ": ");
            validString = Console.ReadLine();
        }
        return validString.Trim();
    }

    public static DateTime GetValidDateTime(string title)
    {
        while (true)
        {
            Console.Write(title+": ");
            string? input = Console.ReadLine();

            if (DateTime.TryParse(input, out DateTime result))
            {
                return result;
            }
            
            Console.WriteLine("Invalid date format.Please enter a valid date format (yyyy.mm.dd)");
            
        }
    }

    public static void GetValidColor(string? title, ConsoleColor color = default)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(title);
        Console.ResetColor(); 
    }
}