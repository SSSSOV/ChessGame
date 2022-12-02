using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame {
    public class Settings { 
        public Color colorBlack { get; set; }
        public Color colorWhite { get; set; }
        public Color colorMove { get; set; }
        public Color colorCut { get; set; }
        public int theme { get; set; }
        

        public Settings() {
            theme = 0;
            colorBlack = Color.FromArgb(116, 150, 84);
            colorWhite = Color.FromArgb(236, 238, 212);
            colorMove = Color.FromArgb(248, 240, 103);
            colorCut = Color.FromArgb(183, 191, 36);
            ReadFromCfg();
        }
        public string ColorToString(Color color) {
            return color.ToArgb().ToString();
        }
        public Color StringToColor(string str) {
            return Color.FromArgb(int.Parse(str));
        }

        public void ReadFromCfg() { ReadFromCfg("cfg.txt"); }
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
                            default:break;
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        public void WriteToCfg() { WriteToCfg("cfg.txt"); }
        public void WriteToCfg(string path) {
            using StreamWriter streamWriter = new StreamWriter(path);
            streamWriter.WriteLine("theme=" + theme.ToString());
            streamWriter.WriteLine("colorBlack=" + ColorToString(colorBlack));
            streamWriter.WriteLine("colorWhite=" + ColorToString(colorWhite));
            streamWriter.WriteLine("colorMove=" + ColorToString(colorMove));
            streamWriter.WriteLine("colorCut=" + ColorToString(colorCut));
        }

    }
}
