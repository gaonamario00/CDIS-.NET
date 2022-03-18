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
    public partial class Facultad_s : TemaEscuela, IAcceso
    {
        #region Eventos
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (sesionIniciada())
                {
                    grd_facultad.DataSource = cargarFacultades();
                    grd_facultad.DataBind();
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void grd_facultad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Editar")
            {
                Response.Redirect("~/Facultades/facultad_u.aspx?pID_Facultad="+e.CommandArgument);
               // Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                Response.Redirect("~/Facultades/facultad_d.aspx?pID_Facultad="+e.CommandArgument);
            }
        }

        #endregion

        #region Metodos

        public DataTable cargarFacultades()
        {

            FacultadBLL facultadBLL = new FacultadBLL();
            DataTable dtFacultades = new DataTable();

            dtFacultades = facultadBLL.cargarFacultades();

            return dtFacultades;
        }

        public bool sesionIniciada()
        {
            if(Session["Usuario"] != null)
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