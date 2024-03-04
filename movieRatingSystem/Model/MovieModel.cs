namespace movieRatingSystem.Model;

public class MovieModel
{
    public int MovieID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }
    public string Description { get; set; }

    public MovieModel()
    {
    }

    public MovieModel(string title, string genre, int releaseYear, string director, string description)
    {
        Title = title;
        Genre = genre;
        ReleaseYear = releaseYear;
        Director = director;
        Description = description;
    }
}