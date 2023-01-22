using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame {
    public class Settings { 
        public Color colorBlack { get; set; } // Color of black fields on the board.
        public Color colorWhite { get; set; } // Color of white fields on the board.
        public Color colorMove { get; set; } // Color of fields on the board where the figure can moves.
        public Color colorCut { get; set; } // Color of fields on the board where the figure can cuts.
        public int theme { get; set; } // Board color theme.
        public bool PaintAllPossible { get; set; } // Is it necessary to draw all possible actions.

        private string defaultPath = "res/cfg.txt"; // Path to the file with settings value.

        /// <summary>
        /// Constructor of setting. If the file with the value is not found, then the default values are set.
        /// </summary>
        public Settings() {
            theme = 2;
            colorBlack = Color.FromArgb(116, 150, 84);
            colorWhite = Color.FromArgb(236, 238, 212);
            colorMove = Color.FromArgb(248, 240, 103);
            colorCut = Color.FromArgb(183, 191, 36);
            PaintAllPossible = false;
            ReadFromCfg();
        }
        
        /// <summary>
        /// Convert color to string.
        /// </summary>
        public string ColorToString(Color color) {
            return color.ToArgb().ToString();
        }
        
        /// <summary>
        /// Convert string to color.
        /// </summary>
        public Color StringToColor(string str) {
            return Color.FromArgb(int.Parse(str));
        }

        /// <summary>
        /// Read file with values from default file.
        /// </summary>
        public void ReadFromCfg() { ReadFromCfg(defaultPath); }

        /// <summary>
        /// Read file with values from file.
        /// </summary
        public void ReadFromCfg(string path) {
            try {
                using StreamReader streamReader = new StreamReader(path);
                string line;
                string[] param;
                while ((line = streamReader.ReadLine()) != null) {
                    param = line.Split('=');
                    switch (param[0]) {
                        case "colorBlack": colorBlack = StringToColor(param[1]); break;
                        case "colorWhite": colorWhite = StringToColor(param[1]); break;
                        case "colorMove": colorMove = StringToColor(param[1]); break;
                        case "colorCut": colorCut = StringToColor(param[1]); break;
                        case "theme": theme = int.Parse(param[1]); break;
                        case "paintAllPossible": PaintAllPossible = param[1] == "True"; break;
                        default: break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Config file not found.\nThe settings are set by default.\n" + ex.Message, "Warning!");
            }
        }

        /// <summary>
        /// Write settings to default file.
        /// </summary>
        public void WriteToCfg() { WriteToCfg(defaultPath); }

        /// <summary>
        /// Write settings to file.
        /// </summary>
        public void WriteToCfg(string path) {
            using StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("theme=" + theme.ToString());
            streamWriter.WriteLine("colorBlack=" + ColorToString(colorBlack));
            streamWriter.WriteLine("colorWhite=" + ColorToString(colorWhite));
            streamWriter.WriteLine("colorMove=" + ColorToString(colorMove));
            streamWriter.WriteLine("colorCut=" + ColorToString(colorCut));
            streamWriter.WriteLine("paintAllPossible=" + PaintAllPossible.ToString());
        }

    }
}
