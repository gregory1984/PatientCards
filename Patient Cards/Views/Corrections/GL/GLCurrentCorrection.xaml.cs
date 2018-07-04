using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Input;
using Patient_Cards.Helpers;
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textbox = sender as TextBox;
            var text = textbox.Text;

            if (!string.IsNullOrWhiteSpace(text) && !text.IsOpticalNumber())
            {
                text = text.Substring(0, text.Length - 1);

                textbox.Text = text;
                textbox.CaretIndex = text.Length;
            }
        }
    }
}
