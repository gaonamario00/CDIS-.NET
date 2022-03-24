﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="facultad_u.aspx.cs" Inherits="Actividad5_Escuela.Facultades.facultad_u" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>

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
                        <asp:TextBox ID="TextCodigo" MaxLength="6" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_codigo" runat="server" ControlToValidate="TextCodigo"
                            ErrorMessage="Campo de codigo es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_codigo" runat="server" ErrorMessage="El codigo debe de contener  4 letras mayusculas y 2 numeros. Ejemplo: FCFM01"
                            ControlToValidate="TextCodigo" ValidationExpression="^[A-Z]{4}[0-9]{2}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre:</td>
                    <td>
                        <asp:TextBox ID="TextNombre" MaxLength="100" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="TextNombre"
                            ErrorMessage="Campo nombre es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Fecha de Creacion:</td>
                    <td>
                        <asp:TextBox ID="TextFechaCreacion" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_fechaCreacion" runat="server" ControlToValidate="TextFechaCreacion"
                            ErrorMessage="Campo fecha es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="cv_fecha" runat="server" ErrorMessage="El formato es incorrecto (dd/mm/yyyy) o (yyyy/mm/dd)"
                            ControlToValidate="TextFechaCreacion" Type="Date" Operator="DataTypeCheck"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>Universidad:</td>
                    <td>
                        <asp:DropDownList ID="ddlUniversidad" runat="server"  CssClass="lista"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfv_universidad" runat="server" ControlToValidate="ddlUniversidad"
                            ErrorMessage="Campo universidad es obligatorio" ValidationGroup="vlg1" InitialValue="0" Display="Dynamic"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="ddlEstado" runat="server"  CssClass="lista" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Ciudad: </td>
                    <td>
                        <asp:DropDownList ID="ddlCiudad" runat="server"  CssClass="lista"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Materias: </td>
                    <td>
                        <asp:ListBox ID="ListBoxMaterias" SelectionMode="Multiple" CssClass="lista" Width="150px" runat="server"></asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click" ValidationGroup="vlg1" />
                    </td>
                </tr>
            </table>

        </ContentTemplate>

    </asp:UpdatePanel>
   
    <script type="text/javascript">

        $(document).ready(function () {

            $("#MainContent_TextFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2010",
                dateFormat: "dd-mm-yy"
            });

            $(".lista").chosen();

        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();
        manager.add_endRequest(function () {

            $("#MainContent_TextFechaCreacion").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: "1900:2010",
                dateFormat: "dd-mm-yy"
            });

            $(".lista").chosen();

        });


    </script>

</asp:Content>
