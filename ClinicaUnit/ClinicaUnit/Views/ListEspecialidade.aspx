<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListEspecialidade.aspx.cs" Inherits="ClinicaUnit.Views.ListEspecialidade" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Especialidades</h2>
    <asp:Label runat="server" class="col-sm-1 control-label">NOME: </asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxNOME"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-1 control-label">DESCRIÇÃO:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-4">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxDescri"></asp:TextBox>
    </asp:Panel>
    <asp:Button runat="server" CssClass="btn btn-default" Text="Filtrar" />
    <p />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" DataKeyNames="id" GridLines="None" AutoGenerateColumns="False" DataSourceID="ObjectDataSourceListEspeci">
        <Columns>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id"></asp:BoundField>
            <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome"></asp:BoundField>
            <asp:BoundField DataField="descri" HeaderText="descri" SortExpression="descri"></asp:BoundField>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-default" runat="server" PostBackUrl='<%# string.Format("~/Views/CadEspecialidade.aspx?ID={0}", Eval("ID")) %>'>Editar</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" CommandName="Delete">Deletar</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceListEspeci" SelectMethod="ListarEspeci" DeleteMethod="Delete" TypeName="ClinicaUnit.Models.EspecialidadeDAO" DataObjectTypeName="ClinicaUnit.Models.Especialidade">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbxNOME" PropertyName="Text" Name="nome" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxDescri" PropertyName="Text" Name="Descri" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>
