namespace WinFormsApppp {
    partial class Main {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsPlayerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playerVsComputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadLevelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_ChessBoard = new System.Windows.Forms.GroupBox();
            this.label_whichPlayer = new System.Windows.Forms.Label();
            this.label_gameOver = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.loadLevelToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playerVsPlayerToolStripMenuItem,
            this.playerVsComputerToolStripMenuItem});
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.newGameToolStripMenuItem.Text = "New game";
            // 
            // playerVsPlayerToolStripMenuItem
            // 
            this.playerVsPlayerToolStripMenuItem.Name = "playerVsPlayerToolStripMenuItem";
            this.playerVsPlayerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.playerVsPlayerToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.playerVsPlayerToolStripMenuItem.Text = "Player vs. Player";
            this.playerVsPlayerToolStripMenuItem.Click += new System.EventHandler(this.playerVsPlayerToolStripMenuItem_Click);
            // 
            // playerVsComputerToolStripMenuItem
            // 
            this.playerVsComputerToolStripMenuItem.Name = "playerVsComputerToolStripMenuItem";
            this.playerVsComputerToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.playerVsComputerToolStripMenuItem.Size = new System.Drawing.Size(298, 22);
            this.playerVsComputerToolStripMenuItem.Text = "Player vs. Computer";
            this.playerVsComputerToolStripMenuItem.Click += new System.EventHandler(this.playerVsComputerToolStripMenuItem_Click);
            // 
            // loadLevelToolStripMenuItem
            // 
            this.loadLevelToolStripMenuItem.Name = "loadLevelToolStripMenuItem";
            this.loadLevelToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.loadLevelToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.loadLevelToolStripMenuItem.Text = "Load level";
            this.loadLevelToolStripMenuItem.Click += new System.EventHandler(this.loadLevelToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.SeToolStripMenuItem_Click);
            // 
            // groupBox_ChessBoard
            // 
            this.groupBox_ChessBoard.Enabled = false;
            this.groupBox_ChessBoard.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox_ChessBoard.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox_ChessBoard.Location = new System.Drawing.Point(12, 27);
            this.groupBox_ChessBoard.Name = "groupBox_ChessBoard";
            this.groupBox_ChessBoard.Size = new System.Drawing.Size(412, 427);
            this.groupBox_ChessBoard.TabIndex = 1;
            this.groupBox_ChessBoard.TabStop = false;
            this.groupBox_ChessBoard.Text = "Chess board";
            // 
            // label_whichPlayer
            // 
            this.label_whichPlayer.AutoSize = true;
            this.label_whichPlayer.Location = new System.Drawing.Point(12, 457);
            this.label_whichPlayer.Name = "label_whichPlayer";
            this.label_whichPlayer.Size = new System.Drawing.Size(0, 16);
            this.label_whichPlayer.TabIndex = 2;
            // 
            // label_gameOver
            // 
            this.label_gameOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_gameOver.Location = new System.Drawing.Point(183, 457);
            this.label_gameOver.Name = "label_gameOver";
            this.label_gameOver.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label_gameOver.Size = new System.Drawing.Size(241, 16);
            this.label_gameOver.TabIndex = 3;
            this.label_gameOver.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 479);
            this.Controls.Add(this.label_gameOver);
            this.Controls.Add(this.label_whichPlayer);
            this.Controls.Add(this.groupBox_ChessBoard);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Cascadia Code SemiBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Chess Game";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem gameToolStripMenuItem;
        private ToolStripMenuItem newGameToolStripMenuItem;
        private GroupBox groupBox_ChessBoard;
        private Label label_whichPlayer;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label label_gameOver;
        private ToolStripMenuItem playerVsPlayerToolStripMenuItem;
        private ToolStripMenuItem playerVsComputerToolStripMenuItem;
        private ToolStripMenuItem loadLevelToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
    }
}