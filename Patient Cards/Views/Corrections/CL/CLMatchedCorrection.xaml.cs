using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.CL;
using Patient_Cards.Helpers;

namespace Patient_Cards.Views.Corrections.CL
{
    public partial class CLMatchedCorrection : UserControl
    {
        private OpticalTextBoxValidator opticalTextBoxValidator;

        public CLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as CLMatchedCorrectionViewModel;

            opticalTextBoxValidator = new OpticalTextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalNumber_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalNumber(sender as TextBox);

        private void OpticalAxis_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalAxis(sender as TextBox);
    }
}
