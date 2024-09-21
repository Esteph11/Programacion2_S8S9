using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;
using EjercicioCRUDMvvm.Views;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProvedoresFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string empresa;

        [ObservableProperty]
        private string encargado;

        [ObservableProperty]
        private string correo;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string direccion;

        private readonly ProvedoresService ProvedoresService;

        public ProvedoresFormViewModel()
        {
            ProvedoresService = new ProvedoresService();
        }

        public ProvedoresFormViewModel(Provedores Provedores)
        {
            ProvedoresService = new ProvedoresService();
            Id = Provedores.Id;
            Empresa = Provedores.Empresa;
            Encargado = Provedores.Encargado;
            Correo = Provedores.Correo;
            Telefono = Provedores.Telefono;
            Direccion = Provedores.Direccion;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        private bool Validar(Provedores Provedores)
        {
            if (Provedores.Empresa is null || Provedores.Empresa == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del producto");
                return false;
            }
            else if (Provedores.Encargado is null || Provedores.Encargado == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la descripción del producto");
                return false;
            }
            else if (Provedores.Correo is null || Provedores.Correo == "")
            {
                Alerta("ADVERTENCIA", "INgrese la marca del producto");
                return false;
            }
            else if (Provedores.Telefono is null || Provedores.Telefono == "")
            {
                Alerta("ADVERTENCIA", "INgrese la marca del producto");
                return false;
            }
            else if (Provedores.Direccion is null || Provedores.Direccion == "")
            {
                Alerta("ADVERTENCIA", "INgrese la marca del producto");
                return false;
            }
            else
            {
                return true;
            }
        }

        [RelayCommand]
        private async Task AddUpdate()
        {
            try
            {
                Provedores Provedores = new Provedores();
                Provedores.Id = Id;
                Provedores.Empresa = Empresa;
                Provedores.Encargado = Encargado;
                Provedores.Correo = Correo;
                Provedores.Telefono = Telefono;
                Provedores.Direccion = Direccion;

                if (Validar(Provedores))
                {
                    if (Id == 0)
                    {
                        ProvedoresService.Insert(Provedores);
                    }
                    else
                    {
                        ProvedoresService.Update(Provedores);
                    }
                    await App.Current!.MainPage!.Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}
