using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Media;
using System.Diagnostics;
using System.Threading;

namespace TicTacTow
{
    #region CPUMoves Class
    /// <summary>
    /// Handles the moves by the CPU
    /// </summary>
    public class CPUMoves
    {
        private GameManager _GameManager;
        public CPUMoves(GameManager g)
        {
            _GameManager = g;
        }
        /// <summary>
        /// The Placing Algorithm
        /// </summary>
        public void PlacingAlgorithm()
        {
            if (CanCPUWin()) return;
            if (CanCPUBlock()) return;
            if (CanCPUBlockSpecificAlgo()) return;
            if (CanCPUPlaceInMiddle()) return;
            if (CanCPUPlaceInCorner()) return;
            PlaceInEmptySpace();
        }
        /// <summary>
        /// Checks if the CPU can win
        /// </summary>
        /// <returns>true if CPU can win</returns>
        public bool CanCPUWin()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (_GameManager.table[i, 0] == _GameManager.table[i, 1] && _GameManager.table[i, 0] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(i, 2))
                    {
                        CPUPlace(i, 2);
                        return true;
                    }

                }
                if (_GameManager.table[0, i] == _GameManager.table[1, i] && _GameManager.table[0, i] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(2, i))
                    {
                        CPUPlace(2, i);
                        return true;
                    }

                }
                if (_GameManager.table[i, 2] == _GameManager.table[i, 1] && _GameManager.table[i, 2] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(i, 0))
                    {
                        CPUPlace(i, 0);
                        return true;
                    }

                }
                if (_GameManager.table[2, i] == _GameManager.table[1, i] && _GameManager.table[2, i] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(0, i))
                    {
                        CPUPlace(0, i);
                        return true;
                    }
                }
                if (_GameManager.table[i, 0] == _GameManager.table[i, 2] && _GameManager.table[i, 0] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(i, 1))
                    {
                        CPUPlace(i, 1);
                        return true;
                    }
                }
                if (_GameManager.table[0, i] == _GameManager.table[2, i] && _GameManager.table[0, i] == MarkType.Cross)
                {
                    if (_GameManager.CanPlace(1, i))
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
        public bool CanCPUBlock()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (_GameManager.table[i, 0] == _GameManager.table[i, 1] && _GameManager.table[i, 0] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(i, 2))
                    {
                        CPUPlace(i, 2);
                        return true;
                    }
                }
                if (_GameManager.table[0, i] == _GameManager.table[1, i] && _GameManager.table[0, i] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(2, i))
                    {
                        CPUPlace(2, i);
                        return true;
                    }
                }
                if (_GameManager.table[i, 2] == _GameManager.table[i, 1] && _GameManager.table[i, 2] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(i, 0))
                    {
                        CPUPlace(i, 0);
                        return true;
                    }
                }
                if (_GameManager.table[2, i] == _GameManager.table[1, i] && _GameManager.table[2, i] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(0, i))
                    {
                        CPUPlace(0, i);
                        return true;
                    }
                }
                if (_GameManager.table[i, 0] == _GameManager.table[i, 2] && _GameManager.table[i, 0] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(i, 1))
                    {
                        CPUPlace(i, 1);
                        return true;
                    }
                }
                if (_GameManager.table[0, i] == _GameManager.table[2, i] && _GameManager.table[0, i] == MarkType.Nought)
                {
                    if (_GameManager.CanPlace(1, i))
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
        public bool CanCPUBlockSpecificAlgo()
        {
            //Top Left
            MarkType tl = _GameManager.table[0, 0];
            //Top Right
            MarkType tr = _GameManager.table[0, 2];
            //Bottom Left
            MarkType bl = _GameManager.table[2, 0];
            //Bottom Right
            MarkType br = _GameManager.table[2, 2];
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
        public bool CanCPUPlaceInMiddle()
        {
            if (_GameManager.CanPlace(1, 1))
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
        public bool CanCPUPlaceInCorner()
        {
            if (_GameManager.CanPlace(0, 0))
            {
                CPUPlace(0, 0);
                return true;
            }
            if (_GameManager.CanPlace(2, 2))
            {
                CPUPlace(2, 2);
                return true;
            }
            if (_GameManager.CanPlace(0, 2))
            {
                CPUPlace(0, 2);
                return true;
            }
            if (_GameManager.CanPlace(2, 0))
            {
                CPUPlace(2, 0);
                return true;
            }
            return false;
        }
        /// <summary>
        /// Places in the first empty space it reaches
        /// </summary>
        public void PlaceInEmptySpace()
        {
            if (_GameManager.CanPlace(0, 1))
            {
                CPUPlace(0, 1);
            }
            if (_GameManager.CanPlace(1, 0))
            {
                CPUPlace(1, 0);
            }
            if (_GameManager.CanPlace(1, 2))
            {
                CPUPlace(1, 2);
            }
            if (_GameManager.CanPlace(2, 1))
            {
                CPUPlace(2, 1);
            }
        }
        /// <summary>
        /// Places the X for the CPU
        /// </summary>
        /// <param name="row">Row on grid</param>
        /// <param name="col">Column on grid</param>
        public void CPUPlace(int row, int col)
        {
            if (_GameManager.CanPlace(row, col))
            {
                _GameManager.table[row, col] = MarkType.Cross;
                string name = $"Button{col}_{row}";
                var lst = _GameManager._Container.Children.Cast<Button>().ToList();
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
    public class GameManager
    {
        #region Private Members
        /// <summary>
        /// The actual grid element
        /// </summary>
        public Grid _Container { get; set; }
        /// <summary>
        /// The game grid
        /// </summary>
        public MarkType[,] table { get; set; }
        /// <summary>
        /// true if the game has ended
        /// </summary>
        public bool IsGameEnded { get; private set; }
        /// <summary>
        /// the thing handling cpu moves
        /// </summary>
        private CPUMoves Moves;
        /// <summary>
        /// Game state manager
        /// </summary>
        private GameState State;
        /// <summary>
        /// The TextBlock Element
        /// </summary>
        private TextBlock txt;
        /// <summary>
        /// Stores the number of games
        /// </summary>
        private int NumberOfGames = 0;
        #endregion
        /// <summary>
        /// Initiate a new game
        /// </summary>
        public void NewGame(Grid Container, TextBlock t)
        {
            NumberOfGames++;
            Container.Children.Cast<Button>().ToList().ForEach(btn =>
            {
                btn.Content = string.Empty;
                btn.IsEnabled = true;
            });
            _Container = Container;
            txt = t;
            Moves = new CPUMoves(this);
            table = new MarkType[3, 3];
            if (IsCPUFirst() == true) Moves.PlacingAlgorithm();
            IsGameEnded = false;
        }
        /// <summary>
        /// Flips a coin to see if CPU is first
        /// </summary>
        /// <returns>true if CPU is first</returns>
        private bool IsCPUFirst()
        {
            Random rand = new Random();
            return (rand.Next(1, 3) == 2);
        }
        /// <summary>
        /// Plays each turn
        /// </summary>
        /// <param name="b">The button which was click</param>
        public void PlayGame(Button b)
        {
            State = new GameState(table);
            PlayerTurn(b);
            Moves.PlacingAlgorithm();
            if (State.IsGameWon() || State.IsGameTied())
            {
                string res = State.IsGameWon() ? "You have lost" : "You have tied";
                IsGameEnded = true;
                NewGame(_Container, txt);
                txt.Text = $"{res}.\nNumber of games: {NumberOfGames}";
            }
            PrintTable();
        }
        /// <summary>
        /// Plays the player turn
        /// </summary>
        /// <param name="b">The button which was click</param>
        private void PlayerTurn(Button b)
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
        public bool CanPlace(int row, int col)
        {
            return table[row, col] == MarkType.Free;
        }
        /// <summary>
        /// Prints the table to the output window in visual studio
        /// </summary>
        private void PrintTable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Trace.Write(table[i, j] + ", ");
                }
                Trace.WriteLine("");
            }
        }
    }
    /// <summary>
    /// Class responsible of game state
    /// </summary>
    public class GameState
    {
        private MarkType[,] table;
        public GameState(MarkType[,] table)
        {
            this.table = table;
        }
        /// <summary>
        /// Checks if the game was won (only CPU can win)
        /// </summary>
        /// <param name="table">Game grid</param>
        /// <returns>true if the CPU won</returns>
        public bool IsGameWon()
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
        public bool IsGameTied()
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

