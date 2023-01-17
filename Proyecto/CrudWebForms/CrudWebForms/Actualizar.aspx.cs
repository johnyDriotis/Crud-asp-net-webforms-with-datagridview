using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudWebForms
{
    public partial class About : Page
    {
       
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataAdapter sda;
        
        public void cargarGeneros() {
            string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
            cnx = new SqlConnection(cadenaConexion);
            string sql = "select idgrupomusical, concat(nombre,' - ',genero) as 'Genero musical' from grupomusical";
            cmd = new SqlCommand(sql, cnx);
            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnx.Close();
            DataSet dts = new DataSet();
            dts.Tables.Add(dt);

            if (dts.Tables[0].Rows.Count > 0)
            {
                ddlGenero.DataTextField = dts.Tables[0].Columns["Genero musical"].ToString();
                ddlGenero.DataValueField = dts.Tables[0].Columns["idgrupomusical"].ToString();
                ddlGenero.DataSource = dts.Tables[0];
                ddlGenero.DataBind();
            }
        }

        public DataTable buscarUsuario(string id)
        {
            string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
            DataTable dt = new DataTable();
            SqlConnection cnx = new SqlConnection(cadenaConexion);
            string consulta = " select U.*,GM.Genero, GM.Epoca, concat(GM.nombre,' - ',GM.genero) as 'Genero musical' from usuario U inner join grupomusical GM on U.idgrupomusical = GM.IdGrupoMusical where U.idusuario = '" + Convert.ToInt32(id) + "'";
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            return dt;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["idUsuario"] != null)
                {
                    cargarGeneros();
                    txtIdUsuario.Value = Session["idUsuario"].ToString();

                    alertError.Visible = false;
                    alertExito.Visible = false;

                    msjError.Visible = false;
                    msjExito.Visible = false;

                    DataTable dt = buscarUsuario(Session["idUsuario"].ToString());

                    foreach (DataRow row in dt.Rows)
                    {
                        txtNombres.Text = row["nombre"].ToString();
                        txtApellidos.Text = row["apellidos"].ToString();
                        txtEdad.Text = row["edad"].ToString();
                        ddlSexo.Text = row["sexo"].ToString();
                        ddlGenero.SelectedValue = row["idgrupomusical"].ToString();
                    }

                }
            }

            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNombres.Text = String.Empty;
            txtApellidos.Text = "";
            txtEdad.Text = "";
            ddlSexo.SelectedValue = "0";

            Response.Redirect("Listar.aspx");
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombres.Text.Trim();
            string apellido = txtApellidos.Text.Trim();
            string edad = txtEdad.Text;
            string sexo = ddlSexo.SelectedValue;
            string genero = ddlGenero.SelectedValue;

            if (nombre.Equals(""))
            {
                alertExito.Visible = false;
                alertExito.Visible = false;
                alertError.Visible = true;
                msjError.InnerText = "Falta ingresar el nombre del usuario";
            }
            else if (apellido.Equals(""))
            {
                alertExito.Visible = false;
                alertExito.Visible = false;
                alertError.Visible = true;
                msjError.InnerText = "Falta ingresar los apellidos del usuario";
            }
            else if (edad == "0" || edad.Trim().Equals(""))
            {
                alertExito.Visible = false;
                alertExito.Visible = false;
                alertError.Visible = true;
                msjError.InnerText = "Falta ingresar la edad usuario";
            }
            else if (sexo.Equals("0"))
            {
                alertExito.Visible = false;
                alertExito.Visible = false;
                alertError.Visible = true;
                msjError.InnerText = "Falta seleccionar el sexo del usuario";
            }
            else if (genero.Equals(""))
            {
                alertExito.Visible = false;
                alertExito.Visible = false;
                alertError.Visible = true;
                msjError.InnerText = "Falta seleccionar el sexo del usuario";
            }
            else
            {
                string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
                cnx = new SqlConnection(cadenaConexion);
                cnx.Open();
                string consulta = "update usuario set nombre='"+nombre+"', apellidos='"+apellido+"', edad='"+edad+"', sexo='"+sexo+"', idgrupomusical='"+genero+"' where idusuario='"+Session["idUsuario"]+"'";
                cmd = new SqlCommand(consulta, cnx);
                int resp = cmd.ExecuteNonQuery();

                if (resp > 0)
                {
                    cnx.Close();
                    Response.Redirect("~/");
                }
            }
        }
    }
}