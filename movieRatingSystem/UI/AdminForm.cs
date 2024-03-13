using Microsoft.VisualBasic.Logging;
using movieRatingSystem.Bll;
using movieRatingSystem.Common;
using movieRatingSystem.Model;
using Mysqlx.Resultset;

namespace movieRatingSystem.UI
{
    public partial class AdminForm : Form
    {
        private MovieBll movieBll;

        private UserBll userBll;

        // 用来控制随机添加电影的进度显示
        private Task _task;
        private int _movieNumber = 0;

        public AdminForm()
        {
            InitializeComponent();
            movieBll = new();
            userBll = new();
            //MessageBox.Show("welcome,this is admin form!");
            Initial();
        }

        // 电影和用户表数据初始化
        public void Initial()
        {
            //UserDataGridView.Dock = DockStyle.Fill;
            UserDataGridView.DataSource = userBll.GetAllUserInfo();
            //MovieDataGridView.Dock = DockStyle.Right;
            MovieDataGridView.DataSource = movieBll.GetAllMovie();

            // 设置窗体的大小和位置
            this.Size = new Size(1000, 500); // 调整窗体大小
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2); // 将窗体居中显示

            // 设置 splitContainer1 的位置和大小
            splitContainer1.Location = new Point(12, 12); // 调整 splitContainer1 的位置
            splitContainer1.Size = new Size(this.Width - 24, this.Height - 24); // 调整 splitContainer1 的大小

            // 设置 splitContainer1.Panel1 和 Panel2 的大小
            splitContainer1.Panel1.Size = new Size(1000, 400);
            splitContainer1.Panel2.Size = new Size(1000, 400);

            // 设置 splitContainer1.SplitterDistance
            splitContainer1.SplitterDistance = splitContainer1.Panel1.Width;

            // 设置 UserDataGridView 和 MovieDataGridView 的 DockStyle
            UserDataGridView.Dock = DockStyle.Fill;
            MovieDataGridView.Dock = DockStyle.Fill;
        }

        private void AddMovieButton_Click(object sender, EventArgs e)
        {
            timer_1s.Enabled = true;
        }

        private void StopAddMovieButton_Click(object sender, EventArgs e)
        {
            timer_1s.Enabled = false;
        }

        // todo 还剩下的问题：
        // 1.自动添加进度条可以优化
        // 2.添加电影后自动将电影放到gridview表单
        // 3.添加完电影后显示完毕
        // 4.admin 启动后会根据movieid查找电影平均分，那里逻辑有点问题，查不到就报错，应当设置为不报错。
        private void timer_1s_Tick(object sender, EventArgs e)
        {
            AddMovieProgressBar.Style = ProgressBarStyle.Marquee;
            int effected = movieBll.insertRandomMovie();
            if (effected != 1)
            {
                MessageBox.Show("随机新增电影信息失败，已关闭功能。");
                reload();
            }

            UpdateProgress(_movieNumber++);
            AddMovieProgressBar.Style = ProgressBarStyle.Continuous;
        }


        private void UpdateProgress(int value)
        {
            if (value == 20)
            {
                timer_1s.Enabled = false;
                _movieNumber = 0;
            }

            if (AddMovieProgressBar.InvokeRequired)
            {
                AddMovieProgressBar.BeginInvoke((MethodInvoker)(() => AddMovieProgressBar.Value = value));
            }
            else
            {
                AddMovieProgressBar.Value = value;
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
        }

        private void UserDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(e.RowIndex + "-" + e.ColumnIndex);
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("不能更新userid!");
                reload();
            }

            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // 获取修改后的值
                UserModel updatedUserModel = new UserModel();
                // 获取 UserID
                int userID = (int)UserDataGridView.Rows[e.RowIndex].Cells[0].Value;
                // 代码可以简洁些，但是写完后就不想改了
                updatedUserModel.UserID = userID;
                updatedUserModel.Username = (string)UserDataGridView.Rows[e.RowIndex].Cells["Username"].Value;
                updatedUserModel.Email = (string)UserDataGridView.Rows[e.RowIndex].Cells["Email"].Value;
                updatedUserModel.Status = (string)UserDataGridView.Rows[e.RowIndex].Cells["Status"].Value;
                // 在这里添加更新数据库的代码，将 newValue 更新到数据库中对应的 UserID 记录
                if (userBll.updatedUserByUserID(userID, updatedUserModel) != 1)
                {
                    MessageBox.Show("更新用户信息失败！");
                }
            }
        }

        private void MovieDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("不能更新movieId!");
                reload();
            }

            if (e.ColumnIndex == 6)
            {
                MessageBox.Show("电影平均评分不能更改");
                reload();
            }

            if (e.RowIndex >= 0 && e.ColumnIndex > 0)
            {
                // 获取修改后的值
                MovieModel updateMovieModel = new MovieModel();
                int movieID = (int)MovieDataGridView.Rows[e.RowIndex].Cells[0].Value;
                updateMovieModel.MovieID = movieID;
                updateMovieModel.Title = (string)MovieDataGridView.Rows[e.RowIndex].Cells["Title"].Value;
                updateMovieModel.Genre = (string)MovieDataGridView.Rows[e.RowIndex].Cells["Genre"].Value;
                updateMovieModel.ReleaseYear = (int)MovieDataGridView.Rows[e.RowIndex].Cells["ReleaseYear"].Value;
                updateMovieModel.Director = (string)MovieDataGridView.Rows[e.RowIndex].Cells["Director"].Value;
                updateMovieModel.Description = (string)MovieDataGridView.Rows[e.RowIndex].Cells["Description"].Value;
                // 在这里添加更新数据库的代码，将 newValue 更新到数据库中对应的 UserID 记录
                if (movieBll.updatedMovieByMovieID(movieID, updateMovieModel) != 1)
                {
                    MessageBox.Show("更新电影信息失败！");
                }
            }
        }

        private void reload()
        {
            Hide();
            AdminForm newAdminForm = new AdminForm();
            newAdminForm.StartPosition = FormStartPosition.CenterScreen;
            newAdminForm.ShowDialog();
            Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Hide();
            GlobalData.UserId = -1;
            LoginForm loginForm = new LoginForm();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.ShowDialog();
        }
    }
}