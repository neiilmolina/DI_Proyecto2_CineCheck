using CommunityToolkit.Mvvm.ComponentModel;
using Proyecto_DI.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_DI.VistaModelo
{
    public partial class ListaVM : ObservableValidator
    {
        public ObservableCollection<Usuario> lista { get; set; } = App.usuarioRepositorio.listarUsuario();
    }
}
