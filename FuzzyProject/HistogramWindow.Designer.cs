namespace FuzzyProject
{
    partial class HistogramWindow
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
            this.histogramControl = new AForge.Controls.Histogram();
            this.SuspendLayout();
            // 
            // histogramControl
            // 
            this.histogramControl.AllowSelection = true;
            this.histogramControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histogramControl.Location = new System.Drawing.Point(0, 0);
            this.histogramControl.MinimumSize = new System.Drawing.Size(256, 0);
            this.histogramControl.Name = "histogramControl";
            this.histogramControl.Size = new System.Drawing.Size(338, 290);
            this.histogramControl.TabIndex = 0;
            this.histogramControl.Text = "histogramControl";
            this.histogramControl.Values = null;
            // 
            // HistogramWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 290);
            this.Controls.Add(this.histogramControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MinimumSize = new System.Drawing.Size(272, 126);
            this.Name = "HistogramWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Histogram";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private AForge.Controls.Histogram histogramControl;
    }
}