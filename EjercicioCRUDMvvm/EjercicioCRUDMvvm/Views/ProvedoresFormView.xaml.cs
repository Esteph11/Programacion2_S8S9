using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views;
public partial class ProvedoresFormView : ContentPage
{
    private ProvedoresFormViewModel ViewModel;
    public ProvedoresFormView()
    {
        InitializeComponent();
        ViewModel = new ProvedoresFormViewModel();
        BindingContext = ViewModel;
    }

    public ProvedoresFormView(Provedores Provedores)
    {
        InitializeComponent();
        ViewModel = new ProvedoresFormViewModel(Provedores);
        BindingContext = ViewModel;
    }
}