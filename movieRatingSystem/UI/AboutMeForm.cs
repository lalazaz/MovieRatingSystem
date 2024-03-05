using movieRatingSystem.Bll;
using movieRatingSystem.Common;
using movieRatingSystem.Model;

namespace movieRatingSystem.UI;

public partial class AboutMeForm : Form
{
    private UserBll userBll;

    public AboutMeForm()
    {
        userBll = new UserBll();
        InitializeComponent();
        Initial();
    }

    private void Initial()
    {
        // 拿出该用户id的评分过的电影，放到ratedMovieListBox中
        List<UserMovieRatingModel> userMovieRatingModels = userBll.GetRatedMovieByUserId(GlobalData.UserId);
        // MessageBox.Show(ratedMovieByUserId.Count().ToString());
        foreach (UserMovieRatingModel userMovieRatingModel in userMovieRatingModels)
        {
            Console.WriteLine(userMovieRatingModel.ToString());
        }

        RateMovieDataGridView.DataSource = userMovieRatingModels;

        // 将用户id对应的信息放入到richText
        UserModel userInfoByUserid = userBll.GetUserInfoByUserid(GlobalData.UserId);
        UserInfoRichTextBox.Text = userInfoByUserid.ToString();
    }

    private void RateMovieDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // MessageBox.Show("click dataGrid");
        if (e.RowIndex >= 0)
        {
            int selectedRowIndex = e.RowIndex;
            DataGridViewRow selectedRow = RateMovieDataGridView.Rows[selectedRowIndex];
            // 获取该行的数据
            string title = selectedRow.Cells["Title"].Value.ToString();
            double rating = Convert.ToDouble(selectedRow.Cells["Rating"].Value);

            MessageBox.Show($"you clicked on row {selectedRowIndex}, Title: {title}, Rating: {rating}");
        }
    }

    // 返回到MainForm.cs
    private void returnPre_Click(object sender, EventArgs e)
    {
        this.Close();
        //new MainForm().Show();
    }
}