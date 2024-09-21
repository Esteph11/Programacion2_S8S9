using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;

namespace AreaCirculoAppMvvm.ViewModels
{
    public partial class AreaCirculoViewModel : ObservableObject
    {
        [ObservableProperty]
        private double radio;

        [ObservableProperty]
        private double resultado;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        [RelayCommand]
        public void Calcular()
        {
            try
            {

                if (Radio >= 0)
                {
 
                    Resultado = CalcularArea();

                }
                else
                {
                    Alerta("ADVERTENCIA", "El valor del radio debe ser un número válido y no negativo.");
                }
            }
            catch (Exception ex)
            {
                Alerta("ERROR", ex.Message);
            }
        }

        [RelayCommand]
        private void Limpiar()
        {
            Radio = 0;
            Resultado = 0;
        }

        public double CalcularArea()
        {
            
            return Math.PI * Math.Pow(Radio, 2); // Área = π * r²  
        }

    }
}

