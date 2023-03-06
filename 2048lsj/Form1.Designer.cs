namespace _2048lsj
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dg = new System.Windows.Forms.DataGridView();
            this.Quitbutton = new System.Windows.Forms.Button();
            this.Playbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Undobutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.scorelabel = new System.Windows.Forms.Label();
            this.Colortestbutton = new System.Windows.Forms.Button();
            this.TB_boardsize = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_newnumbers = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.HB2 = new System.Windows.Forms.HScrollBar();
            this.HB4 = new System.Windows.Forms.HScrollBar();
            this.HB8 = new System.Windows.Forms.HScrollBar();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.LBcolor = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.botButton = new System.Windows.Forms.Button();
            this.LBautoplay = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_boardsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_newnumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg.DefaultCellStyle = dataGridViewCellStyle1;
            this.dg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg.Location = new System.Drawing.Point(45, 218);
            this.dg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.RowHeadersVisible = false;
            this.dg.RowHeadersWidth = 10;
            this.dg.ShowEditingIcon = false;
            this.dg.Size = new System.Drawing.Size(1014, 977);
            this.dg.TabIndex = 0;
            this.dg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(1212, 1124);
            this.Quitbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(166, 71);
            this.Quitbutton.TabIndex = 1;
            this.Quitbutton.Text = "Quit";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // Playbutton
            // 
            this.Playbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playbutton.Location = new System.Drawing.Point(478, 34);
            this.Playbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Playbutton.Name = "Playbutton";
            this.Playbutton.Size = new System.Drawing.Size(267, 52);
            this.Playbutton.TabIndex = 2;
            this.Playbutton.Text = "New game";
            this.Playbutton.UseVisualStyleBackColor = true;
            this.Playbutton.Click += new System.EventHandler(this.Playbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(45, 23);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(238, 96);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Undobutton
            // 
            this.Undobutton.Location = new System.Drawing.Point(339, 34);
            this.Undobutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Undobutton.Name = "Undobutton";
            this.Undobutton.Size = new System.Drawing.Size(110, 35);
            this.Undobutton.TabIndex = 4;
            this.Undobutton.Text = "Undo";
            this.Undobutton.UseVisualStyleBackColor = true;
            this.Undobutton.Click += new System.EventHandler(this.Undobutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(346, 106);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Score";
            // 
            // scorelabel
            // 
            this.scorelabel.AutoSize = true;
            this.scorelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelabel.Location = new System.Drawing.Point(453, 106);
            this.scorelabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scorelabel.Name = "scorelabel";
            this.scorelabel.Size = new System.Drawing.Size(128, 29);
            this.scorelabel.TabIndex = 6;
            this.scorelabel.Text = "                 0";
            this.scorelabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Colortestbutton
            // 
            this.Colortestbutton.Location = new System.Drawing.Point(1197, 506);
            this.Colortestbutton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Colortestbutton.Name = "Colortestbutton";
            this.Colortestbutton.Size = new System.Drawing.Size(112, 35);
            this.Colortestbutton.TabIndex = 7;
            this.Colortestbutton.Text = "Color test";
            this.Colortestbutton.UseVisualStyleBackColor = true;
            this.Colortestbutton.Click += new System.EventHandler(this.Colortestbutton_Click);
            // 
            // TB_boardsize
            // 
            this.TB_boardsize.LargeChange = 2;
            this.TB_boardsize.Location = new System.Drawing.Point(813, 57);
            this.TB_boardsize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_boardsize.Maximum = 12;
            this.TB_boardsize.Minimum = 3;
            this.TB_boardsize.Name = "TB_boardsize";
            this.TB_boardsize.Size = new System.Drawing.Size(156, 69);
            this.TB_boardsize.TabIndex = 8;
            this.TB_boardsize.Value = 4;
            this.TB_boardsize.Scroll += new System.EventHandler(this.TB_boardsize_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(828, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Board size";
            // 
            // TB_newnumbers
            // 
            this.TB_newnumbers.Location = new System.Drawing.Point(813, 135);
            this.TB_newnumbers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TB_newnumbers.Maximum = 5;
            this.TB_newnumbers.Minimum = 1;
            this.TB_newnumbers.Name = "TB_newnumbers";
            this.TB_newnumbers.Size = new System.Drawing.Size(156, 69);
            this.TB_newnumbers.TabIndex = 10;
            this.TB_newnumbers.Value = 1;
            this.TB_newnumbers.Scroll += new System.EventHandler(this.TB_newnumbers_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(822, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "New numbers per turn";
            // 
            // HB2
            // 
            this.HB2.Location = new System.Drawing.Point(1079, 47);
            this.HB2.Name = "HB2";
            this.HB2.Size = new System.Drawing.Size(230, 22);
            this.HB2.TabIndex = 12;
            this.HB2.Value = 90;
            this.HB2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB2_Scroll);
            // 
            // HB4
            // 
            this.HB4.Location = new System.Drawing.Point(1080, 123);
            this.HB4.Name = "HB4";
            this.HB4.Size = new System.Drawing.Size(228, 17);
            this.HB4.TabIndex = 13;
            this.HB4.Value = 10;
            this.HB4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB4_Scroll);
            // 
            // HB8
            // 
            this.HB8.Location = new System.Drawing.Point(1080, 186);
            this.HB8.Name = "HB8";
            this.HB8.Size = new System.Drawing.Size(228, 17);
            this.HB8.TabIndex = 14;
            this.HB8.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB8_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1043, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "% 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1043, 123);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "% 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1043, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 20);
            this.label6.TabIndex = 17;
            this.label6.Text = "% 8";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(795, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(18, 20);
            this.label7.TabIndex = 18;
            this.label7.Text = "3";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(978, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 20);
            this.label8.TabIndex = 19;
            this.label8.Text = "12";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(795, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(976, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "5";
            // 
            // LBcolor
            // 
            this.LBcolor.FormattingEnabled = true;
            this.LBcolor.ItemHeight = 20;
            this.LBcolor.Location = new System.Drawing.Point(1167, 283);
            this.LBcolor.Name = "LBcolor";
            this.LBcolor.Size = new System.Drawing.Size(172, 204);
            this.LBcolor.TabIndex = 22;
            this.LBcolor.SelectedIndexChanged += new System.EventHandler(this.LBcolor_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1066, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(222, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Distribution of added numbers";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1184, 256);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Color scheme:";
            // 
            // botButton
            // 
            this.botButton.Location = new System.Drawing.Point(633, 162);
            this.botButton.Name = "botButton";
            this.botButton.Size = new System.Drawing.Size(127, 33);
            this.botButton.TabIndex = 25;
            this.botButton.Text = "Autoplay";
            this.botButton.UseVisualStyleBackColor = true;
            this.botButton.Click += new System.EventHandler(this.botButton_Click);
            // 
            // LBautoplay
            // 
            this.LBautoplay.FormattingEnabled = true;
            this.LBautoplay.ItemHeight = 20;
            this.LBautoplay.Location = new System.Drawing.Point(1169, 607);
            this.LBautoplay.Name = "LBautoplay";
            this.LBautoplay.Size = new System.Drawing.Size(170, 204);
            this.LBautoplay.TabIndex = 26;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(1184, 584);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 20);
            this.label13.TabIndex = 27;
            this.label13.Text = "Autoplay algorithm";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1412, 1231);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.LBautoplay);
            this.Controls.Add(this.botButton);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.LBcolor);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.HB8);
            this.Controls.Add(this.HB4);
            this.Controls.Add(this.HB2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TB_newnumbers);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_boardsize);
            this.Controls.Add(this.Colortestbutton);
            this.Controls.Add(this.scorelabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Undobutton);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Playbutton);
            this.Controls.Add(this.Quitbutton);
            this.Controls.Add(this.dg);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_boardsize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_newnumbers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg;
        private System.Windows.Forms.Button Quitbutton;
        private System.Windows.Forms.Button Playbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button Undobutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label scorelabel;
        private System.Windows.Forms.Button Colortestbutton;
        private System.Windows.Forms.TrackBar TB_boardsize;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar TB_newnumbers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar HB2;
        private System.Windows.Forms.HScrollBar HB4;
        private System.Windows.Forms.HScrollBar HB8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox LBcolor;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button botButton;
        private System.Windows.Forms.ListBox LBautoplay;
        private System.Windows.Forms.Label label13;
    }
}

