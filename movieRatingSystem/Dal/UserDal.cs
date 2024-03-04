using System.Data;
using movieRatingSystem.Common;
using MySql.Data.MySqlClient;
using MySqlHelper = movieRatingSystem.Common.MySqlHelper;

namespace movieRatingSystem.Dal;

public class UserDal
{
    /**
     * 判断用户登录信息是否合法
     */
    public bool ValidateUserLogin(string username, string password)
    {
        string searchPasswordByName = "select PasswordHash from Users where Username = @Username";
        // 使用参数化查询避免SQL注入攻击
        MySqlParameter parameter = new MySqlParameter("@Username", MySqlDbType.VarChar);
        parameter.Value = username;

        DataTable result = MySqlHelper.ExecuteQuery(searchPasswordByName, parameter);
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
        DataTable dataTable = MySqlHelper.ExecuteQuery(searchByName, parameter);
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
        int rowsAffected = MySqlHelper.ExecuteNonQuery(insertUser, insertParameters);

        return rowsAffected > 0;
    }
    private bool CheckPassword(string inputPassword, string passwordHashFromDatabase)
         {
             return PassWordHelper.GetPasswordHash(inputPassword).Equals(passwordHashFromDatabase);
         }
}