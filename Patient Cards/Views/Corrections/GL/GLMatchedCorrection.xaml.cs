using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.GL;
using Patient_Cards.Helpers;

namespace Patient_Cards.Views.Corrections.GL
{
    public partial class GLMatchedCorrection : UserControl
    {
        private OpticalTextBoxValidator opticalTextBoxValidator;

        public GLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLMatchedCorrectionViewModel;

            opticalTextBoxValidator = new OpticalTextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalNumber_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalNumber(sender as TextBox);

        private void OpticalAxis_TextChanged(object sender, TextChangedEventArgs e)
            => opticalTextBoxValidator.ValidateOpticalAxis(sender as TextBox);
    }
}
