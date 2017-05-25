namespace TheBettingGame
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
            this.pb_BackGround = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_BackGround
            // 
            this.pb_BackGround.Image = global::TheBettingGame.Properties.Resources._1stBackGround;
            this.pb_BackGround.Location = new System.Drawing.Point(0, 0);
            this.pb_BackGround.Name = "pb_BackGround";
            this.pb_BackGround.Size = new System.Drawing.Size(1037, 541);
            this.pb_BackGround.TabIndex = 0;
            this.pb_BackGround.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 541);
            this.Controls.Add(this.pb_BackGround);
            this.Name = "Form1";
            this.Text = "Racing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_BackGround)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_BackGround;
    }
}

