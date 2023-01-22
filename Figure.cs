using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame {
    internal class Figure {

        // Main fields:
        public Point position { get; set; } // Position on board.
        public string name { get; } // Name of figure.
        public int idPlayer { get; } // Id of player.
        public Image image { get; } // Image of figure.
        public int idImage { get; } // Id of image from sprite.
        public bool isMain { get; } // Main figure?
        public bool isFirst { get; set; } // First move?
        public bool isFixed { get; } // Fixed moves?
        public bool isSimetrical { get; } // Simetrical moves?
        public bool isChanging { get; } // Changing moves after first?
        public bool isSame { get; } // Cut same with moves?
        public int moveRadius1 { get; } // Radius for first move.
        public int moveRadius2 { get; } // Radius for another moves.
        public int[,] moves { get; } // Map of moves.
        public int[,] cuts { get; } // Map of cuts.

        // File fields:
        static string figuresPath = "res/figures.txt"; // Path to file with figures descriptions.
        static string spritePath = "res\\Sprite_figures.png"; // Path to file with figures images.

        // Sprite fields:
        private Image spriteFigures = new Bitmap(spritePath); // Sprite with all figures images.
        private Size spriteSize = new(100, 100); // Size of image for figures.

        /// <summary>
        /// Сreating an empty figure.
        /// </summary>
        public Figure() {
            name = "none";
            idPlayer = 0;
        }

        /// <summary>
        /// Initializes a new figure. The image for figures gets from file using name.
        /// </summary>
        /// <param name="name">The name of figure.</param>
        /// <param name="idPlayer">The id of player.</param>
        public Figure(string name, int idPlayer, Point position) {
            this.name = name;
            this.idPlayer = idPlayer;
            this.position = position;
            isFirst = true;

            using StreamReader streamReader = new StreamReader(figuresPath);
            string line;
            string[] param;
            bool isFound = false;
            while ((line = streamReader.ReadLine()) != null) {
                if (line == name) {
                    isFound = true;
                    break;
                }
            }

            if (!isFound) {
                this.name = "none";
                this.idPlayer = 0;
            }
            else {
                idImage = int.Parse(streamReader.ReadLine());
                isMain = streamReader.ReadLine() == "main" ? true : false;
                isFixed = streamReader.ReadLine() == "fixed" ? true : false;
                isSimetrical = streamReader.ReadLine() == "simetrical" ? true : false;
                isChanging = streamReader.ReadLine() == "changing" ? true : false;
                moveRadius1 = int.Parse(streamReader.ReadLine().Split("=")[1]);
                if (isChanging) moveRadius2 = int.Parse(streamReader.ReadLine().Split("=")[1]);
                else moveRadius2 = moveRadius1;
                if (isFixed) moves = MapReadFromSR(streamReader, moveRadius1 * 2 + 1);
                else moves = MapReadFromSR(streamReader, 3);
                isSame = streamReader.ReadLine() == "same" ? true : false;
                if (!isSame) cuts = isFixed ? MapReadFromSR(streamReader, moveRadius2 * 2 + 1) : MapReadFromSR(streamReader, 3);
                else cuts = moves;
                if (!isSimetrical && idPlayer == 1) {
                    moves = FlipYMap(moves, isFixed ? moveRadius1 * 2 + 1 : 3);
                    cuts = FlipYMap(cuts, isFixed ? moveRadius2 * 2 + 1 : 3);
                }

                image = new Bitmap(100, 100);
                Graphics g = Graphics.FromImage(image);
                Point spritePoint = new Point(0, 0);
                spritePoint.X = 100 * idImage;
                if (idPlayer == 2) spritePoint.Y = 100;
                g.DrawImage(spriteFigures, new Rectangle(0, 0, spriteSize.Width, spriteSize.Height), spritePoint.X, spritePoint.Y, spriteSize.Width, spriteSize.Height, GraphicsUnit.Pixel);
            }

            this.position = position;
        }

        /// <summary>
        /// Reads a 2d array from the curent stream.
        /// </summary>
        /// <param name="streamReader">The curent stream.</param>
        /// <param name="sideSize">The side length of 2d array.</param>
        /// <returns>Map from stream.</returns>
        public static int[,] MapReadFromSR(StreamReader streamReader, int sideSize) {
            int[,] map = new int[sideSize,sideSize];
            for (int y = 0; y < sideSize; y++) {
                string line = streamReader.ReadLine();
                for (int x = 0; x < sideSize; x++) {
                    map[x, y] = line[x] == '1' ? 1 : 0;
                }
            }
            return map;
        }

       /// <summary>
       /// Vertical flip array.
       /// </summary>
       /// <param name="map">2d array for flipping.</param>
       /// <param name="sideSize">Side length of 2d array.</param>
       /// <returns>Fliped map.</returns>
        public static int[,] FlipYMap(int[,] map, int sideSize) {
            int[,] newMap = new int[sideSize, sideSize];
            for (int x = 0; x < sideSize; x++)
                for (int y = 0; y < sideSize; y++) {
                    newMap[x, y] = map[x, sideSize - y - 1];
                }
            return newMap;
        }
    }
}
