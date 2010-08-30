namespace FuzzyProject
{
    partial class SubjectiveSystemControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sourceAlgos = new System.Windows.Forms.ListBox();
            this.removeAlgoButton = new System.Windows.Forms.Button();
            this.addAlgoButton = new System.Windows.Forms.Button();
            this.selectedAlgos = new System.Windows.Forms.ListBox();
            this.algorithmsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.imagesListView = new System.Windows.Forms.ListView();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sourceAlgos);
            this.groupBox1.Controls.Add(this.removeAlgoButton);
            this.groupBox1.Controls.Add(this.addAlgoButton);
            this.groupBox1.Controls.Add(this.selectedAlgos);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 161);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Algorytmy";
            // 
            // sourceAlgos
            // 
            this.sourceAlgos.FormattingEnabled = true;
            this.sourceAlgos.Location = new System.Drawing.Point(8, 19);
            this.sourceAlgos.Name = "sourceAlgos";
            this.sourceAlgos.Size = new System.Drawing.Size(121, 134);
            this.sourceAlgos.TabIndex = 1;
            // 
            // removeAlgoButton
            // 
            this.removeAlgoButton.Location = new System.Drawing.Point(135, 88);
            this.removeAlgoButton.Name = "removeAlgoButton";
            this.removeAlgoButton.Size = new System.Drawing.Size(28, 23);
            this.removeAlgoButton.TabIndex = 3;
            this.removeAlgoButton.Text = "<--";
            this.removeAlgoButton.UseVisualStyleBackColor = true;
            this.removeAlgoButton.Click += new System.EventHandler(this.OnRemoveAlgoButtonClick);
            // 
            // addAlgoButton
            // 
            this.addAlgoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addAlgoButton.Location = new System.Drawing.Point(135, 59);
            this.addAlgoButton.Name = "addAlgoButton";
            this.addAlgoButton.Size = new System.Drawing.Size(28, 23);
            this.addAlgoButton.TabIndex = 2;
            this.addAlgoButton.Text = "-->";
            this.addAlgoButton.UseVisualStyleBackColor = true;
            this.addAlgoButton.Click += new System.EventHandler(this.OnAddAlgoButtonClick);
            // 
            // selectedAlgos
            // 
            this.selectedAlgos.DataSource = this.algorithmsBindingSource;
            this.selectedAlgos.FormattingEnabled = true;
            this.selectedAlgos.Location = new System.Drawing.Point(169, 19);
            this.selectedAlgos.Name = "selectedAlgos";
            this.selectedAlgos.Size = new System.Drawing.Size(121, 134);
            this.selectedAlgos.TabIndex = 1;
            // 
            // algorithmsBindingSource
            // 
            this.algorithmsBindingSource.DataMember = "Algorithms";
            this.algorithmsBindingSource.DataSource = this.bindingSource;
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(Logic.Subjective.SubjectiveSystem);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.imagesListView);
            this.groupBox2.Location = new System.Drawing.Point(4, 171);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(296, 285);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Obrazy";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(88, 256);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnRemoveImageButtonClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(6, 256);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Dodaj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSelectImagesClick);
            // 
            // imagesListView
            // 
            this.imagesListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.imagesListView.Location = new System.Drawing.Point(8, 19);
            this.imagesListView.Name = "imagesListView";
            this.imagesListView.Size = new System.Drawing.Size(282, 231);
            this.imagesListView.TabIndex = 0;
            this.imagesListView.UseCompatibleStateImageBehavior = false;
            this.imagesListView.View = System.Windows.Forms.View.List;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(402, 262);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnTrainButtonClick);
            // 
            // SubjectiveSystemControl
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(640, 460);
            this.Name = "SubjectiveSystemControl";
            this.Size = new System.Drawing.Size(640, 460);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button removeAlgoButton;
        private System.Windows.Forms.Button addAlgoButton;
        private System.Windows.Forms.ListBox selectedAlgos;
        private System.Windows.Forms.ListBox sourceAlgos;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.BindingSource algorithmsBindingSource;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView imagesListView;
        private System.Windows.Forms.Button button3;
    }
}
