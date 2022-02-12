using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacTow
{
    #region CPUMoves Class
    /// <summary>
    /// Handles the moves by the CPU
    /// </summary>
    public static class CPUMoves
    {
        /// <summary>
        /// The Placing Algorithm
        /// </summary>
        public static void PlacingAlgorithm()
        {
            if (!CanCPUWin())
            {
                if (!CanCPUBlock())
                {
                    if (!CanCPUBlockSpecificAlgo())
                    {
                        if (!CanCPUPlaceInMiddle())
                        {
                            if (!CanCPUPlaceInCorner())
                            {
                                PlaceInEmptySpace();
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Checks if the CPU can win
        /// </summary>
        /// <returns>true if CPU can win</returns>
        public static bool CanCPUWin()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (GameManager.table[i, 0] == GameManager.table[i, 1] && GameManager.table[i, 0] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(i, 2))
                    {
                        CPUPlace(i, 2);
                        return true;
                    }

                }
                else if (GameManager.table[0, i] == GameManager.table[1, i] && GameManager.table[0, i] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(2, i))
                    {
                        CPUPlace(2, i);
                        return true;
                    }

                }
                else if (GameManager.table[i, 2] == GameManager.table[i, 1] && GameManager.table[i, 2] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(i, 0))
                    {
                        CPUPlace(i, 0);
                        return true;
                    }

                }
                else if (GameManager.table[2, i] == GameManager.table[1, i] && GameManager.table[2, i] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(0, i))
                    {
                        CPUPlace(0, i);
                        return true;
                    }
                }
                else if (GameManager.table[i, 0] == GameManager.table[i, 2] && GameManager.table[i, 0] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(i, 1))
                    {
                        CPUPlace(i, 1);
                        return true;
                    }
                }
                else if (GameManager.table[0, i] == GameManager.table[2, i] && GameManager.table[0, i] == MarkType.Cross)
                {
                    if (GameManager.CanPlace(1, i))
                    {
                        CPUPlace(1, i);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the CPU can block
        /// </summary>
        /// <returns>true if CPU can block</returns>
        public static bool CanCPUBlock()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (GameManager.table[i, 0] == GameManager.table[i, 1] && GameManager.table[i, 0] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(i, 2))
                    {
                        CPUPlace(i, 2);
                        return true;
                    }
                }
                else if (GameManager.table[0, i] == GameManager.table[1, i] && GameManager.table[0, i] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(2, i))
                    {
                        CPUPlace(2, i);
                        return true;
                    }
                }
                else if (GameManager.table[i, 2] == GameManager.table[i, 1] && GameManager.table[i, 2] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(i, 0))
                    {
                        CPUPlace(i, 0);
                        return true;
                    }
                }
                else if (GameManager.table[2, i] == GameManager.table[1, i] && GameManager.table[2, i] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(0, i))
                    {
                        CPUPlace(0, i);
                        return true;
                    }
                }
                else if (GameManager.table[i, 0] == GameManager.table[i, 2] && GameManager.table[i, 0] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(i, 1))
                    {
                        CPUPlace(i, 1);
                        return true;
                    }
                }
                else if (GameManager.table[0, i] == GameManager.table[2, i] && GameManager.table[0, i] == MarkType.Nought)
                {
                    if (GameManager.CanPlace(1, i))
                    {
                        CPUPlace(1, i);
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Checks if the CPU can block a specific algorithm
        /// </summary>
        /// <returns>true if CPU can block a specific algorithm</returns>
        public static bool CanCPUBlockSpecificAlgo()
        {
            //Top Left
            MarkType tl = GameManager.table[0, 0];
            //Top Right
            MarkType tr = GameManager.table[0, 2];
            //Bottom Left
            MarkType bl = GameManager.table[2, 0];
            //Bottom Right
            MarkType br = GameManager.table[2, 2];
            if ((tr == bl && tr == MarkType.Nought) || (tl == br && tl == MarkType.Nought))
            {
                CPUPlace(0, 1);
                return true;

            }
            return false;
        }
        /// <summary>
        /// Checks if the CPU can place in the middle
        /// </summary>
        /// <returns>true if CPU can place in the middle</returns>
        public static bool CanCPUPlaceInMiddle()
        {
            if (GameManager.CanPlace(1, 1))
            {
                CPUPlace(1, 1);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Checks if the CPU can place in a corner
        /// </summary>
        /// <returns>true if CPU can place in corner</returns>
        public static bool CanCPUPlaceInCorner()
        {
            if (GameManager.CanPlace(0, 0))
            {
                CPUPlace(0, 0);
                return true;
            }
            else if (GameManager.CanPlace(2, 2))
            {
                CPUPlace(2, 2);
                return true;
            }
            else if (GameManager.CanPlace(0, 2))
            {
                CPUPlace(0, 2);
                return true;
            }
            else if (GameManager.CanPlace(2, 0))
            {
                CPUPlace(2, 0);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Places in the first empty space it reaches
        /// </summary>
        public static void PlaceInEmptySpace()
        {
            if (GameManager.CanPlace(0, 1))
            {
                CPUPlace(0, 1);
            }
            else if (GameManager.CanPlace(1, 0))
            {
                CPUPlace(1, 0);
            }
            else if (GameManager.CanPlace(1, 2))
            {
                CPUPlace(1, 2);
            }
            else if (GameManager.CanPlace(2, 1))
            {
                CPUPlace(2, 1);
            }
        }
        /// <summary>
        /// Places the X for the CPU
        /// </summary>
        /// <param name="row">Row on grid</param>
        /// <param name="col">Column on grid</param>
        public static void CPUPlace(int row, int col)
        {
            if (GameManager.CanPlace(row, col))
            {
                GameManager.table[row, col] = MarkType.Cross;
                string name = $"Button{col}_{row}";
                var lst = GameManager._Container.Children.Cast<Button>().ToList();
                foreach (var btn in lst)
                {
                    if (btn.Name == name)
                    {
                        btn.Content = "X";
                        btn.IsEnabled = false;
                        btn.Foreground = Brushes.Red;
                    }
                }
            }
        }

    }
    #endregion

    /// <summary>
    /// Managing the game
    /// </summary>
    public static class GameManager
    {
        #region Private Members
        /// <summary>
        /// The actual grid element
        /// </summary>
        public static Grid _Container;
        /// <summary>
        /// The game grid
        /// </summary>
        public static MarkType[,] table;
        /// <summary>
        /// Who starts, true = CPU, false = Player
        /// </summary>
        public static bool WhoStarts;
        /// <summary>
        /// true if the game has ended
        /// </summary>
        public static bool IsGameEnded;
        #endregion
        /// <summary>
        /// Initiate a new game
        /// </summary>
        public static void NewGame(Grid Container)
        {
            Container.Children.Cast<Button>().ToList().ForEach(btn =>
            {
                btn.Content = string.Empty;
                btn.IsEnabled = true;
            });
            _Container = Container;
            table = new MarkType[3, 3];
            WhoStarts = IsCPUFirst();
            if (WhoStarts == true) CPUMoves.PlacingAlgorithm();
            IsGameEnded = false;
        }
        /// <summary>
        /// Flips a coin to see if CPU is first
        /// </summary>
        /// <returns>true if CPU is first</returns>
        public static bool IsCPUFirst()
        {
            Random rand = new Random();
            return (rand.Next(1, 3) == 2);
        }
        /// <summary>
        /// Plays each turn
        /// </summary>
        /// <param name="b">The button which was click</param>
        public static void PlayGame(Button b)
        {
            PlayerTurn(b);
            CPUMoves.PlacingAlgorithm();
            if (GameState.IsGameWon(table) || GameState.IsGameTied(table))
            {
                IsGameEnded = true;
                NewGame(_Container);
            }
        }
        /// <summary>
        /// Plays the player turn
        /// </summary>
        /// <param name="b">The button which was click</param>
        public static void PlayerTurn(Button b)
        {
            if (CanPlace(Grid.GetRow(b), Grid.GetColumn(b)))
            {
                table[Grid.GetRow(b), Grid.GetColumn(b)] = MarkType.Nought;
                b.Content = "O";
                b.Foreground = Brushes.Blue;
                b.IsEnabled = false;
            }
        }
        /// <summary>
        /// Checks if someone can place in the square
        /// </summary>
        /// <param name="row">Row in game grid</param>
        /// <param name="col">Column in game grid</param>
        /// <returns>true if the square is unchecked</returns>
        public static bool CanPlace(int row, int col)
        {
            return table[row, col] == MarkType.Free;
        }
    }
    /// <summary>
    /// Class responsible of game state
    /// </summary>
    public static class GameState
    {
        /// <summary>
        /// Checks if the game was won (only CPU can win)
        /// </summary>
        /// <param name="table">Game grid</param>
        /// <returns>true if the CPU won</returns>
        public static bool IsGameWon(MarkType[,] table)
        {
            bool flag = false;
            for (int i = 0; i < 3 && !flag; i++)
            {
                if (table[i, 0] == table[i, 1] && table[i, 0] == table[i, 2] && (table[i, 0] == MarkType.Nought || table[i, 0] == MarkType.Cross))
                    flag = true;
                else if (table[0, i] == table[1, i] && table[0, i] == table[2, i] && (table[0, i] == MarkType.Nought || table[0, i] == MarkType.Cross))
                    flag = true;
            }
            if (table[0, 0] == table[1, 1] && table[0, 0] == table[2, 2] && (table[0, 0] == MarkType.Nought || table[0, 0] == MarkType.Cross)) flag = true;
            if (table[0, 2] == table[1, 1] && table[0, 2] == table[2, 0] && (table[0, 2] == MarkType.Nought || table[0, 2] == MarkType.Cross)) flag = true;
            return flag;
        }
        /// <summary>
        /// Checks if the game was tied
        /// </summary>
        /// <param name="table">Game grid</param>
        /// <returns>true if there a tie</returns>
        public static bool IsGameTied(MarkType[,] table)
        {
            int temp = 0;
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int j = 0; j < table.GetLength(1); j++)
                {
                    if (table[i, j] != MarkType.Free)
                        temp++;
                }
            }
            return temp == 9;
        }
    }
}

