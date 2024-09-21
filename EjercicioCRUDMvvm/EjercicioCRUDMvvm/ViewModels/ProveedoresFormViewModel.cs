using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;
using EjercicioCRUDMvvm.Views;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProveedoresFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private int id;

        [ObservableProperty]
        private string nombre;

        [ObservableProperty]
        private string apellido;

        [ObservableProperty]
        private string correo;

        [ObservableProperty]
        private string telefono;

        [ObservableProperty]
        private string direccion;

        private readonly ProveedoresService ProductoService;

        public ProveedoresFormViewModel()
        {
            ProveedoresService = new ProveedoresService();
        }

        public ProveedoresFormViewModel(Proveedores Proveedores)
        {
            ProveedoresService = new ProveedoresService();
            Id = Proveedores.Id;
            Nombre = Proveedores.Nombre;
            Apellido = Proveedores.Apellido;
            Correo = Proveedores.Correo;
            Telefono = Proveedores.Telefono;
            Direccion = Proveedores.Direccion;
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        private bool Validar(Proveedores Proveedores)
        {
            if (Proveedores.Nombre is null || Proveedores.Nombre == "")
            {
                Alerta("ADVERTENCIA", "Ingrese el nombre del producto");
                return false;
            }
            else if (Proveedores.Apellido is null || Proveedores.Apellido == "")
            {
                Alerta("ADVERTENCIA", "Ingrese la descripción del producto");
                return false;
            }
            else if (Proveedores.Correo is null || Proveedores.Correo == "")
            {
                Alerta("ADVERTENCIA", "INgrese la marca del producto");
                return false;
            }
            else if (Proveedores.Telefono is null || Proveedores.Telefono == "")
            {
                Alerta("ADVERTENCIA", "INgrese la marca del producto");
                return false;
            }
            else if (Proveedores.Direccion is null || Proveedores.Direccion == "")
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
                Proveedores Proveedores = new Proveedores();
                Proveedores.Id = Id;
                Proveedores.Nombre = Nombre;
                Proveedores.Apellido = Apellido;
                Proveedores.Correo = Correo;
                Proveedores.Telefono = Telefono;
                Proveedores.Direccion = Direccion;

                if (Validar(Proveedores))
                {
                    if (Id == 0)
                    {
                        ProductoService.Insert(Proveedores);
                    }
                    else
                    {
                        ProductoService.Update(Proveedores);
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
