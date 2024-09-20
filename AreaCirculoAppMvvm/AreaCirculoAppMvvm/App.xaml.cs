using AreaCirculoAppMvvm.Views;
namespace AreaCirculoAppMvvm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new AreaCirculoView());
        }
    }
}
