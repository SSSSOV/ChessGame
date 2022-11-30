using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame {
    internal class Figure {

        // Main fields:
        private string name; // Name of figure.
        private int idPlayer; // Id of player.
        private Image image; // Image of figure.

        // Sprite fields:
        private Image spriteFigures = new Bitmap("res\\Sprite_figures.png");
        private Size spriteSize = new Size(100, 100);

        /// <summary>
        /// Сreating an empty figure.
        /// </summary>
        public Figure() {
            name = "none";
            idPlayer = 0;
        }

        /// <summary>
        /// Initializes a new figure.
        /// </summary>
        /// <param name="name">The name of figure.</param>
        /// <param name="idPlayer">The id of player.</param>
        public Figure(string name, int idPlayer) {
            this.name = name;
            this.idPlayer = idPlayer;

            image = new Bitmap(100, 100);
            Graphics g = Graphics.FromImage(image);
            Point spritePoint = new Point(0, 0);
            switch (name) {
                case "pawn": spritePoint.X = 0; break;
                case "rook": spritePoint.X = 100; break;
                case "knight": spritePoint.X = 200; break;
                case "bishop": spritePoint.X = 300; break;
                case "queen": spritePoint.X = 400; break;
                case "king": spritePoint.X = 500; break;
            }
            if (idPlayer == 2) spritePoint.Y = 100;
            g.DrawImage(spriteFigures, new Rectangle(0, 0, spriteSize.Width, spriteSize.Height), spritePoint.X, spritePoint.Y, spriteSize.Width, spriteSize.Height, GraphicsUnit.Pixel);
        }

        /// <summary>
        /// Gets the name of figure.
        /// </summary>
        /// <returns>The name of figure.</returns>
        public string getName() {
            return name;
        }

        /// <summary>
        /// Gets the id of the player who owns the figure.
        /// </summary>
        /// <returns>The id of the player.</returns>
        public int getIdPlayer() {
            return idPlayer;
        }

        public Image getImage() {
            return image;
        }
    }
}
