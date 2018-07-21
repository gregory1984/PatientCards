using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using MahApps.Metro.Controls;
using Patient_Cards.Helpers;
using Patient_Cards.ViewModels.Main;

namespace Patient_Cards.Views.Main
{
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            Thread.CurrentThread.CurrentCulture =
            CultureInfo.GetCultureInfo("pl-PL");

            LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            InitializeComponent();

            var viewmodel = DataContext as MainWindowViewModel;
            viewmodel.ExceptionOccuredEvent += (ex) => MessageBoxes.CriticalQuestion(ex.ToString());

            Unloaded += (sender, e) => viewmodel.UnsubscribePrismEvents();
        }
    }
}
