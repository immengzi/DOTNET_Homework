namespace Bank
{
    partial class Bank_Console
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
            label1 = new Label();
            panel1 = new Panel();
            button1 = new Button();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            button2 = new Button();
            textBox3 = new TextBox();
            label5 = new Label();
            textBox4 = new TextBox();
            label6 = new Label();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 49);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 0;
            label1.Text = "珞珈山银行";
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(80, 112);
            panel1.Name = "panel1";
            panel1.Size = new Size(262, 268);
            panel1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(94, 196);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "登录";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(85, 129);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 23);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(44, 132);
            label4.Name = "label4";
            label4.Size = new Size(35, 17);
            label4.TabIndex = 3;
            label4.Text = "密码:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(85, 85);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 23);
            textBox1.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(44, 88);
            label3.Name = "label3";
            label3.Size = new Size(35, 17);
            label3.TabIndex = 1;
            label3.Text = "账号:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(110, 14);
            label2.Name = "label2";
            label2.Size = new Size(42, 17);
            label2.TabIndex = 0;
            label2.Text = "ATM1";
            // 
            // panel2
            // 
            panel2.Controls.Add(button2);
            panel2.Controls.Add(textBox3);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(textBox4);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label7);
            panel2.Location = new Point(451, 112);
            panel2.Name = "panel2";
            panel2.Size = new Size(262, 268);
            panel2.TabIndex = 6;
            // 
            // button2
            // 
            button2.Location = new Point(94, 196);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "登录";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(85, 129);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(114, 23);
            textBox3.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(44, 132);
            label5.Name = "label5";
            label5.Size = new Size(35, 17);
            label5.TabIndex = 3;
            label5.Text = "密码:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(85, 85);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(114, 23);
            textBox4.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(44, 88);
            label6.Name = "label6";
            label6.Size = new Size(35, 17);
            label6.TabIndex = 1;
            label6.Text = "账号:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(110, 14);
            label7.Name = "label7";
            label7.Size = new Size(42, 17);
            label7.TabIndex = 0;
            label7.Text = "ATM2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Button button1;
        private TextBox textBox2;
        private Label label4;
        private Panel panel2;
        private Button button2;
        private TextBox textBox3;
        private Label label5;
        private TextBox textBox4;
        private Label label6;
        private Label label7;
    }
}