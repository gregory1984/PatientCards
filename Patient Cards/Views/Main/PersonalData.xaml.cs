using Patient_Cards.Helpers;
using System.Windows.Controls;

namespace Patient_Cards.Views.Main
{
    /// <summary>
    /// Interaction logic for PersonalData
    /// </summary>
    public partial class PersonalData : UserControl
    {
        private TextBoxValidator textBoxValidator;

        public PersonalData()
        {
            InitializeComponent();

            textBoxValidator = new TextBoxValidator();
        }

        private void Age_TextChanged(object sender, TextChangedEventArgs e)
            => textBoxValidator.ValidateAge(sender as TextBox);
    }
}
