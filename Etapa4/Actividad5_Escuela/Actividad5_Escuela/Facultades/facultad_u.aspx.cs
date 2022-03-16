using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Escuela_BLL;

namespace Actividad5_Escuela.Facultades
{
    public partial class facultad_u : System.Web.UI.Page
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int ID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);
                cargarUniversidades();
                cargarFacultadByID(ID_Facultad);
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            updateFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad Actualizada exitosamente')", true);
        }

        #endregion

        #region Metodos
        public void cargarFacultadByID(int id)
        {
          
            FacultadBLL facultadBLL = new FacultadBLL();
            DataTable dtFacultad = new DataTable();

            dtFacultad = facultadBLL.cargarFacultadByID(id);

            lblID.Text = dtFacultad.Rows[0]["ID_Facultad"].ToString();
            TextCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            TextNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            TextFechaCreacion.Text = dtFacultad.Rows[0]["fechaCreacion"].ToString().Substring(0,10);
            ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();

        }

        public void cargarUniversidades()
        {
            UniversidadBLL universidadBLL = new UniversidadBLL();
            DataTable dtUniversidades = new DataTable();

           dtUniversidades = universidadBLL.cargarUniversidades();

            ddlUniversidad.DataSource = dtUniversidades;
            ddlUniversidad.DataTextField = "nombre";
            ddlUniversidad.DataValueField = "ID_Universidad";
            ddlUniversidad.DataBind();

            ddlUniversidad.Items.Insert(0, new ListItem("---- Selecione Universidad ----", "0"));

        }

        public void updateFacultad()
        {
            FacultadBLL facultadBLL = new FacultadBLL();

            int ID_Facultad = int.Parse(lblID.Text);
            string codigo = TextCodigo.Text;
            string nombre = TextNombre.Text;
            DateTime fechaCreacion = Convert.ToDateTime(TextFechaCreacion.Text);
            int universidad = int.Parse(ddlUniversidad.SelectedValue);

            facultadBLL.updateFacultad( ID_Facultad, codigo, nombre, fechaCreacion, universidad);
        }

        #endregion

    }
}