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
            this.label2 = new System.Windows.Forms.Label();
            this.labelTicksAvarage = new System.Windows.Forms.Label();
            this.labelMiliseconds = new System.Windows.Forms.Label();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Message avarage time :";
            // 
            // labelTicksAvarage
            // 
            this.labelTicksAvarage.AutoSize = true;
            this.labelTicksAvarage.Location = new System.Drawing.Point(138, 32);
            this.labelTicksAvarage.Name = "labelTicksAvarage";
            this.labelTicksAvarage.Size = new System.Drawing.Size(13, 13);
            this.labelTicksAvarage.TabIndex = 2;
            this.labelTicksAvarage.Text = "0";
            // 
            // labelMiliseconds
            // 
            this.labelMiliseconds.AutoSize = true;
            this.labelMiliseconds.Location = new System.Drawing.Point(193, 32);
            this.labelMiliseconds.Name = "labelMiliseconds";
            this.labelMiliseconds.Size = new System.Drawing.Size(35, 13);
            this.labelMiliseconds.TabIndex = 3;
            this.labelMiliseconds.Text = "[ticks]";
            // 
            // IPCDataReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 88);
            this.Controls.Add(this.labelMiliseconds);
            this.Controls.Add(this.labelTicksAvarage);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelDescription);
            this.Name = "IPCDataReceiver";
            this.Text = "IPCDataReceiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelTicksAvarage;
        private System.Windows.Forms.Label labelMiliseconds;
    }
}

