using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame {
    internal class ChessBoard {

        private Figure[,] board = new Figure[8, 8];

        public ChessBoard() {
            ArrangeFigures();
        }

        /// <summary>
        /// Arrange the figures in their starting positions.
        /// </summary>
        public void ArrangeFigures() {

            board[0, 0] = board[7, 0] = new Figure("rook", 1);
            board[1, 0] = board[6, 0] = new Figure("knight", 1);
            board[2, 0] = board[5, 0] = new Figure("bishop", 1);
            board[3, 0] = new Figure("queen", 1);
            board[4, 0] = new Figure("king", 1);

            for (int x = 0; x < 8; x++) board[x, 1] = new Figure("pawn", 1);
            for (int x = 0; x < 8; x++) for (int y = 2; y < 6; y++) board[x, y] = new Figure();
            for (int x = 0; x < 8; x++) board[x, 6] = new Figure("pawn", 2);

            board[0, 7] = board[7, 7] = new Figure("rook", 2);
            board[1, 7] = board[6, 7] = new Figure("knight", 2);
            board[2, 7] = board[5, 7] = new Figure("bishop", 2);
            board[3, 7] = new Figure("queen", 2);
            board[4, 7] = new Figure("king", 2);
        }

        public int[,] getPossibleMoves(Point point) {
            int[,] map = new int[8, 8];
            int x = point.X, y = point.Y;
            switch(board[x, y].getName()) {

                case "pawn":
                    if (board[x, y].getIdPlayer() == 1) {
                        if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1].getName() != "none" && board[x - 1, y + 1].getIdPlayer() != board[x, y].getIdPlayer()) 
                            map[x - 1, y + 1] = 2;
                        if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1].getName() != "none" && board[x + 1, y + 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 1, y + 1] = 2;
                        if (y + 1 < 8 && board[x, y + 1].getName() == "none") 
                            map[x, y + 1] = 1; else break;
                        if (y == 1 && board[x, y + 2].getName() == "none") 
                            map[x, y + 2] = 1;
                    }
                    else {
                        if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1].getName() != "none" && board[x - 1, y - 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x - 1, y - 1] = 2;
                        if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1].getName() != "none" && board[x - 1, y - 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 1, y - 1] = 2;
                        if (y - 1 >= 0 && board[x, y - 1].getName() == "none")
                            map[x, y - 1] = 1; else break;
                        if (y == 6 && board[x, y - 2].getName() == "none")
                            map[x, y - 2] = 1;
                    }
                break;

                case "rook":
                    for (int i = 1; y - i >= 0; i++)
                        if (board[x, y - i].getName() == "none") map[x, y - i] = 1;
                        else if (board[x, y - i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x, y - i] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; y + i < 8; i++)
                        if (board[x, y + i].getName() == "none") map[x, y + i] = 1;
                        else if (board[x, y + i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x, y + i] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; x - i >= 0; i++) 
                        if (board[x - i, y].getName() == "none") map[x - i, y] = 1; 
                        else if (board[x - i, y].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x - i, y] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; x + i < 8; i++) 
                        if (board[x + i, y].getName() == "none") map[x + i, y] = 1; 
                        else if (board[x + i, y].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x + i, y] = 2;
                            break;
                        }
                        else break;
                break;

                case "knight":
                    if (x - 2 >= 0 && y - 1 >= 0)
                        if (board[x - 2, y - 1].getName() == "none")
                            map[x - 2, y - 1] = 1;
                        else if (board[x - 2, y - 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x - 2, y - 1] = 2;

                    if (x - 1 >= 0 && y - 2 >= 0 ) 
                        if (board[x - 1, y - 2].getName() == "none")
                            map[x - 1, y - 2] = 1;
                        else if (board[x - 1, y - 2].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x - 1, y - 2] = 2;

                    if (x - 2 >= 0 && y + 1 < 8 ) 
                        if (board[x - 2, y + 1].getName() == "none")
                            map[x - 2, y + 1] = 1;
                        else if (board[x - 2, y + 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x - 2, y + 1] = 2;

                    if (x - 1 >= 0 && y + 2 < 8 ) 
                        if (board[x - 1, y + 2].getName() == "none")
                            map[x - 1, y + 2] = 1;
                        else if (board[x - 1, y + 2].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x - 1, y + 2] = 2;

                    if (x + 2 < 8 && y - 1 >= 0 ) 
                        if (board[x + 2, y - 1].getName() == "none")
                            map[x + 2, y - 1] = 1;
                        else if (board[x + 2, y - 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 2, y - 1] = 2;

                    if (x + 1 < 8 && y - 2 >= 0 ) 
                        if (board[x + 1, y - 2].getName() == "none")
                            map[x + 1, y - 2] = 1;
                        else if (board[x + 1, y - 2].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 1, y - 2] = 2;

                    if (x + 2 < 8 && y + 1 < 8 ) 
                        if (board[x + 2, y + 1].getName() == "none")
                            map[x + 2, y + 1] = 1;
                        else if (board[x + 2, y + 1].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 2, y + 1] = 2;

                    if (x + 1 < 8 && y + 2 < 8 ) 
                        if (board[x + 1, y + 2].getName() == "none")
                            map[x + 1, y + 2] = 1;
                        else if (board[x + 1, y + 2].getIdPlayer() != board[x, y].getIdPlayer())
                            map[x + 1, y + 2] = 2;
                    break;

                case "bishop":
                    for (int i = 1; x - i >= 0 && y - i >= 0; i++)
                        if (board[x - i, y - i].getName() == "none") map[x - i, y - i] = 1;
                        else if (board[x - i, y - i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x - i, y - i] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; x - i >= 0 && y + i < 8; i++)
                        if (board[x - i, y + i].getName() == "none") map[x - i, y + i] = 1;
                        else if (board[x - i, y + i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x - i, y + i] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; x + i < 8 && y + i < 8; i++)
                        if (board[x + i, y + i].getName() == "none") map[x + i, y + i] = 1;
                        else if (board[x + i, y + i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x + i, y + i] = 2;
                            break;
                        }
                        else break;
                    for (int i = 1; x + i < 8 && y - i >= 0; i++)
                        if (board[x + i, y - i].getName() == "none") map[x + i, y - i] = 1;
                        else if (board[x + i, y - i].getIdPlayer() != board[x, y].getIdPlayer()) {
                            map[x + i, y - i] = 2;
                            break;
                        }
                        else break;
                break;

                case "queen":
                    for (int i = 1; y - i >= 0; i++) if (board[x, y - i].getName() == "none") map[x, y - i] = 1; else break;
                    for (int i = 1; y + i < 8; i++) if (board[x, y + i].getName() == "none") map[x, y + i] = 1; else break;
                    for (int i = 1; x - i >= 0; i++) if (board[x - i, y].getName() == "none") map[x - i, y] = 1; else break;
                    for (int i = 1; x + i < 8; i++) if (board[x + i, y].getName() == "none") map[x + i, y] = 1; else break;
                    for (int i = 1; x - i >= 0 && y - i >= 0; i++) if (board[x - i, y - i].getName() == "none") map[x - i, y - i] = 1; else break;
                    for (int i = 1; x - i >= 0 && y + i < 8; i++) if (board[x - i, y + i].getName() == "none") map[x - i, y + i] = 1; else break;
                    for (int i = 1; x + i < 8 && y + i < 8; i++) if (board[x + i, y + i].getName() == "none") map[x + i, y + i] = 1; else break;
                    for (int i = 1; x + i < 8 && y - i >= 0; i++) if (board[x + i, y - i].getName() == "none") map[x + i, y - i] = 1; else break;
                break;

                case "king":
                    if (x - 1 >= 0 && y - 1 >= 0 && board[x - 1, y - 1].getName() == "none") map[x - 1, y - 1] = 1;
                    if (y - 1 >= 0 && board[x, y - 1].getName() == "none") map[x, y - 1] = 1;
                    if (x + 1 < 8 && y - 1 >= 0 && board[x + 1, y - 1].getName() == "none") map[x + 1, y - 1] = 1;
                    if (x + 1 < 8 && board[x + 1, y].getName() == "none") map[x + 1, y] = 1;
                    if (x + 1 < 8 && y + 1 < 8 && board[x + 1, y + 1].getName() == "none") map[x + 1, y + 1] = 1;
                    if (y + 1 < 8 && board[x, y + 1].getName() == "none") map[x, y + 1] = 1;
                    if (x - 1 >= 0 && y + 1 < 8 && board[x - 1, y + 1].getName() == "none") map[x - 1, y + 1] = 1;
                    if (x - 1 >= 0 && board[x - 1, y].getName() == "none") map[x - 1, y] = 1;
                break;
            }
            return map;
        }

        public Figure getFigure(Point point) {
            return board[point.X, point.Y];
        }

        public void MoveFigure(Point oldPoint, Point newPoint) {
            board[newPoint.X, newPoint.Y] = board[oldPoint.X, oldPoint.Y];
            board[oldPoint.X, oldPoint.Y] = new Figure();
        }
    }
}
