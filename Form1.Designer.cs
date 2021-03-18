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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            ((System.ComponentModel.ISupportInitialize)(this.dg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_boardsize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TB_newnumbers)).BeginInit();
            this.SuspendLayout();
            // 
            // dg
            // 
            this.dg.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg.ColumnHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dg.Location = new System.Drawing.Point(33, 110);
            this.dg.Name = "dg";
            this.dg.ReadOnly = true;
            this.dg.RowHeadersVisible = false;
            this.dg.RowHeadersWidth = 10;
            this.dg.ShowEditingIcon = false;
            this.dg.Size = new System.Drawing.Size(459, 451);
            this.dg.TabIndex = 0;
            this.dg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dg.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // Quitbutton
            // 
            this.Quitbutton.Location = new System.Drawing.Point(426, 20);
            this.Quitbutton.Name = "Quitbutton";
            this.Quitbutton.Size = new System.Drawing.Size(75, 23);
            this.Quitbutton.TabIndex = 1;
            this.Quitbutton.Text = "Quit";
            this.Quitbutton.UseVisualStyleBackColor = true;
            this.Quitbutton.Click += new System.EventHandler(this.Quitbutton_Click);
            // 
            // Playbutton
            // 
            this.Playbutton.Location = new System.Drawing.Point(319, 22);
            this.Playbutton.Name = "Playbutton";
            this.Playbutton.Size = new System.Drawing.Size(75, 23);
            this.Playbutton.TabIndex = 2;
            this.Playbutton.Text = "New game";
            this.Playbutton.UseVisualStyleBackColor = true;
            this.Playbutton.Click += new System.EventHandler(this.Playbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(30, 15);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(160, 64);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Undobutton
            // 
            this.Undobutton.Location = new System.Drawing.Point(226, 22);
            this.Undobutton.Name = "Undobutton";
            this.Undobutton.Size = new System.Drawing.Size(73, 23);
            this.Undobutton.TabIndex = 4;
            this.Undobutton.Text = "Undo";
            this.Undobutton.UseVisualStyleBackColor = true;
            this.Undobutton.Click += new System.EventHandler(this.Undobutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Score";
            // 
            // scorelabel
            // 
            this.scorelabel.AutoSize = true;
            this.scorelabel.Location = new System.Drawing.Point(302, 69);
            this.scorelabel.Name = "scorelabel";
            this.scorelabel.Size = new System.Drawing.Size(61, 13);
            this.scorelabel.TabIndex = 6;
            this.scorelabel.Text = "                0";
            this.scorelabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Colortestbutton
            // 
            this.Colortestbutton.Location = new System.Drawing.Point(426, 59);
            this.Colortestbutton.Name = "Colortestbutton";
            this.Colortestbutton.Size = new System.Drawing.Size(75, 23);
            this.Colortestbutton.TabIndex = 7;
            this.Colortestbutton.Text = "Color test";
            this.Colortestbutton.UseVisualStyleBackColor = true;
            this.Colortestbutton.Click += new System.EventHandler(this.Colortestbutton_Click);
            // 
            // TB_boardsize
            // 
            this.TB_boardsize.LargeChange = 2;
            this.TB_boardsize.Location = new System.Drawing.Point(542, 37);
            this.TB_boardsize.Maximum = 12;
            this.TB_boardsize.Minimum = 3;
            this.TB_boardsize.Name = "TB_boardsize";
            this.TB_boardsize.Size = new System.Drawing.Size(104, 45);
            this.TB_boardsize.TabIndex = 8;
            this.TB_boardsize.Value = 4;
            this.TB_boardsize.Scroll += new System.EventHandler(this.TB_boardsize_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(552, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Board size";
            // 
            // TB_newnumbers
            // 
            this.TB_newnumbers.Location = new System.Drawing.Point(542, 88);
            this.TB_newnumbers.Maximum = 5;
            this.TB_newnumbers.Minimum = 1;
            this.TB_newnumbers.Name = "TB_newnumbers";
            this.TB_newnumbers.Size = new System.Drawing.Size(104, 45);
            this.TB_newnumbers.TabIndex = 10;
            this.TB_newnumbers.Value = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(548, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "New numbers per turn";
            // 
            // HB2
            // 
            this.HB2.Location = new System.Drawing.Point(542, 162);
            this.HB2.Name = "HB2";
            this.HB2.Size = new System.Drawing.Size(153, 22);
            this.HB2.TabIndex = 12;
            this.HB2.Value = 90;
            this.HB2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB2_Scroll);
            // 
            // HB4
            // 
            this.HB4.Location = new System.Drawing.Point(543, 211);
            this.HB4.Name = "HB4";
            this.HB4.Size = new System.Drawing.Size(152, 17);
            this.HB4.TabIndex = 13;
            this.HB4.Value = 10;
            this.HB4.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB4_Scroll);
            // 
            // HB8
            // 
            this.HB8.Location = new System.Drawing.Point(543, 252);
            this.HB8.Name = "HB8";
            this.HB8.Size = new System.Drawing.Size(152, 17);
            this.HB8.TabIndex = 14;
            this.HB8.Scroll += new System.Windows.Forms.ScrollEventHandler(this.HB8_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(518, 166);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "% 2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(518, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "% 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(518, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "% 8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 573);
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
    }
}

