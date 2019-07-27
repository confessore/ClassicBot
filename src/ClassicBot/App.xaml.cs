using ClassicBot.Statics;
using ClassicBot.Extensions;
using ClassicBot.GUI.Views;
using System.Threading.Tasks;
using System.Windows;

namespace ClassicBot
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    internal partial class App : Application
    {
        protected override async void OnStartup(StartupEventArgs e)
        {
            await Launch();
            base.OnStartup(e);
        }

        bool Injected =>
            System.Diagnostics.Process.GetCurrentProcess().ProcessName.Contains(Strings.Process);

        async Task Launch()
        {
            if (Injected)
            {
                var mainView = new MainView();
                mainView.Show();
            }
            else
            {
                await CheckFilesAndFolders();
                var pidView = new PIDView();
                pidView.Show();
            }
        }

        Task CheckFilesAndFolders()
        {
            Strings.Injector.CheckFile(ClassicBot.Properties.Resources.ClassicBot_Injector);
            Strings.Loader.CheckFile(ClassicBot.Properties.Resources.ClassicBot_Loader);
            Strings.Bases.CheckDirectory();
            Strings.Plugins.CheckDirectory();
            return Task.CompletedTask;
        }
    }
}
