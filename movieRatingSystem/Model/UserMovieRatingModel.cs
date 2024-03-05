namespace movieRatingSystem.Model;

// 用户对应的电影评分
public class UserMovieRatingModel
{
    public string Title { get; set; }
    public decimal Rating { get; set; }

    public override string ToString()
    {
        return $"title:{Title},Rating:{Rating}";
    }

    public UserMovieRatingModel()
    {
    }

    public UserMovieRatingModel(string title, decimal rating)
    {
        Title = title;
        Rating = rating;
    }
}