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
    public partial class WebForm6 : System.Web.UI.Page
    {
        int cv_id = 0;
        int sc_id = 0;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
            if (!IsPostBack)
            {
                cv_id = Convert.ToInt32(Request["cv_id"]);
                //ẩn hiện button
                int cv_tinhTrang = Convert.ToInt32(Request["cv_tinhTrang"]);
                if(cv_tinhTrang == 0)
                {
                    btnXacNhan.Visible = true;
                    btnHuy.Visible = true;
                }
                else if (cv_tinhTrang == 1)
                {
                    btnXacNhan.Visible = false;
                    btnHuy.Visible = true;
                }
                else
                {
                    btnXacNhan.Visible = false;
                    btnHuy.Visible = false;
                }
                string select = "Select * from congviec join suco on suco.sc_id= congviec.sc_id where  cv_id =@cv_id";
                SqlCommand cmd = new SqlCommand(select, con);
                SqlParameter p1 = new SqlParameter("@cv_id", SqlDbType.Int);
                p1.Value = cv_id;
                cmd.Parameters.Add(p1);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                rpChiTietCV.DataSource = rd;
                rpChiTietCV.DataBind();
                con.Close();
            }
        }
        protected void XacNhanCongViec(object sender, EventArgs e)
        {
            try
            {
                cv_id = Convert.ToInt32(Request["cv_id"]);
                TextBox moTa = (TextBox)rpChiTietCV.Items[0].FindControl("txtMoTaCV");
                string abc = moTa.Text;
                string update = " update congviec set cv_moTa = @cv_moTa, cv_tinhTrang=1, cv_ngayCapNhat = getdate() where cv_id = @cv_id ";
                SqlCommand cmd = new SqlCommand(update, con);
                SqlParameter p1 = new SqlParameter("@cv_moTa", SqlDbType.NText);
                p1.Value = abc;
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@cv_id", SqlDbType.Int);
                p2.Value = cv_id;
                cmd.Parameters.Add(p2);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Redirect(Request.RawUrl);
            }
            catch(Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
        protected void QuayLai(object sender, EventArgs e)
        {
            Response.Redirect("frmQuanLyCongViec");
        }

        protected void HuyCongViec(object sender, EventArgs e)
        {
            try
            {
                cv_id = Convert.ToInt32(Request["cv_id"]);
                TextBox moTa = (TextBox)rpChiTietCV.Items[0].FindControl("txtMoTaCV");
                string abc = moTa.Text;
                string update = " update congviec set cv_moTa = @cv_moTa, cv_tinhTrang=3, cv_ngayCapNhat = getdate() where cv_id = @cv_id ";
                SqlCommand cmd = new SqlCommand(update, con);
                SqlParameter p1 = new SqlParameter("@cv_moTa", SqlDbType.NText);
                p1.Value = abc;
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@cv_id", SqlDbType.Int);
                p2.Value = cv_id;
                cmd.Parameters.Add(p2);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                string select = "Select congviec.sc_id from congviec join suco on suco.sc_id= congviec.sc_id where  cv_id =@cv_id";
                SqlCommand cmd_sc = new SqlCommand(select, con);
                SqlParameter p4 = new SqlParameter("@cv_id", SqlDbType.Int);
                p4.Value = cv_id;
                cmd_sc.Parameters.Add(p4);
                con.Open();
                SqlDataReader rd = cmd_sc.ExecuteReader();
                rd.Read();
                sc_id = Convert.ToInt32(rd["sc_id"]);
                con.Close();

                string update3 = "update suco set sc_tinhTrang = '3' where sc_id = @sc_id";
                SqlCommand cmd3 = new SqlCommand(update3, con);
                SqlParameter p3 = new SqlParameter("@sc_id", SqlDbType.Int);
                p3.Value = sc_id;
                cmd3.Parameters.Add(p3);
                con.Open();
                cmd3.ExecuteNonQuery();
                con.Close();
                Response.Redirect("frmQuanLyCongViec");
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}