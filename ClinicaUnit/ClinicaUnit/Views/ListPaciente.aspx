<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListPaciente.aspx.cs" Inherits="ClinicaUnit.Views.ListPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Pacientes</h2>
    <asp:Label runat="server" class="col-sm-2 control-label">Nome: </asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxNOME"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-2 control-label">Cidade:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxCIDADE"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-2 control-label">Endereço:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxEndereco"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-2 control-label">UF:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxUF"></asp:TextBox>
    </asp:Panel>
    <br />    <p />
    <asp:Panel runat="server" CssClass="text-center">
        <asp:Button runat="server" CssClass="btn btn-default" Text="Filtrar" />
    </asp:Panel>
    <p />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="id" GridLines="None"  DataSourceID="ObjectDataSourceListPaciente">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome"></asp:BoundField>
            <asp:BoundField DataField="cpf" HeaderText="CPF" SortExpression="cpf"></asp:BoundField>
            <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone"></asp:BoundField>
            <asp:BoundField DataField="endereco" HeaderText="Endereco" SortExpression="endereco"></asp:BoundField>
            <asp:BoundField DataField="cidade" HeaderText="Cidade" SortExpression="cidade"></asp:BoundField>
            <asp:BoundField DataField="uf" HeaderText="UF" SortExpression="uf"></asp:BoundField>
            <asp:BoundField DataField="plano" HeaderText="Plano" SortExpression="plano"></asp:BoundField>
            <asp:BoundField DataField="sexo" HeaderText="Sexo" SortExpression="sexo"></asp:BoundField>
            <asp:BoundField DataField="dtnaci" HeaderText="Data Nascimento" SortExpression="dtnaci"></asp:BoundField>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-default" runat="server" PostBackUrl='<%# string.Format("~/Views/CadPaciente.aspx?ID={0}", Eval("ID")) %>'>Editar</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" CommandName="Delete">Deletar</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceListPaciente" DataObjectTypeName="ClinicaUnit.Models.Paciente" DeleteMethod="Delete" SelectMethod="ListarPaciente" TypeName="ClinicaUnit.Models.PacienteDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbxNOME" PropertyName="Text" Name="nome" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxCIDADE" PropertyName="Text" Name="cidade" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxEndereco" PropertyName="Text" Name="endereco" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxUF" PropertyName="Text" Name="uf" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
