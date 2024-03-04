using System.Data;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;
using MySqlHelper = movieRatingSystem.Common.MySqlHelper;

namespace movieRatingSystem.Dal;

public class MovieDal
{
    //拿到所有电影名字
    public List<string> GetAllMovieName()
    {
        List<string> res = new List<string>();
        foreach (MovieModel movieModel in GetAllMovie())
        {
            res.Add(movieModel.Title);
        }
        return res;
    }

    //拿到所有电影
    public List<MovieModel> GetAllMovie()
    {
        string searchMovies = "select * from movies";
        MySqlParameter parameter = new MySqlParameter();
        DataTable result = MySqlHelper.ExecuteQuery(searchMovies, parameter);
        List<MovieModel> res = new List<MovieModel>();

        for (var i = 0; i < result.Rows.Count; i++)
        {
            res.Add(new MovieModel(
                result.Rows[i]["Title"].ToString(),
                result.Rows[i]["Genre"].ToString(),
                (int)result.Rows[i]["ReleaseYear"],
                result.Rows[i]["Director"].ToString(),
                result.Rows[i]["Description"].ToString()
            ));
        }

        return res;
    }
}