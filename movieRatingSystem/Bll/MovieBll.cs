using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.Bll;

public class MovieBll
{
    private MovieDal movieDal;
    private RatingDal ratingDal;

    public MovieBll()
    {
        movieDal = new MovieDal();
        ratingDal = new RatingDal();
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

    //根据电影名字得到电影平均评分
    //本来应当就是这里写逻辑的，上面都写到Dal中去了
    public decimal GetAvgRatingByMovieName(string selectedMovieName)
    {
        MovieModel movieModel = movieDal.GetMovieInfoByName(selectedMovieName);
        int movieModelMovieId = movieModel.MovieID;
        decimal avgRatingByMovieId = ratingDal.getAvgRatingByMovieID(movieModelMovieId);
        return avgRatingByMovieId;
    }
}