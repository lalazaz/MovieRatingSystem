namespace movieRatingSystem.UI
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AddMovieButton = new Button();
            timer_1s = new System.Windows.Forms.Timer(components);
            UserDataGridView = new DataGridView();
            MovieDataGridView = new DataGridView();
            splitContainer1 = new SplitContainer();
            ExitButton = new Button();
            StopAddMovieButton = new Button();
            AddMovieProgressBar = new ProgressBar();
            ((System.ComponentModel.ISupportInitialize)UserDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)MovieDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // AddMovieButton
            // 
            AddMovieButton.Location = new Point(1218, 49);
            AddMovieButton.Name = "AddMovieButton";
            AddMovieButton.Size = new Size(115, 36);
            AddMovieButton.TabIndex = 3;
            AddMovieButton.Text = "自动20条添加电影";
            AddMovieButton.UseVisualStyleBackColor = true;
            AddMovieButton.Click += AddMovieButton_Click;
            // 
            // timer_1s
            // 
            timer_1s.Interval = 1000;
            timer_1s.Tick += timer_1s_Tick;
            // 
            // UserDataGridView
            // 
            UserDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            UserDataGridView.Location = new Point(36, 0);
            UserDataGridView.Name = "UserDataGridView";
            UserDataGridView.RowHeadersWidth = 51;
            UserDataGridView.Size = new Size(478, 288);
            UserDataGridView.TabIndex = 4;
            UserDataGridView.CellValueChanged += UserDataGridView_CellValueChanged;
            // 
            // MovieDataGridView
            // 
            MovieDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            MovieDataGridView.Location = new Point(3, -20);
            MovieDataGridView.Name = "MovieDataGridView";
            MovieDataGridView.RowHeadersWidth = 51;
            MovieDataGridView.Size = new Size(517, 340);
            MovieDataGridView.TabIndex = 5;
            MovieDataGridView.CellValueChanged += MovieDataGridView_CellValueChanged;
            // 
            // splitContainer1
            // 
            splitContainer1.Location = new Point(12, 1);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(UserDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(MovieDataGridView);
            splitContainer1.Size = new Size(1200, 300);
            splitContainer1.SplitterDistance = 528;
            splitContainer1.TabIndex = 6;
            // 
            // ExitButton
            // 
            ExitButton.Location = new Point(1218, 368);
            ExitButton.Name = "ExitButton";
            ExitButton.Size = new Size(115, 29);
            ExitButton.TabIndex = 7;
            ExitButton.Text = "退出";
            ExitButton.UseVisualStyleBackColor = true;
            ExitButton.Click += ExitButton_Click;
            // 
            // StopAddMovieButton
            // 
            StopAddMovieButton.Location = new Point(1218, 112);
            StopAddMovieButton.Name = "StopAddMovieButton";
            StopAddMovieButton.Size = new Size(115, 29);
            StopAddMovieButton.TabIndex = 8;
            StopAddMovieButton.Text = "停止添加电影";
            StopAddMovieButton.UseVisualStyleBackColor = true;
            StopAddMovieButton.Click += StopAddMovieButton_Click;
            // 
            // AddMovieProgressBar
            // 
            AddMovieProgressBar.Location = new Point(1218, 194);
            AddMovieProgressBar.Maximum = 20;
            AddMovieProgressBar.Name = "AddMovieProgressBar";
            AddMovieProgressBar.Size = new Size(125, 29);
            AddMovieProgressBar.TabIndex = 9;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1399, 590);
            Controls.Add(AddMovieProgressBar);
            Controls.Add(StopAddMovieButton);
            Controls.Add(ExitButton);
            Controls.Add(splitContainer1);
            Controls.Add(AddMovieButton);
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            ((System.ComponentModel.ISupportInitialize)UserDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)MovieDataGridView).EndInit();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Button AddMovieButton;
        private System.Windows.Forms.Timer timer_1s;
        private DataGridView UserDataGridView;
        private DataGridView MovieDataGridView;
        private SplitContainer splitContainer1;
        private Button ExitButton;
        private Button StopAddMovieButton;
        private ProgressBar AddMovieProgressBar;
    }
}