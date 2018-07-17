using System.Windows.Controls;
using Patient_Cards.ViewModels.Corrections.GL;
using Patient_Cards.Helpers;

namespace Patient_Cards.Views.Corrections.GL
{
    public partial class GLMatchedCorrection : UserControl
    {
        private TextBoxValidator textBoxValidator;

        public GLMatchedCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLMatchedCorrectionViewModel;

            textBoxValidator = new TextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalNumber_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalNumber(sender as TextBox);

        private void OpticalAxis_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalAxis(sender as TextBox);
    }
}
