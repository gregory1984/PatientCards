using System.Windows.Controls;
using Patient_Cards.ViewModels.Dictionaries;

namespace Patient_Cards.Views.Dictionaries
{
    public partial class Complaints : UserControl
    {
        public Complaints()
        {
            InitializeComponent();

            var viewmodel = DataContext as ComplaintsViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
