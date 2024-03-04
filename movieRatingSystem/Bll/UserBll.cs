using movieRatingSystem.Dal;

namespace movieRatingSystem.Bll;

public class UserBll
{
    private UserDal userDAL;

    public UserBll()
    {
        userDAL = new UserDal();
    }
    public bool ValidateUserLogin(string username, string password)
    {
        // 在BLL中处理业务逻辑，调用UserDAL进行数据库操作
        return userDAL.ValidateUserLogin(username, password);
    }

    public bool RegisterUser(string username, string password, string email)
    {
        // 在BLL中处理业务逻辑，调用UserDAL进行数据库操作
        return userDAL.RegisterUser(username, password, email);
    }
    
}