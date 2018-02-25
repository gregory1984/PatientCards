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
    }
}
