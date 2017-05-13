<%@ Page Title="" Language="C#" MasterPageFile="~/Views/MasterPage.Master" AutoEventWireup="true" CodeBehind="Consultas.aspx.cs" Inherits="ClinicaUnit.Views.Consultas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:FormView ID="Cadastro" DefaultMode="Insert" Width="100%" runat="server">
        <InsertItemTemplate>
            <h2 class="form-signin-heading">Cadastro de Consultas</h2>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Paciente</label>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:DropDownList ID="ESTADO" CssClass="form-control" runat="server">

                    </asp:DropDownList>                
              </asp:Panel>  
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="SERGE" class="col-sm-2 control-label">Convênio</label>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" CssClass="form-control" runat="server">

                    </asp:DropDownList>                
              </asp:Panel>  
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="PACIENTE" class="col-sm-2 control-label">Médico</label>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:Panel runat="server" CssClass="col-sm-4">
                    <asp:DropDownList ID="DropDownList2" CssClass="form-control" runat="server">

                    </asp:DropDownList>                
              </asp:Panel>  
              </asp:Panel>
            </asp:Panel>
            <asp:Panel CssClass="form-group" runat="server">
                <label for="OBS" class="col-sm-2 control-label">Observação</label>
                <asp:Panel runat="server" CssClass="col-sm-6">
                    <asp:TextBox TextMode="MultiLine" runat="server" ID="OBS" CssClass="form-control" MaxLength="300"></asp:TextBox>
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
