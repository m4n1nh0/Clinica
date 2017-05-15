<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="CadConvenio.aspx.cs" Inherits="ClinicaUnit.Views.CadConvenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >
    <asp:FormView ID="Cadastro" Width="100%" runat="server" DataKeyNames="ID" DefaultMode="Edit" DataSourceID="ObjectDataSourceConvenio">
        <EditItemTemplate>
            <h2 class="form-signin-heading">Editar de Convênio</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                </asp:Panel>
                <label for="SIGLA" class="col-sm-2 control-label">SIGLA</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="SIGLA" CssClass="form-control" MaxLength="50" Text='<%# Bind("sigla") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="TELEFONE" class="col-sm-2 control-label">Telefone</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="TELEFONE" CssClass="form-control" MaxLength="20" TextMode="Phone" Text='<%# Bind("telefone") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnEditar" CssClass="btn btn-success" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastro de Convênio</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="NOME" class="col-sm-2 control-label">Nome</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="NOME" CssClass="form-control" MaxLength="50" TextMode="SingleLine" Text='<%# Bind("nome") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvNome" SetFocusOnError="true"  ControlToValidate="NOME" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:Panel>
                <label for="SIGLA" class="col-sm-2 control-label">SIGLA</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="SIGLA" CssClass="form-control" MaxLength="50" Text='<%# Bind("sigla") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvSigla" SetFocusOnError="true"  ControlToValidate="SIGLA" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="TELEFONE" class="col-sm-2 control-label">Telefone</label>
                <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:TextBox runat="server" ID="TELEFONE" CssClass="form-control" MaxLength="20" TextMode="Phone" Text='<%# Bind("telefone") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ID="rfvTel" SetFocusOnError="true"  ControlToValidate="TELEFONE" ErrorMessage="*Campo Obrigatorio!" ToolTip="Campo Obrigatorio!" ForeColor="Red"></asp:RequiredFieldValidator>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success" CommandName="Insert" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceConvenio" DataObjectTypeName="ClinicaUnit.Models.Convenio" InsertMethod="Insert" SelectMethod="ObterConvenio" TypeName="ClinicaUnit.Models.ConvenioDAO" UpdateMethod="UPDATE">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="ID" Name="id_convenio" Type="Int32"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
