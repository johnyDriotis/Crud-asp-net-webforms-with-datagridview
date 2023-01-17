<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Actualizar.aspx.cs" Inherits="CrudWebForms.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-sm-9 col-md-9" style="top: 100px">
        <div class="well">
            <div class="form-horizontal">
                <fieldset>
                    <legend class="text-center">Modificar usuario</legend>

                    <asp:HiddenField ID="txtIdUsuario" runat="server" /> 

                    <div class="form-group">
                        <div class="alert alert-dismissible alert-success" id="alertExito" runat="server" >
                            <button type="button" class="close" data-dismiss="alert">&times;</button>
                            <strong id="msjExito" runat="server"></strong>
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <div runat="server" id="alertError" class="alert alert-dismissible alert-danger">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">&times;</button>
                            <strong id="msjError" runat="server"></strong>
                        </div>
                    </div>
                    

                    <div class="form-group">
                        <asp:Label ID="lblNombres" runat="server" Text="Nombres: " CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" placeholder="Ingrese nombre de usuario"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblApellidos" runat="server" Text="Apellidos: " CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Ingrese apellidos de usuario"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="lblEdad" runat="server" Text="Edad: " CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-8">
                            <asp:TextBox ID="txtEdad" runat="server" CssClass="form-control" placeholder="Ingrese la edad del usuario" TextMode="Number"></asp:TextBox>
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label ID="cmbSexo" runat="server" Text="Sexo: " CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-8">
                            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Seleccione el sexo" Value="0" />
                                <asp:ListItem Text="Masculino" Value="M" />
                                <asp:ListItem Text="Femenino" Value="F" />
                            </asp:DropDownList>
                        </div>
                    </div>

                    <!-- Se carga dinamicamente -->
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Seleccione genero musical: " CssClass="col-lg-2"></asp:Label>
                        <div class="col-lg-8">
                            <asp:DropDownList ID="ddlGenero" runat="server" CssClass="form-control">
                                
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="btn-group col-lg-12 col-lg-offset-2">
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-danger" OnClick="btnCancelar_Click"/>
                            <asp:Button ID="btnAceptar" runat="server" Text="Modificar" CssClass="btn btn-primary center-block " OnClick="btnAceptar_Click" />
                            <asp:Button ID="btnListado" runat="server" Text="Volver" CssClass="btn btn-info center-block " OnClick="btnListado_Click" />
                        </div>
                    </div>
                    


                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
