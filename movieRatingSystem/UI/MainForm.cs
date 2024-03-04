using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using movieRatingSystem.Bll;

namespace movieRatingSystem.UI
{
    public partial class MainForm : Form
    {
        private MovieBll movieBll;

        public MainForm()
        {
            InitializeComponent();
            Initial();
        }

        private void Initial()
        {
            movieBll = new MovieBll();
            //MessageBox.Show("主页面初始化成功！");
            MovieNameListBox.Name = "done";
            List<string> allMovieName = movieBll.GetAllMovieName();
            foreach (string s in allMovieName)
            {
                MessageBox.Show(s);
            }
        }
    }
}