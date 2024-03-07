namespace movieRatingSystem.Model;

public class MovieNameAndUserID
{
    public string Title { get; set; }
    public int UserID { get; set; }

    public MovieNameAndUserID()
    {
    }

    public MovieNameAndUserID(string title, int userId)
    {
        Title = title;
        UserID = userId;
    }
}