using movieRatingSystem.Model;

namespace movieRatingSystem.Common;

public class GlobalData
{
    // 存放用户的id作为全局变量
    public static int UserId { get; set; }

    // 电影数据
    public static MovieModel MovieModel { get; set; }
}