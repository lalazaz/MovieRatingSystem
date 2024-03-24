using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using movieRatingSystem.Bll;
using movieRatingSystem.Common;
using movieRatingSystem.Model;

namespace movieRatingSystem.UI;

public partial class AboutMeForm : Form
{
    private UserBll userBll;

    private RatingBll ratingBll;

    //默认头像图片存放地址 这里的winform写错了。。
    private string defaultAvatarPath = @"D:\\Code\\winfrom\\movieRatingSystem\\avatar_files";

    // 引用头像图片的流
    private FileStream avatarFileStream;

    // 头像图片的阈值
    private long maxFileSizeInBytes = 1024 * 1024;

    public AboutMeForm()
    {
        userBll = new UserBll();
        ratingBll = new RatingBll();
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

            //MessageBox.Show($"you clicked on row {selectedRowIndex}, Title: {title}, Rating: {rating}");
        }
    }

    // 返回到MainForm.cs
    private void returnPre_Click(object sender, EventArgs e)
    {
        Close();
        //new MainForm().Show();
    }

    // 用户在个人界面对电影评分进行更改
    // 用户更改GridViewData，进行判断，只能更改评分，更改名字无效，更改评分后触发下面事件，对评分进行格式判断，然后找到对应的行根据电影名字更新到ratings表
    // 只能一行一行的更改，因为这个事件触发也就是一行更改后点击另一方就触发
    private void RateMovieDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("电影名字无法更改，请重新进入我的页面");
                reload();
                return;
            }

            object cellValue = RateMovieDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            // 处理单元格值更改的逻辑
            bool isMatch = new Regex("^[0-9]").IsMatch(cellValue.ToString());
            //MessageBox.Show("匹配的字符串为：" + cellValue.ToString() + isMatch);
            //MessageBox.Show(isMatch + "-"+cellValue);
            if (!isMatch ||
                !int.TryParse(cellValue.ToString(), out int numericRate) || numericRate < 0 || numericRate > 10)
            {
                MessageBox.Show("评分输入不合法，请输入0-10的整数。");
                reload();
                return;
            }

            //MessageBox.Show($"Cell value changed at row {e.RowIndex}, column {e.ColumnIndex}. New value: {cellValue}");
            string? movieName = RateMovieDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString();
            decimal updatedRating = (decimal)RateMovieDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            //MessageBox.Show($"改变评分的电影名字:{movieName}");
            int changeRatingByMovieNameAndUserId = ratingBll.changeRatingByMovieNameAndUserID(
                new MovieNameAndUserID(movieName, GlobalData.UserId),
                updatedRating
            );
            if (changeRatingByMovieNameAndUserId == 1)
            {
                MessageBox.Show("更新评分成功！");
            }
            else
            {
                MessageBox.Show("更新评分失败！");
            }
        }
    }

    //  这里更改评分为字母有异常，以及前面的评分可能也有
    private void RateMovieDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
    {
        if (e.Exception is FormatException)
        {
            MessageBox.Show("评分只能为数字，请输入0-10的整数。");
            reload();
        }
    }

    private void reload()
    {
        Hide();
        AboutMeForm newAboutMeForm = new AboutMeForm();
        newAboutMeForm.StartPosition = FormStartPosition.CenterScreen;
        newAboutMeForm.ShowDialog();
        Close();
    }

    // todo 
    private void ExportMovieNameButton_Click(object sender, EventArgs e)
    {
    }

    private void AboutMeForm_Load(object sender, EventArgs e)
    {
        string defaultFilePath = defaultAvatarPath + "\\default.png";
        string myAvatarPath = defaultAvatarPath + "\\" + GlobalData.UserId + ".png";

        string targetFilePath = File.Exists(myAvatarPath) ? myAvatarPath : defaultFilePath;
        //再判断一下吧
        if (File.Exists(targetFilePath))
        {
            avatarFileStream = new FileStream(targetFilePath, FileMode.Open, FileAccess.Read);

            // Image originalImage = Image.FromFile(targetFilePath);
            // 使用流中读取，后面释放流就可以释放缓存
            Image originalImage = Image.FromStream(avatarFileStream);
            avatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            avatarPictureBox.Image = ResizeImage(originalImage, avatarPictureBox.Size);
        }
    }

    // 调整头像图片显示大小的方法
    private Image ResizeImage(Image image, Size newSize)
    {
        Bitmap newImage = new Bitmap(newSize.Width, newSize.Height);
        using (Graphics g = Graphics.FromImage(newImage))
        {
            g.DrawImage(image, new Rectangle(Point.Empty, newSize));
        }

        return newImage;
    }

    private void avatarPictureBox_Click(object sender, EventArgs e)
    {
        // 打开文件对话框，选择图片文件
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|All files (*.*)|*.*";
        try
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 加载选定的图片文件
                string imagePath = openFileDialog.FileName;
                Image originalImage = Image.FromFile(imagePath);
                // 将上传的图片放到文件夹中，如果已经存在则删除文件夹的文件，使用这个
                reloadPicture(originalImage);
                // 将图片调整为适应 PictureBox 控件大小
                avatarPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                avatarPictureBox.Image = ResizeImage(originalImage, avatarPictureBox.Size);
            }
        }
        catch (Exception exception)
        {
            MessageBox.Show("出错了" + exception);
        }
    }

    // 更换头像，如果使用默认头像则将新上传头像放到文件夹中，如果原来已经有，则将原来已经有的使用userid+时间戳放到delete中，再存入现在的
    private void reloadPicture(Image inputImage)
    {
        if (!File.Exists(defaultAvatarPath + "\\" + GlobalData.UserId + ".png"))
        {
            inputImage.Save(defaultAvatarPath + "\\" + GlobalData.UserId + ".png",
                ImageFormat.Png);
        }
        else
        {
            if (!Directory.Exists(defaultAvatarPath + "\\delete"))
            {
                Directory.CreateDirectory(defaultAvatarPath + "\\delete");
            }

            File.Copy(defaultAvatarPath + "\\" + GlobalData.UserId + ".png",
                defaultAvatarPath + "\\delete" + "\\" + GlobalData.UserId + "_" +
                DateTimeOffset.UtcNow.ToUnixTimeSeconds() + ".png");
            ResizeImage(Image.FromFile(defaultAvatarPath + "\\default.png"), avatarPictureBox.Size);

            //使用原来图片的引用
            avatarFileStream.Close();
            avatarFileStream.Dispose();

            File.Delete(defaultAvatarPath + "\\" + GlobalData.UserId + ".png");

            // todo 这里图片超过大小进行压缩
            inputImage.Save(defaultAvatarPath + "\\" + GlobalData.UserId + ".png", ImageFormat.Png);
        }
    }
}