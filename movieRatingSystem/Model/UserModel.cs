namespace movieRatingSystem.Model;

public class UserModel
{
    private int UserID { get; set; }
    private string Username { get; set; }
    private string Password { get; set; }
    private string Email { get; set; }
    private DateTime RegistrationDate { get; set; }
    private bool Status { get; set; }

    public UserModel()
    {
    }

    public UserModel(string username, string password, string email)
    {
        Username = username;
        Password = password;
        Email = email;
    }
}