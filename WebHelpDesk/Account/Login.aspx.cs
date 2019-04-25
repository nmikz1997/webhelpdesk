using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using WebHelpDesk.Models;
using System.Data.SqlClient;  
using System.Configuration;

namespace WebHelpDesk.Account
{
    public partial class Login : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
       /* protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }*/

        protected void LogIn(object sender, EventArgs e)
        {
            try
            {
                string uid = txtTaiKhoan.Text;
                string pass = txtPassword.Text;
                con.Open();
                string qry = "select * from nhanvien where nv_id='" + uid + "' and nv_password='" + pass + "'";
                SqlCommand cmd = new SqlCommand(qry, con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    Session["nvId"] = string.Format("{0}", sdr["nv_id"]);
                    Session["nvTen"] = string.Format("{0}", sdr["nv_ten"]);
                    Session["nvgioiTinh"] = string.Format("{0}", sdr["nv_gioiTinh"]);
                    Session["nvChuyenMon"] = string.Format("{0}", sdr["nv_chuyenMon"]);
                    Session["nvLevel"] = string.Format("{0}", sdr["nv_level"]);
                    Session["bpId"] = string.Format("{0}", sdr["bp_id"]);
                    Response.Redirect("~/frmQuanLySuCo.aspx");
                }
                else
                {
                   

                }
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}
