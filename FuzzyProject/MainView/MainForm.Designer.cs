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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.operationProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.startProcessingButton = new System.Windows.Forms.Button();
            this.algoritmsListCombo = new System.Windows.Forms.ComboBox();
            this.algoritmLabel = new System.Windows.Forms.Label();
            this.algorithmConfigurationGroup = new System.Windows.Forms.GroupBox();
            this.parametersGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setParameterDefaultButtonValue = new System.Windows.Forms.DataGridViewButtonColumn();
            this.algorithmParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.operationTimerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainMenuStrip.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.sourceImagePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.processedImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.algorithmConfigurationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmParametersBindingSource)).BeginInit();
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
            this.tabContainer.Size = new System.Drawing.Size(760, 487);
            this.tabContainer.TabIndex = 1;
            // 
            // sourceImagePage
            // 
            this.sourceImagePage.Controls.Add(this.sourcePictureBox);
            this.sourceImagePage.Location = new System.Drawing.Point(4, 22);
            this.sourceImagePage.Name = "sourceImagePage";
            this.sourceImagePage.Padding = new System.Windows.Forms.Padding(3);
            this.sourceImagePage.Size = new System.Drawing.Size(752, 461);
            this.sourceImagePage.TabIndex = 0;
            this.sourceImagePage.Text = "Źródło";
            this.sourceImagePage.UseVisualStyleBackColor = true;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePictureBox.Location = new System.Drawing.Point(3, 3);
            this.sourcePictureBox.Name = "sourcePictureBox";
            this.sourcePictureBox.Size = new System.Drawing.Size(746, 455);
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
            this.processedImageTabPage.Size = new System.Drawing.Size(752, 461);
            this.processedImageTabPage.TabIndex = 1;
            this.processedImageTabPage.Text = "Przetworzony";
            this.processedImageTabPage.UseVisualStyleBackColor = true;
            // 
            // processedPictureBox
            // 
            this.processedPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.processedPictureBox.Location = new System.Drawing.Point(3, 3);
            this.processedPictureBox.Name = "processedPictureBox";
            this.processedPictureBox.Size = new System.Drawing.Size(746, 441);
            this.processedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.processedPictureBox.TabIndex = 0;
            this.processedPictureBox.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationProgressBar,
            this.operationTimerLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 692);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(784, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip";
            // 
            // operationProgressBar
            // 
            this.operationProgressBar.Enabled = false;
            this.operationProgressBar.Name = "operationProgressBar";
            this.operationProgressBar.Size = new System.Drawing.Size(100, 16);
            this.operationProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // startProcessingButton
            // 
            this.startProcessingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startProcessingButton.Location = new System.Drawing.Point(203, 131);
            this.startProcessingButton.Name = "startProcessingButton";
            this.startProcessingButton.Size = new System.Drawing.Size(125, 35);
            this.startProcessingButton.TabIndex = 3;
            this.startProcessingButton.Text = "Przetwarzaj";
            this.startProcessingButton.UseVisualStyleBackColor = true;
            this.startProcessingButton.Click += new System.EventHandler(this.OnProcessImageClick);
            // 
            // algoritmsListCombo
            // 
            this.algoritmsListCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.algoritmsListCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.algoritmsListCombo.FormattingEnabled = true;
            this.algoritmsListCombo.Location = new System.Drawing.Point(6, 16);
            this.algoritmsListCombo.Name = "algoritmsListCombo";
            this.algoritmsListCombo.Size = new System.Drawing.Size(191, 21);
            this.algoritmsListCombo.TabIndex = 4;
            this.algoritmsListCombo.SelectedValueChanged += new System.EventHandler(this.OnAlgoritmsListSelectionChanged);
            // 
            // algoritmLabel
            // 
            this.algoritmLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.algoritmLabel.AutoSize = true;
            this.algoritmLabel.Location = new System.Drawing.Point(16, 651);
            this.algoritmLabel.Name = "algoritmLabel";
            this.algoritmLabel.Size = new System.Drawing.Size(50, 13);
            this.algoritmLabel.TabIndex = 5;
            this.algoritmLabel.Text = "Algorytm:";
            // 
            // algorithmConfigurationGroup
            // 
            this.algorithmConfigurationGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.algorithmConfigurationGroup.Controls.Add(this.parametersGridView);
            this.algorithmConfigurationGroup.Controls.Add(this.algoritmsListCombo);
            this.algorithmConfigurationGroup.Controls.Add(this.startProcessingButton);
            this.algorithmConfigurationGroup.Location = new System.Drawing.Point(13, 520);
            this.algorithmConfigurationGroup.Name = "algorithmConfigurationGroup";
            this.algorithmConfigurationGroup.Size = new System.Drawing.Size(752, 169);
            this.algorithmConfigurationGroup.TabIndex = 6;
            this.algorithmConfigurationGroup.TabStop = false;
            this.algorithmConfigurationGroup.Text = "Algorytm";
            // 
            // parametersGridView
            // 
            this.parametersGridView.AllowUserToAddRows = false;
            this.parametersGridView.AllowUserToDeleteRows = false;
            this.parametersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.parametersGridView.AutoGenerateColumns = false;
            this.parametersGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.parametersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn,
            this.setParameterDefaultButtonValue});
            this.parametersGridView.DataSource = this.algorithmParametersBindingSource;
            this.parametersGridView.Location = new System.Drawing.Point(203, 16);
            this.parametersGridView.Name = "parametersGridView";
            this.parametersGridView.Size = new System.Drawing.Size(425, 106);
            this.parametersGridView.TabIndex = 5;
            this.parametersGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OnParametersGridViewCellContentClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Nazwa";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            dataGridViewCellStyle1.Format = "N2";
            this.valueDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.valueDataGridViewTextBoxColumn.HeaderText = "Wartość";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // setParameterDefaultButtonValue
            // 
            this.setParameterDefaultButtonValue.HeaderText = "Wartość domyślna";
            this.setParameterDefaultButtonValue.Name = "setParameterDefaultButtonValue";
            this.setParameterDefaultButtonValue.Text = "Przywróć";
            // 
            // algorithmParametersBindingSource
            // 
            this.algorithmParametersBindingSource.DataSource = typeof(Logic.AlgorithmParameter);
            // 
            // operationTimerLabel
            // 
            this.operationTimerLabel.Name = "operationTimerLabel";
            this.operationTimerLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 714);
            this.Controls.Add(this.algorithmConfigurationGroup);
            this.Controls.Add(this.algoritmLabel);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.algorithmConfigurationGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.parametersGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmParametersBindingSource)).EndInit();
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
        private System.Windows.Forms.ToolStripProgressBar operationProgressBar;
        private System.Windows.Forms.GroupBox algorithmConfigurationGroup;
        private System.Windows.Forms.DataGridView parametersGridView;
        private System.Windows.Forms.BindingSource algorithmParametersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn setParameterDefaultButtonValue;
        private System.Windows.Forms.ToolStripStatusLabel operationTimerLabel;
    }
}

