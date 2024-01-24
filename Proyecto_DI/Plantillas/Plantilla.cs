using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DI.Plantilla
{
    public class Plantilla : ContentPage
    {
        public Plantilla()
        {
            var plantilla = Application.Current.Resources["plantilla"] as ControlTemplate;
            ControlTemplate = plantilla;
        }
    }
}
