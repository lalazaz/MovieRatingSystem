using movieRatingSystem.Dal;

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
}