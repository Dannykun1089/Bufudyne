
namespace Bufudyne
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.lblAlbumEntryPrompt = new System.Windows.Forms.Label();
            this.lblTrackEntryPrompt = new System.Windows.Forms.Label();
            this.tbxAlbumEntry = new System.Windows.Forms.TextBox();
            this.tbxTrackEntry = new System.Windows.Forms.TextBox();
            this.pgbAlbumProgress = new System.Windows.Forms.ProgressBar();
            this.lblAlbumProgress = new System.Windows.Forms.Label();
            this.lblCurrentTrack = new System.Windows.Forms.Label();
            this.btnDownloadAlbum = new System.Windows.Forms.Button();
            this.btnDownloadTrack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAlbumEntryPrompt
            // 
            this.lblAlbumEntryPrompt.AutoSize = true;
            this.lblAlbumEntryPrompt.ForeColor = System.Drawing.Color.White;
            this.lblAlbumEntryPrompt.Location = new System.Drawing.Point(13, 18);
            this.lblAlbumEntryPrompt.Name = "lblAlbumEntryPrompt";
            this.lblAlbumEntryPrompt.Size = new System.Drawing.Size(83, 17);
            this.lblAlbumEntryPrompt.TabIndex = 0;
            this.lblAlbumEntryPrompt.Text = "Album URL:";
            // 
            // lblTrackEntryPrompt
            // 
            this.lblTrackEntryPrompt.AutoSize = true;
            this.lblTrackEntryPrompt.ForeColor = System.Drawing.Color.White;
            this.lblTrackEntryPrompt.Location = new System.Drawing.Point(13, 57);
            this.lblTrackEntryPrompt.Name = "lblTrackEntryPrompt";
            this.lblTrackEntryPrompt.Size = new System.Drawing.Size(80, 17);
            this.lblTrackEntryPrompt.TabIndex = 1;
            this.lblTrackEntryPrompt.Text = "Track URL:";
            // 
            // tbxAlbumEntry
            // 
            this.tbxAlbumEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxAlbumEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxAlbumEntry.ForeColor = System.Drawing.Color.White;
            this.tbxAlbumEntry.Location = new System.Drawing.Point(102, 19);
            this.tbxAlbumEntry.Name = "tbxAlbumEntry";
            this.tbxAlbumEntry.Size = new System.Drawing.Size(212, 15);
            this.tbxAlbumEntry.TabIndex = 2;
            // 
            // tbxTrackEntry
            // 
            this.tbxTrackEntry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.tbxTrackEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTrackEntry.ForeColor = System.Drawing.Color.White;
            this.tbxTrackEntry.Location = new System.Drawing.Point(102, 58);
            this.tbxTrackEntry.Name = "tbxTrackEntry";
            this.tbxTrackEntry.Size = new System.Drawing.Size(212, 15);
            this.tbxTrackEntry.TabIndex = 3;
            // 
            // pgbAlbumProgress
            // 
            this.pgbAlbumProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.pgbAlbumProgress.Location = new System.Drawing.Point(16, 130);
            this.pgbAlbumProgress.Name = "pgbAlbumProgress";
            this.pgbAlbumProgress.Size = new System.Drawing.Size(460, 23);
            this.pgbAlbumProgress.TabIndex = 4;
            // 
            // lblAlbumProgress
            // 
            this.lblAlbumProgress.ForeColor = System.Drawing.Color.White;
            this.lblAlbumProgress.Location = new System.Drawing.Point(16, 99);
            this.lblAlbumProgress.Name = "lblAlbumProgress";
            this.lblAlbumProgress.Size = new System.Drawing.Size(460, 25);
            this.lblAlbumProgress.TabIndex = 6;
            this.lblAlbumProgress.Text = "Album Progress: ";
            this.lblAlbumProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrentTrack
            // 
            this.lblCurrentTrack.ForeColor = System.Drawing.Color.White;
            this.lblCurrentTrack.Location = new System.Drawing.Point(16, 160);
            this.lblCurrentTrack.Name = "lblCurrentTrack";
            this.lblCurrentTrack.Size = new System.Drawing.Size(460, 25);
            this.lblCurrentTrack.TabIndex = 7;
            this.lblCurrentTrack.Text = "Current Track: ";
            this.lblCurrentTrack.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnDownloadAlbum
            // 
            this.btnDownloadAlbum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDownloadAlbum.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDownloadAlbum.FlatAppearance.BorderSize = 0;
            this.btnDownloadAlbum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadAlbum.ForeColor = System.Drawing.Color.White;
            this.btnDownloadAlbum.Location = new System.Drawing.Point(329, 10);
            this.btnDownloadAlbum.Name = "btnDownloadAlbum";
            this.btnDownloadAlbum.Size = new System.Drawing.Size(147, 33);
            this.btnDownloadAlbum.TabIndex = 9;
            this.btnDownloadAlbum.Text = "Download Album";
            this.btnDownloadAlbum.UseVisualStyleBackColor = false;
            this.btnDownloadAlbum.Click += new System.EventHandler(this.btnDownloadAlbum_Click);
            // 
            // btnDownloadTrack
            // 
            this.btnDownloadTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnDownloadTrack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDownloadTrack.FlatAppearance.BorderSize = 0;
            this.btnDownloadTrack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadTrack.ForeColor = System.Drawing.Color.White;
            this.btnDownloadTrack.Location = new System.Drawing.Point(329, 49);
            this.btnDownloadTrack.Name = "btnDownloadTrack";
            this.btnDownloadTrack.Size = new System.Drawing.Size(147, 32);
            this.btnDownloadTrack.TabIndex = 10;
            this.btnDownloadTrack.Text = "Download Track";
            this.btnDownloadTrack.UseVisualStyleBackColor = false;
            this.btnDownloadTrack.Click += new System.EventHandler(this.btnDownloadTrack_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(513, 206);
            this.Controls.Add(this.btnDownloadTrack);
            this.Controls.Add(this.btnDownloadAlbum);
            this.Controls.Add(this.lblCurrentTrack);
            this.Controls.Add(this.lblAlbumProgress);
            this.Controls.Add(this.pgbAlbumProgress);
            this.Controls.Add(this.tbxTrackEntry);
            this.Controls.Add(this.tbxAlbumEntry);
            this.Controls.Add(this.lblTrackEntryPrompt);
            this.Controls.Add(this.lblAlbumEntryPrompt);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Bufudyne";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAlbumEntryPrompt;
        private System.Windows.Forms.Label lblTrackEntryPrompt;
        private System.Windows.Forms.TextBox tbxAlbumEntry;
        private System.Windows.Forms.TextBox tbxTrackEntry;
        private System.Windows.Forms.ProgressBar pgbAlbumProgress;
        private System.Windows.Forms.Label lblAlbumProgress;
        private System.Windows.Forms.Label lblCurrentTrack;
        private System.Windows.Forms.Button btnDownloadAlbum;
        private System.Windows.Forms.Button btnDownloadTrack;
    }
}

