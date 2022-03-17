using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Escuela_DAL;

namespace Escuela_BLL
{
    public class UsuarioBLL
    {

        public DataTable consultarUsuario(string nombre, string contrasena)
        {
            UsuarioDAL usuario = new UsuarioDAL();
            return usuario.consultarUsuario(nombre, contrasena);
        }

    }
}
