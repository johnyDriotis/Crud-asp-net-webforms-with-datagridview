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
    public partial class _Default : Page
    {

        string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
        
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection(cadenaConexion);
            string sql = "select U.idusuario, U.Nombre, U.Apellidos, U.Edad, GM.Nombre as 'Grupo', GM.Genero, GM.Epoca from Usuario U inner join grupomusical GM on U.IdGrupoMusical = GM.IdGrupoMusical";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cnx.Close();
            DataSet dts = new DataSet();
            dts.Tables.Add(dt);

            if (dts.Tables[0].Rows.Count > 0) {
                list.DataSource = dts.Tables[0];
                list.DataBind();
            }
        }

        // Evento al seleccionar una fila
        protected void list_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Write("<script>" + "alert('Correcto')" + "</script>");
        }

        // Evento para el boton modificar
        protected void list_RowEditing(object sender, GridViewEditEventArgs e)
        {
            string idUsuario = list.Rows[e.NewEditIndex].Cells[2].Text;
            Session["idUsuario"] = idUsuario;

            Response.Redirect("~/Actualizar");
        }

        // Evento para el boton eliminar
        protected void list_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string idUsuario = list.Rows[e.RowIndex].Cells[2].Text;
            Session["idUsuario"] = idUsuario;

            /*
            Response.Write("<script>");
            Response.Write("var c = window.confirm('Desea eliminar el usuario con ID " + Session["idUsuario"] + "');");
            Response.Write("if(c == true){");
            Response.Write("alert('Se eliminó el registro correctamente');");
            Response.Write("}");
            Response.Write("</script>");
            */

            string cadenaConexion = "data source=DESKTOP-P7E7AGO; initial catalog=empresa; integrated security=true;";
            SqlConnection cnx = new SqlConnection(cadenaConexion);
            cnx.Open();
            string consulta = "delete from usuario where idusuario = '" + Convert.ToInt32(Session["idUsuario"].ToString()) + "'";
            SqlCommand cmd = new SqlCommand(consulta, cnx);
            int resp = cmd.ExecuteNonQuery();

            if (resp > 0)
            {
                cnx.Close();
                Response.Redirect("~/");
            }
            

        }

        // Evento para ocultar la algunas columnas
        protected void list_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Visible = false;
        }
    }
}