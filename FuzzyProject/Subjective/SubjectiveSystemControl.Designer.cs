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
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
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
            // SubjectiveSystemControl
            // 
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.groupBox1);
            this.Name = "SubjectiveSystemControl";
            this.Size = new System.Drawing.Size(640, 480);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
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
    }
}
