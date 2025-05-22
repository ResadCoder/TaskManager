namespace TaskManagmentConsoleApp.Models;

public class User
{
    private static User[] _users = [];
    private  string _password;
    public string Username{get; set;}
    
    public  string Password
    {
        set => _password=value;
    }
    
    private bool CheckUsername(string username)
    {
        return Username == username;
    }
    
    private bool CheckPassword(string password)
    {
        return _password == password;
    }
    
    public void ChangePassword(string oldPassword, string newPassword)
    {
        if (CheckPassword(oldPassword))
        {
            _password = newPassword;
        }
        else
            Console.WriteLine("Passwords do not match");
    }

    private static bool CheckIfUniqueUsername(string username)
    {
        foreach (var user in _users)
        {
            if (user.Username == username)
                return false;
        }
        return true;
    }


    public static void Register(string username, string password)
    {
        
        if (!CheckIfUniqueUsername(username))
        {
            Console.WriteLine("username already exists");
            return ;
        }

        User newUser = new User()
        {
            Username = username,
            Password = password
        };
        
        Array.Resize(ref _users, _users.Length + 1);
        _users[^1] = newUser;
        Console.WriteLine("Registered successfully");
    }

    public static User? Login(string username, string password)
    {
        foreach (var user in _users)
        {
            if (user.Username == username && user._password == password)
            {
                Console.WriteLine("Login was successful!");
                return user; 
            }
        }

        Console.WriteLine("Invalid username or password.");
        return null; 
    }

    public static void ShowAllUsers()
    {
        foreach (var user in _users)
        {
            Console.WriteLine(user);
        }
    }

    public override string ToString()
    {
        return $"Username: {Username}, Password: {_password}";
    }
    
}