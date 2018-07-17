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
        private TextBoxValidator textBoxValidator;

        public CLSharpness()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLSharpnessViewModel;

            textBoxValidator = new TextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalSharpness_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalSharpness(sender as TextBox);
    }
}
