namespace Checkers_Game
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.m_buttonDone = new System.Windows.Forms.Button();
            this.m_Label1 = new System.Windows.Forms.Label();
            this.m_RadioButtonSize6 = new System.Windows.Forms.RadioButton();
            this.m_RadioButtonSize8 = new System.Windows.Forms.RadioButton();
            this.m_RadioButtonSize10 = new System.Windows.Forms.RadioButton();
            this.m_Label2 = new System.Windows.Forms.Label();
            this.m_Label3 = new System.Windows.Forms.Label();
            this.m_CheckBoxPlayer2 = new System.Windows.Forms.CheckBox();
            this.m_TextBoxPlayer1Name = new System.Windows.Forms.TextBox();
            this.m_TextBoxPlayer2Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_buttonDone
            // 
            this.m_buttonDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonDone.Location = new System.Drawing.Point(460, 372);
            this.m_buttonDone.Margin = new System.Windows.Forms.Padding(5);
            this.m_buttonDone.Name = "m_buttonDone";
            this.m_buttonDone.Size = new System.Drawing.Size(103, 37);
            this.m_buttonDone.TabIndex = 2;
            this.m_buttonDone.Text = "Done";
            this.m_buttonDone.UseVisualStyleBackColor = true;
            this.m_buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // m_Label1
            // 
            this.m_Label1.AutoSize = true;
            this.m_Label1.Location = new System.Drawing.Point(41, 44);
            this.m_Label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.m_Label1.Name = "m_Label1";
            this.m_Label1.Size = new System.Drawing.Size(115, 25);
            this.m_Label1.TabIndex = 1;
            this.m_Label1.Text = "Board Size:";
            // 
            // m_RadioButtonSize6
            // 
            this.m_RadioButtonSize6.AutoSize = true;
            this.m_RadioButtonSize6.Location = new System.Drawing.Point(132, 74);
            this.m_RadioButtonSize6.Margin = new System.Windows.Forms.Padding(5);
            this.m_RadioButtonSize6.Name = "m_RadioButtonSize6";
            this.m_RadioButtonSize6.Size = new System.Drawing.Size(66, 29);
            this.m_RadioButtonSize6.TabIndex = 2;
            this.m_RadioButtonSize6.TabStop = true;
            this.m_RadioButtonSize6.Text = "6x6";
            this.m_RadioButtonSize6.UseVisualStyleBackColor = true;
            // 
            // m_RadioButtonSize8
            // 
            this.m_RadioButtonSize8.AutoSize = true;
            this.m_RadioButtonSize8.Location = new System.Drawing.Point(263, 74);
            this.m_RadioButtonSize8.Margin = new System.Windows.Forms.Padding(5);
            this.m_RadioButtonSize8.Name = "m_RadioButtonSize8";
            this.m_RadioButtonSize8.Size = new System.Drawing.Size(66, 29);
            this.m_RadioButtonSize8.TabIndex = 3;
            this.m_RadioButtonSize8.TabStop = true;
            this.m_RadioButtonSize8.Text = "8x8";
            this.m_RadioButtonSize8.UseVisualStyleBackColor = true;
            // 
            // m_RadioButtonSize10
            // 
            this.m_RadioButtonSize10.AutoSize = true;
            this.m_RadioButtonSize10.Location = new System.Drawing.Point(376, 74);
            this.m_RadioButtonSize10.Margin = new System.Windows.Forms.Padding(5);
            this.m_RadioButtonSize10.Name = "m_RadioButtonSize10";
            this.m_RadioButtonSize10.Size = new System.Drawing.Size(88, 29);
            this.m_RadioButtonSize10.TabIndex = 4;
            this.m_RadioButtonSize10.TabStop = true;
            this.m_RadioButtonSize10.Text = "10x10";
            this.m_RadioButtonSize10.UseVisualStyleBackColor = true;
            // 
            // m_Label2
            // 
            this.m_Label2.AutoSize = true;
            this.m_Label2.Location = new System.Drawing.Point(41, 138);
            this.m_Label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.m_Label2.Name = "m_Label2";
            this.m_Label2.Size = new System.Drawing.Size(85, 25);
            this.m_Label2.TabIndex = 5;
            this.m_Label2.Text = "Players:";
            // 
            // m_Label3
            // 
            this.m_Label3.AutoSize = true;
            this.m_Label3.Location = new System.Drawing.Point(110, 194);
            this.m_Label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.m_Label3.Name = "m_Label3";
            this.m_Label3.Size = new System.Drawing.Size(91, 25);
            this.m_Label3.TabIndex = 6;
            this.m_Label3.Text = "Player 1:";
            // 
            // m_CheckBoxPlayer2
            // 
            this.m_CheckBoxPlayer2.AutoSize = true;
            this.m_CheckBoxPlayer2.Location = new System.Drawing.Point(82, 263);
            this.m_CheckBoxPlayer2.Margin = new System.Windows.Forms.Padding(5);
            this.m_CheckBoxPlayer2.Name = "m_CheckBoxPlayer2";
            this.m_CheckBoxPlayer2.Size = new System.Drawing.Size(113, 29);
            this.m_CheckBoxPlayer2.TabIndex = 8;
            this.m_CheckBoxPlayer2.Text = "Player 2:";
            this.m_CheckBoxPlayer2.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2.CheckedChanged += new System.EventHandler(this.CheckBoxPlayer2_CheckedChanged);
            // 
            // m_TextBoxPlayer1Name
            // 
            this.m_TextBoxPlayer1Name.BackColor = System.Drawing.SystemColors.Info;
            this.m_TextBoxPlayer1Name.Location = new System.Drawing.Point(266, 194);
            this.m_TextBoxPlayer1Name.Margin = new System.Windows.Forms.Padding(5);
            this.m_TextBoxPlayer1Name.MaxLength = 10;
            this.m_TextBoxPlayer1Name.Name = "m_TextBoxPlayer1Name";
            this.m_TextBoxPlayer1Name.Size = new System.Drawing.Size(213, 47);
            this.m_TextBoxPlayer1Name.TabIndex = 0;
            // 
            // m_TextBoxPlayer2Name
            // 
            this.m_TextBoxPlayer2Name.BackColor = System.Drawing.SystemColors.Info;
            this.m_TextBoxPlayer2Name.Enabled = false;
            this.m_TextBoxPlayer2Name.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.m_TextBoxPlayer2Name.Location = new System.Drawing.Point(266, 263);
            this.m_TextBoxPlayer2Name.Margin = new System.Windows.Forms.Padding(5);
            this.m_TextBoxPlayer2Name.MaxLength = 10;
            this.m_TextBoxPlayer2Name.Name = "m_TextBoxPlayer2Name";
            this.m_TextBoxPlayer2Name.Size = new System.Drawing.Size(213, 47);
            this.m_TextBoxPlayer2Name.TabIndex = 1;
            this.m_TextBoxPlayer2Name.Text = "Computer";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.BackgroundImage = global::Checkers_Game.Properties.Resources.Checkers_Board;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(578, 422);
            this.Controls.Add(this.m_TextBoxPlayer2Name);
            this.Controls.Add(this.m_TextBoxPlayer1Name);
            this.Controls.Add(this.m_CheckBoxPlayer2);
            this.Controls.Add(this.m_Label3);
            this.Controls.Add(this.m_Label2);
            this.Controls.Add(this.m_RadioButtonSize10);
            this.Controls.Add(this.m_RadioButtonSize8);
            this.Controls.Add(this.m_RadioButtonSize6);
            this.Controls.Add(this.m_Label1);
            this.Controls.Add(this.m_buttonDone);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Adobe Gothic Std B", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Checkers Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_buttonDone;
        private System.Windows.Forms.Label m_Label1;
        private System.Windows.Forms.RadioButton m_RadioButtonSize6;
        private System.Windows.Forms.RadioButton m_RadioButtonSize8;
        private System.Windows.Forms.RadioButton m_RadioButtonSize10;
        private System.Windows.Forms.Label m_Label2;
        private System.Windows.Forms.Label m_Label3;
        private System.Windows.Forms.CheckBox m_CheckBoxPlayer2;
        private System.Windows.Forms.TextBox m_TextBoxPlayer1Name;
        private System.Windows.Forms.TextBox m_TextBoxPlayer2Name;
    }
}

