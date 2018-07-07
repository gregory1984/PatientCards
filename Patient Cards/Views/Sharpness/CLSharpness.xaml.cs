using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Sharpness;
using System.Windows.Controls;

namespace Patient_Cards.Views.Sharpness
{
    /// <summary>
    /// Interaction logic for CLSharpness
    /// </summary>
    public partial class CLSharpness : UserControl
    {
        private OpticalTextBoxValidator opticalTextBoxValidator;

        public CLSharpness()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLSharpnessViewModel;

            opticalTextBoxValidator = new OpticalTextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalSharpness_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalSharpness(sender as TextBox);
    }
}
