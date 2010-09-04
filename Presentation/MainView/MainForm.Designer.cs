namespace Presentation.MainView
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
            this.systemSubiektywnyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wczytajToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zapiszToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabContainer = new System.Windows.Forms.TabControl();
            this.sourceImageTabPage = new System.Windows.Forms.TabPage();
            this.sourcePictureBox = new Presentation.CustomPictureBox();
            this.processedImageTabPage = new System.Windows.Forms.TabPage();
            this.processedPictureBox = new Presentation.CustomPictureBox();
            this.evaluationTabPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.sourceImageEvaluationScore = new System.Windows.Forms.Label();
            this.processedImageEvaluationScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.fuzzProcessedScore = new System.Windows.Forms.Label();
            this.fuzzSourceScore = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.operationProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.operationTimerLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.startProcessingButton = new System.Windows.Forms.Button();
            this.algoritmsListCombo = new System.Windows.Forms.ComboBox();
            this.algoritmLabel = new System.Windows.Forms.Label();
            this.algorithmConfigurationGroup = new System.Windows.Forms.GroupBox();
            this.parametersGridView = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.setParameterDefaultButtonValue = new System.Windows.Forms.DataGridViewButtonColumn();
            this.algorithmParametersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainMenuStrip.SuspendLayout();
            this.tabContainer.SuspendLayout();
            this.sourceImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).BeginInit();
            this.processedImageTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).BeginInit();
            this.evaluationTabPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.algorithmConfigurationGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmParametersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenuStrip
            // 
            this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.systemSubiektywnyToolStripMenuItem});
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
            // systemSubiektywnyToolStripMenuItem
            // 
            this.systemSubiektywnyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowyToolStripMenuItem,
            this.wczytajToolStripMenuItem,
            this.zapiszToolStripMenuItem});
            this.systemSubiektywnyToolStripMenuItem.Name = "systemSubiektywnyToolStripMenuItem";
            this.systemSubiektywnyToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.systemSubiektywnyToolStripMenuItem.Text = "System subiektywny";
            // 
            // nowyToolStripMenuItem
            // 
            this.nowyToolStripMenuItem.Name = "nowyToolStripMenuItem";
            this.nowyToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.nowyToolStripMenuItem.Text = "Nowy";
            this.nowyToolStripMenuItem.Click += new System.EventHandler(this.OnNewToolStripMenuItemClick);
            // 
            // wczytajToolStripMenuItem
            // 
            this.wczytajToolStripMenuItem.Name = "wczytajToolStripMenuItem";
            this.wczytajToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.wczytajToolStripMenuItem.Text = "Wczytaj stan";
            this.wczytajToolStripMenuItem.Click += new System.EventHandler(this.OnLoadToolStripMenuItemClick);
            // 
            // zapiszToolStripMenuItem
            // 
            this.zapiszToolStripMenuItem.Name = "zapiszToolStripMenuItem";
            this.zapiszToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.zapiszToolStripMenuItem.Text = "Zapisz stan";
            this.zapiszToolStripMenuItem.Click += new System.EventHandler(this.OnSaveToolStripMenuItemClick);
            // 
            // tabContainer
            // 
            this.tabContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabContainer.Controls.Add(this.sourceImageTabPage);
            this.tabContainer.Controls.Add(this.processedImageTabPage);
            this.tabContainer.Controls.Add(this.evaluationTabPage);
            this.tabContainer.Location = new System.Drawing.Point(12, 27);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.SelectedIndex = 0;
            this.tabContainer.Size = new System.Drawing.Size(760, 487);
            this.tabContainer.TabIndex = 1;
            // 
            // sourceImageTabPage
            // 
            this.sourceImageTabPage.Controls.Add(this.sourcePictureBox);
            this.sourceImageTabPage.Location = new System.Drawing.Point(4, 22);
            this.sourceImageTabPage.Name = "sourceImageTabPage";
            this.sourceImageTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.sourceImageTabPage.Size = new System.Drawing.Size(752, 461);
            this.sourceImageTabPage.TabIndex = 0;
            this.sourceImageTabPage.Text = "Źródło";
            this.sourceImageTabPage.UseVisualStyleBackColor = true;
            // 
            // sourcePictureBox
            // 
            this.sourcePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.sourcePictureBox.IsSource = false;
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
            this.processedPictureBox.IsSource = false;
            this.processedPictureBox.Location = new System.Drawing.Point(3, 3);
            this.processedPictureBox.Name = "processedPictureBox";
            this.processedPictureBox.Size = new System.Drawing.Size(746, 441);
            this.processedPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.processedPictureBox.TabIndex = 0;
            this.processedPictureBox.TabStop = false;
            // 
            // evaluationTabPage
            // 
            this.evaluationTabPage.Controls.Add(this.groupBox2);
            this.evaluationTabPage.Controls.Add(this.groupBox1);
            this.evaluationTabPage.Location = new System.Drawing.Point(4, 22);
            this.evaluationTabPage.Name = "evaluationTabPage";
            this.evaluationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.evaluationTabPage.Size = new System.Drawing.Size(752, 461);
            this.evaluationTabPage.TabIndex = 2;
            this.evaluationTabPage.Text = "Ewaluacja";
            this.evaluationTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.sourceImageEvaluationScore);
            this.groupBox2.Controls.Add(this.processedImageEvaluationScore);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Con";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(10, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Obraz przetworzony:";
            // 
            // sourceImageEvaluationScore
            // 
            this.sourceImageEvaluationScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.sourceImageEvaluationScore.Location = new System.Drawing.Point(200, 38);
            this.sourceImageEvaluationScore.Name = "sourceImageEvaluationScore";
            this.sourceImageEvaluationScore.Size = new System.Drawing.Size(128, 20);
            this.sourceImageEvaluationScore.TabIndex = 0;
            // 
            // processedImageEvaluationScore
            // 
            this.processedImageEvaluationScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.processedImageEvaluationScore.Location = new System.Drawing.Point(200, 61);
            this.processedImageEvaluationScore.Name = "processedImageEvaluationScore";
            this.processedImageEvaluationScore.Size = new System.Drawing.Size(129, 20);
            this.processedImageEvaluationScore.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(10, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Obraz źródłowy:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.fuzzProcessedScore);
            this.groupBox1.Controls.Add(this.fuzzSourceScore);
            this.groupBox1.Location = new System.Drawing.Point(6, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fuzz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(10, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Obraz przetworzony:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(10, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Obraz źródłowy:";
            // 
            // fuzzProcessedScore
            // 
            this.fuzzProcessedScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fuzzProcessedScore.Location = new System.Drawing.Point(200, 55);
            this.fuzzProcessedScore.Name = "fuzzProcessedScore";
            this.fuzzProcessedScore.Size = new System.Drawing.Size(129, 20);
            this.fuzzProcessedScore.TabIndex = 2;
            // 
            // fuzzSourceScore
            // 
            this.fuzzSourceScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.fuzzSourceScore.Location = new System.Drawing.Point(200, 32);
            this.fuzzSourceScore.Name = "fuzzSourceScore";
            this.fuzzSourceScore.Size = new System.Drawing.Size(128, 20);
            this.fuzzSourceScore.TabIndex = 3;
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
            // operationTimerLabel
            // 
            this.operationTimerLabel.Name = "operationTimerLabel";
            this.operationTimerLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // startProcessingButton
            // 
            this.startProcessingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startProcessingButton.Location = new System.Drawing.Point(-1, 43);
            this.startProcessingButton.Name = "startProcessingButton";
            this.startProcessingButton.Size = new System.Drawing.Size(125, 35);
            this.startProcessingButton.TabIndex = 3;
            this.startProcessingButton.Text = "Przetwarza&j";
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
            this.parametersGridView.Size = new System.Drawing.Size(425, 153);
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
            dataGridViewCellStyle1.Format = "N5";
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
            this.Text = "Fuzz";
            this.ResizeEnd += new System.EventHandler(this.OnSizeChanged);
            this.mainMenuStrip.ResumeLayout(false);
            this.mainMenuStrip.PerformLayout();
            this.tabContainer.ResumeLayout(false);
            this.sourceImageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sourcePictureBox)).EndInit();
            this.processedImageTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.processedPictureBox)).EndInit();
            this.evaluationTabPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.TabPage sourceImageTabPage;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Button startProcessingButton;
        private System.Windows.Forms.TabPage processedImageTabPage;
        private System.Windows.Forms.ComboBox algoritmsListCombo;
        private System.Windows.Forms.Label algoritmLabel;
        private System.Windows.Forms.ToolStripProgressBar operationProgressBar;
        private System.Windows.Forms.GroupBox algorithmConfigurationGroup;
        private System.Windows.Forms.DataGridView parametersGridView;
        private System.Windows.Forms.BindingSource algorithmParametersBindingSource;
        private System.Windows.Forms.ToolStripStatusLabel operationTimerLabel;
        private System.Windows.Forms.TabPage evaluationTabPage;
        private System.Windows.Forms.Label sourceImageEvaluationScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label processedImageEvaluationScore;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label fuzzProcessedScore;
        private System.Windows.Forms.Label fuzzSourceScore;
        private CustomPictureBox sourcePictureBox;
        private CustomPictureBox processedPictureBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewButtonColumn setParameterDefaultButtonValue;
        private System.Windows.Forms.ToolStripMenuItem systemSubiektywnyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wczytajToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zapiszToolStripMenuItem;
    }
}

