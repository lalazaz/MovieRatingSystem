namespace movieRatingSystem.Model;

public class UserModel
{
    public int UserID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool Status { get; set; }

    public override string ToString()
    {
        return $"Username: {Username} \nEmail: {Email} \n";
    }

    public UserModel()
    {
    }

    public UserModel(int userId, string username, string email)
    {
        UserID = userId;
        Username = username;
        Email = email;
    }

    public UserModel(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}