using TaskManagmentConsoleApp.Extensions;
using TaskManagmentConsoleApp.Models;

namespace TaskManagmentConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        User? currentUser = null;
       
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\t\t\t\t\t\t\t\t\tWelcome to BDU's official website");
        Console.ResetColor();
        while (true)
        {
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Register.");
            int userChoiceMainMenu = Helpers.GetValidInteger("Select", 0, 2);
            
            MainMenu mainMenuChoice = (MainMenu)userChoiceMainMenu;
            
            switch (mainMenuChoice)
            {
                case MainMenu.Exit:
                    Console.WriteLine("Goodbye!!!");
                    return;
                
                case MainMenu.Login:
                    string usernameLogin = Helpers.GetValidString("Enter username");
                    string passwordLogin = Helpers.GetValidString("Enter password",true);
                    currentUser = User.Login(usernameLogin, passwordLogin);
                    
                    if (currentUser != null)
                    {
                        bool next = true;
                        while (next)
                        {
                            Console.WriteLine("0. Go to main menu");
                            Console.WriteLine("1. Change password");
                            
                            int userChoiceUserMenu = Helpers.GetValidInteger("Select", 0, 1);
                            UserMenu userMenuChoice = (UserMenu)userChoiceUserMenu;
                            
                            switch (userMenuChoice)
                            {
                                case UserMenu.BackToMainMenu:
                                    next = false;
                                    break;
                                
                                case UserMenu.ChangePassword:
                                    string oldPasssword = Helpers.GetValidString("Enter old password",true);
                                    string newPasssword = Helpers.GetValidString("Enter new password",true);
                                    currentUser.ChangePassword(oldPasssword, newPasssword);
                                    break;
                            }
                            
                        }
                    }
                    break;
                
                case MainMenu.Register:
                    string usernameEnter = Helpers.GetValidString("Enter username");
                    string passwordEnter = Helpers.GetValidString("Enter password",true);
                    Console.WriteLine();
                    User.Register(usernameEnter, passwordEnter);
                    break;
            }
            
            User.ShowAllUsers();
            
        }

    }
}