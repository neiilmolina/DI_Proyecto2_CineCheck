namespace Proyecto_DI.Plantillas
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
