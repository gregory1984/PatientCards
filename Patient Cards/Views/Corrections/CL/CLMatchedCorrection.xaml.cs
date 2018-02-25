using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.CL;

namespace Patient_Cards.Views.Corrections.CL
{
    public partial class CLMatchedCorrection : UserControl
    {
        public CLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLMatchedCorrectionViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
