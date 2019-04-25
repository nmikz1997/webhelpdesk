<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmChiTiet.aspx.cs" Inherits="WebHelpDesk.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12" >
            <asp:Repeater ID="rpChiTiet" runat="server">
                <ItemTemplate>
                    <div style="text-align:Center;padding: 30px 0px;background-color:#F5F5F5;margin-bottom:10px">
                        <h2 ><%# Eval("faq_ten")%></h2>
                        <span><%# Eval("nv_ten") %></span>
                    </div>
                    
                    <div style="background-color:#F5F5F5"><%# Eval("faq_noiDung") %></div>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
    </div>
</asp:Content>
