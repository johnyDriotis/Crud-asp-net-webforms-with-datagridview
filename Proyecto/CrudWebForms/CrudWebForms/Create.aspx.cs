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
    public partial class _Create : Page
    {
        SqlConnection cnx;
        SqlCommand cmd;
        SqlDataAdapter sda;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                // Cargando los datos desde la base de datos al dropdownlist
                string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
                cnx = new SqlConnection(cadenaConexion);
                string sql = "select idgrupomusical, concat(nombre,' - ',genero) as 'genero' from grupomusical";
                cmd = new SqlCommand(sql, cnx);
                sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                cnx.Close();
                DataSet dts = new DataSet();
                dts.Tables.Add(dt);

                if (dts.Tables[0].Rows.Count > 0)
                {
                    ddlGenero.Items.Clear();
                    ddlGenero.DataSource = dts.Tables[0];
                    ddlGenero.DataValueField = dts.Tables[0].Columns["idgrupomusical"].ToString();
                    ddlGenero.DataTextField = dts.Tables[0].Columns["genero"].ToString();
                    ddlGenero.DataBind();
                }

                alertExito.Visible = false;
                alertError.Visible = false;
            }
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e){
            txtNombres.Text = String.Empty;
            txtApellidos.Text = "";
            txtEdad.Text = "";
            ddlSexo.SelectedValue = "0";

            Response.Redirect("Listar.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e){
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
            else {
                string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
                cnx = new SqlConnection(cadenaConexion);
                cnx.Open();
                string consulta = "insert into usuario values('" + nombre + "', '" + apellido + "', '" + Convert.ToInt32(edad) + "', '" + sexo + "', '" + Convert.ToInt32(genero) + "')";
                cmd = new SqlCommand(consulta, cnx);
                int resp = cmd.ExecuteNonQuery();

                if (resp > 0)
                {
                    cnx.Close();
                    Response.Redirect("~/");
                }
            }

            
        }

        protected void btnListado_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}