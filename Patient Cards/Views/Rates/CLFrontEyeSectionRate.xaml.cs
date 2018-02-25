using System.Windows.Controls;
using Patient_Cards.ViewModels.Rates;

namespace Patient_Cards.Views.Rates
{
    public partial class CLFrontEyeSectionRate : UserControl
    {
        public CLFrontEyeSectionRate()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLFrontEyeSectionRateViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
