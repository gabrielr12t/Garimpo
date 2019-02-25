<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="CaixaMensagem.aspx.cs" Inherits="Paginas_Usuário_CaixaMensagem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <style>
        .centralizar {
            margin-left: 20%;
        }


        .linha-vertical {
            height: 100%; /*Altura da linha*/
            border-right: 0.4px solid; /* Adiciona borda esquerda na div como ser fosse uma linha.*/
        }

        .corFundo {
            background-color: #f3f1fa;
        }
    </style>
    <h4 class="title"><span class="text"><strong>Caixa de mensagem</strong></span></h4>


    
    <%--AQUI COMEÇA A BRINCADEIRA--%>


   
   <table class="table">
        <thead>
            <tr>
               <%-- <th></th>
                <th>Tipo da Mensagem</th>
                <th>Conteúdo</th>
                <th>data</th>
                <th>Remover</th>--%>
                <asp:Literal ID="ltlThMensagem" runat="server"></asp:Literal>
            </tr>
        </thead>
        <tbody>
            <asp:Literal ID="lblDinamica" runat="server"></asp:Literal>
        </tbody>
    </table>

   <div class="pagination pagination-centered">
            <ul>
                <%--<li><a href="#">Ant</a></li>
                <li class="active"><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">Próx</a></li>--%>
                <asp:Literal ID="ltlPag" runat="server"></asp:Literal>
            </ul>
   </div>

     












    <%--------MODAL VISUALIZAR MENSAGEM ----------------%>
    <div class="modal hide fade" id="modalMensagem">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>Mensagem</h3>
        </div>
        <div class="modal-body">
            <asp:TextBox ID="txtConteudoVisualizar" CssClass="textbox" ReadOnly="true" Width="96%" Font-Size="Large" TextMode="MultiLine" Rows="4" runat="server" ClientIDMode="Static"></asp:TextBox><br />
            <asp:Label ID="lblMensagemRespondida" runat="server"></asp:Label>
        </div>
    </div>

    <div id="modalResponder" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">Responder mensagem</h3>
        </div>
        <div class="modal-body center">
            <strong>Pergunta: </strong>
            <br />
            <asp:TextBox ID="txtConteudo" CssClass="input-xlarge" ReadOnly="true" runat="server" ClientIDMode="Static"></asp:TextBox><br />
            <strong>Resposta: </strong>
            <br />
            <asp:TextBox ID="txtResposta" CssClass="input-xlarge" runat="server"></asp:TextBox><br />
            <asp:RequiredFieldValidator ID="cvNome" ValidationGroup="cadastroRapido" ErrorMessage="Campo obrigatório" ControlToValidate="txtResposta" Display="Dynamic" ForeColor="red" runat="server"></asp:RequiredFieldValidator>
            <asp:Button ID="btnEnv" Text="Enviar" CssClass="i2Style i2Style:active" runat="server" OnClick="btnEnv_Click" />
            <asp:HiddenField ID="txtCodigo" runat="server" ClientIDMode="Static"></asp:HiddenField>
            <asp:HiddenField ID="txtUsuCpf" runat="server" ClientIDMode="Static"></asp:HiddenField>
            <asp:HiddenField ID="txtCpfPergunta" runat="server" ClientIDMode="Static"></asp:HiddenField>
            <asp:HiddenField ID="txtPerguntaCodigo" runat="server" ClientIDMode="Static"></asp:HiddenField>
            <asp:HiddenField ID="txtCodigoProduto" runat="server" ClientIDMode="Static"></asp:HiddenField>
        </div>
        <div class="modal-footer">
            <button class="botao " data-dismiss="modal" aria-hidden="true">cancelar</button>
        </div>
    </div>

    <script type="text/javascript">     

        //exlcuir mensagem
        $(".excluirMensagem").click(function () {
            var cod = $(this).attr("id");
            $.ajax({
                type: 'POST',
                url: 'CaixaMensagem.aspx/Exclui',
                data: JSON.stringify({
                    'cod': cod
                }),
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',
                success: function (r) {
                    if (r.d == "s") {
                        location.reload();
                    }
                    else
                        alert("Não foi possível atualizar este produto");
                }
            });
        });//----------

        $(".responder").click(function () {
            $("#modalResponder").modal("show");
            var dados = $(this).attr("rel").split("|");
            $("#txtCodigo").val(dados[0]);
            $("#txtConteudo").val(dados[1]);
            $("#txtUsuCpf").val(dados[2]);
            $("#txtCpfPergunta").val(dados[3]);
            $("#txtPerguntaCodigo").val(dados[4]);
            $("#txtCodigoProduto").val(dados[5]);
        });
    </script>

    <script type="text/javascript">
        $(".visualizar").click(function () {
            $("#modalMensagem").modal("show");
            var dados = $(this).attr("rel").split("|");
            $("#txtCodigoVisualizar").val(dados[0]);
            $("#txtConteudoVisualizar").val(dados[1]);
            $("#txtMensagemRespondida").val(dados[3]);
        });
    </script>

    <script type="text/javascript">            
        $(document).ready(function () {
            $('[data-toogle="tooltip"]').tooltip();
        });
    </script>

    <%---------------------------------------------------------%>
</asp:Content>

