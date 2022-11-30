using ChessGame;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApppp {
    public partial class Main : Form {

        Color black = Color.FromArgb(116, 150, 84);
        Color white = Color.FromArgb(236, 238, 212);
        Color yellow = Color.FromArgb(248, 240, 103);
        Color red = Color.FromArgb(183, 191, 36);

        ChessBoard cb = new ChessBoard();
        Point selectedPoint = new Point(-1, -1);
        Button[,] game_field = new Button[8, 8];
        int[,] map = new int[8, 8];
        Point point_of_field = new Point(6, 20);
        Random random = new Random();
        int player = 0;

        private void ResetButtonColor(Point p) {
            game_field[p.X, p.Y].BackColor = (p.X + p.Y) % 2 == 0 ? white : black;
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
            InitializeComponent();
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    Button button = new Button();
                    button.Name = "button_" + x.ToString() + y.ToString();
                    button.Size = new Size(50, 50);
                    button.Location = new Point(x * 50 + point_of_field.X, y * 50 + point_of_field.Y);
                    button.BackColor = (x + y) % 2 == 0 ? white : black;
                    button.Click += new EventHandler(OnButtonPress);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.FlatStyle= FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    game_field[x, y] = button;
                    groupBox_ChessBoard.Controls.Add(button);
                }
        }

        public void OnButtonPress(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (button.BackColor != yellow && button.BackColor != red) {
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
                        if (map[x, y] == 1) game_field[x, y].BackColor = yellow;
                        if (map[x, y] == 2) game_field[x, y].BackColor = red;
                            isNotMoveble = false;
                    }
                if (isNotMoveble) selectedPoint.X = -1;
            }
            else if (button.BackColor == yellow) {
                Point newPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                cb.MoveFigure(selectedPoint, newPoint);
                ResetButtonsColor(map);
                DrowFigure(selectedPoint);
                DrowFigure(newPoint);
                selectedPoint.X = -1;
                player = player % 2 + 1;
                label_whichPlayer.Text = player.ToString() + " player move.";
            }
            else if (button.BackColor == red) {
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
    }
}