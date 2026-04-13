namespace QuizApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBox1 = new ListBox();
            button1 = new Button();
            labelQuestion = new Label();
            btnOption1 = new Button();
            btnOption2 = new Button();
            btnOption3 = new Button();
            btnOption4 = new Button();
            btnNext = new Button();
            lblScore = new Label();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(32, 160);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(706, 196);
            listBox1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(626, 362);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 1;
            button1.Text = "Load Questions";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            labelQuestion.AutoSize = false;
            labelQuestion.Location = new Point(32, 24);
            labelQuestion.Size = new Size(706, 48);
            labelQuestion.Font = new Font(labelQuestion.Font.FontFamily, 12);
            labelQuestion.Name = "labelQuestion";

            int optY = 80;
            btnOption1.Location = new Point(32, optY);
            btnOption1.Size = new Size(340, 34);
            btnOption1.Name = "btnOption1";

            btnOption2.Location = new Point(398, optY);
            btnOption2.Size = new Size(340, 34);
            btnOption2.Name = "btnOption2";

            btnOption3.Location = new Point(32, optY + 44);
            btnOption3.Size = new Size(340, 34);
            btnOption3.Name = "btnOption3";

            btnOption4.Location = new Point(398, optY + 44);
            btnOption4.Size = new Size(340, 34);
            btnOption4.Name = "btnOption4";

            btnNext.Location = new Point(498, 362);
            btnNext.Size = new Size(112, 34);
            btnNext.Name = "btnNext";
            btnNext.Text = "Next";
            btnNext.UseVisualStyleBackColor = true;

            lblScore.Location = new Point(32, 362);
            lblScore.Size = new Size(200, 34);
            lblScore.Name = "lblScore";
            lblScore.Text = "Score: 0";

            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(listBox1);
            Controls.Add(labelQuestion);
            Controls.Add(btnOption1);
            Controls.Add(btnOption2);
            Controls.Add(btnOption3);
            Controls.Add(btnOption4);
            Controls.Add(btnNext);
            Controls.Add(lblScore);
            Name = "Form1";
            Text = "QuizApp";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private Button button1;
        private Label labelQuestion;
        private Button btnOption1;
        private Button btnOption2;
        private Button btnOption3;
        private Button btnOption4;
        private Button btnNext;
        private Label lblScore;
    }
}
