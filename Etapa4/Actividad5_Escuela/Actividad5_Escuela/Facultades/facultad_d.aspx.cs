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
    public partial class facultad_d : System.Web.UI.Page
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            deleteFacultad();
            //Response.Redirect("~/Facultades/facultad_s.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad eliminada exitosamente')", true);
            
        }

        #endregion

        #region Metodos

        public void cargarFacultadByID(int id)
        {
            FacultadBLL facultadBLL = new FacultadBLL();
            DataTable dtFacultad = new DataTable();

            dtFacultad = facultadBLL.cargarFacultadByID(id);

            lblID.Text = dtFacultad.Rows[0]["ID_Facultad"].ToString();
            lblCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            lblNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            lblFechaCreacion.Text = dtFacultad.Rows[0]["fechaCreacion"].ToString().Substring(0, 10);
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

        public void deleteFacultad()
        {
          
            FacultadBLL facultadBLL = new FacultadBLL();

            int ID_Facultad = int.Parse(lblID.Text);

            facultadBLL.deleteFacultad(ID_Facultad);
        }

        #endregion

    }
}