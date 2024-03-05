using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.Bll;

public class UserBll
{
    private UserDal userDal = new();

    public UserModel GetUserInfoByUserid(int userid)
    {
        return userDal.GetUserInfoByUserid(userid);
    }

    public List<UserMovieRatingModel> GetRatedMovieByUserId(int userid)
    {
        return userDal.GetRatedMovieByUserId(userid);
    }

    public bool ValidateUserLogin(string username, string password)
    {
        // 在BLL中处理业务逻辑，调用UserDal进行数据库操作
        return userDal.ValidateUserLogin(username, password);
    }

    public bool RegisterUser(string username, string password, string email)
    {
        // 在BLL中处理业务逻辑，调用UserDal进行数据库操作
        return userDal.RegisterUser(username, password, email);
    }

    public int GetUserIdByUserName(string name)
    {
        return userDal.GetUserIdByUserName(name);
    }
}