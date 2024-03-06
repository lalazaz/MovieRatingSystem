using System.Text.RegularExpressions;
using movieRatingSystem.Bll;
using movieRatingSystem.Common;
using movieRatingSystem.Dal;
using movieRatingSystem.Model;

namespace movieRatingSystem.UI;

public partial class MovieDetailForm : Form
{
    private RatingBll ratingBll = new();

    public MovieDetailForm()
    {
        InitializeComponent();

        //显示选择电影的值
        //MessageBox.Show(GlobalData.MovieModel.ToString());
        MovieDetailPropertyGrid.Dock = DockStyle.Fill;
        MovieDetailPropertyGrid.SelectedObject = GlobalData.MovieModel;

        this.KeyPreview = true;
        this.KeyDown += MainForm_esc_down;
    }

    // 按esc退出此form
    private void MainForm_esc_down(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
        {
            this.Close();
        }
    }

    // 逻辑是0-10，只能是整数，其他格式不算
    private void rateButton_Click(object sender, EventArgs e)
    {
        string rate = RateTextBox.Text;
        //MessageBox.Show(rate);
        //输入判断
        /*string pattern = @"^[0-9]|10$";
        Regex regex = new Regex(pattern);
        if (!regex.IsMatch(rate))
        {
            MessageBox.Show("评分输入不合法，请输入0-10的整数。");
        }*/
        if (!int.TryParse(rate, out int numericRate) || numericRate < 0 || numericRate > 10)
        {
            MessageBox.Show("评分输入不合法，请输入0-10的整数。");
            return;
        }

        // 评分插入到数据库，且用户不能已经评分过该电影
        decimal ratingByUserId = ratingBll.RatingByUserID(GlobalData.UserId, GlobalData.MovieModel.MovieID);
        if (ratingByUserId != -1)
        {
            MessageBox.Show($"您已经评分过改电影，您的评分为：{ratingByUserId},请前往你的主页查看");
            return;
        }

        RatingModel ratingModel = new RatingModel();
        // 拿出属性
        if (GlobalData.MovieModel != null)
        {
            ratingModel.MovieID = GlobalData.MovieModel.MovieID;
        }

        ratingModel.UserID = GlobalData.UserId;
        ratingModel.Rating = Convert.ToDecimal(rate);
        int insertRating = ratingBll.insertRating(ratingModel);
        if (insertRating == 1)
        {
            MessageBox.Show("评分成功！");
        }
        else
        {
            MessageBox.Show("评分失败，请稍后再试");
        }
    }
}