namespace WindowsFormsApplication1
{
    partial class Parser
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
            this.textBoxURL = new System.Windows.Forms.TextBox();
            this.buttonParse = new System.Windows.Forms.Button();
            this.textBoxIR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonShuffle = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxURL
            // 
            this.textBoxURL.Location = new System.Drawing.Point(12, 12);
            this.textBoxURL.Name = "textBoxURL";
            this.textBoxURL.Size = new System.Drawing.Size(284, 20);
            this.textBoxURL.TabIndex = 0;
            // 
            // buttonParse
            // 
            this.buttonParse.Location = new System.Drawing.Point(13, 35);
            this.buttonParse.Name = "buttonParse";
            this.buttonParse.Size = new System.Drawing.Size(283, 23);
            this.buttonParse.TabIndex = 1;
            this.buttonParse.Text = "Parse!";
            this.buttonParse.UseVisualStyleBackColor = true;
            this.buttonParse.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxIR
            // 
            this.textBoxIR.Location = new System.Drawing.Point(56, 64);
            this.textBoxIR.Name = "textBoxIR";
            this.textBoxIR.Size = new System.Drawing.Size(60, 20);
            this.textBoxIR.TabIndex = 2;
            this.textBoxIR.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "index";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(196, 60);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 4;
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(13, 90);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(283, 20);
            this.textBoxPath.TabIndex = 5;
            this.textBoxPath.Text = "D:\\Учеба\\Text categorization\\Выборки\\MD";
            this.textBoxPath.TextChanged += new System.EventHandler(this.textBoxPath_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 144);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "объединить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // buttonShuffle
            // 
            this.buttonShuffle.Location = new System.Drawing.Point(189, 144);
            this.buttonShuffle.Name = "buttonShuffle";
            this.buttonShuffle.Size = new System.Drawing.Size(107, 23);
            this.buttonShuffle.TabIndex = 7;
            this.buttonShuffle.Text = "Перемешать";
            this.buttonShuffle.UseVisualStyleBackColor = true;
            this.buttonShuffle.Click += new System.EventHandler(this.buttonShuffle_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Кодировка";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(13, 243);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(103, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "Переименовать";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(189, 243);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(107, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Перевод";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 173);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(105, 34);
            this.button5.TabIndex = 11;
            this.button5.Text = "Объединить в памяти";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Parser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 302);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonShuffle);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxIR);
            this.Controls.Add(this.buttonParse);
            this.Controls.Add(this.textBoxURL);
            this.Name = "Parser";
            this.Text = "Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxURL;
        private System.Windows.Forms.Button buttonParse;
        private System.Windows.Forms.TextBox textBoxIR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonShuffle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

