using System.Data;
using movieRatingSystem.Common;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;

namespace movieRatingSystem.Dal;

public class RatingDal
{
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