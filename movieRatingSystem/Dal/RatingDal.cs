using movieRatingSystem.Common;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;

namespace movieRatingSystem.Dal;

public class RatingDal
{
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
            new MySqlParameter("@Rating", MySqlDbType.Double) { Value = ratingModel.RatingID }
        };
        return MyMySqlHelper.ExecuteNonQuery(insertRatingsql, parameters);
    }
}