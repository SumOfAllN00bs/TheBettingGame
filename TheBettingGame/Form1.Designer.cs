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
            this.components = new System.ComponentModel.Container();
            this.pb_BackGround = new System.Windows.Forms.PictureBox();
            this.gameTic = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            this.pb_BackGround.Click += new System.EventHandler(this.pb_BackGround_Click);
            this.pb_BackGround.Paint += new System.Windows.Forms.PaintEventHandler(this.pb_BackGround_Paint);
            // 
            // gameTic
            // 
            this.gameTic.Enabled = true;
            this.gameTic.Interval = 33;
            this.gameTic.Tick += new System.EventHandler(this.gameTic_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(431, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1037, 541);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pb_BackGround);
            this.Name = "Form1";
            this.Text = "Racing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_BackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_BackGround;
        private System.Windows.Forms.Timer gameTic;
        private System.Windows.Forms.Label label1;
    }
}

