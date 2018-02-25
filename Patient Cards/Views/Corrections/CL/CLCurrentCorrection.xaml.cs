using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.CL;

namespace Patient_Cards.Views.Corrections.CL
{
    public partial class CLCurrentCorrection : UserControl
    {
        public CLCurrentCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLCurrentCorrectionViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
