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
    public partial class facultad_u : TemaEscuela, IAcceso
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
                   // cargarEstados();
                    cargarFacultadByID(ID_Facultad);
                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            updateFacultad();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('Facultad Actualizada exitosamente')", true);
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEstado.SelectedIndex != 0)
            {
                ddlCiudad.Items.Clear();
                cargarCiudadesPorEstado();
            }
            else
            {
                ddlCiudad.Items.Clear();
            }
        }

        #endregion

        #region Metodos
        public void cargarFacultadByID(int id)
        {
          
            FacultadBLL facultadBLL = new FacultadBLL();

            Facultad facultad = new Facultad();

            facultad = facultadBLL.cargarFacultadByID(id);

            lblID.Text = facultad.ID_Facultad.ToString();
            TextCodigo.Text = facultad.codigo;
            TextNombre.Text = facultad.nombre;
            TextFechaCreacion.Text = facultad.fechaCreacion.ToString().Substring(0, 10);
            ddlUniversidad.SelectedValue = facultad.universidad.ToString();

            //lblID.Text = dtFacultad.Rows[0]["ID_Facultad"].ToString();
            //TextCodigo.Text = dtFacultad.Rows[0]["codigo"].ToString();
            //TextNombre.Text = dtFacultad.Rows[0]["nombre"].ToString();
            //TextFechaCreacion.Text = dtFacultad.Rows[0]["fechaCreacion"].ToString().Substring(0,10);
            //ddlUniversidad.SelectedValue = dtFacultad.Rows[0]["universidad"].ToString();

            cargarEstados();
            ddlEstado.SelectedValue = facultad.Ciudad1.estado.ToString();
            //ddlEstado.SelectedValue = dtFacultad.Rows[0]["estado"].ToString();

            cargarCiudadesPorEstado();
            //ddlCiudad.SelectedValue = dtFacultad.Rows[0]["ciudad"].ToString();
            ddlCiudad.SelectedValue = facultad.ciudad.ToString();

            cargarMaterias();
            List<MateriaFacultad> listMaterias = new List<MateriaFacultad>();
            listMaterias = facultad.MateriaFacultad.ToList();

            foreach (MateriaFacultad materiaFacu in listMaterias)
            {
                ListBoxMaterias.Items.FindByValue(materiaFacu.Materia.ToString()).Selected = true;
            }

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

        public void updateFacultad()
        {
            //int pID_Facultad = int.Parse(Request.QueryString["pID_Facultad"]);

            FacultadBLL facultadBLL = new FacultadBLL();

            //int ID_Facultad = int.Parse(lblID.Text);
            //string codigo = TextCodigo.Text;
            //string nombre = TextNombre.Text;
            //DateTime fechaCreacion = Convert.ToDateTime(TextFechaCreacion.Text);
            //int universidad = int.Parse(ddlUniversidad.SelectedValue);
            //int ciudad = int.Parse(ddlCiudad.SelectedValue);

            Facultad facultad = new Facultad();

            facultad.ID_Facultad = int.Parse(lblID.Text);
            facultad.codigo = TextCodigo.Text;
            facultad.nombre = TextNombre.Text;
            facultad.fechaCreacion = Convert.ToDateTime(TextFechaCreacion.Text);
            facultad.universidad = int.Parse(ddlUniversidad.SelectedValue);
            facultad.ciudad = int.Parse(ddlCiudad.SelectedValue);

            MateriaFacultad materiaFacu;
            List<MateriaFacultad> listMatFacu = new List<MateriaFacultad>();

            foreach (ListItem item in ListBoxMaterias.Items)
            {
                if (item.Selected)
                {
                    materiaFacu = new MateriaFacultad();
                    materiaFacu.Materia = int.Parse(item.Value);
                    materiaFacu.Facultad = facultad.ID_Facultad;
                    listMatFacu.Add(materiaFacu);
                }
            }

            try
            {
                facultadBLL.updateFacultad(facultad, listMatFacu
                    //ID_Facultad, codigo, nombre, fechaCreacion, universidad, ciudad
                    );
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "Alta", "alert('" + ex.Message + "')", true);
            }

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

        public void cargarEstados()
        {
            EstadosBLL estado = new EstadosBLL();
            DataTable dtEstados = new DataTable();

            dtEstados = estado.cargarEstados();

            ddlEstado.DataSource = dtEstados;
            ddlEstado.DataTextField = "nombre";
            ddlEstado.DataValueField = "ID_Estado";
            ddlEstado.DataBind();

            ddlEstado.Items.Insert(0, new ListItem("---- Selecciones Estado ----", "0"));
        }

        public void cargarCiudadesPorEstado()
        {
            CiudadBLL ciudad = new CiudadBLL();
            DataTable dtCiudad = new DataTable();

            dtCiudad = ciudad.cargarCiudadesPorEstado(int.Parse(ddlEstado.SelectedValue));

            ddlCiudad.DataSource = dtCiudad;
            ddlCiudad.DataTextField = "nombre";
            ddlCiudad.DataValueField = "ID_Ciudad";
            ddlCiudad.DataBind();

            ddlCiudad.Items.Insert(0, new ListItem("---- Selecciones Ciudad ----", "0"));
        }

        public void cargarMaterias()
        {
            MateriaBLL materia = new MateriaBLL();
            List<Materia> listMaterias = new List<Materia>();

            listMaterias = materia.cargarMaterias();

            ListBoxMaterias.DataSource = listMaterias;
            ListBoxMaterias.DataTextField = "nombre";
            ListBoxMaterias.DataValueField = "ID_Materia";
            ListBoxMaterias.DataBind();

        }

        #endregion

    }
}