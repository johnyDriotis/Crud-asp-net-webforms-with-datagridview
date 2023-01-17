<%@ Page Title="Listado de usuarios con su musica" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="CrudWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <hr />
    <hr />

    <legend>Ver Usuarios con su género musical</legend>

    
    <!-- Boton para agregar un usuario-->
    <asp:LinkButton ID="linkAgregar" Text="Agregar usuario" CssClass="btn btn-primary" runat="server" href="Create"></asp:LinkButton>

    <br />
    <br />

     <div class="panel panel-info">
        <div class="table-responsive">
            <asp:GridView ID="list" runat="server" CssClass="table table-bordered" AlternatingRowStyle-BackColor="#99ccff" AlternatingRowStyle-ForeColor="Orange" OnSelectedIndexChanged="list_SelectedIndexChanged" OnRowEditing="list_RowEditing" OnRowDeleting="list_RowDeleting" OnRowDataBound="list_RowDataBound" >
                <AlternatingRowStyle BackColor="#ebebeb" ForeColor="#400000"></AlternatingRowStyle>
                <Columns>
                    <asp:ButtonField ButtonType="Button" CommandName="Edit" HeaderText="Modificar" ShowHeader="True" Text="Modificar" ControlStyle-CssClass="btn btn-info">
                        <ControlStyle CssClass="btn btn-info"></ControlStyle>
                    </asp:ButtonField>
                    <asp:ButtonField ButtonType="Button" CommandName="Delete" HeaderText="Eliminar" ShowHeader="True" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" />
                    
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
