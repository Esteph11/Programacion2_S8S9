using AreaCirculoAppMvvm.ViewModels;

namespace AreaCirculoAppMvvm.Views
{
    public partial class AreaCirculoView : ContentPage
    {
        private AreaCirculoViewModel ViewModel;
        public AreaCirculoView()
        {
            InitializeComponent();
            BindingContext = new AreaCirculoViewModel();
            BindingContext = ViewModel;
        }
    }
}
