using System.Data;
using movieRatingSystem.Common;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;

namespace movieRatingSystem.Dal;

public class RatingDal
{
    //根据电影id拿到他的平均评分
    public decimal getAvgRatingByMovieID(int movieID)
    {
        decimal res = 0;
        string getAvgRatingSql = "SELECT AVG(Rating) AS AvgRating FROM ratings WHERE MovieID = @MovieID";
        MySqlParameter parameter = new MySqlParameter("@MovieID", MySqlDbType.Int32);
        parameter.Value = movieID;
        DataTable executeQuery = MyMySqlHelper.ExecuteQuery(getAvgRatingSql, parameter);
        // MessageBox.Show(executeQuery.Rows[0]["AvgRating"].GetType().ToString());
        // 避免没有查出平均分的报错
        res = 0;
        if (executeQuery.Rows.Count > 0)
        {
            if (!executeQuery.Rows[0]["AvgRating"].GetType().ToString().Equals("System.DBNull"))
            {
                res = (decimal)executeQuery.Rows[0]["AvgRating"];
            }
        }

        return res;
    }


    // 根据电影名字和用户id更改电影评分
    public int changeRatingByMovieNameAndUserID(MovieNameAndUserID movieNameAndUserId, decimal rating)
    {
        string updateSql = "update ratings R " +
                           "inner join movies M " +
                           "on R.MovieID = M.MovieID " +
                           "set R.Rating = @Rating where M.Title = @MovingName and R.UserID = @UserID";
        MySqlParameter[] parameters = new MySqlParameter[]
        {
            new MySqlParameter("@Rating", MySqlDbType.Decimal) { Value = rating },
            new MySqlParameter("@MovingName", MySqlDbType.VarChar) { Value = movieNameAndUserId.Title },
            new MySqlParameter("@UserID", MySqlDbType.Int32) { Value = movieNameAndUserId.UserID },
        };
        return MyMySqlHelper.ExecuteNonQuery(updateSql, parameters);
    }


    //根据userid查看用户是否评分过该电影
    public decimal RatingByUserID(int userID, int movieID)
    {
        decimal res = -1;
        // 查出来很多此用户的评分表
        string getRatingByUserID = "select * from ratings where UserID = @UserID";
        MySqlParameter parameter = new MySqlParameter("@UserID", MySqlDbType.Int32);
        parameter.Value = userID;
        DataTable dataTable = MyMySqlHelper.ExecuteQuery(getRatingByUserID, parameter);
        if (dataTable.Rows.Count > 0)
        {
            for (var i = 0; i < dataTable.Rows.Count; i++)
            {
                if (movieID == (int)dataTable.Rows[i]["MovieID"])
                {
                    res = (decimal)dataTable.Rows[i]["Rating"];
                    break;
                }
            }
        }

        return res;
    }

    //插入电影评分
    public int InsertRating(RatingModel ratingModel)
    {
        string insertRatingsql = "insert into ratings " +
                                 "(MovieID,UserID,Rating) " +
                                 "Values (@MovieID,@UserID,@Rating)";
        MySqlParameter[] parameters =
        {
            new MySqlParameter("@MovieID", MySqlDbType.Int32) { Value = ratingModel.MovieID },
            new MySqlParameter("@UserID", MySqlDbType.Int32) { Value = ratingModel.UserID },
            new MySqlParameter("@Rating", MySqlDbType.Decimal) { Value = ratingModel.Rating }
        };
        return MyMySqlHelper.ExecuteNonQuery(insertRatingsql, parameters);
    }
}