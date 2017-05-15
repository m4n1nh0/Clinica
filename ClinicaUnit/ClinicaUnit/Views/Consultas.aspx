<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ClinicaUnit.Views.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" DefaultMode="Edit" DataKeyNames="ID_p, ID_c, ID_m, DATACON" Width="100%" runat="server">
        <EditItemTemplate>
            <h2 class="form-signin-heading">Editar de Consultas</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Paciente</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="PACIENTE" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="CONVENIO" class="col-sm-2 control-label">Convênio</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="CONVENIO" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                </asp:Panel>  
              </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="MEDICO" class="col-sm-2 control-label">Médico</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="MEDICO" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DATA" class="col-sm-2 control-label">Data</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="DATA" TextMode="Date" ReadOnly="true"></asp:TextBox>
                </asp:Panel>
                <label for="TURNO" class="col-sm-2 control-label">Turno</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:DropDownList ID="TURNO" CssClass="form-control" runat="server">
                        <asp:ListItem>Manhã</asp:ListItem>
                        <asp:ListItem>Tarde</asp:ListItem>
                        <asp:ListItem>Noite</asp:ListItem>
                    </asp:DropDownList>                
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label class="col-sm-2 control-label">Situação</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="AGEND" runat="server" Text="Agendada" CssClass="form-control" GroupName="SIT"/>
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="REALI" runat="server" Text="Realizada"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="CANCE" runat="server" Text="Cancelada"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="RET" runat="server" Text="Retorno"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="MEDI" class="col-sm-2 control-label">Medicamentos</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="MEDI" TextMode="MultiLine"></asp:TextBox>
                </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <asp:Panel runat="server" CssClass="col-sm-12 text-center">
                    <asp:Button runat="server" ID="BtnEditar" CssClass="btn btn-success" CommandName="Update" Text="Salvar"></asp:Button>
                </asp:Panel>
            </asp:Panel>
        </EditItemTemplate>
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastrar de Consultas</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Paciente</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="PACIENTE" CssClass="form-control" runat="server">

                    </asp:DropDownList>                
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="CONVENIO" class="col-sm-2 control-label">Convênio</label>
                    <asp:Panel runat="server" CssClass="col-sm-8">
                        <asp:DropDownList ID="CONVENIO" CssClass="form-control" runat="server" SelectedValue='<%# Bind("id") %>' DataSourceID="ObjectDataSourceSelConvenio" DataTextField="nome" DataValueField="id">
                            <asp:ListItem Value="-1">Selecionar</asp:ListItem>
                        </asp:DropDownList>
                        <asp:ObjectDataSource runat="server" ID="ObjectDataSourceSelConvenio" SelectMethod="ListarConveio" TypeName="ClinicaUnit.Models.ConvenioDAO">
                            <SelectParameters>
                                <asp:Parameter Name="nomeConv" Type="String"></asp:Parameter>
                                <asp:Parameter Name="Sigla" Type="String"></asp:Parameter>
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </asp:Panel>  
              </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="MEDICO" class="col-sm-2 control-label">Médico</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:DropDownList ID="MEDICO" CssClass="form-control" runat="server">

                    </asp:DropDownList>                
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="DATA" class="col-sm-2 control-label">Data</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:TextBox runat="server" CssClass="form-control" ID="DATA" TextMode="Date"></asp:TextBox>
                </asp:Panel>
                <label for="PACIENTE" class="col-sm-2 control-label">Turno</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:DropDownList ID="TURNO" CssClass="form-control" runat="server">
                        <asp:ListItem>Manhã</asp:ListItem>
                        <asp:ListItem>Tarde</asp:ListItem>
                        <asp:ListItem>Noite</asp:ListItem>
                    </asp:DropDownList>                
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label class="col-sm-2 control-label">Situação</label>
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="AGEND" runat="server" Text="Agendada" CssClass="form-control" GroupName="SIT"/>
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="REALI" runat="server" Text="Realizada"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="CANCE" runat="server" Text="Cancelada"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
                <asp:Panel runat="server" CssClass="col-sm-2">
                    <asp:RadioButton ID="RET" runat="server" Text="Retorno"  CssClass="form-control" GroupName="SIT" />
                </asp:Panel> 
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="MEDI" class="col-sm-2 control-label">Medicamentos</label>
                <asp:Panel runat="server" CssClass="col-sm-8">
                    <asp:TextBox runat="server" CssClass="form-control" ID="MEDI" TextMode="MultiLine"></asp:TextBox>
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
