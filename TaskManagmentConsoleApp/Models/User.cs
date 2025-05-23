using TaskManagmentConsoleApp.Extensions;

namespace TaskManagmentConsoleApp.Models;

public class User
{
    private static User[] _users = [];
    
    public static int UsersCount = 0;
    
    private Task[] _tasks =  [];
    
    public int TaskCount = 0;
    
    private  string? _password;
    public string? Username{get; private set;}
    
    public  string? Password
    {
        set => _password=value;
    }
    
    
    public void ChangePassword(string? oldPassword, string? newPassword)
    {
        if (CheckPassword(oldPassword))
        {
            Password = newPassword;
          Helper.GetValidColor("Password changed !",ConsoleColor.Green);
        }
        else
            Helper.GetValidColor("Passwords do not match.", ConsoleColor.Red);
    }

    public void ChangeUsername(string? username)
    {
        if (CheckIfUniqueUsername(username))
        {
            Username=username;
        }
        else
        {
            Helper.GetValidColor("This username is already in use", ConsoleColor.Yellow);
        }
    }
    
    public static void Register(string? username, string? password)
    {
        
        if (!CheckIfUniqueUsername(username))
        {
            Helper.GetValidColor("This username already exists", ConsoleColor.Red);
            return ;
        }
        User newUser = new User()
        {
            Username = username,
            Password = password
        };
        
        Array.Resize(ref _users, _users.Length + 1);
        _users[^1] = newUser;
        UsersCount++;
       Helper.GetValidColor("Registered successfully", ConsoleColor.Green);
    }

    public static User? Login(string? username, string? password)
    {
        if (_users.Length == 0) return null;
        
        foreach (var user in _users)
        {
            if (user.Username == username && user._password == password)
            {
                Helper.GetValidColor("Login successfully", ConsoleColor.Green);
                return user; 
            }
        }
        
        Helper.GetValidColor("invalid username or password",ConsoleColor.Red);
        return null; 
    }

    public void AddTask()
    {
       string? description = Helper.GetValidString("Please enter a description", true);
       DateTime deadline = Helper.GetValidDateTime("Please enter a deadline");
       Task newTask = new Task(description, deadline);
       Array.Resize(ref _tasks, _tasks.Length + 1);
       _tasks[^1] = newTask;
       TaskCount++;
    }
    public void ShowTasks()
    {
        if (TaskCount == 0)
        {
            Console.WriteLine("No tasks found");
            return;
        }
        foreach (var task in _tasks)
        {
            if (task.TaskStatus)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            
            Console.WriteLine(task);
            Console.ResetColor();
        }
    }

    public void SolveTask(int taskId)
    {
        if (TaskCount == 0)
        {
            Console.WriteLine("No tasks found");
            return;
        }
        
        foreach (var task in _tasks)
        {
            if (task.TaskId != taskId) continue;
            
            if (task.TaskStatus)
            {
                Helper.GetValidColor("This task has been completed", ConsoleColor.Green);
                return;
            }

            if (task.Deadline < DateTime.Now)
            {
                Helper.GetValidColor("Deadline has passed. Cannot complete this task.", ConsoleColor.Red);
                return;
            }
            task.TaskStatus = true;
            Helper.GetValidColor($"{task} --- completed", ConsoleColor.Green);
            return;
        }
        
    }
    
    private static bool CheckIfUniqueUsername(string? username)
    {
        foreach (var user in _users)
        {
            if (user.Username == username)
                return false;
        }
        return true;
    }
    private bool CheckPassword(string? password)
    {
        return _password == password;
    }
    
    public override string ToString()
    {
        return $"Username: {Username}, Password: {_password}";
    }
    
}