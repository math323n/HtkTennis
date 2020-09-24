using HtkTennis.GUI.ViewModels;
using HtkTennis.Utilities;

using System;
using System.Windows;
using System.Windows.Controls;

namespace HtkTennis.GUI.UserControls
{
    /// <summary>
    /// Interaction logic for CourtControls.xaml
    /// </summary>
    public partial class CourtControl: UserControl
    {
        #region Fields
        private readonly CourtViewModel viewModel;
        private bool isLoaded;
        #endregion

        #region Constructor
        public CourtControl()
        {
            InitializeComponent();

            // Initialize the viewModel
            viewModel = DataContext as CourtViewModel;
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