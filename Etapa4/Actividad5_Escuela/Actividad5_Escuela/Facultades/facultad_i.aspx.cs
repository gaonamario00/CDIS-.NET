using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;

using Escuela_BLL;

namespace Actividad5_Escuela.Facultades
{
    public partial class facultad_i : System.Web.UI.Page
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarUniversidades();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(),"Alta", "alert('Facultad agregada exitosamente')", true);
        }

        #endregion

        #region Metodos
        public void agregarFacultad()
        {

            FacultadBLL facultadBLL = new FacultadBLL();

            string codigo = TextCodigo.Text;
            string nombre = TextNombre.Text;
            DateTime fechaCreacion = Convert.ToDateTime(TextFechaCreacion.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);

            facultadBLL.agregarFacultad(codigo, nombre, fechaCreacion, universidad);

        }

        public void cargarUniversidades()
        {
            UniversidadBLL universidad = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();

            dtUniversidades = universidad.cargarUniversidades();

            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem("---- Selecione Universidad ----","0"));

        }

        #endregion

    }
}