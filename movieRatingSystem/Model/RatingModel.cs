namespace movieRatingSystem.Model;

public class RatingModel
{
    public int RatingID { get; set; }
    public int MovieID { get; set; }
    public int UserID { get; set; }
    public decimal Rating { get; set; }

    public override string ToString()
    {
        return $"RatingID: {RatingID}, MovieID: {MovieID}, UserID: {UserID}, Rating: {Rating}";
    }
}