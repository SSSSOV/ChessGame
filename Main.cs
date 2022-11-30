namespace WinFormsApppp {
    public partial class Main : Form {

        Button[,] game_field = new Button[8, 8];
        int[,] map = new int[8, 8] {
            {15, 14, 13, 12, 11, 13, 14, 15},
            {16, 16, 16, 16, 16, 16, 16, 16},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {0, 0, 0, 0, 0, 0, 0, 0},
            {26, 26, 26, 26, 26, 26, 26, 26},
            {25, 24, 23, 22, 21, 23, 24, 25},
        };
        Point point_of_field = new Point(0, 27);

        public Main() {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e) {
            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    Button button = new Button();
                    button.Size = new Size(50, 50);
                    button.Location = new Point(point_of_field.X + i * 50, point_of_field.Y + j * 50);
                    switch (map[i, j] / 10) {
                        case 
                    }
                }
            }
        }
    }
}