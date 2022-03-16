<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_s.aspx.cs" Inherits="Actividad5_Escuela.Facultades.Facultad_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <asp:GridView ID="grd_facultad" AutoGenerateColumns="false" runat="server" OnRowCommand="grd_facultad_RowCommand" >
        <Columns>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" ImageUrl="~/Imagenes/outline_edit_black_24dp.png" Height="20px" Width="20px" 
                        CommandName="Editar" CommandArgument='<%# Eval("ID_Facultad") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" ImageUrl="~/Imagenes/outline_delete_black_24dp.png" Height="20px" Width="20px" 
                        CommandName="Eliminar" CommandArgument='<%# Eval("ID_Facultad") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="ID" DataField="ID_Facultad" />
            <asp:BoundField HeaderText="Codigo" DataField="codigo" />
            <asp:BoundField HeaderText="Nombre" DataField="nombre" />
            <asp:BoundField HeaderText="Fecha de Creacion" DataField="fechaCreacion" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField HeaderText="IDUniversidad" DataField="nombreUniversidad" />
        </Columns>

    </asp:GridView>
</asp:Content>
