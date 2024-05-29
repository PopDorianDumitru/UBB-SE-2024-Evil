using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using All_Things_Evil.ViewModels;
using All_Things_Evil.Services;

namespace All_Things_Evil.Views
{
    public partial class FightingGameView : UserControl
    {
        private IFightingGameViewModel _viewModel;

        public FightingGameView(IFightingGameViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
            UpdateUI();
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DisplayWinWindow")
            {
                DisplayWinWindow();
            }
            else if (e.PropertyName == "DisplayLoseWindow")
            {
                DisplayLoseWindow();
            }
            else
            {
                UpdateUI();
            }
        }

        private void UpdateUI()
        {
            energyLabelPlayer1.Content = $"Energy: {_viewModel.Player1Energy}";
            energyLabelPlayer2.Content = $"Energy: {_viewModel.Player2Energy}";
            healthBarPlayer1.Value = _viewModel.Player1Health;
            healthBarPlayer2.Value = _viewModel.Player2Health;
            inputDamagePlayer1.Text = _viewModel.Player1Damage.ToString();
            inputBlockPlayer1.Text = _viewModel.Player1Block.ToString();
        }

        private void DoMoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(inputDamagePlayer1.Text, out int damage) && int.TryParse(inputBlockPlayer1.Text, out int block))
            {
                _viewModel.Player1Damage = damage;
                _viewModel.Player1Block = block;
                _viewModel.DoMoveCommand.Execute(null);
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for damage and block.");
            }
        }

        private void DisplayWinWindow()
        {
            var windowFactory = _viewModel.GetWindowFactory();
            var winWindow = windowFactory.CreateFightingGameWinWindow();
            MainGrid.Children.Add(winWindow);
        }

        private void DisplayLoseWindow()
        {
            var windowFactory = _viewModel.GetWindowFactory();
            var loseWindow = windowFactory.CreateFightingGameLoseWindow();
            loseWindow.ExitButtonClicked += LoseWindow_ExitButtonClicked;
            MainGrid.Children.Add(loseWindow);
        }

        private void LoseWindow_ExitButtonClicked(object sender, EventArgs e)
        {
            ExitGame();
        }

        private void ExitGame()
        {
            var parent = this.Parent as Panel;
            if (parent != null)
            {
                parent.Children.Remove(this);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.SaveGameCommand.Execute(null);
        }
    }
}
