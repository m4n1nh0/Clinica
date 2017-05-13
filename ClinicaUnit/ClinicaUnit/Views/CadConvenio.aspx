<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadConvenio.aspx.cs" Inherits="ClinicaUnit.Views.CadConvenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" DefaultMode="Insert" Width="100%" runat="server">
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastro de Convênio</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine"></asp:TextBox>
                </asp:Panel>
                <label for="SIGLA" class="col-sm-2 control-label">SIGLA</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="SIGLA" CssClass="form-control" MaxLength="50"></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="TELEFONE" class="col-sm-2 control-label">Telefone</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="TELEFONE" CssClass="form-control" MaxLength="20" TextMode="Phone"></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success" CommandName="Insert" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
</asp:Content>
