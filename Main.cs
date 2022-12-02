using ChessGame;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApppp {
    public partial class Main : Form {

        Settings settings = new();

        ChessBoard cb = new();
        Point selectedPoint = new(-1, -1);
        Button[,] game_field = new Button[8, 8];
        int[,] map = new int[8, 8];
        Point point_of_field = new(6, 20);
        Random random = new();
        int player = 0;

        private void ResetButtonColor(Point p) {
            game_field[p.X, p.Y].BackColor = (p.X + p.Y) % 2 == 0 ? settings.colorWhite : settings.colorBlack;
        }
        private void ResetButtonsColor(int[,] map) {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    if (map[x, y] != 0) ResetButtonColor(new Point(x, y));
                }
        }
        public void DrowFigure(Point p) {
            Figure figure = cb.getFigure(p);
            if (figure.getName() != "none") game_field[p.X, p.Y].BackgroundImage = figure.getImage();
            else game_field[p.X, p.Y].BackgroundImage = null;
        }
        public void DrowFigures(int[,] map) {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    if (map[x, y] != 0) DrowFigure(new Point(x, y));
                }
        }
        public void DrowAllFigures() {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    DrowFigure(new Point(x, y));
                }
        }


        public Main() {
            settings.ReadFromCfg();
            InitializeComponent();
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    Button button = new Button();
                    button.Name = "button_" + x.ToString() + y.ToString();
                    button.Size = new Size(50, 50);
                    button.Location = new Point(x * 50 + point_of_field.X, y * 50 + point_of_field.Y);
                    button.BackColor = (x + y) % 2 == 0 ? settings.colorWhite : settings.colorBlack;
                    button.Click += new EventHandler(OnButtonPress);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    game_field[x, y] = button;
                    groupBox_ChessBoard.Controls.Add(button);
                }
        }

        public void OnButtonPress(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (button.BackColor != settings.colorMove && button.BackColor != settings.colorCut) {
                ResetButtonsColor(map);
                selectedPoint.X = -1;
            }
            if (selectedPoint.X == -1) {
                selectedPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                if (cb.getFigure(selectedPoint).getIdPlayer() != player) return;
                map = cb.getPossibleMoves(selectedPoint);
                bool isNotMoveble = true;
                for (int x = 0; x < 8; x++)
                    for (int y = 0; y < 8; y++) {
                        if (map[x, y] == 1) game_field[x, y].BackColor = settings.colorMove;
                        if (map[x, y] == 2) game_field[x, y].BackColor = settings.colorCut;
                            isNotMoveble = false;
                    }
                if (isNotMoveble) selectedPoint.X = -1;
            }
            else if (button.BackColor == settings.colorMove) {
                Point newPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                cb.MoveFigure(selectedPoint, newPoint);
                ResetButtonsColor(map);
                DrowFigure(selectedPoint);
                DrowFigure(newPoint);
                selectedPoint.X = -1;
                player = player % 2 + 1;
                label_whichPlayer.Text = player.ToString() + " player move.";
            }
            else if (button.BackColor == settings.colorCut) {
                Point newPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                cb.MoveFigure(selectedPoint, newPoint);
                ResetButtonsColor(map);
                DrowFigure(selectedPoint);
                DrowFigure(newPoint);
                selectedPoint.X = -1;
                player = player % 2 + 1;
                label_whichPlayer.Text = player.ToString() + " player move.";
            }
        }

        private void NewGame(object sender, EventArgs e) {
            groupBox_ChessBoard.Enabled = true;
            cb.ArrangeFigures();
            DrowAllFigures();
            selectedPoint.X = -1;

            player = random.Next(1,3);
            label_whichPlayer.Text = player.ToString() + " player move.";
        }

        private void SeToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsForm sf = new(settings);
            sf.Owner = this;
            sf.ShowDialog();
            settings.ReadFromCfg();
            SetButtonColors();
        }
        private void SetButtonColors() {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    game_field[x, y].BackColor = (x + y) % 2 == 0 ? settings.colorWhite : settings.colorBlack;
                }
        }
    }
}