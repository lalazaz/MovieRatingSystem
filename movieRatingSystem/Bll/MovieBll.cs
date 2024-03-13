using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.Bll;

public class MovieBll
{
    private MovieDal movieDal = new();
    private RatingDal ratingDal = new();


    public List<MovieModel> GetAllMovie()
    {
        List<MovieModel> movieModels = movieDal.GetAllMovie();
        foreach (MovieModel movieModel in movieModels)
        {
            movieModel.AvgRating = GetAvgRatingByMovieName(movieModel.Title);
        }

        return movieModels;
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

    public int updatedMovieByMovieID(int movieId, MovieModel updateMovieModel)
    {
        return movieDal.updatedUserByUserID(movieId, updateMovieModel);
    }

    public int insertRandomMovie()
    {
        //Title、Genre、ReleaseYear[int 1893 - 2024]、Director、Description 信息都随机生成
        // new Random(1989)
        string Title = Guid.NewGuid().ToString().Split("-")[0];
        string Genre = Title + "_Genre";
        int RandomReleaseYear = new Random().Next(2024 - 1893) + 1893;
        string Director = Title + "_Director";
        string Description = Title + "_Description";

        MovieModel randomMovieModel = new MovieModel(Title, Genre, RandomReleaseYear, Director, Description);
        return movieDal.insertRandomMovie(randomMovieModel);
    }
}