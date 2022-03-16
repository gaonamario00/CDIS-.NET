<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Actividad5_Escuela.Facultades.facultad_u" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <table>
         <tr>
             <td>ID:</td>
             <td>
                <asp:Label ID="lblID" runat="server" Text=""></asp:Label>
             </td>
             
         </tr>
        <tr>
            <td>codigo:</td>
            <td>
                <asp:TextBox ID="TextCodigo" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nombre:</td>
            <td>
                <asp:TextBox ID="TextNombre" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Fecha de Creacion:</td>
            <td>
                <asp:TextBox ID="TextFechaCreacion" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Universidad:</td>
            <td>
                <asp:DropDownList ID="ddlUniversidad" runat="server"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
