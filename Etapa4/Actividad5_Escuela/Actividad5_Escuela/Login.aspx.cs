using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Escuela_BLL;

namespace Actividad5_Escuela
{
    public partial class Login : System.Web.UI.Page
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioValido())
            {
                Response.Redirect("~/Facultades/facultad_s.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Sesion", "alert('El usuario y/o la contraseña son invalidos!')", true);
            }
        }

        #endregion

        #region Metodos

        public bool usuarioValido()
        {
            bool acceso = false;

            UsuarioBLL usuarioBLL = new UsuarioBLL();
            DataTable dtUsuario = new DataTable();

            dtUsuario = usuarioBLL.consultarUsuario(TextUsuario.Text, TextContrasena.Text);

            if(dtUsuario.Rows.Count > 0)
            {
                Session["Usuario"] = dtUsuario;
                acceso = true;

            }

            return acceso;
        }

        #endregion
    }
}