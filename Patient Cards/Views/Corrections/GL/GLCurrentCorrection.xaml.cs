using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Corrections.GL;

namespace Patient_Cards.Views.Corrections.GL
{
    public partial class GLCurrentCorrection : UserControl
    {
        private TextBoxValidator textBoxValidator;

        public GLCurrentCorrection()
        {
            InitializeComponent();

            var viewmodel = DataContext as GLCurrentCorrectionViewModel;

            textBoxValidator = new TextBoxValidator();

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }

        private void OpticalNumber_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalNumber(sender as TextBox);

        private void OpticalAxis_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateOpticalAxis(sender as TextBox);
    }
}
