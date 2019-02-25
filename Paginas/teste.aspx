<%@ Page Title="" Language="C#" MasterPageFile="~/Paginas/Master/MasterPrivada.master" AutoEventWireup="true" CodeFile="teste.aspx.cs" Inherits="Paginas_teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <script type="text/javascript">
        $(function () {
            $('#<%=txtNome.ClientID%>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "/Paginas/teste.aspx/Metodo",
                        data: "{'pre':'" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return { value: item }
                            }))
                        },
                        error: function (XMLHhttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                }
            });
        });
    </script>

    <table>
        <tr>
            <td>
                <div>
                    <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                </div>
            </td>
        </tr>
    </table>

   
</asp:Content>

