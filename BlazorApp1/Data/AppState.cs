namespace BlazorApp1.Data;

public class AppState
{
    public bool IsLoggedIn { get; set; } = false;
    public int? UserId { get; set; }

    public void LogIn(int userId)
    {
        IsLoggedIn = true;
        UserId = userId;
    }

    public void LogOut()
    {
        IsLoggedIn = false;
        UserId = null;
    }
}