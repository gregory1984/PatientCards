using System.Windows.Controls;
using Patient_Cards.ViewModels.Dictionaries;

namespace Patient_Cards.Views.Dictionaries
{
    public partial class Others : UserControl
    {
        public Others()
        {
            InitializeComponent();

            var viewmodel = DataContext as OthersViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OthersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (sender as ListBox).SelectedIndex = -1;
        }
    }
}
