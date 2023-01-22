using ChessGame;
using System.Diagnostics;
using System.Media;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApppp {
    public partial class Main : Form {

        Settings settings = new(); // Field with settings object.
        ChessBoard cb = new(); // Field with chess.

        Button[,] game_field = new Button[8, 8]; // 2d array with buttons.
        Random random = new(); // Pseudo-random number generator.
        SoundPlayer soundPlayer; // Controls the playback of a WAV audio file.
        int[,] map = new int[8, 8]; // Map with 
        int player = 0; // Id of curent move player.
        bool isComputer = false; // Game with computer.
        Point selectedPoint = new(-1, -1); // Selected point.
        Point point_of_field = new(6, 20); // The point from which the playing field is drawn.

        /// <summary>
        /// Reset color for button.
        /// </summary>
        /// <param name="p">Button coordinates.</param>
        private void ResetButtonColor(Point p) {
            game_field[p.X, p.Y].BackColor = (p.X + p.Y) % 2 == 0 ? settings.colorWhite : settings.colorBlack;
        }

        /// <summary>
        /// Reset colors for buttons.
        /// </summary>
        /// <param name="map">Map of buttons.</param>
        private void ResetButtonsColor(int[,] map) {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    if (map[x, y] != 0) ResetButtonColor(new Point(x, y));
                }
        }
        
        /// <summary>
        /// Reset color for all buttons.
        /// </summary>
        private void ResetAllButtonsColor() {
            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++) {
                    ResetButtonColor(new Point(x, y));
                }
        }

        /// <summary>
        /// Draw a figure on the board.
        /// </summary>
        /// <param name="p">Figure coordinates.</param>
        public void DrowFigure(Point p) {
            Figure figure = cb.getFigure(p);
            if (figure.name != "none") game_field[p.X, p.Y].BackgroundImage = figure.image;
            else game_field[p.X, p.Y].BackgroundImage = null;
        }
        
        /// <summary>
        /// Draw all figures on the board.
        /// </summary>
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
                    button.BackColor = (x + y) % 2 == 0 ? settings.colorWhite : settings.colorBlack;
                    button.Click += new EventHandler(OnButtonPress);
                    button.BackgroundImageLayout = ImageLayout.Stretch;
                    button.FlatStyle = FlatStyle.Flat;
                    button.FlatAppearance.BorderSize = 0;
                    game_field[x, y] = button;
                    groupBox_ChessBoard.Controls.Add(button);
                }
        }

        /// <summary>
        /// Chess board buttons click handler
        /// </summary>
        public void OnButtonPress(object sender, EventArgs e) {
            Button button = (Button)sender;

            if (button.BackColor != settings.colorMove && button.BackColor != settings.colorCut) {
                ResetButtonsColor(map);
                selectedPoint.X = -1;
            }
            if (selectedPoint.X == -1) {
                selectedPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                if (cb.getFigure(selectedPoint).idPlayer != player) return;
                map = cb.getPossibleActions(selectedPoint);
                bool isNotMoveble = true;
                for (int x = 0; x < 8; x++)
                    for (int y = 0; y < 8; y++) {
                        if (map[x, y] == 1) game_field[x, y].BackColor = settings.colorMove;
                        if (map[x, y] == 2) game_field[x, y].BackColor = settings.colorCut;
                        if (settings.PaintAllPossible) {
                            if (map[x, y] == 3) game_field[x, y].BackColor = Color.Orange;
                            if (map[x, y] == 4) game_field[x, y].BackColor = Color.OrangeRed;
                        }
                        isNotMoveble = false;
                    }
                if (isNotMoveble) selectedPoint.X = -1;
            }
            else {
                if (button.BackColor == settings.colorMove) {
                    soundPlayer = new SoundPlayer("res/sound_move.wav");
                    soundPlayer.Play();
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
                    soundPlayer = new SoundPlayer("res/sound_cut.wav");
                    soundPlayer.Play();
                    Point newPoint = new Point(int.Parse(button.Name[7].ToString()), int.Parse(button.Name[8].ToString()));
                    cb.CutFigure(selectedPoint, newPoint);
                    ResetButtonsColor(map);
                    DrowFigure(selectedPoint);
                    DrowFigure(newPoint);
                    selectedPoint.X = -1;
                    player = player % 2 + 1;
                    label_whichPlayer.Text = player.ToString() + " player move.";
                }

                label_gameOver.Text = cb.GameOver();
                if (label_gameOver.Text == "Checkmate for 2 player" || label_gameOver.Text == "Checkmate for 1 player")
                    groupBox_ChessBoard.Enabled = false;

                if (isComputer && groupBox_ChessBoard.Enabled == true) {
                    var t = Task.Run(async delegate {
                        await Task.Delay(random.Next(1000, 3000));
                        return 42;
                    });
                    t.Wait();
                    RandomMoveForFirstPlayer(sender, e);
                }
            }
        }

        /// <summary>
        /// Create a new game and unlock the board.
        /// </summary>
        /// <param name="path">Path to the file with level.</param>
        private void NewGame(string path = "Default") {
            groupBox_ChessBoard.Enabled = true;
            ResetAllButtonsColor();
            cb.ArrangeFigures(path);
            DrowAllFigures();
            selectedPoint.X = -1;

            label_gameOver.Text = cb.GameOver();
        }

        /// <summary>
        /// Open the settings form for changing settings.
        /// </summary>
        private void SeToolStripMenuItem_Click(object sender, EventArgs e) {
            SettingsForm sf = new(settings);
            sf.Owner = this;
            sf.ShowDialog();
            settings.ReadFromCfg();
            ResetAllButtonsColor();
        }
        
        /// <summary>
        /// Do computer move for first player when player vs. computer.
        /// </summary>
        private void RandomMoveForFirstPlayer(object sender, EventArgs e) {
            int num_of_figure = random.Next(0, cb.figuresPlayer1.Length);
            int amount_possible_actions = 0;
            int[,] possible_actions_map;
            Point[] possible_actions = new Point[20];
            int count = 0;

            possible_actions_map = cb.getPossibleActions(cb.figuresPlayer1[num_of_figure].position);
            while (ChessBoard.IsEmptyMap(possible_actions_map)) {
                num_of_figure = random.Next(0, cb.figuresPlayer1.Length);
                possible_actions_map = cb.getPossibleActions(cb.figuresPlayer1[num_of_figure].position);
                count++;
                if(count > 5) {
                    label_gameOver.Text = "Checkmate for 1 player";
                    groupBox_ChessBoard.Enabled = false;
                    MessageBox.Show("Checkmate for 1 player.", "GameOver!");
                    return;
                }
            }

            selectedPoint = cb.figuresPlayer1[num_of_figure].position;

            for (int x = 0; x < 8; x++) {
                for(int y = 0; y < 8; y++) {
                    if (possible_actions_map[x, y] == 1 || possible_actions_map[x, y] == 2) {
                        possible_actions[amount_possible_actions] = new Point(x, y);
                        amount_possible_actions++;
                        if (amount_possible_actions == 19) break;
                    }
                }
                if (amount_possible_actions == 19) break;
            }

            int num_of_action = random.Next(0, amount_possible_actions);

            Point randomPoint = possible_actions[num_of_action];
            if (cb.getFigure(randomPoint).name != "none") {
                soundPlayer = new SoundPlayer("res/sound_cut.wav");
                soundPlayer.Play();
                cb.CutFigure(selectedPoint, randomPoint);
                ResetButtonsColor(map);
                DrowFigure(selectedPoint);
                DrowFigure(randomPoint);
                selectedPoint.X = -1;
                player = player % 2 + 1;
                label_whichPlayer.Text = player.ToString() + " player move.";
            }
            else {
                soundPlayer = new SoundPlayer("res/sound_move.wav");
                soundPlayer.Play();
                cb.MoveFigure(selectedPoint, randomPoint);
                ResetButtonsColor(map);
                DrowFigure(selectedPoint);
                DrowFigure(randomPoint);
                selectedPoint.X = -1;
                player = player % 2 + 1;
                label_whichPlayer.Text = player.ToString() + " player move.";
            }
            label_gameOver.Text = cb.GameOver();
            if (label_gameOver.Text == "Checkmate for 2 player" || label_gameOver.Text == "Checkmate for 1 player")
                groupBox_ChessBoard.Enabled = false;
        }

        /// <summary>
        /// Start game player vs. player.
        /// </summary>
        private void playerVsPlayerToolStripMenuItem_Click(object sender, EventArgs e) {
            NewGame();
            isComputer = false;
            player = random.Next(1, 3);
            label_whichPlayer.Text = player.ToString() + " player move.";
        }

        /// <summary>
        /// Start game player vs. computer.
        /// </summary>
        private void playerVsComputerToolStripMenuItem_Click(object sender, EventArgs e) {
            NewGame();
            isComputer = true;
            player = 2;
            label_whichPlayer.Text = player.ToString() + " player move.";
        }

        /// <summary>
        /// Load level player vs. computer from file.
        /// </summary>
        private void loadLevelToolStripMenuItem_Click(object sender, EventArgs e) {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt";

            if (openFileDialog1.ShowDialog() == DialogResult.OK) NewGame(openFileDialog1.FileName);
            isComputer = true;
            player = 2;
            label_whichPlayer.Text = player.ToString() + " player move.";
        }
    }
}