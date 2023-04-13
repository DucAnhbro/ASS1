using SaleWPFApp;
using System.Windows;

namespace ASS1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void ApplicationStart(object sender, StartupEventArgs e)
        {
            WindowLogin login = new WindowLogin();
            login.Show();
        }
    }
}
