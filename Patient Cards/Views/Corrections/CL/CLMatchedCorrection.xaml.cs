using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.CL;
using Patient_Cards.Helpers;

namespace Patient_Cards.Views.Corrections.CL
{
    public partial class CLMatchedCorrection : UserControl
    {
        private TextBoxValidator textBoxValidator;

        public CLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLMatchedCorrectionViewModel;

            textBoxValidator = new TextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalNumber_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalNumber(sender as TextBox);

        private void OpticalAxis_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalAxis(sender as TextBox);
    }
}
