using System.Windows.Controls;
using Patient_Cards.ViewModels.Dictionaries;

namespace Patient_Cards.Views.Dictionaries
{
    public partial class Medicaments : UserControl
    {
        public Medicaments()
        {
            InitializeComponent();

            var viewmodel = DataContext as MedicamentsViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
