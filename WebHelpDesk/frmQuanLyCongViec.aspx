<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmQuanLyCongViec.aspx.cs" Inherits="WebHelpDesk.WebForm5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <h2 style="text-align:center">Công việc của bạn</h2>
            <table class="table table-borderd table-striped" >
                <tr>
                    <th>Mã CV</th>
                    <th>Nhân viên gặp sự cố</th>
                    <th>Ngày dự kiến</th>
                    <th>Tình trạng</th>
                    <th>Sự kiện</th>
                </tr>
                <asp:Repeater runat="server" ID="rpCongViec">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("cv_id") %>
                            </td>
                            <td><%# Eval(" cv_nvKhacPhuc_id") %></td>
                            <td><%# Eval("sc_thoiGianDuKien" ,"{0:dd/MM/yyyy}") %></td>
                            <td><%# Eval(" cv_tinhTrang").ToString().Replace("0","Chưa xác nhận").Replace("1","Đã xác nhận").Replace("2","Hoàn thành").Replace("3","Đã hủy bỏ") %></td>
                            <td style="padding:5px;width:30%">
                                <a href="frmChiTietCV?cv_id=<%# Eval("cv_id") %>&cv_tinhTrang=<%# Eval("cv_tinhTrang") %>" type="button" class="btn btn-info">Xem thông tin</a>
                                <a href="frmQuanLyCongViec?cv_id=<%# Eval("cv_id") %>&action=hoanthanh" type="button" class="btn btn-success">Hoàn thành</a>
                                <a href="frmQuanLyCongViec?cv_id=<%# Eval("cv_id") %>&action=huybo&sc_id=<%# Eval("sc_id") %> "  type="button" class="btn btn-danger">Không khắc phục được</a>
                             </td>
                        </tr>
                    </ItemTemplate> 
                </asp:Repeater>
            </table> 
     &nbsp;</div>
    <div class="col-md-12">
        <h2 style="text-align:center">Lịch sử công việc của bạn</h2>
            <table class="table table-borderd table-striped" >
                <tr>
                    <th>Mã CV</th>
                    <th>Nhân viên gặp sự cố</th>
                    <th>Ngày dự kiến</th>
                    <th>Ngày cập nhật</th>
                    <th>Tình trạng</th>
                    <th>Sự kiện</th>
                </tr>
                <asp:Repeater runat="server" ID="rpLichSu_CV">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Eval("cv_id") %>
                            </td>
                            <td><%# Eval(" cv_nvKhacPhuc_id") %></td>
                            <td><%# Eval("sc_thoiGianDuKien" ,"{0:dd/MM/yyyy}") %></td>
                            <td><%# Eval("cv_ngayCapNhat" ,"{0:dd/MM/yyyy}") %></td>
                            <td><%# Eval("cv_tinhTrang").ToString().Replace("0","Chưa xác nhận").Replace("1","Đã xác nhận").Replace("2","Hoàn thành").Replace("3","Đã hủy bỏ") %></td>
                            <td style="padding:5px;width:10%">
                                <a href="frmChiTietCV?cv_id=<%# Eval("cv_id") %>&cv_tinhTrang=<%# Eval("cv_tinhTrang") %>" type="button" class="btn btn-info">Xem thông tin</a>
                             </td>
                        </tr>
                    </ItemTemplate> 
                </asp:Repeater>
            </table> 
     &nbsp;</div>
</asp:Content>

