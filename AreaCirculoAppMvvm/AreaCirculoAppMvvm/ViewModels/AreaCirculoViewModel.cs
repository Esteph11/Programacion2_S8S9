using System.ComponentModel;
using System.Runtime.CompilerServices;
using AreaCirculoAppMvvm.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace AreaCirculoAppMvvm.ViewModels
{
    public class AreaCirculoViewModel : ObservableObject
    {
        [ObservableProperty]
        private double radio;
        [ObservableProperty]
        private double resultado;

        private void Alerta(string Titulo, string Mensaje)
        {
            MainThread.BeginInvokeOnMainThread(async () => await App.Current!.MainPage!.DisplayAlert(Titulo, Mensaje, "Aceptar"));
        }

        public double Radio
        {
            get => radio;
            set
            {
                radio = value;
                OnPropertyChanged();
            }
        }

        public double Resultado
        {
            get => resultado;
            set
            {
                resultado = value;
                OnPropertyChanged();
            }
        }

        public void CalcularArea()
        {
            // Aquí no necesitas convertir Radio, ya que ya es un double  
            if (Radio >= 0) // Asegúrate de que el radio sea un número válido (no negativo)  
            {
                Circulo circulo = new Circulo { Radio = Radio }; // Usa la propiedad directamente  
                Resultado = circulo.CalcularArea();
            }
            else
            {
                Alerta("ADVERTENCIA", "El valor del radio debe ser un número válido y no negativo.");
            }
        }



        [RelayCommand]
        private void Limpiar()
        {
            radio = 0;
            resultado = 0;
          
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
