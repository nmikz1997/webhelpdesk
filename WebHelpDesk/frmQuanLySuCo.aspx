<%@ Page Title="Quản Lý Sự Cố" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmQuanLySuCo.aspx.cs" Inherits="WebHelpDesk.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-12">
        <div class="alert alert-success" runat="server" id="success" >
          <strong>Success!</strong> Thao tác của bạn thành công
        </div>
        <div class="alert alert-danger" runat="server" id="danger" >
          <strong>Danger!</strong> Có lỗi khi thực hiện thao tác này
        </div>
        <div class="form-horizontal">
            <h2 class="text-center" runat="server" style="color: #000000; background-color: #FFFFFF" ><em><asp:Label runat="server" ID="titleSuCo" >Báo cáo sự cố mới</asp:Label></em></h2>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Mã sự cố</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server"  CssClass="form-control" ID="txtMaSC" ReadOnly="true" TextMode="Number" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Nhân viên báo cáo sự cố</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server"  CssClass="form-control" ID="txtNV_BC" ReadOnly="true" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server"  CssClass="col-md-2 control-label">Nhân viên gặp sự cố</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtNV_GSC" CssClass="form-control"  />
                
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server"  CssClass="col-md-2 control-label">Loại sự cố</asp:Label>
                <div class="col-md-8">
                    <asp:ListBox ID="lbLoaiSuCo" CssClass="form-control" style="width:50%" runat="server" Rows="1">
                        <asp:ListItem>Sữa chữa phần cứng</asp:ListItem>
                        <asp:ListItem>Sữa chữa phần mềm</asp:ListItem>
                        <asp:ListItem>Sữa chữa phần cứng và phần mềm</asp:ListItem>
                        <asp:ListItem>Thay phần cứng</asp:ListItem>
                        <asp:ListItem>Nhiễm Virus</asp:ListItem>
                        <asp:ListItem>Khác</asp:ListItem>
                    </asp:ListBox>
                
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server"  CssClass="col-md-2 control-label">Ngày lỗi</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtDate" CssClass="form-control" style="width:30%" TextMode="Date"> </asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server"  CssClass="col-md-2 control-label">Mô tả</asp:Label>
                <div class="col-md-8">
                    <asp:TextBox runat="server" ID="txtMoTa" CssClass="form-control" Rows="5" TextMode="MultiLine"  />
                
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server"  CssClass="col-md-2 control-label">Hình ảnh</asp:Label>
                <div class="col-md-8">
                    <asp:FileUpload ID="fp_img" runat="server" />
                    <asp:Image ID="image1" Width="200px" Height="150px" runat="server" />
                </div>
                <div class="form-group" runat="server" id="eventButtonAdd">
                    <div class="col-md-8">
                        <asp:Button ID="btnThem" style="margin-top:20px;position:relative ;left:110%" runat="server" CssClass="btn btn-success" OnClick="btnThem_Click" Text="Thêm sự cố" />
                    </div>
                    
                </div>
                <div class="form-group" id="eventButton" runat="server">
                    <div class="col-md-8" style="left:65%;position:relative" >
                        
                        <asp:Button ID="btnCapNhat" style="margin:20px;" runat="server" CssClass="btn btn-warning"  OnClick="btnCapNhat_click" Text="Cập nhật" />
                        <asp:Button ID="btnHuy"  runat="server" CssClass="btn btn-danger" OnClick="btnHuy_click" Text="Hủy" />
                    </div>
                </div>
            </div>
            &nbsp;</div>
        
    </div>
    <div>

        <asp:GridView ID="GridViewSC" Width="100%" runat="server"  OnRowDataBound="gv_RowDataBound" AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleted="GridViewSC_RowDeleted" OnRowDeleting="GridViewSC_RowDeleting" OnSelectedIndexChanged="GridViewSC_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White"/>
            <Columns>
                <asp:BoundField DataField="sc_id" HeaderText="Mã" />
                <asp:BoundField DataField="sc_moTa" HeaderText="Mô tả" />
                <asp:BoundField DataField="sc_thoiGianDuKien" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Thời gian dự kiến" />
                <asp:BoundField DataField="sc_ngayThem" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày Thêm" />
                <asp:BoundField DataField="sc_ngayCapNhat" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày Cập Nhật" />
                <asp:BoundField DataField="sc_nvBaoCao_id" HeaderText="Nhân Viên Báo Cáo" />
                <asp:BoundField DataField="sc_nvGapSuCo_id" HeaderText="Nhân Viên Gặp Sự Cố" />
                <asp:BoundField DataField="sc_tinhTrang" HeaderText="Tình Trạng" />
                <asp:CommandField ButtonType="Button"  CancelText="" DeleteText="Xóa" EditText="Sửa" SelectText="Chọn" ShowCancelButton="False" ShowDeleteButton="true" ShowSelectButton="true" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>

    </div>  
   
</asp:Content>
