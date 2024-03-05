using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.Bll;

public class MovieBll
{
    private MovieDal movieDal;

    public MovieBll()
    {
        movieDal = new MovieDal();
    }

    public List<string> GetAllMovieName()
    {
        return movieDal.GetAllMovieName();
    }

    public MovieModel GetMovieInfoByName(string movieName)
    {
        return movieDal.GetMovieInfoByName(movieName);
    }

    public List<string> GetMovieNamesByKeyword(string keyword)
    {
        return movieDal.GetMovieNamesByKeyword(keyword);
    }
}