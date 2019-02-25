<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterADM.master" AutoEventWireup="true" CodeFile="ModerarUsuarios.aspx.cs" Inherits="Paginas_ADM_ModerarUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script src="../../../themes/js/jquery-1.7.2.min.js"></script>
    <script src="../../../bootstrap/js/bootstrap.js"></script>

    <style>
        .switch {
            position: relative;
            display: inline-block;
            width: 60px;
            height: 34px;
        }

            .switch input {
                display: none;
            }

        .slider {
            position: absolute;
            cursor: pointer;
            top: 0;
            left: 0;
            right: 0;
            bottom: 0;
            background-color: #ccc;
            -webkit-transition: .4s;
            transition: .4s;
        }

            .slider:before {
                position: absolute;
                content: "";
                height: 26px;
                width: 26px;
                left: 4px;
                bottom: 4px;
                background-color: white;
                -webkit-transition: .4s;
                transition: .4s;
            }

        input:checked + .slider {
            background-color: #af58dd;
        }

        input:focus + .slider {
            box-shadow: 0 0 1px #af58dd;
        }

        input:checked + .slider:before {
            -webkit-transform: translateX(26px);
            -ms-transform: translateX(26px);
            transform: translateX(26px);
        }

        /* Rounded sliders */
        .slider.round {
            border-radius: 34px;
        }

            .slider.round:before {
                border-radius: 50%;
            }
    </style>



    <div class="row">

        <div class="span8">
            <div>
                <br />
                <asp:TextBox ID="txtBuscar" class="textbox input-xxlarge" placeholder="Pequisa por nome" runat="server"></asp:TextBox>
            </div>
            <asp:Panel ID="Panel1" DefaultButton="btnNomes" runat="server">
                <asp:Button ID="btnNomes" class="i2Style i2Style:active" runat="server" Text="Pesquisar" OnClick="btnNomes_Click" /><br />
            </asp:Panel>
            <br />
            <h4 class="title"><span class="text"><strong>Usuários do sistema </strong></span></h4>
            <%-----------------------%>
            <table class='table table-striped'>
                <thead>
                    <tr>
                        <th>Foto</th>
                        <th>Nome</th>
                        <th>Tipo de <br />Usuário</th>
                        <th>Status:<br />
                            Ativo/Inativo</th>
                        <th>Adicionar<br />ADMs</th>

                    </tr>
                </thead>
                <tbody>
                    <asp:Literal ID="ltlUsers" runat="server"></asp:Literal>
                </tbody>
            </table>
            <%------------------------------%>
        </div>
    </div>

    <script src="../../themes/js/jsModerarUsuario.js"></script>
    <script src="../../themes/js/jsAdicionarRemoverADM.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('[data-toggle="tooltip"]').tooltip();
        });
    </script>

    <script>

        function sucesso() {
            swal("Endereço excluído!", {
                button: false,
            });
            setTimeout(function () {
                window.location.href = 'ModerarUsuarios.aspx';
            }, 1500);
    </script>




</asp:Content>

