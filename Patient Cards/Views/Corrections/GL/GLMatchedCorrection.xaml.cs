using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.GL;

namespace Patient_Cards.Views.Corrections.GL
{
    public partial class GLMatchedCorrection : UserControl
    {
        public GLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLMatchedCorrectionViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
