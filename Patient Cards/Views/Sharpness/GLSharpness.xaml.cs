using System.Text.RegularExpressions;
using System.Windows.Controls;
using Patient_Cards.ViewModels.Sharpness;
using Patient_Cards.Helpers;

namespace Patient_Cards.Views.Sharpness
{
    public partial class GLSharpness : UserControl
    {
        private OpticalTextBoxValidator opticalTextBoxValidator;

        public GLSharpness()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLSharpnessViewModel;

            opticalTextBoxValidator = new OpticalTextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalSharpness_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalSharpness(sender as TextBox);
    }
}
