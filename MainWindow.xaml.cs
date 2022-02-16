using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace TicTacTow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameManager g;
        #region Constructor
        /// <summary>
        /// Default Contructor
        /// </summary>
        public MainWindow()
        {
            g = new GameManager();
            InitializeComponent();
            g.NewGame(Container, Announcer);
        }

        #endregion
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = (Button)sender;
            if (!g.IsGameEnded)
                g.PlayGame(b);
        }
    }
}
