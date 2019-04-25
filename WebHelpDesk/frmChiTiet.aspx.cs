using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebHelpDesk
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        int faq_id = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            faq_id = Convert.ToInt32(Request["faq_id"]);
            int capnhat = Convert.ToInt32(Request["capnhat"]);
           
            if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
            if (!IsPostBack)
            {
                
                string  selectFAQ = "select * from FAQ join nhanvien on nhanvien.nv_id = faq_nvDeXuat_id where faq_id = " + faq_id+"";

                SqlCommand thucthi = new SqlCommand(selectFAQ, con);
                con.Open();
                SqlDataReader rd = thucthi.ExecuteReader();

                rpChiTiet.DataSource = rd;
                rpChiTiet.DataBind();
                con.Close();


            }
        }
       
    }
}