using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.GL;

namespace Patient_Cards.Views.Corrections.GL
{

    public partial class GLCurrentCorrection : UserControl
    {
        public GLCurrentCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLCurrentCorrectionViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
