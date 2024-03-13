using System.Data;
using movieRatingSystem.Common;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;

namespace movieRatingSystem.Dal;

public class MovieDal
{
    //根据电影名字对所有电影进行模糊查找，对应电影名字集合
    public List<string> GetMovieNamesByKeyword(string keyword)
    {
        List<string> res = new List<string>();
        string selectMoviesByKeyword = "select * from movies where LOWER(Title) like LOWER(@keyword)";
        MySqlParameter parameter = new MySqlParameter("@keyword", MySqlDbType.VarChar);
        // 添加通配符以实现模糊匹配
        parameter.Value = $"%{keyword}%";

        DataTable dataTable = MyMySqlHelper.ExecuteQuery(selectMoviesByKeyword, parameter);
        foreach (DataRow dataTableRow in dataTable.Rows)
        {
            res.Add(dataTableRow["Title"].ToString());
        }

        return res;
    }


    //根据电影名字获取电影信息
    public MovieModel GetMovieInfoByName(string movieName)
    {
        MovieModel movieModel = new MovieModel();
        // 1. sql
        string selectInfoByName = "select * from movies where Title = @Title";
        // 2. 构建参数
        MySqlParameter parameter = new MySqlParameter("@Title", MySqlDbType.VarChar);
        parameter.Value = movieName;
        // 3.放入参数执行sql
        DataTable dataTable = MyMySqlHelper.ExecuteQuery(selectInfoByName, parameter);
        // 4.处理结果
        if (dataTable.Rows.Count > 0)
        {
            movieModel = new MovieModel(
                (int)dataTable.Rows[0]["MovieID"],
                dataTable.Rows[0]["Title"].ToString(),
                dataTable.Rows[0]["Genre"].ToString(),
                (int)dataTable.Rows[0]["ReleaseYear"],
                dataTable.Rows[0]["Director"].ToString(),
                dataTable.Rows[0]["Description"].ToString()
            );
        }

        return movieModel;
    }

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
        DataTable result = MyMySqlHelper.ExecuteQuery(searchMovies, parameter);
        List<MovieModel> res = new List<MovieModel>();

        for (var i = 0; i < result.Rows.Count; i++)
        {
            res.Add(new MovieModel(
                (int)result.Rows[i]["MovieID"],
                result.Rows[i]["Title"].ToString(),
                result.Rows[i]["Genre"].ToString(),
                (int)result.Rows[i]["ReleaseYear"],
                result.Rows[i]["Director"].ToString(),
                result.Rows[i]["Description"].ToString()
            ));
        }

        return res;
    }

    public int updatedUserByUserID(int movieId, MovieModel updateMovieModel)
    {
        string updateSql = "update movies SET " +
                           "Title = @Title, " +
                           "Genre = @Genre, " +
                           "ReleaseYear = @ReleaseYear, " +
                           "Director = @Director, " +
                           "Description = @Description " +
                           "where movieID = @movieID";
        MySqlParameter[] updateParameters =
        {
            new MySqlParameter("Title", MySqlDbType.VarChar) { Value = updateMovieModel.Title },
            new MySqlParameter("Genre", MySqlDbType.VarChar) { Value = updateMovieModel.Genre },
            new MySqlParameter("ReleaseYear", MySqlDbType.Int32) { Value = updateMovieModel.ReleaseYear },
            new MySqlParameter("Director", MySqlDbType.VarChar) { Value = updateMovieModel.Director },
            new MySqlParameter("Description", MySqlDbType.VarChar) { Value = updateMovieModel.Description },
            new MySqlParameter("movieID", MySqlDbType.Int32) { Value = movieId }
        };
        return MyMySqlHelper.ExecuteNonQuery(updateSql, updateParameters);
    }

    public int insertRandomMovie(MovieModel randomMovieModel)
    {
        string insertSql = "INSERT INTO movies (Title, Genre, ReleaseYear, Director, Description) " +
                           "VALUES (@Title, @Genre, @ReleaseYear, @Director, @Description)";
        MySqlParameter[] insertParameters =
        {
            new MySqlParameter("Title", MySqlDbType.VarChar) { Value = randomMovieModel.Title },
            new MySqlParameter("Genre", MySqlDbType.VarChar) { Value = randomMovieModel.Genre },
            new MySqlParameter("ReleaseYear", MySqlDbType.Int32) { Value = randomMovieModel.ReleaseYear },
            new MySqlParameter("Director", MySqlDbType.VarChar) { Value = randomMovieModel.Director },
            new MySqlParameter("Description", MySqlDbType.VarChar) { Value = randomMovieModel.Description }
        };
        return MyMySqlHelper.ExecuteNonQuery(insertSql, insertParameters);
    }
}