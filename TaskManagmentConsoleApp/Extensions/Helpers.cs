namespace TaskManagmentConsoleApp.Extensions;

public static class Helpers
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
    
    
    
    public static string GetValidString(string title,bool password = false)
    {
        Console.Write(title + ": ");
        string? validString = Console.ReadLine();
        
        while (string.IsNullOrWhiteSpace(validString) || (validString.Any(char.IsNumber) && password == false))
        {
            Console.WriteLine("Wrong character");
            Console.Write(title + ": ");
            validString = Console.ReadLine();
        }
        return validString.Trim();

    }
}