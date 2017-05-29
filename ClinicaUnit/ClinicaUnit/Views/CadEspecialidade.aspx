<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadEspecialidade.aspx.cs" Inherits="ClinicaUnit.Views.CadEspecialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" Width="100%" runat="server" DataKeyNames="ID" DefaultMode="Edit" DataSourceID="ObjectDataSource1">
        <EditItemTemplate>
            <h2 class="form-signin-heading">Editar de Especialidade</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-10">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DESCRI" class="col-sm-2 control-label">Descrição</label>
                <asp:Panel runat="server" CssClass="col-sm-10">
                    <asp:TextBox runat="server" ID="DESCRI" CssClass="form-control" MaxLength="500" TextMode="MultiLine" Text='<%# Bind("descri") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnEditar" CssClass="btn btn-success" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastro de Especialidade</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-10">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DESCRI" class="col-sm-2 control-label">Descrição</label>
                <asp:Panel runat="server" CssClass="col-sm-10">
                    <asp:TextBox runat="server" ID="DESCRI" CssClass="form-control" MaxLength="500" TextMode="MultiLine" Text='<%# Bind("descri") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success" CommandName="Insert" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1" DataObjectTypeName="ClinicaUnit.Models.Especialidade" InsertMethod="Insert" SelectMethod="ObterEspeci" TypeName="ClinicaUnit.Models.EspecialidadeDAO" UpdateMethod="UPDATE">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="ID" Name="id_especi" Type="Int32"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
