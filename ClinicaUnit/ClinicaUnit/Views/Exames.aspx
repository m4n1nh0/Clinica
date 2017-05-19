<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Exames.aspx.cs" Inherits="ClinicaUnit.Views.Exames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" DefaultMode="Edit" DataKeyNames="id_paciente,id_exame,dtexame" Width="100%" runat="server" DataSourceID="ObjectDataSource1CadReqExame">
        <EditItemTemplate>
            <h2 class="form-signin-heading">Editar Requisição de Exames</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Paciente</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="PACIENTE" CssClass="form-control" Enabled="false" runat="server" SelectedValue='<%# Bind("Id_paciente") %>' DataSourceID="ObjectDataSourceSelectPaciente" DataTextField="nome" DataValueField="id">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectPaciente" SelectMethod="ListarPaciente" TypeName="ClinicaUnit.Models.PacienteDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                            <asp:Parameter Name="cidade" Type="String"></asp:Parameter>
                            <asp:Parameter Name="endereco" Type="String"></asp:Parameter>
                            <asp:Parameter Name="uf" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="EXAME" class="col-sm-2 control-label">Exame</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="EXAME" CssClass="form-control" runat="server" Enabled="false" SelectedValue='<%# Bind("Id_exame") %>' DataSourceID="ObjectDataSourceSelectExame" DataTextField="Nome1" DataValueField="Id1">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectExame" SelectMethod="ListarExame" TypeName="ClinicaUnit.Models.ExameDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DATA" class="col-sm-2 control-label">Data</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="DATA" TextMode="DateTime" ReadOnly="true" Text='<%# Bind("dtexameup") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label class="col-sm-2 control-label">Observação</label>
                <asp:RadioButtonList ID="SITUACAO" runat="server" SelectedValue='<%# Bind("tipo") %>' RepeatDirection="Horizontal" OnSelectedIndexChanged="SITUACAO_SelectedIndexChanged">
                    <asp:ListItem Value="P" Text="Particular"></asp:ListItem>
                    <asp:ListItem Value="C" Text="Convênio"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="VAL" class="col-sm-2 control-label">Valor</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="VAL" TextMode="SingleLine" Text='<%# Bind("valor") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="CONVENIO" class="col-sm-2 control-label">Convênio</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="CONVENIO" SelectedValue='<%# Bind("convenio") %>' CssClass="form-control" runat="server" DataSourceID="ObjectDataSourceSelectConvenio" DataTextField="nome" DataValueField="id" AppendDataBoundItems="True">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectConvenio" SelectMethod="ListarConveio" TypeName="ClinicaUnit.Models.ConvenioDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nomeConv" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Sigla" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnEditar" CssClass="btn btn-success" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastar Requisição de Exames</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Paciente</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="PACIENTE" CssClass="form-control" runat="server" SelectedValue='<%# Bind("Id_paciente") %>' DataSourceID="ObjectDataSourceSelectPaciente" DataTextField="nome" DataValueField="id">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectPaciente" SelectMethod="ListarPaciente" TypeName="ClinicaUnit.Models.PacienteDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                            <asp:Parameter Name="cidade" Type="String"></asp:Parameter>
                            <asp:Parameter Name="endereco" Type="String"></asp:Parameter>
                            <asp:Parameter Name="uf" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="EXAME" class="col-sm-2 control-label">Exame</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="EXAME" CssClass="form-control" runat="server" SelectedValue='<%# Bind("Id_exame") %>' DataSourceID="ObjectDataSourceSelectExame" DataTextField="Nome1" DataValueField="Id1">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectExame" SelectMethod="ListarExame" TypeName="ClinicaUnit.Models.ExameDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nome" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DATA" class="col-sm-2 control-label">Data</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="DATA" TextMode="Date" Text='<%# Bind("dtexame") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label class="col-sm-2 control-label">Observação</label>
                <asp:RadioButtonList ID="SITUACAO" runat="server" SelectedValue='<%# Bind("tipo") %>' RepeatDirection="Horizontal">
                    <asp:ListItem Value="P" Text="Particular"></asp:ListItem>
                    <asp:ListItem Value="C" Text="Convênio"></asp:ListItem>
                </asp:RadioButtonList>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="VAL" class="col-sm-2 control-label">Valor</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="VAL" TextMode="Number" Text='<%# Bind("valor") %>'></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="CONVENIO" class="col-sm-2 control-label">Convênio</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="CONVENIO" SelectedValue='<%# Bind("convenio") %>' CssClass="form-control" runat="server" DataSourceID="ObjectDataSourceSelectConvenio" DataTextField="nome" DataValueField="id" AppendDataBoundItems="True">
                        <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                    </asp:DropDownList>
                    <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelectConvenio" SelectMethod="ListarConveio" TypeName="ClinicaUnit.Models.ConvenioDAO">
                        <SelectParameters>
                            <asp:Parameter Name="nomeConv" Type="String"></asp:Parameter>
                            <asp:Parameter Name="Sigla" Type="String"></asp:Parameter>
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnSalvar" CssClass="btn btn-success" CommandName="Insert" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </InsertItemTemplate>
    </asp:FormView>
    <asp:ObjectDataSource runat="server" ID="ObjectDataSource1CadReqExame" DataObjectTypeName="ClinicaUnit.Models.Req_exame" InsertMethod="Insert" SelectMethod="ObterReqExame" TypeName="ClinicaUnit.Models.ReqExameDAO" UpdateMethod="UPDATE">
        <SelectParameters>
            <asp:QueryStringParameter QueryStringField="id_paciente" Name="id_paciente" Type="Int32"></asp:QueryStringParameter>
            <asp:QueryStringParameter QueryStringField="id_exame" Name="id_exame" Type="Int32"></asp:QueryStringParameter>
            <asp:QueryStringParameter QueryStringField="dtexame" Name="dtconsulta" Type="DateTime"></asp:QueryStringParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
