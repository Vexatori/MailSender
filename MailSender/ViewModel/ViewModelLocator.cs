using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

using MailSender.Infrastructure;
using MailSender.lib;
using MailSender.lib.Data;
using MailSender.lib.Interfaces;

namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainWindowViewModel>();
            SimpleIoc.Default.Register<SendWithOwnDataWindowViewModel>();
            SimpleIoc.Default.Register<MailSender.lib.Data.Context.MailDatabaseContext>();

            //SimpleIoc.Default.Register<IRecipientsData, InMemoryRecipientsData>();

            SimpleIoc.Default.Register<IRecipientsData, EFRecipientsData>();

            SimpleIoc.Default.Register<IMailsData, InMemoryMailsData>();

            SimpleIoc.Default.Register<IMailService, MailService>();
            //SimpleIoc.Default.Register<IMailService, DebugMailService>();

            SimpleIoc.Default.Register<IServersData, EFServersData>();

            //if(!SimpleIoc.Default.IsRegistered<MailDatabaseContext>())
            //    SimpleIoc.Default.Register<MailDatabaseContext>(()=>new MailDatabaseContext());
        }

        public MainWindowViewModel MainWindowModel => ServiceLocator.Current.GetInstance<MainWindowViewModel>();

        public SendWithOwnDataWindowViewModel SendWithOwnDataWindowModel => ServiceLocator.Current.GetInstance<SendWithOwnDataWindowViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}