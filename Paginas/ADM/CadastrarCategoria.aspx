﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="CadastrarCategoria.aspx.cs" Inherits="Paginas_ADM_CadastrarCategoriaSubcategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div id="collapseOne" class="accordion-body in collapse">
        <div class="accordion-inner">
            <div class="row-fluid">

                <asp:Panel ID="pnlCategoria" DefaultButton="btnCadastrar" runat="server">
                    <div class="span9 pull-right">
                        <h4 class="title"><span class="text"><strong>Cadastrar Categorias</strong></span></h4>

                        <label class="control-label">Selecione um Estilo: </label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-upload "></i></span>
                                <asp:DropDownList ID="ddlEstilo" CssClass="input-medium" runat="server" OnSelectedIndexChanged="ddlEstilo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <label class="control-label">Categoria: </label>
                        <div class="controls">
                            <div class="input-prepend">
                                <span class="add-on"><i class="icon-upload "></i></span>
                                <asp:TextBox ID="txtCategoria" runat="server" CssClass="input-medium" placeholder="Digite a categoria" type="text"></asp:TextBox>
                            </div>
                        </div>
                        <div class="actions">
                            <asp:Button ID="btnCadastrar" CssClass="i2Style i2Style:active " runat="server" Text="Cadastrar" OnClick="btnCadastrar_Click" /><br />
                            <br />
                            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
                        </div>
                    </div>
                </asp:Panel>


                <%--Grid de Categorias cadastradas--%>
                <div class="span11 center">
                    <asp:GridView ID="gridCategoria" runat="server" CssClass="table" AutoGenerateColumns="False" CellPadding="3" DataKeyNames="cat_codigo" GridLines="Horizontal" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px">
                        <AlternatingRowStyle BackColor="#F7F7F7" />
                        <Columns>
                            <asp:BoundField DataField="cat_nome" HeaderText="Categorias" />
                        </Columns>
                        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <PagerStyle ForeColor="#4A3C8C" HorizontalAlign="Right" BackColor="#E7E7FF" />
                        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                        <SortedAscendingCellStyle BackColor="#F4F4FD" />
                        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                        <SortedDescendingCellStyle BackColor="#D8D8F0" />
                        <SortedDescendingHeaderStyle BackColor="#3E3277" />
                    </asp:GridView>
                </div>

                <%--////////////////--%>
            </div>
            <asp:Label ID="lblQuantidade" runat="server"></asp:Label>
        </div>
    </div>


</asp:Content>

