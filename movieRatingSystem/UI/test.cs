using MySql.Data.MySqlClient;

namespace movieRatingSystem
{
    public partial class test : Form
    {
        public test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("show all movie and rating information!");
            string sql = "select Title from Movies";
            string conStr = "server=localhost;user id=root;password=123456;database=movie_rating_system";
            MySqlConnection connection = new MySqlConnection(conStr);
            connection.Open();
            //MessageBox.Show("连接成功！");
            MySqlCommand command = new MySqlCommand(sql,connection);
            MySqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader.GetString(0).ToString();
            }
            reader.Close();
            connection.Close();
        }
    }
}
