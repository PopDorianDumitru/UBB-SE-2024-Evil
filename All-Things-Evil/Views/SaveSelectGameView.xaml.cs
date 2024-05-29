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
    /// Interaction logic for SaveSelectGameView.xaml
    /// </summary>
    public partial class SaveSelectGameView : UserControl
    {
        private ISaveSelectGameViewModel viewModel;
        public SaveSelectGameView()
        {
            InitializeComponent();
        }

        public SaveSelectGameView(ISaveSelectGameViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            this.viewModel = viewModel;
        }

        private void StartNewRunButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(viewModel.NewRunName))
                {
                    var fightingGameWindow = viewModel.CreateFightingGameWindowNewSave(newSaveNameTextBox.Text);
                    MainContentControl.Content = fightingGameWindow;
                }
            }
            catch (System.Exception exception)
            {
            }
        }

        private void ContinueGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (viewModel.SelectedGameSave != null)
                {
                    var fightingGameWindow = viewModel.CreateFightingGameWindow(selectedSaveComboBox.SelectedIndex);
                    MainContentControl.Content = fightingGameWindow;
                }
            }
            catch (System.Exception exception)
            {
            }
        }
    }
}
