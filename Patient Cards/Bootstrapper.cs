using System.Windows;
using Prism.Modularity;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Patient_Cards.Helpers;
using Patient_Cards.Views.Main;
using Patient_Cards_Model.Interfaces;
using Patient_Cards_Model.Services;

namespace Patient_Cards
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            Container.RegisterInstance(UnityNames.VersionData, new VersionData(), new ContainerControlledLifetimeManager());
            Container.RegisterType<IDatabaseService, DatabaseService>();
            Container.RegisterType<IDictionariesService, DictionariesService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IDocumentsService, DocumentsService>();
            Container.RegisterType<ISharpnessService, SharpnessService>();
            Container.RegisterType<IRatesService, RatesService>();
            Container.RegisterType<ICorrectionService, CorrectionService>();
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
        }
    }
}
