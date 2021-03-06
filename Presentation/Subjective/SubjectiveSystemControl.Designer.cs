﻿namespace Presentation.Subjective
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
            this.observersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.processingMethodCombo = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.observersBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
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
            this.groupBox1.Text = "1. Algorytmy";
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
            this.selectedAlgos.DisplayMember = "CustomName";
            this.selectedAlgos.FormattingEnabled = true;
            this.selectedAlgos.Location = new System.Drawing.Point(169, 19);
            this.selectedAlgos.Name = "selectedAlgos";
            this.selectedAlgos.Size = new System.Drawing.Size(121, 134);
            this.selectedAlgos.TabIndex = 1;
            this.selectedAlgos.ValueMember = "CustomName";
            // 
            // algorithmsBindingSource
            // 
            this.algorithmsBindingSource.DataSource = typeof(Logic.Subjective.AlgorithmInfo);
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
            this.groupBox2.Size = new System.Drawing.Size(296, 222);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2. Obrazy";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(88, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "Usuń";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnRemoveImageButtonClick);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(8, 185);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 24);
            this.button1.TabIndex = 3;
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
            this.imagesListView.Size = new System.Drawing.Size(282, 160);
            this.imagesListView.TabIndex = 0;
            this.imagesListView.UseCompatibleStateImageBehavior = false;
            this.imagesListView.View = System.Windows.Forms.View.List;
            // 
            // button3
            // 
            this.button3.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.observersBindingSource, "CanBeTrained", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(21, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Trenowanie";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.OnTrainButtonClick);
            // 
            // observersBindingSource
            // 
            this.observersBindingSource.DataSource = typeof(Logic.Subjective.ObserverData);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.comboBox1);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(307, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 161);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "3. Trening";
            // 
            // button6
            // 
            this.button6.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.observersBindingSource, "FullyTrained", true));
            this.button6.Enabled = false;
            this.button6.Location = new System.Drawing.Point(21, 130);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(94, 23);
            this.button6.TabIndex = 8;
            this.button6.Text = "Wnioskowanie";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.OnInferingButtonCLick);
            // 
            // label3
            // 
            this.label3.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.observersBindingSource, "Status", true, System.Windows.Forms.DataSourceUpdateMode.Never));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(111, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 23);
            this.label3.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(18, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Stan treningu:";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(254, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(37, 24);
            this.button5.TabIndex = 5;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.OnRemoveObserverClick);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(213, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(37, 24);
            this.button4.TabIndex = 5;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.OnAddObserverClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Obserwator";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.observersBindingSource;
            this.comboBox1.DisplayMember = "ObserverName";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(85, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.ValueMember = "ObserverName";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.processingMethodCombo);
            this.groupBox4.Controls.Add(this.button7);
            this.groupBox4.Location = new System.Drawing.Point(307, 171);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(300, 222);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "4. Wykorzystanie ocen algorytmów";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(21, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Metoda przetwarzania:";
            // 
            // processingMethodCombo
            // 
            this.processingMethodCombo.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.observersBindingSource, "EvaluationDone", true));
            this.processingMethodCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.processingMethodCombo.Enabled = false;
            this.processingMethodCombo.FormattingEnabled = true;
            this.processingMethodCombo.Location = new System.Drawing.Point(21, 105);
            this.processingMethodCombo.Name = "processingMethodCombo";
            this.processingMethodCombo.Size = new System.Drawing.Size(270, 21);
            this.processingMethodCombo.TabIndex = 1;
            // 
            // button7
            // 
            this.button7.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.observersBindingSource, "EvaluationDone", true));
            this.button7.Enabled = false;
            this.button7.Location = new System.Drawing.Point(21, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(94, 50);
            this.button7.TabIndex = 0;
            this.button7.Text = "Przetwarzaj obraz";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.OnProcessImageClick);
            // 
            // SubjectiveSystemControl
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximumSize = new System.Drawing.Size(640, 460);
            this.Name = "SubjectiveSystemControl";
            this.Size = new System.Drawing.Size(640, 460);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.algorithmsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.observersBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
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
        private System.Windows.Forms.ListView imagesListView;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.BindingSource observersBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox processingMethodCombo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
