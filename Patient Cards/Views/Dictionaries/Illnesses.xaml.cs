using System.Windows.Controls;
using Patient_Cards.ViewModels.Dictionaries;

namespace Patient_Cards.Views.Dictionaries
{
    public partial class Illnesses : UserControl
    {
        public Illnesses()
        {
            InitializeComponent();

            var viewmodel = DataContext as IllnessesViewModel;

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
