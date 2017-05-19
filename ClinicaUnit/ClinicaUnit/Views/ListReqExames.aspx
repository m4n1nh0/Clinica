<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="ListReqExames.aspx.cs" Inherits="ClinicaUnit.Views.ListReqExames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Lista de Requisições de Exames</h2>
    <asp:Label runat="server" class="col-sm-2 control-label">Nome Paciente: </asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-10">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxNOME"></asp:TextBox>
    </asp:Panel><br />
    <asp:Label runat="server" class="col-sm-2 control-label">Exame:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-10">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxExame"></asp:TextBox>
    </asp:Panel>
    <asp:Label runat="server" class="col-sm-2 control-label">Data:</asp:Label>
    <asp:Panel runat="server" CssClass="col-sm-2">
        <asp:TextBox runat="server" CssClass="form-control" ID="tbxData" TextMode="Date"></asp:TextBox>
    </asp:Panel>
    <asp:Panel runat="server" CssClass="text-center col-sm-1">
        <asp:Button runat="server" CssClass="btn btn-default" Text="Filtrar" />
    </asp:Panel>
    <p />
    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped" AutoGenerateColumns="False" DataKeyNames="id_paciente,id_exame,dtexame" GridLines="None"   DataSourceID="ObjectDataSourceListReqExame">
        <Columns>
            <asp:BoundField DataField="id_paciente" HeaderText="Cod. Paciente" SortExpression="id_paciente"></asp:BoundField>
            <asp:BoundField DataField="nomePaci" HeaderText="Paciente" SortExpression="nomePaci"></asp:BoundField>
            <asp:BoundField DataField="id_exame" HeaderText="Cod. Exame" SortExpression="id_exame"></asp:BoundField>
            <asp:BoundField DataField="nomeExame" HeaderText="Exame" SortExpression="nomeExame"></asp:BoundField>
            <asp:BoundField DataField="dtexame" HeaderText="Data Exame" SortExpression="dtexame"></asp:BoundField>
            <asp:BoundField DataField="tipo" HeaderText="Tipo" SortExpression="tipo"></asp:BoundField>
            <asp:BoundField DataField="id_convenio" HeaderText="Cod. Convenio" SortExpression="id_convenio"></asp:BoundField>
            <asp:BoundField DataField="nomeConv" HeaderText="Convenio" SortExpression="nomeConv"></asp:BoundField>
            <asp:BoundField DataField="valor" HeaderText="Valor" SortExpression="valor"></asp:BoundField>
            <asp:TemplateField HeaderText="Ações">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1"  CssClass="btn btn-default" runat="server" PostBackUrl='<%# "~/Views/Exames.aspx?ID_PACIENTE="+Eval("ID_PACIENTE")+"&ID_EXAME="+Eval("ID_EXAME")+"&DTEXAME="+Eval("DTEXAME") %>'>Editar</asp:LinkButton>
                    <asp:LinkButton ID="LinkButton2"  CssClass="btn btn-danger" runat="server" CommandName="Delete">Deletar</asp:LinkButton>                    
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceListReqExame" DataObjectTypeName="ClinicaUnit.Models.Req_exame" DeleteMethod="Delete" SelectMethod="ListarReqExame" TypeName="ClinicaUnit.Models.ReqExameDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="tbxData" PropertyName="Text" Name="Data" Type="DateTime"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxNOME" PropertyName="Text" Name="nomePaci" Type="String"></asp:ControlParameter>
            <asp:ControlParameter ControlID="tbxExame" PropertyName="Text" Name="nomeConv" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
