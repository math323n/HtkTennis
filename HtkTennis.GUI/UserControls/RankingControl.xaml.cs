using HtkTennis.GUI.ViewModels;
using HtkTennis.Utilities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HtkTennis.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for RankingControl.xaml
    /// </summary>
    public partial class RankingControl: UserControl
    {
        #region Fields
        private readonly RankingViewModel viewModel;
        private bool isLoaded;
        #endregion

        #region Constructor
        public RankingControl()
        {
            InitializeComponent();

            // Initialize the viewModel
            viewModel = DataContext as RankingViewModel;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Runs when Controller is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnLoaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Check if isLoaded is false
                if(!isLoaded)
                {
                    // Set isLoaded to true
                    isLoaded = !isLoaded;

                    await viewModel.InitializeAsync();
                }
            }
            catch(Exception ex)
            {
                Logger.Log(ex);
                Exception originalException = ex.GetOriginalException();

                MessageBox.Show(originalException.Message, "An error has occurred, please check the log file for further information.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
