using System;

namespace FuzzyProject
{
    partial class MainForm
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
            this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.sourceImagePage = new System.Windows.Forms.TabPage();
            this.sourcePictureBox = new System.Windows.Forms.PictureBox();
            this.processedImageTabPage = new System.Windows.Forms.TabPage();
            this.processedPictureBox = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.startProcessingButton = new System.Windows.Forms.Button();
            this.algoritmsListCombo = new System.Windows.Forms.ComboBox();
            this.algoritmLabel = new System.Windows.Forms.Label();
            this.mainMenuStrip.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.sourceImagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.processedImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainMenuStrip.Name = "mainMenuStrip";
            this.mainMenuStrip.Size = new System.Drawing.Size(784, 24);
            this.mainMenuStrip.TabIndex = 0;
            this.mainMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.fileToolStripMenuItem.Text = "Plik";
            // 
            // loadImageToolStripMenuItem
            // 
            this.loadImageToolStripMenuItem.Name = "loadImageToolStripMenuItem";
            this.loadImageToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.loadImageToolStripMenuItem.Text = "Wczytaj...";
            this.loadImageToolStripMenuItem.Click += new System.EventHandler(this.OnLoadImageToolStripMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.quitToolStripMenuItem.Text = "Zakończ";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.OnQuitToolStripMenuItemClick);
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.sourceImagePage);
            this.tabContainer.Controls.Add(this.processedImageTabPage);
            this.tabContainer.Location = new System.Drawing.Point(12, 27);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(760, 473);
            this.tabContainer.TabIndex = 1;
            // 
            // sourceImagePage
            // 
            this.sourceImagePage.Controls.Add(this.sourcePictureBox);
            this.sourceImagePage.Location = new System.Drawing.Point(4, 22);
            this.sourceImagePage.Name = "sourceImagePage";
            this.sourceImagePage.Padding = new System.Windows.Forms.Padding(3);
            this.sourceImagePage.Size = new System.Drawing.Size(752, 447);
            this.sourceImagePage.TabIndex = 0;
            this.sourceImagePage.Text = "Źródło";
            this.sourceImagePage.UseVisualStyleBackColor = true;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourcePictureBox.Location = new System.Drawing.Point(3, 3);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(746, 441);
            this.sourcePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.sourcePictureBox.TabIndex = 0;
            this.sourcePictureBox.TabStop = false;
            // 
            // processedImageTabPage
            // 
            this.processedImageTabPage.Controls.Add(this.processedPictureBox);
            this.processedImageTabPage.Location = new System.Drawing.Point(4, 22);
            this.processedImageTabPage.Name = "processedImageTabPage";
            this.processedImageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.processedImageTabPage.Size = new System.Drawing.Size(752, 447);
            this.processedImageTabPage.TabIndex = 1;
            this.processedImageTabPage.Text = "Przetworzony";
            this.processedImageTabPage.UseVisualStyleBackColor = true;
            // 
            // processedPictureBox
            // 
            this.processedPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processedPictureBox.Location = new System.Drawing.Point(3, 3);
            this.processedPictureBox.Name = "processedPictureBox";
            this.processedPictureBox.Size = new System.Drawing.Size(746, 441);
            this.processedPictureBox.TabIndex = 0;
            this.processedPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 540);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // startProcessingButton
            // 
            this.startProcessingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startProcessingButton.Location = new System.Drawing.Point(216, 501);
            this.startProcessingButton.Name = "startProcessingButton";
            this.startProcessingButton.Size = new System.Drawing.Size(86, 35);
            this.startProcessingButton.TabIndex = 3;
            this.startProcessingButton.Text = "Przetwarzaj";
            this.startProcessingButton.UseVisualStyleBackColor = true;
            // 
            // algoritmsListCombo
            // 
            this.algoritmsListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algoritmsListCombo.FormattingEnabled = true;
            this.algoritmsListCombo.Location = new System.Drawing.Point(19, 515);
            this.algoritmsListCombo.Name = "algoritmsListCombo";
            this.algoritmsListCombo.Size = new System.Drawing.Size(191, 21);
            this.algoritmsListCombo.TabIndex = 4;
            this.algoritmsListCombo.SelectedValueChanged += new System.EventHandler(this.OnAlgoritmsListSelectionChanged);
            // 
            // algoritmLabel
            // 
            this.algoritmLabel.AutoSize = true;
            this.algoritmLabel.Location = new System.Drawing.Point(16, 499);
            this.algoritmLabel.Name = "algoritmLabel";
            this.algoritmLabel.Size = new System.Drawing.Size(50, 13);
            this.algoritmLabel.TabIndex = 5;
            this.algoritmLabel.Text = "Algorytm:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.algoritmLabel);
            this.Controls.Add(this.algoritmsListCombo);
            this.Controls.Add(this.startProcessingButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.mainMenuStrip);
            this.MainMenuStrip = this.mainMenuStrip;
            this.Name = "MainForm";
            this.Text = "Fuzzy";
            this.ResizeEnd += new System.EventHandler(this.OnSizeChanged);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.sourceImagePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.processedImageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabContainer;
        private System.Windows.Forms.TabPage sourceImagePage;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button startProcessingButton;
        private System.Windows.Forms.PictureBox sourcePictureBox;
        private System.Windows.Forms.TabPage processedImageTabPage;
        private System.Windows.Forms.PictureBox processedPictureBox;
        private System.Windows.Forms.ComboBox algoritmsListCombo;
        private System.Windows.Forms.Label algoritmLabel;
    }
}

