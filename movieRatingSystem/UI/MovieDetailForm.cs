using System.Text.RegularExpressions;
using movieRatingSystem.Common;

namespace movieRatingSystem.UI;

public partial class MovieDetailForm : Form
{
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
        string rate = RateTextBox.Text.ToString();
        //MessageBox.Show(rate);
        //输入判断
        /*string pattern = @"^[0-9]|10$";
        Regex regex = new Regex(pattern);
        if (!regex.IsMatch(rate))
        {
            MessageBox.Show("评分输入不合法，请输入0-10的整数。");
        }*/
        if (!(rate.Equals("0") || rate.Equals("1") || rate.Equals("2") || rate.Equals("3") || rate.Equals("4") ||
              rate.Equals("5") || rate.Equals("6") || rate.Equals("7") || rate.Equals("8") || rate.Equals("9") ||
              rate.Equals("10")))
        {
            MessageBox.Show("评分输入不合法，请输入0-10的整数。");
            return;
        } 
        // 评分插入到数据库，且用户不能已经评分过该电影
        
    }
}