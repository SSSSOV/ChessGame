namespace ChessGame {
    partial class SettingsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox_colorButtons = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button_cutColor = new System.Windows.Forms.Button();
            this.button_moveColor = new System.Windows.Forms.Button();
            this.button_whiteColor = new System.Windows.Forms.Button();
            this.button_blackColor = new System.Windows.Forms.Button();
            this.comboBox_theme = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox_colorButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Settings:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select theme:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox_colorButtons);
            this.groupBox1.Controls.Add(this.comboBox_theme);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 145);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Theme:";
            // 
            // groupBox_colorButtons
            // 
            this.groupBox_colorButtons.Controls.Add(this.label6);
            this.groupBox_colorButtons.Controls.Add(this.label5);
            this.groupBox_colorButtons.Controls.Add(this.label4);
            this.groupBox_colorButtons.Controls.Add(this.label3);
            this.groupBox_colorButtons.Controls.Add(this.button_cutColor);
            this.groupBox_colorButtons.Controls.Add(this.button_moveColor);
            this.groupBox_colorButtons.Controls.Add(this.button_whiteColor);
            this.groupBox_colorButtons.Controls.Add(this.button_blackColor);
            this.groupBox_colorButtons.Location = new System.Drawing.Point(6, 44);
            this.groupBox_colorButtons.Name = "groupBox_colorButtons";
            this.groupBox_colorButtons.Size = new System.Drawing.Size(230, 96);
            this.groupBox_colorButtons.TabIndex = 4;
            this.groupBox_colorButtons.TabStop = false;
            this.groupBox_colorButtons.Text = "Colors:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cut";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Move";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(62, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "White";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Black";
            // 
            // button_cutColor
            // 
            this.button_cutColor.Location = new System.Drawing.Point(174, 20);
            this.button_cutColor.Name = "button_cutColor";
            this.button_cutColor.Size = new System.Drawing.Size(50, 50);
            this.button_cutColor.TabIndex = 4;
            this.button_cutColor.UseVisualStyleBackColor = true;
            this.button_cutColor.Click += new System.EventHandler(this.Button_Color_Click);
            // 
            // button_moveColor
            // 
            this.button_moveColor.Location = new System.Drawing.Point(118, 20);
            this.button_moveColor.Name = "button_moveColor";
            this.button_moveColor.Size = new System.Drawing.Size(50, 50);
            this.button_moveColor.TabIndex = 4;
            this.button_moveColor.UseVisualStyleBackColor = true;
            this.button_moveColor.Click += new System.EventHandler(this.Button_Color_Click);
            // 
            // button_whiteColor
            // 
            this.button_whiteColor.Location = new System.Drawing.Point(62, 20);
            this.button_whiteColor.Name = "button_whiteColor";
            this.button_whiteColor.Size = new System.Drawing.Size(50, 50);
            this.button_whiteColor.TabIndex = 4;
            this.button_whiteColor.UseVisualStyleBackColor = true;
            this.button_whiteColor.Click += new System.EventHandler(this.Button_Color_Click);
            // 
            // button_blackColor
            // 
            this.button_blackColor.Location = new System.Drawing.Point(6, 20);
            this.button_blackColor.Name = "button_blackColor";
            this.button_blackColor.Size = new System.Drawing.Size(50, 50);
            this.button_blackColor.TabIndex = 4;
            this.button_blackColor.UseVisualStyleBackColor = true;
            this.button_blackColor.Click += new System.EventHandler(this.Button_Color_Click);
            // 
            // comboBox_theme
            // 
            this.comboBox_theme.FormattingEnabled = true;
            this.comboBox_theme.Items.AddRange(new object[] {
            "Classic",
            "Dark",
            "Light",
            "Custom"});
            this.comboBox_theme.Location = new System.Drawing.Point(110, 14);
            this.comboBox_theme.Name = "comboBox_theme";
            this.comboBox_theme.Size = new System.Drawing.Size(126, 24);
            this.comboBox_theme.TabIndex = 3;
            this.comboBox_theme.SelectedIndexChanged += new System.EventHandler(this.comboBox_theme_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(179, 445);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(98, 445);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(267, 480);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Cascadia Code", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_colorButtons.ResumeLayout(false);
            this.groupBox_colorButtons.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private GroupBox groupBox1;
        private ComboBox comboBox_theme;
        private Button button_blackColor;
        private Button button_whiteColor;
        private Button button_moveColor;
        private Button button_cutColor;
        private Button button1;
        private Button button2;
        private GroupBox groupBox_colorButtons;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ColorDialog colorDialog;
    }
}