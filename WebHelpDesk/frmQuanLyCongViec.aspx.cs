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
    public partial class WebForm5 : System.Web.UI.Page
    {
        int cv_id = 0;
        int sc_id = 0;
        string action = "";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
            if (!IsPostBack)
            {
                
                string select = "Select * from congviec join suco on suco.sc_id= congviec.sc_id where  cv_nvKhacPhuc_id ='" + Session["nvId"] + "' and cv_tinhTrang <2";
                SqlCommand thucthi = new SqlCommand(select, con);
                con.Open();
                //Của FAQ đã duyệt
                SqlDataReader rd = thucthi.ExecuteReader();
                rpCongViec.DataSource = rd;
                rpCongViec.DataBind();
                con.Close();
                if(Request["cv_id"] != null)
                {
                    cv_id = Convert.ToInt32(Request["cv_id"]);
                    sc_id = Convert.ToInt32(Request["sc_id"]);
                    action = Convert.ToString(Request["action"]);
                    if (action == "huybo")
                    {
                        string update = "update congviec set cv_tinhTrang = '3' where cv_id = @cv_id";
                        SqlCommand cmd = new SqlCommand(update, con);
                        SqlParameter p1 = new SqlParameter("@cv_id", SqlDbType.Int);
                        p1.Value = cv_id;
                        cmd.Parameters.Add(p1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
    
                        //Update sự cố 
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
                    if(action == "hoanthanh")
                    {
                        string update = "update congviec set cv_tinhTrang = '2' where cv_id = @cv_id";
                        SqlCommand cmd = new SqlCommand(update, con);
                        SqlParameter p1 = new SqlParameter("@cv_id", SqlDbType.Int);
                        p1.Value = cv_id;
                        cmd.Parameters.Add(p1);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Response.Redirect("frmQuanLyCongViec");

                    }
                }
                //Lịch sử công việc
                string select2 = "Select * from congviec join suco on suco.sc_id= congviec.sc_id where  cv_nvKhacPhuc_id ='" + Session["nvId"] + "' and cv_tinhTrang >1";
                SqlCommand thucthi2 = new SqlCommand(select2, con);
                con.Open();
                //Của FAQ đã duyệt
                SqlDataReader rd2 = thucthi2.ExecuteReader();
                rpLichSu_CV.DataSource = rd2;
                rpLichSu_CV.DataBind();
                con.Close();
            }
        }
        
    }
}