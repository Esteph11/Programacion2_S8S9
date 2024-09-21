using EjercicioCRUDMvvm.ViewModels;

namespace EjercicioCRUDMvvm.Views;

public partial class ProvedoresMainView : ContentPage
{
    private ProvedoresMainViewModel ViewModel;

    public ProvedoresMainView()
    {
        InitializeComponent();
        ViewModel = new ProvedoresMainViewModel();
        this.BindingContext = ViewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ViewModel.GetAll();
    }

}