using System.ComponentModel;

namespace movieRatingSystem.UI;

partial class AboutMeForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        label1 = new Label();
        RateMovieDataGridView = new DataGridView();
        label2 = new Label();
        UserInfoRichTextBox = new RichTextBox();
        returnPre = new Button();
        ExportMovieNameButton = new Button();
        avatarPictureBox = new PictureBox();
        ((ISupportInitialize)RateMovieDataGridView).BeginInit();
        ((ISupportInitialize)avatarPictureBox).BeginInit();
        SuspendLayout();
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(87, 47);
        label1.Name = "label1";
        label1.Size = new Size(99, 20);
        label1.TabIndex = 0;
        label1.Text = "我看过的电影";
        // 
        // RateMovieDataGridView
        // 
        RateMovieDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        RateMovieDataGridView.Location = new Point(72, 88);
        RateMovieDataGridView.Name = "RateMovieDataGridView";
        RateMovieDataGridView.RowHeadersWidth = 51;
        RateMovieDataGridView.Size = new Size(377, 268);
        RateMovieDataGridView.TabIndex = 1;
        RateMovieDataGridView.CellContentClick += RateMovieDataGridView_CellContentClick;
        RateMovieDataGridView.CellValueChanged += RateMovieDataGridView_CellValueChanged;
        RateMovieDataGridView.DataError += RateMovieDataGridView_DataError;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(587, 53);
        label2.Name = "label2";
        label2.Size = new Size(69, 20);
        label2.TabIndex = 2;
        label2.Text = "我的信息";
        // 
        // UserInfoRichTextBox
        // 
        UserInfoRichTextBox.Location = new Point(540, 88);
        UserInfoRichTextBox.Name = "UserInfoRichTextBox";
        UserInfoRichTextBox.ReadOnly = true;
        UserInfoRichTextBox.Size = new Size(216, 268);
        UserInfoRichTextBox.TabIndex = 3;
        UserInfoRichTextBox.Text = "";
        // 
        // returnPre
        // 
        returnPre.Location = new Point(540, 409);
        returnPre.Name = "returnPre";
        returnPre.Size = new Size(94, 29);
        returnPre.TabIndex = 4;
        returnPre.Text = "返回";
        returnPre.UseVisualStyleBackColor = true;
        returnPre.Click += returnPre_Click;
        // 
        // ExportMovieNameButton
        // 
        ExportMovieNameButton.Location = new Point(294, 409);
        ExportMovieNameButton.Name = "ExportMovieNameButton";
        ExportMovieNameButton.Size = new Size(155, 29);
        ExportMovieNameButton.TabIndex = 5;
        ExportMovieNameButton.Text = "导出电影名称列表";
        ExportMovieNameButton.UseVisualStyleBackColor = true;
        ExportMovieNameButton.Click += ExportMovieNameButton_Click;
        // 
        // avatarPictureBox
        // 
        avatarPictureBox.Location = new Point(663, 20);
        avatarPictureBox.Name = "avatarPictureBox";
        avatarPictureBox.Size = new Size(93, 62);
        avatarPictureBox.TabIndex = 6;
        avatarPictureBox.TabStop = false;
        // 
        // AboutMeForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(avatarPictureBox);
        Controls.Add(ExportMovieNameButton);
        Controls.Add(returnPre);
        Controls.Add(UserInfoRichTextBox);
        Controls.Add(label2);
        Controls.Add(RateMovieDataGridView);
        Controls.Add(label1);
        Name = "AboutMeForm";
        Text = "AboutMe";
        Load += AboutMeForm_Load;
        ((ISupportInitialize)RateMovieDataGridView).EndInit();
        ((ISupportInitialize)avatarPictureBox).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label label1;
    private DataGridView RateMovieDataGridView;
    private Label label2;
    private RichTextBox UserInfoRichTextBox;
    private Button returnPre;
    private Button ExportMovieNameButton;
    private PictureBox avatarPictureBox;
}