using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Patient_Cards.Helpers
{
    public class TextBoxValidator
    {
        public void ValidateAge(TextBox textbox)
        {
            var text = textbox.Text;

            if (!string.IsNullOrWhiteSpace(text) && !text.IsPositiveInteger())
            {
                ProcessTextBox(textbox);
            }
        }

        public void ValidateOpticalNumber(TextBox textbox)
        {
            var text = textbox.Text;

            if (!string.IsNullOrWhiteSpace(text) && !text.IsOpticalNumber())
            {
                ProcessTextBox(textbox);
            }
        }

        public void ValidateOpticalAxis(TextBox textbox)
        {
            var text = textbox.Text;

            if (!string.IsNullOrWhiteSpace(text) && !text.IsOpticalAxis())
            {
                ProcessTextBox(textbox);
            }
        }

        public void ValidateOpticalSharpness(TextBox textbox)
        {
            var text = textbox.Text;

            if (!string.IsNullOrWhiteSpace(text) && !text.IsOpticalSharpness())
            {
                ProcessTextBox(textbox);
            }
        }

        private void ProcessTextBox(TextBox textbox)
        {
            textbox.Text = textbox.Text.Substring(0, textbox.Text.Length - 1);
            textbox.CaretIndex = textbox.Text.Length;
        }
    }
}
