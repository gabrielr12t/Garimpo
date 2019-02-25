<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="SobreNos.aspx.cs" Inherits="Paginas_TESTEEEE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <br />
    <h2>Exemplos de coisas legais</h2>
    <div class="accordion" id="accordion2">
        <div class="accordion-group">

            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapseOne">O que é o Garimpo
                </a>
            </div>

            <div id="collapseOne" class="accordion-body collapse in">
                <div class="accordion-inner">
                    O Garimpo é um ..............
                </div>
            </div>

        </div>

        <div class="accordion-group">
            <div class="accordion-heading">
                <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo">Como Funciona o Garimpo? ...................
                </a>
            </div>

            <div id="collapseTwo" class="accordion-body collapse">
                <div class="accordion-inner">
                    Qualquer pessoa pode vender.........
                </div>
            </div>

        </div>
    </div>

    <div class="btn-group" data-toggle="buttons-radio">
        <button type="button" class="btn btn-primary">Left</button>
        <button type="button" class="btn btn-primary">Middle</button>
        <button type="button" class="btn btn-primary">Right</button>

    </div>
    <!-- Button to trigger modal -->
    <a href="#myModal" role="button" class="btn" data-toggle="modal">Ver a modal</a>

    <!-- Modal -->
    <div id="myModal" class="modal hide fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">×</button>
            <h3 id="myModalLabel">Exemplo Modal </h3>
        </div>
        <div class="modal-body">
            <p>Podemos utilizar para algo no futuro</p>
        </div>
        <div class="modal-footer">
            <button class="btn" data-dismiss="modal" aria-hidden="true">Fechar</button>
            <button class="botao">Salvar</button>
        </div>

    </div>
    <br />

    <div class="alert alert-block">
        <button type="button" class="close" data-dismiss="alert">&times;</button>
        <h4>Warning!</h4>
        Best check yo self, you're not...
    </div>

    <address>
        <strong>Twitter, Inc.</strong><br>
        795 Folsom Ave, Suite 600<br>
        San Francisco, CA 94107<br>
        <abbr title="Phone">P:</abbr>
        (123) 456-7890
    </address>

    <address>
        <strong>Full Name</strong><br>
        <a href="mailto:#">first.last@example.com</a>
    </address>
</asp:Content>

