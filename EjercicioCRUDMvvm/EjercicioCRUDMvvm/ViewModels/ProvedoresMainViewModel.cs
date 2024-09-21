using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EjercicioCRUDMvvm.Models;
using EjercicioCRUDMvvm.Services;
using System.Collections.ObjectModel;
using EjercicioCRUDMvvm.Views;
using EjercicioCRUDMvvm;

namespace EjercicioCRUDMvvm.ViewModels
{
    public partial class ProvedoresMainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Provedores> provedoresCollection = new ObservableCollection<Provedores>();

        private readonly ProvedoresService ProvedoresService;

        public ProvedoresMainViewModel()
        {
            ProvedoresService = new ProvedoresService();
        }

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public void GetAll()
        {
            var GetAll = ProvedoresService.GetAll();

            if (GetAll.Count > 0)
            {
                ProvedoresCollection.Clear();
                foreach (var producto in GetAll)
                {
                    ProvedoresCollection.Add(producto);
                }
            }
        }

        [RelayCommand]
        private async Task GoToAddProductoForm()
        {
            await App.Current!.MainPage!.Navigation.PushAsync(new ProvedoresFormView());
        }

        [RelayCommand]
        private async Task SelectProducto(Provedores Provedores)
        {
            try
            {
                const string ACTUALIZAR = "1. Actualizar";
                const string ELIMINAR = "2. Eliminar";

                string res = await App.Current!.MainPage!.DisplayActionSheet("OPCIONES", "Cancelar", null, ACTUALIZAR, ELIMINAR);

                if (res == ACTUALIZAR)
                {
                    await App.Current.MainPage.Navigation.PushAsync(new ProvedoresFormView(Provedores));
                }
                else if (res == ELIMINAR)
                {
                    bool respuesta = await App.Current!.MainPage!.DisplayAlert("ELIMINAR PRODUCTO", "¿Desea eliminar el producto?", "Si", "No");

                    if (respuesta)
                    {
                        int del = ProvedoresService.Delete(Provedores);

                        if (del > 0)
                        {
                            ProvedoresCollection.Remove(Provedores);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

    }
}