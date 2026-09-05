namespace WindowsFormsApp8
{
    partial class Form2
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnLoadEpisodes = new System.Windows.Forms.Button();
            this.txtSeriesTitle = new System.Windows.Forms.TextBox();
            this.btnAddSeries = new System.Windows.Forms.Button();
            this.btnLoadSeries = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSeriesId = new System.Windows.Forms.TextBox();
            this.btnDeleteSeries = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSeriesIdForEpisodes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddEpisode = new System.Windows.Forms.Button();
            this.txtEpisodeTitle = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtEpisodeSeriesId = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUpdateSeriesId = new System.Windows.Forms.TextBox();
            this.txtUpdateSeriesTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnUpdateSeries = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(578, 321);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btnLoadEpisodes
            // 
            this.btnLoadEpisodes.Location = new System.Drawing.Point(182, 407);
            this.btnLoadEpisodes.Name = "btnLoadEpisodes";
            this.btnLoadEpisodes.Size = new System.Drawing.Size(75, 23);
            this.btnLoadEpisodes.TabIndex = 1;
            this.btnLoadEpisodes.Text = "show";
            this.btnLoadEpisodes.UseVisualStyleBackColor = true;
            this.btnLoadEpisodes.Click += new System.EventHandler(this.btnLoadEpisodes_Click);
            // 
            // txtSeriesTitle
            // 
            this.txtSeriesTitle.Location = new System.Drawing.Point(688, 381);
            this.txtSeriesTitle.Name = "txtSeriesTitle";
            this.txtSeriesTitle.Size = new System.Drawing.Size(100, 20);
            this.txtSeriesTitle.TabIndex = 2;
            this.txtSeriesTitle.TextChanged += new System.EventHandler(this.txtSeriesTitle_TextChanged);
            // 
            // btnAddSeries
            // 
            this.btnAddSeries.Location = new System.Drawing.Point(688, 415);
            this.btnAddSeries.Name = "btnAddSeries";
            this.btnAddSeries.Size = new System.Drawing.Size(75, 23);
            this.btnAddSeries.TabIndex = 3;
            this.btnAddSeries.Text = "add";
            this.btnAddSeries.UseVisualStyleBackColor = true;
            this.btnAddSeries.Click += new System.EventHandler(this.btnAddSeries_Click);
            // 
            // btnLoadSeries
            // 
            this.btnLoadSeries.Location = new System.Drawing.Point(571, 407);
            this.btnLoadSeries.Name = "btnLoadSeries";
            this.btnLoadSeries.Size = new System.Drawing.Size(75, 23);
            this.btnLoadSeries.TabIndex = 4;
            this.btnLoadSeries.Text = "show";
            this.btnLoadSeries.UseVisualStyleBackColor = true;
            this.btnLoadSeries.Click += new System.EventHandler(this.btnLoadSeries_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(135, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "epiesod";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(578, 342);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "series";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtSeriesId
            // 
            this.txtSeriesId.Location = new System.Drawing.Point(417, 371);
            this.txtSeriesId.Name = "txtSeriesId";
            this.txtSeriesId.Size = new System.Drawing.Size(100, 20);
            this.txtSeriesId.TabIndex = 7;
            this.txtSeriesId.TextChanged += new System.EventHandler(this.txtSeriesId_TextChanged);
            // 
            // btnDeleteSeries
            // 
            this.btnDeleteSeries.Location = new System.Drawing.Point(430, 407);
            this.btnDeleteSeries.Name = "btnDeleteSeries";
            this.btnDeleteSeries.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteSeries.TabIndex = 8;
            this.btnDeleteSeries.Text = "delete";
            this.btnDeleteSeries.UseVisualStyleBackColor = true;
            this.btnDeleteSeries.Click += new System.EventHandler(this.btnDeleteSeries_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(396, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "id";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(666, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "title";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txtSeriesIdForEpisodes
            // 
            this.txtSeriesIdForEpisodes.Location = new System.Drawing.Point(182, 381);
            this.txtSeriesIdForEpisodes.Name = "txtSeriesIdForEpisodes";
            this.txtSeriesIdForEpisodes.Size = new System.Drawing.Size(100, 20);
            this.txtSeriesIdForEpisodes.TabIndex = 11;
            this.txtSeriesIdForEpisodes.TextChanged += new System.EventHandler(this.txtSeriesIdForEpisodes_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(164, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "id";
            // 
            // btnAddEpisode
            // 
            this.btnAddEpisode.Location = new System.Drawing.Point(50, 407);
            this.btnAddEpisode.Name = "btnAddEpisode";
            this.btnAddEpisode.Size = new System.Drawing.Size(75, 23);
            this.btnAddEpisode.TabIndex = 13;
            this.btnAddEpisode.Text = "add";
            this.btnAddEpisode.UseVisualStyleBackColor = true;
            this.btnAddEpisode.Click += new System.EventHandler(this.btnAddEpisode_Click);
            // 
            // txtEpisodeTitle
            // 
            this.txtEpisodeTitle.Location = new System.Drawing.Point(41, 381);
            this.txtEpisodeTitle.Name = "txtEpisodeTitle";
            this.txtEpisodeTitle.Size = new System.Drawing.Size(100, 20);
            this.txtEpisodeTitle.TabIndex = 14;
            this.txtEpisodeTitle.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "title";
            // 
            // txtEpisodeSeriesId
            // 
            this.txtEpisodeSeriesId.Location = new System.Drawing.Point(41, 355);
            this.txtEpisodeSeriesId.Name = "txtEpisodeSeriesId";
            this.txtEpisodeSeriesId.Size = new System.Drawing.Size(100, 20);
            this.txtEpisodeSeriesId.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 358);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "id";
            // 
            // txtUpdateSeriesId
            // 
            this.txtUpdateSeriesId.Location = new System.Drawing.Point(688, 255);
            this.txtUpdateSeriesId.Name = "txtUpdateSeriesId";
            this.txtUpdateSeriesId.Size = new System.Drawing.Size(100, 20);
            this.txtUpdateSeriesId.TabIndex = 18;
            // 
            // txtUpdateSeriesTitle
            // 
            this.txtUpdateSeriesTitle.Location = new System.Drawing.Point(688, 290);
            this.txtUpdateSeriesTitle.Name = "txtUpdateSeriesTitle";
            this.txtUpdateSeriesTitle.Size = new System.Drawing.Size(100, 20);
            this.txtUpdateSeriesTitle.TabIndex = 19;
            this.txtUpdateSeriesTitle.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(657, 297);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "id";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(649, 258);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "title";
            // 
            // btnUpdateSeries
            // 
            this.btnUpdateSeries.Location = new System.Drawing.Point(702, 329);
            this.btnUpdateSeries.Name = "btnUpdateSeries";
            this.btnUpdateSeries.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateSeries.TabIndex = 22;
            this.btnUpdateSeries.Text = "update";
            this.btnUpdateSeries.UseVisualStyleBackColor = true;
            this.btnUpdateSeries.Click += new System.EventHandler(this.btnUpdateSeries_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnUpdateSeries);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUpdateSeriesTitle);
            this.Controls.Add(this.txtUpdateSeriesId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtEpisodeSeriesId);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEpisodeTitle);
            this.Controls.Add(this.btnAddEpisode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSeriesIdForEpisodes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnDeleteSeries);
            this.Controls.Add(this.txtSeriesId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoadSeries);
            this.Controls.Add(this.btnAddSeries);
            this.Controls.Add(this.txtSeriesTitle);
            this.Controls.Add(this.btnLoadEpisodes);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnLoadEpisodes;
        private System.Windows.Forms.TextBox txtSeriesTitle;
        private System.Windows.Forms.Button btnAddSeries;
        private System.Windows.Forms.Button btnLoadSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSeriesId;
        private System.Windows.Forms.Button btnDeleteSeries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSeriesIdForEpisodes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddEpisode;
        private System.Windows.Forms.TextBox txtEpisodeTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEpisodeSeriesId;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtUpdateSeriesId;
        private System.Windows.Forms.TextBox txtUpdateSeriesTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnUpdateSeries;
    }
}