<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="CadastroProdutoNovo.aspx.cs" Inherits="Paginas_Produtos_CadastroProdutoNovo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $(document).ready(function () {
            $('.telefone').mask('(99) 9999-9999');
            $('.data').mask('99/99/9999');
            $('.cep').mask('99999-999');
            $(".preco").maskMoney({ prefix: 'R$ ', allowNegative: false, thousands: '.', decimal: ',', affixesStay: false });
        });


        function concluir() {
            swal("Para vender é obrigatório ter completado o dadastro e possuir um endereço!!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = '/Paginas/Cadastro/ConcluirCadastro.aspx';
            }, 2000);
        }
    </script>
    <style>
        .textbox {
            border-radius: 3px !important;
        }

        .botaonovo {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
            color: #ffffff;
            padding: 10px 20px;
            background: -moz-linear-gradient( top, #bf20bf 0%, #bf20bf);
            background: -webkit-gradient( linear, left top, left bottom, from(#bf20bf), to(#bf20bf));
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            border-radius: 10px;
            border: 2px solid #d17dc4;
            -moz-box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            -webkit-box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            box-shadow: 0px 1px 3px rgba(000,000,000,1), inset 0px 0px 3px rgba(219,40,219,0.2);
            text-shadow: 0px -1px 0px rgba(209,157,209,0.2), 0px 1px 0px rgba(255,255,255,1);
        }

        .swal-overlay {
            background-color: rgba(75, 62, 110,0.45);
        }
    </style>

    <h4 class="title">Informações<strong> para cadastrar seu produto</strong></h4>
    <br />

    <h4><strong class="text-center">Informe o tipo de produto que você deseja vender</strong></h4>
    <div class="col-md-12">
        <asp:RadioButtonList ID="rbtOpcoes" CssClass="rbt radio" AutoPostBack="true" RepeatDirection="Horizontal" runat="server" Width="1000px" OnSelectedIndexChanged="rbtOpcoes_SelectedIndexChanged" Font-Size="Large">
            <asp:ListItem Value="Roupas"> Roupas </asp:ListItem>
            <asp:ListItem Value="Calcados"> Calçados </asp:ListItem>
            <asp:ListItem> Bijoterias </asp:ListItem>
            <asp:ListItem> Acessórios </asp:ListItem>
            <asp:ListItem> Cosméticos </asp:ListItem>
            <asp:ListItem> Bolsas </asp:ListItem>
            <asp:ListItem> Pessoal </asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
    <br />

    <asp:Panel ID="pnl2" Visible="false" runat="server">
        <h4><strong class="text-center">É uma calça ou derivado ou camisa e derivado?</strong></h4>
        <div class="col-md-12">
            <asp:RadioButtonList ID="rbtRoupas" CssClass="rbt radio" AutoPostBack="true" OnTextChanged="rbtRoupas_TextChanged" RepeatDirection="Horizontal" runat="server" Width="300" OnSelectedIndexChanged="rbtOpcoes_SelectedIndexChanged" Font-Size="Large">
                <asp:ListItem Value="Camisas">Camisas e afins</asp:ListItem>
                <asp:ListItem Value="Calcas">Calças e afins</asp:ListItem>
            </asp:RadioButtonList>
        </div>
    </asp:Panel>

    <br />
    <br />
    <h4 class="title"><strong></strong></h4>
    <div class="row">

        <asp:Panel ID="pnlGeral" Visible="false" DefaultButton="btnFinalizar" runat="server">
            <div class="container">
                <div class="col-md-4">
                    <div class="control-group">
                        Nome: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:TextBox ID="txtNome" runat="server" MaxLength="26" CssClass="input-xlarge textbox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group">
                        Descriçao: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:TextBox ID="txtDescricao" MaxLength="50" CssClass="input-xlarge textbox" TextMode="MultiLine" runat="server" Rows="2"></asp:TextBox><br />                            
                        </div>                                               
                    </div>
                    <div class="control-group">
                        Preço: <a class="obrigatorio">*</a>
                        <div class="control">
                            <asp:TextBox ID="txtPreco" CssClass="span2 textbox preco" runat="server"></asp:TextBox>
                        </div>
                        <%--<asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ControlToValidate="txtPreco" ErrorMessage="Data inválida" Display="Dynamic" ForeColor="Red" ValidationExpression="^\d+?(.|,\d+)$"></asp:RegularExpressionValidator>--%>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="control-group">
                        Marca: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:DropDownList ID="ddlMarca" CssClass="dropdown textbox span2" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <asp:Panel ID="pnlMarca" DefaultButton="btnMarca" runat="server">
                        <div class="control-group">
                            Não encontrou a marca? <a style="color: red">adicione aqui</a>
                            <div class="controls">
                                <asp:TextBox ID="txtMarca" CssClass="input-xlarge textbox" runat="server"></asp:TextBox>
                            </div>
                            <div class="controls">
                                <asp:Button ID="btnMarca" ValidationGroup="cadastro" runat="server" Text="Adicionar" OnClick="btnMarca_Click" CssClass="botaonovo" />
                            </div>
                            <div class="controls">
                                <asp:Label ID="lblMarca" runat="server"></asp:Label>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="updPanel" runat="server">
                    <ContentTemplate>
                        <div class="col-md-3">
                            <div class="control-group">
                                Estilo: <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlEstilo" OnTextChanged="ddlEstilo_TextChanged" CssClass="dropdown textbox span2" AutoPostBack="true" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                Categoria: <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlCategoria" OnTextChanged="ddlCategoria_TextChanged" CssClass="dropdown textbox span2" AutoPostBack="true" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="control-group">
                                SubCategoria: <a class="obrigatorio">*</a>
                                <div class="controls">
                                    <asp:DropDownList ID="ddlSubcategoria" CssClass="dropdown textbox span2" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>


                <h4 class="title" style="margin-left: 15px"><strong></strong></h4>
                <div class="col-md-4">
                    <div class="control-group">
                        Condição: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:DropDownList ID="ddlCondicao" CssClass="dropdown textbox span2" runat="server">
                                <asp:ListItem Value="novo">Novo</asp:ListItem>
                                <asp:ListItem Value="semi-novo">Semi-Novo</asp:ListItem>
                                <asp:ListItem Value="usado">Usado</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="control-group">
                        Quantidade: <a class="obrigatorio">*</a>
                        <div class="controls">
                            <asp:DropDownList ID="ddlQuantidade" CssClass="dropdown textbox span2" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                    <div class="control-group">
                        <asp:Label ID="lblCor" runat="server">Cores:<a class="obrigatorio">*</a></asp:Label>
                        <div class="controls">
                            <fieldset>
                                <asp:CheckBoxList ID="cblCor" runat="server" RepeatColumns="3" Width="200px"></asp:CheckBoxList>
                            </fieldset>
                            &nbsp;                                                                     
                        </div>
                    </div>
                    <%--  <div class="control-group">
                         <asp:Label ID="lblCor" runat="server">Cores:<a class="obrigatorio">*</a></asp:Label><br />
                        <asp:Repeater ID="gridCor"  runat="server" >
                            <ItemTemplate>
                                <img src='<%# Eval("cor_imagem") %>' alt="" style="border: 0.6px groove" class="img-circle" width="10%" height="10%" />
                                <asp:CheckBoxList ID="cblCor" CommandName="comando" runat="server" CommandArgument='<%#Eval("cor_codigo") %>'  >
                                   
                                </asp:CheckBoxList>                                
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>--%>

                    <div class="control-group">
                        Fotos do seu produto<a class="obrigatorio">*</a>
                        <div class="controls">
                            <img src="../../themes/icones/Camera_Next_30014.png" style="width: 50px; height: 50px" />
                            <asp:FileUpload ID="img1" runat="server" ForeColor="219,40,219" AllowMultiple="true" /><br />
                        </div>                        
                    </div>
                </div>

                <asp:Panel ID="pnlCamisa" Visible="false" runat="server">
                    <div class="col-md-3">
                        <div class="control-group">
                            Tamanho: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlTamanhoCamisas" CssClass="dropdown textbox span2" runat="server">
                                    <asp:ListItem Value="PP">PP</asp:ListItem>
                                    <asp:ListItem Value="P">P</asp:ListItem>
                                    <asp:ListItem Value="M">M</asp:ListItem>
                                    <asp:ListItem Value="G">G</asp:ListItem>
                                    <asp:ListItem Value="GG">GG</asp:ListItem>
                                    <asp:ListItem Value="XG">XG</asp:ListItem>
                                    <asp:ListItem Value="XGG">XGG</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlCalcado" Visible="false" runat="server">
                    <div class="col-md-3">
                        <div class="control-group">
                            Tamanho: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlTamanhoCalcado" CssClass="dropdown textbox span2" runat="server">
                                    <asp:ListItem Value="35">35</asp:ListItem>
                                    <asp:ListItem Value="36">36</asp:ListItem>
                                    <asp:ListItem Value="37">37</asp:ListItem>
                                    <asp:ListItem Value="38">38</asp:ListItem>
                                    <asp:ListItem Value="39">39</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                    <asp:ListItem Value="41">41</asp:ListItem>
                                    <asp:ListItem Value="42">42</asp:ListItem>
                                    <asp:ListItem Value="43">43</asp:ListItem>
                                    <asp:ListItem Value="44">44</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlCalcas" Visible="false" runat="server">
                    <div class="col-md-3">
                        <div class="control-group">
                            Tamanho: <a class="obrigatorio">*</a>
                            <div class="controls">
                                <asp:DropDownList ID="ddlTamanhoCalcas" CssClass="dropdown textbox span2" runat="server">
                                    <asp:ListItem Value="36">36</asp:ListItem>
                                    <asp:ListItem Value="38">38</asp:ListItem>
                                    <asp:ListItem Value="40">40</asp:ListItem>
                                    <asp:ListItem Value="42">42</asp:ListItem>
                                    <asp:ListItem Value="44">44</asp:ListItem>
                                    <asp:ListItem Value="46">46</asp:ListItem>
                                    <asp:ListItem Value="48">48</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <div class="col-md-3">
                    <div class="control-group">
                        <asp:Label ID="lblEnvio" runat="server">Como você pode enviar?:<a class="obrigatorio">*</a></asp:Label>
                        <div class="controls">
                            <fieldset>
                                <asp:CheckBoxList ID="cblEnvios" runat="server" RepeatColumns="3" Width="200px"></asp:CheckBoxList>
                            </fieldset>
                            &nbsp;                                                                     
                        </div>
                    </div>
                </div>

                <div class="col-md-3">
                    <div class="control-group">
                        <div class="controls">
                            <asp:Button ID="btnFinalizar" Text="Finalizar" CssClass="botaonovo" runat="server" OnClick="btnFinalizar_Click" />
                        </div>
                    </div>
                    <div class="control-group">
                        <div class="controls">
                            <asp:Label ID="lblRetorno" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
    </div>

    <script type="text/javascript">
        function Confirma() {
            swal("Produto Cadastrado!!", {
                icon: "success",
                buttons: {
                    // cancel: "Run away!",
                    catch: {
                        text: "Ok",
                        value: "ok",
                    },
                },
            })
                .then((value) => {
                    switch (value) {
                        case "ok":
                            swal("Você receberá uma mensagem quando seu produto for aprovado!", {
                                button: false,
                            });
                            setTimeout(function () {
                                window.location.href = '/Paginas/Index.aspx';
                            }, 2300);
                            break;
                        default:
                            //swal("Você receberá uma mensagem quando seu produto for aprovado!", {
                            //    button: false,
                            //});
                            //setTimeout(function () {
                            window.location.href = '/Paginas/Index.aspx';
                            //}, 2300);
                    }
                });
        }
    </script>
</asp:Content>

