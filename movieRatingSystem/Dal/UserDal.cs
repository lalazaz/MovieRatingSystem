using System.Data;
using movieRatingSystem.Common;
using movieRatingSystem.Model;
using MySql.Data.MySqlClient;

namespace movieRatingSystem.Dal;

// Dal层的逻辑可以移到Bll层去，返回对方使用model包装
public class UserDal
{
    /**
     * 根据userid拿到用户信息
     */
    public UserModel GetUserInfoByUserid(int userid)
    {
        UserModel userInfo = null;

        string query = "SELECT * FROM Users WHERE UserId = @userId";
        MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.Int32);
        parameter.Value = userid;

        DataTable dataTable = MyMySqlHelper.ExecuteQuery(query, parameter);

        if (dataTable.Rows.Count > 0)
        {
            DataRow row = dataTable.Rows[0];
            // 根据实际的表结构和 UserModel 类来设置用户信息
            userInfo = new UserModel()
            {
                UserID = userid,
                Username = row["Username"].ToString(),
                Email = row["Email"].ToString(),
            };
        }

        return userInfo;
    }

    /**
     * 根据userid拿到这个用户看过的所有电影，需要连表查询
     * 结果只要电影名字和自己评分的多少
     * Dictionary就很好
     */
    public List<UserMovieRatingModel> GetRatedMovieByUserId(int userId)
    {
        List<UserMovieRatingModel> dictionary = new List<UserMovieRatingModel>();
        string searchMovieNameAndRatingByUserId = "select ratings.Rating, movies.Title " +
                                                  "from ratings " +
                                                  "inner join movies on ratings.MovieID = movies.MovieID " +
                                                  "where ratings.UserID = @userId";
        MySqlParameter parameter = new MySqlParameter("@userId", MySqlDbType.Int32);
        parameter.Value = userId;
        DataTable dataTable = MyMySqlHelper.ExecuteQuery(searchMovieNameAndRatingByUserId, parameter);
        for (var i = 0; i < dataTable.Rows.Count; i++)
        {
            dictionary.Add(new UserMovieRatingModel(
                dataTable.Rows[i]["Title"].ToString(),
                (decimal)dataTable.Rows[i]["Rating"]));
        }

        return dictionary;
    }


    /**
     * 根据用户名查找用户id
     */
    public int GetUserIdByUserName(string name)
    {
        string searchUserIdByUserName = "select UserID from users where Username = @name";
        MySqlParameter parameter = new MySqlParameter("@name", MySqlDbType.VarChar);
        parameter.Value = name;
        DataTable dataTable = MyMySqlHelper.ExecuteQuery(searchUserIdByUserName, parameter);
        if (dataTable.Rows.Count > 0)
        {
            return (int)dataTable.Rows[0]["UserID"];
        }

        return -1;
    }

    /**
     * 判断用户登录信息是否合法
     */
    public bool ValidateUserLogin(string username, string password)
    {
        string searchPasswordByName = "select PasswordHash from Users where Username = @Username";
        // 使用参数化查询避免SQL注入攻击
        MySqlParameter parameter = new MySqlParameter("@Username", MySqlDbType.VarChar);
        parameter.Value = username;

        DataTable result = MyMySqlHelper.ExecuteQuery(searchPasswordByName, parameter);
        if (result.Rows.Count > 0)
        {
            string passwordHash = result.Rows[0]["PasswordHash"].ToString();

            //进行密码对比
            if (CheckPassword(password, passwordHash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false; //不存在
        }
    }

    /**
     * 进行注册
     * 1.user先判断不在库中
     * 2.两个密码一致
     */
    public bool RegisterUser(string username, string password, string email)
    {
        if (username.Equals(""))
        {
            MessageBox.Show("用户名不能为空！");
            return false;
        }

        string searchByName = "select * from Users where Username = @Username";
        MySqlParameter parameter = new MySqlParameter("@Username", MySqlDbType.VarChar);
        parameter.Value = username;
        DataTable dataTable = MyMySqlHelper.ExecuteQuery(searchByName, parameter);
        if (dataTable.Rows.Count > 0)
        {
            MessageBox.Show("用户名已经存在！");
            return false;
        }

        string insertUser = @"insert into Users (Username, PasswordHash, Email, RegistrationDate, Status) 
                                values (@Username, @PasswordHash, @Email, CURRENT_TIMESTAMP, 'Active')";
        MySqlParameter[] insertParameters =
        {
            new MySqlParameter("@Username", MySqlDbType.VarChar) { Value = username },
            new MySqlParameter("@PasswordHash", MySqlDbType.VarChar)
                { Value = PassWordHelper.GetPasswordHash(password) },
            new MySqlParameter("@Email", MySqlDbType.VarChar) { Value = email }
        };
        int rowsAffected = MyMySqlHelper.ExecuteNonQuery(insertUser, insertParameters);

        return rowsAffected > 0;
    }

    private bool CheckPassword(string inputPassword, string passwordHashFromDatabase)
    {
        return PassWordHelper.GetPasswordHash(inputPassword).Equals(passwordHashFromDatabase);
    }
}