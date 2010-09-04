namespace Presentation.Subjective
{
    partial class TrainingWindow
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.excellentButton = new System.Windows.Forms.Button();
            this.goodButton = new System.Windows.Forms.Button();
            this.fairButton = new System.Windows.Forms.Button();
            this.poorButton = new System.Windows.Forms.Button();
            this.badButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourcePicture = new CustomPictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.processedImage = new CustomPictureBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePicture)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(784, 494);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // progressBar
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.progressBar, 2);
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(3, 471);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(778, 20);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.nextButton);
            this.panel1.Controls.Add(this.excellentButton);
            this.panel1.Controls.Add(this.goodButton);
            this.panel1.Controls.Add(this.fairButton);
            this.panel1.Controls.Add(this.poorButton);
            this.panel1.Controls.Add(this.badButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 39);
            this.panel1.TabIndex = 2;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Enabled = false;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nextButton.Location = new System.Drawing.Point(684, 3);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(85, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Dalej -->";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.OnNextClick);
            // 
            // excellentButton
            // 
            this.excellentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.excellentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.excellentButton.Location = new System.Drawing.Point(442, 3);
            this.excellentButton.Name = "excellentButton";
            this.excellentButton.Size = new System.Drawing.Size(85, 23);
            this.excellentButton.TabIndex = 4;
            this.excellentButton.Tag = "1";
            this.excellentButton.Text = "Doskonała";
            this.excellentButton.UseVisualStyleBackColor = true;
            this.excellentButton.Click += new System.EventHandler(this.OnScoreButtonClick);
            // 
            // goodButton
            // 
            this.goodButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.goodButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.goodButton.Location = new System.Drawing.Point(357, 3);
            this.goodButton.Name = "goodButton";
            this.goodButton.Size = new System.Drawing.Size(85, 23);
            this.goodButton.TabIndex = 3;
            this.goodButton.Tag = "2";
            this.goodButton.Text = "Dobra";
            this.goodButton.UseVisualStyleBackColor = true;
            this.goodButton.Click += new System.EventHandler(this.OnScoreButtonClick);
            // 
            // fairButton
            // 
            this.fairButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fairButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fairButton.Location = new System.Drawing.Point(272, 3);
            this.fairButton.Name = "fairButton";
            this.fairButton.Size = new System.Drawing.Size(85, 23);
            this.fairButton.TabIndex = 2;
            this.fairButton.Tag = "3";
            this.fairButton.Text = "Niezła";
            this.fairButton.UseVisualStyleBackColor = true;
            this.fairButton.Click += new System.EventHandler(this.OnScoreButtonClick);
            // 
            // poorButton
            // 
            this.poorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.poorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.poorButton.Location = new System.Drawing.Point(187, 3);
            this.poorButton.Name = "poorButton";
            this.poorButton.Size = new System.Drawing.Size(85, 23);
            this.poorButton.TabIndex = 1;
            this.poorButton.Tag = "4";
            this.poorButton.Text = "Kiepska";
            this.poorButton.UseVisualStyleBackColor = true;
            this.poorButton.Click += new System.EventHandler(this.OnScoreButtonClick);
            // 
            // badButton
            // 
            this.badButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.badButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.badButton.Location = new System.Drawing.Point(102, 3);
            this.badButton.Name = "badButton";
            this.badButton.Size = new System.Drawing.Size(85, 23);
            this.badButton.TabIndex = 0;
            this.badButton.Tag = "5";
            this.badButton.Text = "Zła";
            this.badButton.UseVisualStyleBackColor = true;
            this.badButton.Click += new System.EventHandler(this.OnScoreButtonClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(4, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ocena jakości:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sourcePicture);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 417);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obraz źródłowy";
            // 
            // sourcePicture
            // 
            this.sourcePicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePicture.IsSource = false;
            this.sourcePicture.Location = new System.Drawing.Point(3, 16);
            this.sourcePicture.Name = "sourcePicture";
            this.sourcePicture.Size = new System.Drawing.Size(380, 398);
            this.sourcePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sourcePicture.TabIndex = 4;
            this.sourcePicture.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.processedImage);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(395, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 417);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Obraz przetworzony";
            // 
            // processedImage
            // 
            this.processedImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedImage.IsSource = false;
            this.processedImage.Location = new System.Drawing.Point(3, 16);
            this.processedImage.Name = "processedImage";
            this.processedImage.Size = new System.Drawing.Size(380, 398);
            this.processedImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.processedImage.TabIndex = 1;
            this.processedImage.TabStop = false;
            // 
            // TrainingWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 494);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "TrainingWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trenowanie systemu";
            this.ResizeEnd += new System.EventHandler(this.OnTrainingWindowResizeEnd);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePicture)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button excellentButton;
        private System.Windows.Forms.Button goodButton;
        private System.Windows.Forms.Button fairButton;
        private System.Windows.Forms.Button poorButton;
        private System.Windows.Forms.Button badButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private CustomPictureBox sourcePicture;
        private System.Windows.Forms.GroupBox groupBox2;
        private CustomPictureBox processedImage;


    }
}