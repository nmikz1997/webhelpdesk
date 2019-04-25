<%@ Page Title="Thêm FAQ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmFAQ.aspx.cs" Inherits="WebHelpDesk._Default" %>
<%@ Register Namespace="CKEditor.NET" Assembly="CKEditor.NET" TagPrefix="CKEditor" %>  
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12">
            <div class="alert alert-success" runat="server" id="success" >
              <strong>Success!</strong> Thao tác của bạn thành công
            </div>
            <div class="alert alert-danger" runat="server" id="danger" >
              <strong>Danger!</strong> Có lỗi khi thực hiện thao tác này
            </div>
            <div class="form-horizontal">
              <h2 class="text-center" runat="server" style="color: #000000; background-color: #FFFFFF" ><em><asp:Label runat="server" ID="titleFAQ" >Đề xuất FAQ mới</asp:Label></em></h2>
                <div class="form-group">
                    <asp:Label runat="server" CssClass="col-md-2 control-label">Tiêu đề của FAQ</asp:Label>
                    <div class="col-md-8">
                        <asp:TextBox runat="server"  CssClass="form-control" ID="txtFAQ_TieuDe" />
                    </div>
                </div> 
                <CKEditor:CKEditorControl ID="CKEditor1" Height="500" runat="server"></CKEditor:CKEditorControl>        
                <div class="form-group" id="eventButton" runat="server">
                    <div class="col-md-8" style="left:88%;position:relative" >
                        <asp:Button ID="btnThemFAQ"  style="margin-top:20px" runat="server" OnClick="themFAQ" CssClass="btn btn-success"  Text="Thêm FAQ" />
                        <asp:Button  runat="server" CssClass="btn btn-info" style="margin-top:20px;" ID="btnCapNhat_FAQ" OnClick="capNhat_FAQ" Text="Cập nhật" />
                        <asp:Button  runat="server" CssClass="btn btn-warning" ID="btnHuy_FAQ" style="margin-top:20px;" OnClick="huyBo_FAQ" Text="Hủy" />
                    </div>
                </div>
            &nbsp;</div>
             
        </div>
    </div>
        

</asp:Content>
