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
            this.gameTic = new System.Windows.Forms.Timer(this.components);
            this.dgv_Bettors = new System.Windows.Forms.DataGridView();
            this.dgv_Bets = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_AddBettor = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BettorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_NameOfBettor = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rb_Racer1 = new System.Windows.Forms.RadioButton();
            this.rb_Racer2 = new System.Windows.Forms.RadioButton();
            this.rb_Racer3 = new System.Windows.Forms.RadioButton();
            this.rb_Racer4 = new System.Windows.Forms.RadioButton();
            this.btn_PlaceBet = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_StartRace = new System.Windows.Forms.Button();
            this.btn_RestartGame = new System.Windows.Forms.Button();
            this.btn_FinishBettors = new System.Windows.Forms.Button();
            this.txt_Bet_BettorName = new System.Windows.Forms.TextBox();
            this.num_BetAmount = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.pb_BackGround = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bettors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_BetAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BackGround)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTic
            // 
            this.gameTic.Interval = 33;
            this.gameTic.Tick += new System.EventHandler(this.gameTic_Tick);
            // 
            // dgv_Bettors
            // 
            this.dgv_Bettors.AllowUserToAddRows = false;
            this.dgv_Bettors.AllowUserToDeleteRows = false;
            this.dgv_Bettors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Bettors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Bettors.Location = new System.Drawing.Point(1036, 25);
            this.dgv_Bettors.Name = "dgv_Bettors";
            this.dgv_Bettors.ReadOnly = true;
            this.dgv_Bettors.Size = new System.Drawing.Size(234, 230);
            this.dgv_Bettors.TabIndex = 1;
            this.dgv_Bettors.TabStop = false;
            // 
            // dgv_Bets
            // 
            this.dgv_Bets.AllowUserToAddRows = false;
            this.dgv_Bets.AllowUserToDeleteRows = false;
            this.dgv_Bets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgv_Bets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Bets.Location = new System.Drawing.Point(1036, 286);
            this.dgv_Bets.Name = "dgv_Bets";
            this.dgv_Bets.ReadOnly = true;
            this.dgv_Bets.Size = new System.Drawing.Size(234, 255);
            this.dgv_Bets.TabIndex = 2;
            this.dgv_Bets.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 544);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Create Bettor";
            // 
            // btn_AddBettor
            // 
            this.btn_AddBettor.Location = new System.Drawing.Point(15, 650);
            this.btn_AddBettor.Name = "btn_AddBettor";
            this.btn_AddBettor.Size = new System.Drawing.Size(75, 23);
            this.btn_AddBettor.TabIndex = 1;
            this.btn_AddBettor.Tag = "Bettor";
            this.btn_AddBettor.Text = "Add Bettor";
            this.btn_AddBettor.UseVisualStyleBackColor = true;
            this.btn_AddBettor.Click += new System.EventHandler(this.btn_AddBettor_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 585);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // txt_BettorName
            // 
            this.txt_BettorName.Location = new System.Drawing.Point(15, 601);
            this.txt_BettorName.Name = "txt_BettorName";
            this.txt_BettorName.Size = new System.Drawing.Size(100, 20);
            this.txt_BettorName.TabIndex = 0;
            this.txt_BettorName.Tag = "Bettor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(290, 544);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Make Bet";
            // 
            // lbl_NameOfBettor
            // 
            this.lbl_NameOfBettor.AutoSize = true;
            this.lbl_NameOfBettor.Location = new System.Drawing.Point(290, 567);
            this.lbl_NameOfBettor.Name = "lbl_NameOfBettor";
            this.lbl_NameOfBettor.Size = new System.Drawing.Size(81, 13);
            this.lbl_NameOfBettor.TabIndex = 8;
            this.lbl_NameOfBettor.Text = "Name of Bettor:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 598);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Racer to bet on";
            // 
            // rb_Racer1
            // 
            this.rb_Racer1.AutoSize = true;
            this.rb_Racer1.Location = new System.Drawing.Point(293, 614);
            this.rb_Racer1.Name = "rb_Racer1";
            this.rb_Racer1.Size = new System.Drawing.Size(60, 17);
            this.rb_Racer1.TabIndex = 4;
            this.rb_Racer1.TabStop = true;
            this.rb_Racer1.Tag = "Bet";
            this.rb_Racer1.Text = "Racer1";
            this.rb_Racer1.UseVisualStyleBackColor = true;
            // 
            // rb_Racer2
            // 
            this.rb_Racer2.AutoSize = true;
            this.rb_Racer2.Location = new System.Drawing.Point(359, 614);
            this.rb_Racer2.Name = "rb_Racer2";
            this.rb_Racer2.Size = new System.Drawing.Size(60, 17);
            this.rb_Racer2.TabIndex = 5;
            this.rb_Racer2.TabStop = true;
            this.rb_Racer2.Tag = "Bet";
            this.rb_Racer2.Text = "Racer2";
            this.rb_Racer2.UseVisualStyleBackColor = true;
            // 
            // rb_Racer3
            // 
            this.rb_Racer3.AutoSize = true;
            this.rb_Racer3.Location = new System.Drawing.Point(425, 614);
            this.rb_Racer3.Name = "rb_Racer3";
            this.rb_Racer3.Size = new System.Drawing.Size(60, 17);
            this.rb_Racer3.TabIndex = 6;
            this.rb_Racer3.TabStop = true;
            this.rb_Racer3.Tag = "Bet";
            this.rb_Racer3.Text = "Racer3";
            this.rb_Racer3.UseVisualStyleBackColor = true;
            // 
            // rb_Racer4
            // 
            this.rb_Racer4.AutoSize = true;
            this.rb_Racer4.Location = new System.Drawing.Point(491, 614);
            this.rb_Racer4.Name = "rb_Racer4";
            this.rb_Racer4.Size = new System.Drawing.Size(60, 17);
            this.rb_Racer4.TabIndex = 7;
            this.rb_Racer4.TabStop = true;
            this.rb_Racer4.Tag = "Bet";
            this.rb_Racer4.Text = "Racer4";
            this.rb_Racer4.UseVisualStyleBackColor = true;
            // 
            // btn_PlaceBet
            // 
            this.btn_PlaceBet.Location = new System.Drawing.Point(491, 650);
            this.btn_PlaceBet.Name = "btn_PlaceBet";
            this.btn_PlaceBet.Size = new System.Drawing.Size(75, 23);
            this.btn_PlaceBet.TabIndex = 9;
            this.btn_PlaceBet.Tag = "Bet";
            this.btn_PlaceBet.Text = "Place Bet";
            this.btn_PlaceBet.UseVisualStyleBackColor = true;
            this.btn_PlaceBet.Click += new System.EventHandler(this.btn_PlaceBet_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(691, 544);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Race";
            // 
            // btn_StartRace
            // 
            this.btn_StartRace.Location = new System.Drawing.Point(694, 562);
            this.btn_StartRace.Name = "btn_StartRace";
            this.btn_StartRace.Size = new System.Drawing.Size(75, 23);
            this.btn_StartRace.TabIndex = 10;
            this.btn_StartRace.Tag = "Race";
            this.btn_StartRace.Text = "Start Race";
            this.btn_StartRace.UseVisualStyleBackColor = true;
            this.btn_StartRace.Click += new System.EventHandler(this.btn_StartRace_Click);
            // 
            // btn_RestartGame
            // 
            this.btn_RestartGame.Location = new System.Drawing.Point(694, 650);
            this.btn_RestartGame.Name = "btn_RestartGame";
            this.btn_RestartGame.Size = new System.Drawing.Size(75, 23);
            this.btn_RestartGame.TabIndex = 11;
            this.btn_RestartGame.Text = "Restart";
            this.btn_RestartGame.UseVisualStyleBackColor = true;
            this.btn_RestartGame.Click += new System.EventHandler(this.btn_RestartGame_Click);
            // 
            // btn_FinishBettors
            // 
            this.btn_FinishBettors.Location = new System.Drawing.Point(105, 650);
            this.btn_FinishBettors.Name = "btn_FinishBettors";
            this.btn_FinishBettors.Size = new System.Drawing.Size(75, 23);
            this.btn_FinishBettors.TabIndex = 2;
            this.btn_FinishBettors.Tag = "Bettor";
            this.btn_FinishBettors.Text = "Finish";
            this.btn_FinishBettors.UseVisualStyleBackColor = true;
            this.btn_FinishBettors.Click += new System.EventHandler(this.btn_FinishBettors_Click);
            // 
            // txt_Bet_BettorName
            // 
            this.txt_Bet_BettorName.Enabled = false;
            this.txt_Bet_BettorName.Location = new System.Drawing.Point(374, 564);
            this.txt_Bet_BettorName.Name = "txt_Bet_BettorName";
            this.txt_Bet_BettorName.Size = new System.Drawing.Size(100, 20);
            this.txt_Bet_BettorName.TabIndex = 3;
            this.txt_Bet_BettorName.Tag = "";
            // 
            // num_BetAmount
            // 
            this.num_BetAmount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.num_BetAmount.Location = new System.Drawing.Point(359, 653);
            this.num_BetAmount.Name = "num_BetAmount";
            this.num_BetAmount.Size = new System.Drawing.Size(120, 20);
            this.num_BetAmount.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(290, 655);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Bet Amount:";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1134, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Bettors";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1134, 270);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Bets";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 697);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.num_BetAmount);
            this.Controls.Add(this.txt_Bet_BettorName);
            this.Controls.Add(this.btn_FinishBettors);
            this.Controls.Add(this.btn_RestartGame);
            this.Controls.Add(this.btn_StartRace);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_PlaceBet);
            this.Controls.Add(this.rb_Racer4);
            this.Controls.Add(this.rb_Racer3);
            this.Controls.Add(this.rb_Racer2);
            this.Controls.Add(this.rb_Racer1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbl_NameOfBettor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_BettorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_AddBettor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv_Bets);
            this.Controls.Add(this.dgv_Bettors);
            this.Controls.Add(this.pb_BackGround);
            this.Name = "Form1";
            this.Text = "Racing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bettors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Bets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_BetAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_BackGround)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_BackGround;
        private System.Windows.Forms.Timer gameTic;
        private System.Windows.Forms.DataGridView dgv_Bettors;
        private System.Windows.Forms.DataGridView dgv_Bets;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_AddBettor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BettorName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_NameOfBettor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rb_Racer1;
        private System.Windows.Forms.RadioButton rb_Racer2;
        private System.Windows.Forms.RadioButton rb_Racer3;
        private System.Windows.Forms.RadioButton rb_Racer4;
        private System.Windows.Forms.Button btn_PlaceBet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_StartRace;
        private System.Windows.Forms.Button btn_RestartGame;
        private System.Windows.Forms.Button btn_FinishBettors;
        private System.Windows.Forms.TextBox txt_Bet_BettorName;
        private System.Windows.Forms.NumericUpDown num_BetAmount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

