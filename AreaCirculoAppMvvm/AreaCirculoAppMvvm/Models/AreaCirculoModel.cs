using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AreaCirculoAppMvvm.Models;


namespace AreaCirculoAppMvvm.Models
{
    public class Circulo
    {
        public double Radio { get; set; }

        public double CalcularArea()
        {
            return Math.PI * Math.Pow(Radio, 2); // Área = π * r²  
        }
    }
}
