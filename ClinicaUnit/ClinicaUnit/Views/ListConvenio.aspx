<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListConvenio.aspx.cs" Inherits="ClinicaUnit.Views.ListConvenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Convênio</h2>
    <asp:Label runat="server" class="col-sm-1 control-label">NOME: </asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxNOME"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-1 control-label">SIGLA:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxSIGLA"></asp:TextBox>
    </asp:Panel>
    <asp:Button runat="server" CssClass="btn btn-default" Text="Filtrar" />
    <p />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceListConvenio">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="Nome" SortExpression="nome"></asp:BoundField>
            <asp:BoundField DataField="sigla" HeaderText="Sigla" SortExpression="sigla"></asp:BoundField>
            <asp:BoundField DataField="telefone" HeaderText="Telefone" SortExpression="telefone"></asp:BoundField>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-default" runat="server" PostBackUrl='<%# string.Format("~/Views/CadConvenio.aspx?ID={0}", Eval("ID")) %>'>Editar</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" CommandName="Delete">Deletar</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceListConvenio" SelectMethod="ListarConveio" DeleteMethod="Delete" TypeName="ClinicaUnit.Models.ConvenioDAO" DataObjectTypeName="ClinicaUnit.Models.Convenio">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbxNOME" PropertyName="Text" Name="nomeConv" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxSIGLA" PropertyName="Text" Name="Sigla" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
