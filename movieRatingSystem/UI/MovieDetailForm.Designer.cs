using System.ComponentModel;

namespace movieRatingSystem.UI;

partial class MovieDetailForm
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
        MovieDetailPropertyGrid = new PropertyGrid();
        rateButton = new Button();
        RateTextBox = new TextBox();
        tableLayoutPanel1 = new TableLayoutPanel();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // MovieDetailPropertyGrid
        // 
        MovieDetailPropertyGrid.Location = new Point(3, 3);
        MovieDetailPropertyGrid.Name = "MovieDetailPropertyGrid";
        MovieDetailPropertyGrid.Size = new Size(349, 227);
        MovieDetailPropertyGrid.TabIndex = 0;
        // 
        // rateButton
        // 
        rateButton.Location = new Point(393, 236);
        rateButton.Name = "rateButton";
        rateButton.Size = new Size(125, 27);
        rateButton.TabIndex = 1;
        rateButton.Text = "评分";
        rateButton.UseVisualStyleBackColor = true;
        rateButton.Click += rateButton_Click;
        // 
        // RateTextBox
        // 
        RateTextBox.Location = new Point(3, 236);
        RateTextBox.Name = "RateTextBox";
        RateTextBox.Size = new Size(125, 27);
        RateTextBox.TabIndex = 2;
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 74.00379F));
        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25.9962044F));
        tableLayoutPanel1.Controls.Add(MovieDetailPropertyGrid, 0, 0);
        tableLayoutPanel1.Controls.Add(rateButton, 1, 1);
        tableLayoutPanel1.Controls.Add(RateTextBox, 0, 1);
        tableLayoutPanel1.Location = new Point(130, 45);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 2;
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 87.59399F));
        tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.4060154F));
        tableLayoutPanel1.Size = new Size(527, 266);
        tableLayoutPanel1.TabIndex = 3;
        // 
        // MovieDetailForm
        // 
        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        Name = "MovieDetailForm";
        Text = "MovieDetailForm";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private PropertyGrid MovieDetailPropertyGrid;
    private Button rateButton;
    private TextBox RateTextBox;
    private TableLayoutPanel tableLayoutPanel1;
}