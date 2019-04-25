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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
       
        protected void Page_Load(object sender, EventArgs e)
        {
            cp_themFAQ.Visible = false;
            bpCNTT.Visible = false;
            if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
            if (!IsPostBack)
            {

                string selectFAQ = "";
                if (Session["bpId"].ToString().Trim() == "CNTT")
                {
                    cp_themFAQ.Visible = true;
                    selectFAQ = "Select * from FAQ where faq_hienThi !=0";
                    bpCNTT.Visible = true;
                }

                else
                {
                    selectFAQ = "Select * from FAQ where faq_hienThi = 1";
                }
                SqlCommand thucthi = new SqlCommand(selectFAQ, con);
                //Của FAQ chưa duyệt
                string selectFAQ_0 = "";
                selectFAQ_0 = "Select * from FAQ where faq_nvDeXuat_id ='"+Session["nvId"] +"' order by faq_hienThi ASC";
                SqlCommand FAQ_0 = new SqlCommand(selectFAQ_0, con);
                con.Open();
                //Của FAQ đã duyệt
                SqlDataReader rd = thucthi.ExecuteReader();
                rpFAQ.DataSource = rd;
                rpFAQ.DataBind();
                con.Close();
                //Của FAQ chưa duyệt
                con.Open();
                SqlDataReader read = FAQ_0.ExecuteReader();
                rp_FAQ_ChuaXacNhan.DataSource = read;
                rp_FAQ_ChuaXacNhan.DataBind();
                con.Close();
                

            }
        }

    }
}