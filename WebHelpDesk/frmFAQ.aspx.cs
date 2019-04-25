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
    public partial class _Default : Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
        int faq_id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            success.Visible = false;
            danger.Visible = false;
            btnCapNhat_FAQ.Visible = false;
            btnHuy_FAQ.Visible = false;
            if (Request["faq_id"] != null)
            {
                btnThemFAQ.Visible = false;
                btnCapNhat_FAQ.Visible = true;
                btnHuy_FAQ.Visible = true;
                faq_id = Convert.ToInt32(Request["faq_id"]);
                int capnhat = Convert.ToInt32(Request["capnhat"]);     
                if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
                if (!IsPostBack)
                {

                    string selectFAQ = "select * from FAQ join nhanvien on nhanvien.nv_id = faq_nvDeXuat_id where faq_id = " + faq_id + "";
                    titleFAQ.Text = "Cập nhật FAQ";
                    SqlCommand thucthi = new SqlCommand(selectFAQ, con);
                    con.Open();
                    SqlDataReader rd = thucthi.ExecuteReader();
                    rd.Read();
                    txtFAQ_TieuDe.Text = rd["faq_ten"].ToString();
                    CKEditor1.Text = rd["faq_noiDung"].ToString();
                    con.Close();


                }
            }
        }

        protected void themFAQ(object sender, EventArgs e)
        {
            try
            {

                string strInsert = "insert into FAQ(faq_ten,faq_noiDung,faq_nvDeXuat_id) values(N'" + txtFAQ_TieuDe.Text
                        + "',N'" + CKEditor1.Text
                        + "',N'" + Session["nvId"]
                        + "')";


                SqlCommand cmd = new SqlCommand(strInsert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                success.Visible = true;
            }
            catch (Exception)
            {
                danger.Visible = true;
            }
            Response.Redirect("~/frmQuanLyFAQ.aspx");
            con.Close();
        }
        protected void capNhat_FAQ(object sender, EventArgs e)
        {
            try
            {
                string strUpdate = "update FAQ set faq_ten = @faq_ten, faq_noiDung = @faq_noiDung where faq_id =  @faq_id";
                SqlCommand cmd = new SqlCommand(strUpdate, con);

                SqlParameter p1 = new SqlParameter("@faq_ten", SqlDbType.NVarChar);
                p1.Value = txtFAQ_TieuDe.Text.Trim();
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@faq_noiDung", SqlDbType.NText);
                p2.Value = CKEditor1.Text.Trim();
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@faq_id", SqlDbType.Int);
                p3.Value = faq_id;
                cmd.Parameters.Add(p3);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect("frmQuanLyFAQ");
            }
            catch (Exception ex)
            {
                danger.Visible = true;
            }

        }
        protected void huyBo_FAQ(object sender, EventArgs e)
        {
            Response.Redirect("frmQuanLyFAQ");
        }

    }
}