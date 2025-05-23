using TaskManagmentConsoleApp.Extensions;
using TaskManagmentConsoleApp.Models;

namespace TaskManagmentConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        User? currentUser = null;
        
        while (true)
        {
            Helper.GetValidColor("\t\t\t\t\t\t\t\t\tWelcome to BDU's official website\n\n", ConsoleColor.Green);
            
            Console.WriteLine("0. Exit.");
            Console.WriteLine("1. Login.");
            Console.WriteLine("2. Register.");
            int userChoiceMainMenu = Helper.GetValidInteger("Select", 0, 2);
            
            MainMenuEnum mainMenuEnumChoice = (MainMenuEnum)userChoiceMainMenu;
            
            Console.Clear();
            switch (mainMenuEnumChoice)
            {
               
                case MainMenuEnum.Exit:
                    Console.WriteLine("Goodbye!!!");
                    return;
                
                case MainMenuEnum.Login:
                    if (User.UsersCount==0)
                    {
                        Console.WriteLine("No users have been registered.");
                        break;
                    }
                    
                    Console.Clear();
                    string? usernameLogin = Helper.GetValidString("Enter username");
                    string? passwordLogin = Helper.GetValidString("Enter password",true);
                    currentUser = User.Login(usernameLogin, passwordLogin);
                    
                    if (currentUser != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current User: {currentUser.Username} \n\n");
                        bool next = true;
                        while (next)
                        {
                            Console.WriteLine("0. Go to main menu");
                            Console.WriteLine("1. Change password");
                            Console.WriteLine("2. Change username");
                            Console.WriteLine("3. Show tasks");
                            Console.WriteLine("4. Solve task");
                            Console.WriteLine("5. Add task");
                            
                            int userChoiceUserMenu = Helper.GetValidInteger("Select", 0, 5);
                            UserMenuEnum userMenuEnumChoice = (UserMenuEnum)userChoiceUserMenu;
                            
                            switch (userMenuEnumChoice)
                            {
                                case UserMenuEnum.BackToMainMenu:
                                    next = false;
                                    break;
                                case UserMenuEnum.ChangePassword:
                                    string? oldPassword = Helper.GetValidString("Enter old password",true);
                                    string? newPassword = Helper.GetValidString("Enter new password",true);
                                    currentUser.ChangePassword(oldPassword, newPassword);
                                    break;
                                
                                case UserMenuEnum.ChangeUsername:
                                    string? newUsername = Helper.GetValidString("Enter new username");
                                    currentUser.ChangeUsername(newUsername);
                                    
                                    break;
                                case UserMenuEnum.ShowTasks:
                                    currentUser.ShowTasks();
                                    
                                    break;
                                case UserMenuEnum.SolveTasks:
                                    int taskId = Helper.GetValidInteger("Select task ID",1, currentUser.TaskCount);
                                    currentUser.SolveTask(taskId);
                                    break;
                                case UserMenuEnum.AddTask:
                                    currentUser.AddTask();
                                    break;
                                
                            }

                            if (userChoiceUserMenu == 0) continue;
                            Console.WriteLine("Press any key to continue...");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    break;
                
                case MainMenuEnum.Register:
                    string? usernameEnter = Helper.GetValidString("Enter username");
                    string? passwordEnter = Helper.GetValidString("Enter password",true);
                    User.Register(usernameEnter, passwordEnter);
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
            
        }

    }
}