<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmChiTietCV.aspx.cs" Inherits="WebHelpDesk.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <h2>Thông tin chi tiết công việc</h2>
            <table class="table ">
                <asp:Repeater runat="server" ID="rpChiTietCV">
                    <ItemTemplate>
                        <tr>
                            <td>Mã công việc</td>
                            <td><%# Eval("cv_id") %></td>
                        </tr>
                        <tr>
                            <td>Ngày dự kiến hoàn thành</td>
                            <td><%# Eval("sc_thoiGianDuKien","{0:dd/MM/yyyy}") %></td>
                        </tr>
                        <tr>
                            <td style="width:20%">Nội dung công việc</td>
                            <td style="width:80%">
                                <asp:TextBox runat="server" Width="100%" Rows="5" ID="txtMoTaCV" Text='<%# Eval("cv_moTa").ToString()%>' TextMode="MultiLine" > </asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Tình trạng công việc</td>
                            <td><%# Eval("cv_tinhTrang").ToString().Replace("0","Chưa xác nhận").Replace("1","Đã xác nhận").Replace("2","Hoàn thành").Replace("3","Đã hủy bỏ") %></td>
                        </tr>
                        <tr>
                            <td>Sự cố của nhân viên</td>
                            <td><%# Eval("sc_nvGapSuCo_id") %></td>
                        </tr>
                        <tr>
                            <td>Thông tin sự cố</td>
                            <td><%# Eval("sc_moTa") %></td>
                        </tr>
                        <tr>
                            <td>Hình ảnh của sự cố</td>
                            <td><img src="/images/<%# Eval("sc_img") %>" alt="Hình ảnh sự cố chưa có" /></td>
                        </tr>
                     </ItemTemplate> 
                </asp:Repeater>
               
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Button ID="btnXacNhan"  runat="server" CssClass="btn btn-success" OnClick="XacNhanCongViec" Text="Xác nhận"  Visible="false" />
            <asp:Button ID="btnHuy"  runat="server" CssClass="btn btn-danger" OnClick="HuyCongViec"  Text="Không khắc phục được" Visible="false" />
            <asp:Button ID="btnQuayLai"  runat="server" CssClass="btn btn-warning" OnClick="QuayLai"  Text="Quay lại" />
        </div>

    </div>
</asp:Content>
