using System.Text.RegularExpressions;
using System.Windows.Controls;
using Patient_Cards.ViewModels.Sharpness;

namespace Patient_Cards.Views.Sharpness
{
    public partial class GLSharpness : UserControl
    {
        public GLSharpness()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLSharpnessViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
