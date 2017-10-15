namespace MultiMonitorManager
{
    partial class Form1
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
            this.AutoSetBackgrounds = new System.Windows.Forms.Button();
            this.ChooseWallpaperFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AutoSetBackgrounds
            // 
            this.AutoSetBackgrounds.Location = new System.Drawing.Point(25, 28);
            this.AutoSetBackgrounds.Name = "AutoSetBackgrounds";
            this.AutoSetBackgrounds.Size = new System.Drawing.Size(170, 23);
            this.AutoSetBackgrounds.TabIndex = 0;
            this.AutoSetBackgrounds.Text = "Auto Set Backgrounds";
            this.AutoSetBackgrounds.UseVisualStyleBackColor = true;
            this.AutoSetBackgrounds.Click += new System.EventHandler(this.AutoSetBackgrounds_Click);
            // 
            // ChooseWallpaperFolder
            // 
            this.ChooseWallpaperFolder.Location = new System.Drawing.Point(291, 27);
            this.ChooseWallpaperFolder.Name = "ChooseWallpaperFolder";
            this.ChooseWallpaperFolder.Size = new System.Drawing.Size(145, 23);
            this.ChooseWallpaperFolder.TabIndex = 1;
            this.ChooseWallpaperFolder.Text = "Choose Wallpaper folder";
            this.ChooseWallpaperFolder.UseVisualStyleBackColor = true;
            this.ChooseWallpaperFolder.Click += new System.EventHandler(this.ChooseWallpaperFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(767, 518);
            this.Controls.Add(this.ChooseWallpaperFolder);
            this.Controls.Add(this.AutoSetBackgrounds);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AutoSetBackgrounds;
        private System.Windows.Forms.Button ChooseWallpaperFolder;
    }
}

