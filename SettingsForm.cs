using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessGame {
    public partial class SettingsForm : Form {

        Settings settings; // Settings object.

        /// <summary>
        /// Set components value from settings object.
        /// </summary>
        /// <param name="settings">Settings object</param>
        private void SetComponentsValue(Settings settings) {
            comboBox_theme.SelectedIndex = settings.theme;
            button_blackColor.BackColor = settings.colorBlack;
            button_whiteColor.BackColor = settings.colorWhite;
            button_moveColor.BackColor = settings.colorMove;
            button_cutColor.BackColor = settings.colorCut;
            checkBox_paintAllPosible.Checked = settings.PaintAllPossible;
        }
       
        public SettingsForm(Settings settings) {
            InitializeComponent();
            this.settings = settings;
            SetComponentsValue(settings);
        }

        /// <summary>
        /// Button click event handler. Shows a form for choosing a color.
        /// </summary>
        private void Button_Color_Click(object sender, EventArgs e) {
            Button buttonColor = (Button)sender;
            if(colorDialog.ShowDialog() == DialogResult.OK) {
                buttonColor.BackColor = colorDialog.Color;
                comboBox_theme.SelectedIndex = 3;
            }
        }

        /// <summary>
        /// Button click event handler. Save settings to the file.
        /// </summary>
        private void buttonSave_Click(object sender, EventArgs e) {
            settings.colorBlack = button_blackColor.BackColor;
            settings.colorWhite = button_whiteColor.BackColor;
            settings.colorMove = button_moveColor.BackColor;
            settings.colorCut = button_cutColor.BackColor;
            settings.WriteToCfg();
            this.Close();
        }

        /// <summary>
        /// Color theme change handler.
        /// </summary>
        private void comboBox_theme_SelectedIndexChanged(object sender, EventArgs e) {
            switch (comboBox_theme.SelectedIndex) {
                case 0: {
                    settings.theme = 0;
                    button_blackColor.BackColor = Color.FromArgb(184, 139, 98);
                    button_whiteColor.BackColor = Color.FromArgb(242, 216, 179);
                    button_moveColor.BackColor = Color.FromArgb(95, 192, 224);
                    button_cutColor.BackColor = Color.FromArgb(255, 102, 102);
                }
                break;
                case 1: {
                    settings.theme = 1;
                    button_blackColor.BackColor = Color.FromArgb(16, 22, 44);
                    button_whiteColor.BackColor = Color.FromArgb(55, 65, 98);
                    button_moveColor.BackColor = Color.FromArgb(51, 89, 102);
                    button_cutColor.BackColor = Color.FromArgb(0, 51, 102);
                }
                break;
                case 2: {
                    settings.theme = 2;
                    button_blackColor.BackColor = Color.FromArgb(116, 150, 84);
                    button_whiteColor.BackColor = Color.FromArgb(236, 238, 212);
                    button_moveColor.BackColor = Color.FromArgb(248, 240, 103);
                    button_cutColor.BackColor = Color.FromArgb(183, 191, 36);
                } break;
                default: {
                    settings.theme = 3;
                }
                break;
            }
                
        }

        /// <summary>
        /// Check box render handler for all possible actions.
        /// </summary>
        private void checkBox_paintAllPosible_CheckedChanged(object sender, EventArgs e) {
            settings.PaintAllPossible = checkBox_paintAllPosible.Checked;
        }

        /// <summary>
        /// Cancel button click handler. Resets all changes.
        /// </summary>
        private void button_cancel_Click(object sender, EventArgs e) {
            settings.ReadFromCfg();
            this.Close();
        }
    }
}
