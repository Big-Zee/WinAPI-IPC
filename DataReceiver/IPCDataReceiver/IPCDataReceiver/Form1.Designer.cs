namespace IPCDataReceiver
{
    partial class IPCDataReceiver
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
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(12, 9);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(286, 13);
            this.labelDescription.TabIndex = 0;
            this.labelDescription.Text = "POC application to see how fast IPC over SendMessage is.";
            // 
            // IPCDataReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 72);
            this.Controls.Add(this.labelDescription);
            this.MaximumSize = new System.Drawing.Size(350, 110);
            this.MinimumSize = new System.Drawing.Size(350, 110);
            this.Name = "IPCDataReceiver";
            this.Text = "IPCDataReceiver";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPCDataReceiver_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
    }
}

