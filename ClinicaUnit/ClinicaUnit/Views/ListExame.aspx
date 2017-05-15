<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListExame.aspx.cs" Inherits="ClinicaUnit.Views.ListExame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Exames</h2>
    <asp:Label runat="server" class="col-sm-1 control-label">NOME: </asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxNOME"></asp:TextBox>
    </asp:Panel>
    <asp:Button runat="server" CssClass="btn btn-default" Text="Filtrar" />
    <p />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" DataKeyNames="Id1" GridLines="None" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceListExame">
        <Columns>
            <asp:BoundField DataField="Id1" HeaderText="ID" SortExpression="Id1"></asp:BoundField>
            <asp:BoundField DataField="Nome1" HeaderText="Nome" SortExpression="Nome1"></asp:BoundField>
            <asp:BoundField DataField="Obs1" HeaderText="Observação" SortExpression="Obs1"></asp:BoundField>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" CssClass="btn btn-default" runat="server" PostBackUrl='<%# string.Format("~/Views/CadExame.aspx?ID1={0}", Eval("ID1")) %>'>Editar</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2" CssClass="btn btn-danger" runat="server" CommandName="Delete">Deletar</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceListExame" DataObjectTypeName="ClinicaUnit.Models.Exame" DeleteMethod="Delete" SelectMethod="ListarExame" TypeName="ClinicaUnit.Models.ExameDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbxNOME" PropertyName="Text" Name="nome" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
