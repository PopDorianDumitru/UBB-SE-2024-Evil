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
using All_Things_Evil.ViewModels;

namespace All_Things_Evil.Views
{
    /// <summary>
    /// Interaction logic for FightingGameWinView.xaml
    /// </summary>
    public partial class FightingGameWinView : UserControl
    {
        public FightingGameWinView()
        {
            InitializeComponent();
        }

        public void Continue_Button_Click(object sender, RoutedEventArgs eventArguments)
        {
            var parent = this.Parent as Panel;
            if (parent != null)
            {
                parent.Children.Remove(this);
            }
        }
    }
}
