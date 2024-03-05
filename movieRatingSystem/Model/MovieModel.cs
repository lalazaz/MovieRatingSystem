using System.ComponentModel;
using System.Drawing.Design;
using movieRatingSystem.Common;

namespace movieRatingSystem.Model;

public class MovieModel
{
    public int MovieID { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Director { get; set; }

    [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    public string Description { get; set; }

    public override string ToString()
    {
        return
            $" Title: {Title}, \n Genre: {Genre}, \n ReleaseYear: {ReleaseYear},\n Director: {Director}, \n Description: {Description}";
    }

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