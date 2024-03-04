namespace movieRatingSystem.UI
{
    partial class RegisterForm
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
            NameTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            NameLabel = new Label();
            PasswordLabel = new Label();
            EmaiLabel = new Label();
            EmailTextBox = new TextBox();
            label1 = new Label();
            confrimPasswordTextBox = new TextBox();
            RegisterButton = new Button();
            SuspendLayout();
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(337, 128);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(117, 27);
            NameTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Location = new Point(337, 178);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new Size(117, 27);
            PasswordTextBox.TabIndex = 1;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(260, 133);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(49, 20);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "name";
            // 
            // PasswordLabel
            // 
            PasswordLabel.AutoSize = true;
            PasswordLabel.Location = new Point(244, 181);
            PasswordLabel.Name = "PasswordLabel";
            PasswordLabel.Size = new Size(79, 20);
            PasswordLabel.TabIndex = 3;
            PasswordLabel.Text = "password";
            // 
            // EmaiLabel
            // 
            EmaiLabel.AutoSize = true;
            EmaiLabel.Location = new Point(244, 299);
            EmaiLabel.Name = "EmaiLabel";
            EmaiLabel.Size = new Size(47, 20);
            EmaiLabel.TabIndex = 4;
            EmaiLabel.Text = "Email";
            // 
            // EmailTextBox
            // 
            EmailTextBox.Location = new Point(337, 296);
            EmailTextBox.Name = "EmailTextBox";
            EmailTextBox.Size = new Size(117, 27);
            EmailTextBox.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(181, 241);
            label1.Name = "label1";
            label1.Size = new Size(142, 20);
            label1.TabIndex = 7;
            label1.Text = "confirm_password";
            label1.Click += label1_Click;
            // 
            // confrimPasswordTextBox
            // 
            confrimPasswordTextBox.Location = new Point(337, 238);
            confrimPasswordTextBox.Name = "confrimPasswordTextBox";
            confrimPasswordTextBox.Size = new Size(117, 27);
            confrimPasswordTextBox.TabIndex = 6;
            // 
            // RegisterButton
            // 
            RegisterButton.Location = new Point(337, 359);
            RegisterButton.Name = "RegisterButton";
            RegisterButton.Size = new Size(94, 29);
            RegisterButton.TabIndex = 8;
            RegisterButton.Text = "注册";
            RegisterButton.UseVisualStyleBackColor = true;
            RegisterButton.Click += RegisterButton_Click;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(RegisterButton);
            Controls.Add(label1);
            Controls.Add(confrimPasswordTextBox);
            Controls.Add(EmailTextBox);
            Controls.Add(EmaiLabel);
            Controls.Add(PasswordLabel);
            Controls.Add(NameLabel);
            Controls.Add(PasswordTextBox);
            Controls.Add(NameTextBox);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameTextBox;
        private TextBox PasswordTextBox;
        private Label NameLabel;
        private Label PasswordLabel;
        private Label EmaiLabel;
        private TextBox EmailTextBox;
        private Label label1;
        private TextBox confrimPasswordTextBox;
        private Button RegisterButton;
    }
}