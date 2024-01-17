using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Proyecto_DI.Vistas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace Proyecto_DI.VistaModelo
{
    public partial class RegistroVM : ObservableValidator
    {
        public int contErr = 0;
        public ObservableCollection<string> ErrorNick { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ErrorNombre { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ErrorEdad { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ErrorPass { get; set; } = new ObservableCollection<string>();
        public ObservableCollection<string> ErrorPassCopy { get; set; } = new ObservableCollection<string>();

        public String nick;
        [Required(ErrorMessage = "Debes introducir un nick")]
        public String Nick
        {
            get => nick;
            set => SetProperty(ref nick, value);
        }

        public String nombre;
        [Required(ErrorMessage = "Debes introducir un nombre")]
        [RegularExpression(@"^\D*$", ErrorMessage = "El nombre no debe contener números")]
        public String Nombre
        {
            get => nombre;
            set => SetProperty(ref nombre, value);
        }

        public String edad;
        [Required(ErrorMessage = "Debes introducir tu edad")]
        [RegularExpression(@"^([1-9]|[1-9][0-9])$", ErrorMessage ="Debe de ser una edad válida (1-99)")]
        public String Edad
        {
            get => edad;
            set => SetProperty(ref edad, value);
        }

        public String password;
        [Required(ErrorMessage = "Debes introducir una contraseña")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "La contraseña debe de ser mayor de 5 caractéres")]
        public String Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public String passwordCopy;
        [Required(ErrorMessage = "Debes repetir la contraseña")]
        [Compare(nameof(Password), ErrorMessage = "No coinciden las contraseñas")]
        public String PasswordCopy
        {
            get => passwordCopy;
            set => SetProperty(ref passwordCopy, value);
        }

        [RelayCommand]
        public async Task validarAsync()
        {
            ValidateAllProperties();
            ErrorNick.Clear();
            ErrorNombre.Clear();
            ErrorEdad.Clear();
            ErrorPass.Clear();
            ErrorPassCopy.Clear();
            GetErrors(nameof(Nick)).ToList().ForEach(f => { ErrorNick.Add(f.ErrorMessage); contErr++; });
            GetErrors(nameof(Nombre)).ToList().ForEach(f => { ErrorNombre.Add(f.ErrorMessage); contErr++; });
            GetErrors(nameof(Edad)).ToList().ForEach(f => { ErrorEdad.Add(f.ErrorMessage); contErr++; });
            GetErrors(nameof(Password)).ToList().ForEach(f => { ErrorPass.Add(f.ErrorMessage); contErr++; });
            GetErrors(nameof(PasswordCopy)).ToList().ForEach(f => { ErrorPassCopy.Add(f.ErrorMessage); contErr++; });

            if (contErr == 0)
            {
                App.usuarioRepositorio.add(new Modelo.Usuario { Nick = Nick, Nombre = Nombre, Edad = int.Parse(edad), Password = Password });
                await AppShell.Current.GoToAsync(nameof(Vistas.Login));
            }

        }

        [RelayCommand]
        public async Task cambiarAloginAsync()
        {
            await AppShell.Current.GoToAsync(nameof(Vistas.Login));
        }

    }
}
