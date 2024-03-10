using movieRatingSystem.Bll;
using movieRatingSystem.Common;

namespace movieRatingSystem.UI
{
    public partial class MainForm : Form
    {
        private MovieBll movieBll;

        public MainForm()
        {
            InitializeComponent();
            Initial();
            this.KeyPreview = true;
            this.KeyDown += MainForm_entry_down;
        }

        private void MainForm_entry_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchMovieByName_Click(sender, e);
            }
        }

        private void Initial()
        {
            movieBll = new MovieBll();
            //MessageBox.Show("主页面初始化成功！");
            MovieNameListBox.Name = "done";
            List<string> allMovieName = movieBll.GetAllMovieName();
            MovieNameListBox.Items.AddRange(allMovieName.ToArray());
            MovieNameListBox.Name = allMovieName.Count.ToString();
        }

        private void MovieNameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(sender + "," + e.ToString);
            // 获取选中的电影名字
            object? selectedItem = MovieNameListBox.SelectedItem;
            string selectedMovieName = "";
            if (selectedItem != null)
            {
                selectedMovieName = selectedItem.ToString();
            }

            if (!selectedMovieName.Equals(""))
            {
                //MessageBox.Show($"you selected:{selectedMovieName}");
                //MessageBox.Show(movieBll.GetMovieInfoByName(selectedMovieName).ToString());
                //进入电影详情页面
                GlobalData.MovieModel = movieBll.GetMovieInfoByName(selectedMovieName);

                //注入选择电影的平均评分
                decimal AvgRating = movieBll.GetAvgRatingByMovieName(selectedMovieName);
                GlobalData.MovieModel.AvgRating = AvgRating;
                
                MovieDetailForm movieDetailForm = new MovieDetailForm();
                movieDetailForm.StartPosition = FormStartPosition.CenterScreen;
                movieDetailForm.ShowDialog();
            }
        }

        private void SearchMovieByName_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(searchTextbox.Text);
            List<string> movieNamesByKeyword = movieBll.GetMovieNamesByKeyword(searchTextbox.Text);
            MovieNameListBox.Items.Clear();
            MovieNameListBox.Items.AddRange(movieNamesByKeyword.ToArray());
        }

        private void aboutMeButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("进入我的主页");
            AboutMeForm aboutMe = new AboutMeForm();
            aboutMe.Show();
            // this.Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("再见！");
            GlobalData.UserId = -1;

            this.Close();
            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }
    }
}