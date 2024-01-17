using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_DI.Repositorio;
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
            ValidateAllProperties();
            ErrorNick.Clear();
            ErrorPass.Clear();
            GetErrors(nameof(Nick)).ToList().ForEach(f => ErrorNick.Add(f.ErrorMessage));
            GetErrors(nameof(Password)).ToList().ForEach(f => ErrorPass.Add(f.ErrorMessage));
            
            if (App.usuarioRepositorio.verUsuario(Nick, Password))
            {
                await AppShell.Current.GoToAsync(nameof(Vistas.Lista));
            }

        }

        [RelayCommand]
        public async Task cambiarAregisterAsync()
        {
            await AppShell.Current.GoToAsync(nameof(Vistas.Registro));
        }
    }
}

