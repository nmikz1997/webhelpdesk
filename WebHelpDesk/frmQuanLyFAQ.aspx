<%@ Page Title="FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmQuanLyFAQ.aspx.cs" Inherits="WebHelpDesk.WebForm3" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<style>
     .stt{
         text-align:center;
         width:20px;
     }
    .table tbody > tr > td{
        vertical-align:unset;
        padding:0px;
    }
   
</style>
    <h2>Danh sách các câu hỏi thường gặp</h2>
    <div class="row">
        <div class="col-md-10 col-md-offset-1">
            
            <table class="table table-striped">
                <caption id="cp_themFAQ" runat="server" style="text-align:right;font-size:14px;color:deepskyblue"><a href="frmFAQ">Thêm câu hỏi mới</a></caption>   
                <asp:Repeater runat="server" ID="rpFAQ">
                    <ItemTemplate>
                        <tr>
                            <td class="stt"><%# Eval("faq_id") %></td>
                            <td style="padding:10px"><a href="frmChiTiet?faq_id=<%# Eval("faq_id") %>"><%# Eval("faq_ten") %></a></td>
                        </tr>
                    </ItemTemplate> 
                </asp:Repeater>
            </table> 
        </div>
    </div>

    <div class="row" style="padding-top:100px" id="bpCNTT" runat="server">
        <h2>Câu hỏi mà bạn đã đề xuất</h2>
        <div class="col-md-10 col-md-offset-1">
            
            <table class="table table-borderd table-striped" >
                <tr>
                    <th>Tên FAQ</th>
                    <th>Ngày thêm</th>
                    <th>Trạng thái</th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rp_FAQ_ChuaXacNhan">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <a href="frmChiTiet?faq_id=<%# Eval("faq_id") %>"><%# Eval("faq_ten") %></a>
                                 <asp:Label runat="server" ID="lblId" Text='<%# Eval("faq_id") %>' Visible="false"></asp:Label>
                            </td>
                            <td><%# Eval("faq_ngayThem" ,"{0:dd/MM/yyyy}") %></td>
                            <td><%# Eval("faq_hienThi").ToString().Replace("0","Chưa xác nhận").Replace("1","Đã xác nhận/Hiện").Replace("2","Đã xác nhận/Ẩn") %></td>
                            <td style="padding:5px; width:10%" >
                                <a href="frmFAQ?faq_id=<%# Eval("faq_id") %>" type="button" class="btn btn-info" >Cập nhật</a>
                            </td>
                        </tr>
                    </ItemTemplate> 
                </asp:Repeater>
            </table> 
        </div>
    </div>
</asp:Content>
