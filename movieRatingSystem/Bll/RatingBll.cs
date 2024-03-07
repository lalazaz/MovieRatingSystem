using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.Bll;

public class RatingBll
{
    private RatingDal ratingDal = new();

    public int changeRatingByMovieNameAndUserID(MovieNameAndUserID movieNameAndUserID, decimal updatedRating)
    {
        return ratingDal.changeRatingByMovieNameAndUserID(movieNameAndUserID, updatedRating);
    }

    public decimal RatingByUserID(int userID, int movieID)
    {
        return ratingDal.RatingByUserID(userID, movieID);
    }

    public int insertRating(RatingModel ratingModel)
    {
        return ratingDal.InsertRating(ratingModel);
    }
}