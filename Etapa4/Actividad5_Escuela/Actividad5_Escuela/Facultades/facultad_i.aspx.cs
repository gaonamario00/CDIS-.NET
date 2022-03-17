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
    public partial class facultad_i : System.Web.UI.Page, IAcceso
    {
        #region Eventos

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    cargarUniversidades();
                    cargarTabla();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }                
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            agregarFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad agregada exitosamente')", true);
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

            try
            {
                facultadBLL.agregarFacultad(codigo, nombre, fechaCreacion, universidad);
                Console.WriteLine("A");
                limpiarCampos();

                DataTable dtfacultades = new DataTable();
                dtfacultades = (DataTable)ViewState["tablaFacultades"];

                dtfacultades.Rows.Add(codigo, nombre);

                grd_facultades.DataSource = dtfacultades;
                grd_facultades.DataBind();
        }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alert('"+ex.Message+"')", true);
        }


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

        public void limpiarCampos()
        {
            TextCodigo.Text = "";
            TextNombre.Text = "";
            TextFechaCreacion.Text = "";
            ddlUniversidad.SelectedIndex = 0;
        }

        public void cargarTabla()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("codigo");
            dt.Columns.Add("nombre");

            ViewState["tablaFacultades"] = dt;

        }

        #endregion

    }
}