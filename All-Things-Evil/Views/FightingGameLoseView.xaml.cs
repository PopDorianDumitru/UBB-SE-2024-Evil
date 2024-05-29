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
using System.Windows.Shapes;

namespace All_Things_Evil.Views
{
    /// <summary>
    /// Interaction logic for FightingGameLoseView.xaml
    /// </summary>
    public partial class FightingGameLoseView : UserControl
    {
        public event EventHandler ExitButtonClicked;

        public FightingGameLoseView()
        {
            InitializeComponent();
        }

        public void Exit_Button_Click(object sender, RoutedEventArgs eventArguments)
        {
            ExitButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
