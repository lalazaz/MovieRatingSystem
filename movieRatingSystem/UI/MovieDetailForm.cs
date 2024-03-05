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

    // 逻辑是0-10，小数只能是.5其他格式不算
    private void rateButton_Click(object sender, EventArgs e)
    {
        MessageBox.Show(RateTextBox.Text.ToString());
        
    }
}