using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Escuela_BLL;
using Escuela_DAL;

namespace Actividad5_Escuela.Facultades
{
    public partial class facultad_d : TemaEscuela, IAcceso
    {

        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    int ID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);
                    cargarUniversidades();
                    cargarFacultadByID(ID_Facultad);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            deleteFacultad();
            //Response.Redirect("~/Facultades/facultad_s.aspx");
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Delete", "alert('Facultad eliminada exitosamente')", true);
            
        }

        #endregion

        #region Metodos

        public void cargarFacultadByID(int id)
        {
            FacultadBLL facultadBLL = new FacultadBLL();
            
            Facultad facultad = new Facultad();

            facultad = facultadBLL.cargarFacultadByID(id);

            lblID.Text = facultad.ID_Facultad.ToString();
            lblCodigo.Text = facultad.codigo;
            lblNombre.Text = facultad.nombre;
            lblFechaCreacion.Text = facultad.fechaCreacion.ToString();
            ddlUniversidad.SelectedValue = facultad.universidad.ToString();

            //lblID.Text = dtFacultad.Rows[0]["ID_Facultad"].ToString();
            //lblCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            //lblNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            //lblFechaCreacion.Text = dtFacultad.Rows[0]["fechaCreacion"].ToString().Substring(0, 10);
            //ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();
        }

        public void cargarUniversidades()
        {
            UniversidadBLL universidadBLL = new UniversidadBLL();
            List<Universidad> universidadList = new List<Universidad>();

            universidadList = universidadBLL.cargarUniversidades();

            ddlUniversidad.DataSource = universidadList;
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

        public bool sesionIniciada()
        {
            if (Session["Usuario"] != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

    }
}