namespace OursMarble
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
            this.GameBoard = new System.Windows.Forms.PictureBox();
            this.Dice_Start = new System.Windows.Forms.Button();
            this.dice1 = new System.Windows.Forms.PictureBox();
            this.dice2 = new System.Windows.Forms.PictureBox();
            this.log = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_account = new System.Windows.Forms.Label();
            this.Ready_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).BeginInit();
            this.SuspendLayout();
            // 
            // GameBoard
            // 
            this.GameBoard.BackColor = System.Drawing.SystemColors.Window;
            this.GameBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameBoard.Location = new System.Drawing.Point(12, 12);
            this.GameBoard.Name = "GameBoard";
            this.GameBoard.Size = new System.Drawing.Size(540, 540);
            this.GameBoard.TabIndex = 0;
            this.GameBoard.TabStop = false;
            this.GameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Dice_Start
            // 
            this.Dice_Start.Location = new System.Drawing.Point(720, 477);
            this.Dice_Start.Name = "Dice_Start";
            this.Dice_Start.Size = new System.Drawing.Size(68, 74);
            this.Dice_Start.TabIndex = 1;
            this.Dice_Start.Text = "주사위\r\n굴리기";
            this.Dice_Start.UseVisualStyleBackColor = true;
            this.Dice_Start.Click += new System.EventHandler(this.button1_Click);
            // 
            // dice1
            // 
            this.dice1.Location = new System.Drawing.Point(558, 477);
            this.dice1.Name = "dice1";
            this.dice1.Size = new System.Drawing.Size(75, 75);
            this.dice1.TabIndex = 2;
            this.dice1.TabStop = false;
            // 
            // dice2
            // 
            this.dice2.Location = new System.Drawing.Point(639, 477);
            this.dice2.Name = "dice2";
            this.dice2.Size = new System.Drawing.Size(75, 75);
            this.dice2.TabIndex = 3;
            this.dice2.TabStop = false;
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(558, 66);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.Size = new System.Drawing.Size(230, 390);
            this.log.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "현재 잔액: ";
            // 
            // label_account
            // 
            this.label_account.AutoSize = true;
            this.label_account.Location = new System.Drawing.Point(725, 459);
            this.label_account.Name = "label_account";
            this.label_account.Size = new System.Drawing.Size(63, 15);
            this.label_account.TabIndex = 6;
            this.label_account.Text = "10000000";
            this.label_account.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Ready_Button
            // 
            this.Ready_Button.Location = new System.Drawing.Point(558, 12);
            this.Ready_Button.Name = "Ready_Button";
            this.Ready_Button.Size = new System.Drawing.Size(66, 48);
            this.Ready_Button.TabIndex = 7;
            this.Ready_Button.Text = "게임\r\n준비";
            this.Ready_Button.UseVisualStyleBackColor = true;
            this.Ready_Button.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 564);
            this.Controls.Add(this.Ready_Button);
            this.Controls.Add(this.label_account);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.dice2);
            this.Controls.Add(this.dice1);
            this.Controls.Add(this.Dice_Start);
            this.Controls.Add(this.GameBoard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GameBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dice2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox GameBoard;
        private System.Windows.Forms.Button Dice_Start;
        private System.Windows.Forms.PictureBox dice1;
        private System.Windows.Forms.PictureBox dice2;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_account;
        private System.Windows.Forms.Button Ready_Button;
    }
}

