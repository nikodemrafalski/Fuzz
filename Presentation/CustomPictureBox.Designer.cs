namespace Presentation
{
    partial class CustomPictureBox
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
            this.contextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.histogramStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setAsSourceStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveImageStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // contextStrip
            // 
            this.contextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.histogramStripItem,
            this.setAsSourceStripItem,
            this.saveImageStripItem});
            this.contextStrip.Name = "contextStrip";
            this.contextStrip.Size = new System.Drawing.Size(168, 70);
            this.contextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.OnContextStripOpening);
            // 
            // histogramStripItem
            // 
            this.histogramStripItem.Name = "histogramStripItem";
            this.histogramStripItem.Size = new System.Drawing.Size(167, 22);
            this.histogramStripItem.Text = "Histogram";
            // 
            // setAsSourceStripItem
            // 
            this.setAsSourceStripItem.Name = "setAsSourceStripItem";
            this.setAsSourceStripItem.Size = new System.Drawing.Size(167, 22);
            this.setAsSourceStripItem.Text = "Ustaw jako źródło";
            // 
            // saveImageStripItem
            // 
            this.saveImageStripItem.Name = "saveImageStripItem";
            this.saveImageStripItem.Size = new System.Drawing.Size(167, 22);
            this.saveImageStripItem.Text = "Zapisz";
            this.contextStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip contextStrip;
        private System.Windows.Forms.ToolStripMenuItem histogramStripItem;
        private System.Windows.Forms.ToolStripMenuItem setAsSourceStripItem;
        private System.Windows.Forms.ToolStripMenuItem saveImageStripItem;
    }
}
