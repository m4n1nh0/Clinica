<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadExame.aspx.cs" Inherits="ClinicaUnit.Views.CadExame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" DefaultMode="Edit" DataKeyNames="ID" Width="100%" runat="server">
        <EditItemTemplate>
            <h2 class="form-signin-heading">Editar de Exame</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="OBS" class="col-sm-2 control-label">Observação</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="OBS" CssClass="form-control" MaxLength="300" Text='<%# Bind("obs") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnEditar" CssClass="btn btn-success" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastro de Exame</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvNome" SetFocusOnError="true"  ControlToValidate="NOME" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="OBS" class="col-sm-2 control-label">Observação</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="OBS" CssClass="form-control" MaxLength="300" Text='<%# Bind("obs") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvOBS" SetFocusOnError="true"  ControlToValidate="OBS" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" ForeColor="Red"></asp:RequiredFieldValidator>
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
