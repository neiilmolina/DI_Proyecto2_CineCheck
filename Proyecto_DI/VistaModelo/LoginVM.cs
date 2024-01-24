using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_DI.Modelo;
using Proyecto_DI.Repositorio;
using Proyecto_DI.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DI.VistaModelo
{
    public partial class LoginVM : ObservableValidator
    {

        public ObservableCollection<string> ErrorNick { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ErrorPass { get; set; } = new ObservableCollection<string>();
        public static bool usuarioEncontrado { get; set; } = false;

        public String nick;
        [Required(ErrorMessage = "Debes introducir un nick")]
        public String Nick
        {
            get => nick;
            set => SetProperty(ref nick, value);
        }

        public String password;
        [Required(ErrorMessage = "Debes introducir una contraseña")]
        public String Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        [RelayCommand]
        public async Task validarAsync()
        {
            int contErr = 0;
            ValidateAllProperties();
            ErrorNick.Clear();
            ErrorPass.Clear();
            GetErrors(nameof(Nick)).ToList().ForEach(f => { ErrorNick.Add(f.ErrorMessage); contErr++; });
            GetErrors(nameof(Password)).ToList().ForEach(f => { ErrorPass.Add(f.ErrorMessage);  contErr++; } );

            if (App.usuarioRepositorio.verUsuario(Nick, Password))
            {
                Usuario usuario = App.usuarioRepositorio.obtenerUsuario(Nick);
                usuarioEncontrado = true;
                await Application.Current.MainPage.DisplayAlert("Iniciar Sesión", "Inicio de sesión con éxito", "Ok");
                Preferences.Default.Set(App.usuario_id, usuario.Id);
                await AppShell.Current.GoToAsync(nameof(Vistas.PaginaPrincipal));
            }
            else 
            { 
                await Application.Current.MainPage.DisplayAlert("Iniciar Sesión", "No se puede Iniciar Sesión", "Ok");
            }


        }

        [RelayCommand]
        public async Task cambiarAregisterAsync()
        {
            await AppShell.Current.GoToAsync(nameof(Vistas.Registro));
        }
    }
}

