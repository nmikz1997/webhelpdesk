using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Globalization;

namespace WebHelpDesk
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        int i = 0;
        DataTable dtSuCo;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["nvId"] == null) Response.Redirect("~/Account/Login.aspx");
            if (!IsPostBack)
            {
                success.Visible = false;
                danger.Visible = false;
                eventButton.Visible = false;
                eventButtonAdd.Visible = true;
                txtNV_BC.Text = Session["nvId"].ToString().Trim();
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
                //Mã id sự cố
                string selectID = "select max(sc_id) as max from suco";
                SqlCommand thucthi = new SqlCommand(selectID, con);
                con.Open();
                SqlDataReader rd = thucthi.ExecuteReader();
                rd.Read();
                i = Convert.ToInt32(rd["max"]) + 1;
                txtMaSC.Text = i.ToString();
                con.Close();
                //Load DataGridView
                Load();
                
                if (Request.Params["scID"] != null)
                {
                    titleSuCo.Text = "Sửa thông tin sự cố";
                    eventButton.Visible = true;
                    eventButtonAdd.Visible = false;
                    string id = Request.QueryString["scID"];
                    txtMaSC.Text = id;
                    //thực thi select suco where id
                    string selectForm = "Select * from suco where sc_id = '" + id + "'";
                    //điền vào form
                    SqlCommand sl = new SqlCommand(selectForm, con);
                    con.Open();
                    SqlDataReader readForm = sl.ExecuteReader();

                    if (readForm.Read() == true)
                    {
                        //Url images
                        image1.ImageUrl = String.Format(@"~\images\{0}", readForm["sc_img"]);
                        //Xu ly ngay
                        txtNV_BC.Text = String.Format("{0}", readForm["sc_nvBaoCao_id"]).Trim();
                        txtNV_GSC.Text = String.Format("{0}", readForm["sc_nvGapSuCo_id"]).Trim();
                        txtMoTa.Text = String.Format("{0}", readForm["sc_moTa"]);
                        txtDate.Text = String.Format("{0:yyyy-MM-dd}", readForm["sc_ngayThem"]); ;
                        lbLoaiSuCo.Text = String.Format("{0}", readForm["sc_lsc"]);
                    }
                    con.Close();
                }
            }
        }

        /*protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }*/

        protected void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                if (fp_img.HasFile)
                {
                    name = fp_img.FileName;
                    name = (i+Path.GetExtension(name)).ToString();
                    string strInsert = "insert into suco(sc_nvBaoCao_id,sc_nvGapSuCo_id,sc_moTa,sc_img,sc_lsc,sc_ngayThem) values('" + txtNV_BC.Text
                            + "','" + txtNV_GSC.Text
                            + "',N'" + txtMoTa.Text
                            + "','" + name
                            + "',N'" + lbLoaiSuCo.Text
                            + "','" + txtDate.Text
                            + "')";
            
                   
                    SqlCommand cmd = new SqlCommand(strInsert, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    string filename = "images/" + name;
                    string filepath = MapPath(filename);
                    fp_img.SaveAs(filepath);
                    success.Visible = true;
                }
                else
                {
                    string strInsert = "insert into suco(sc_nvBaoCao_id,sc_nvGapSuCo_id,sc_moTa,sc_lsc,sc_ngayThem) values('" + txtNV_BC.Text
                            + "','" + txtNV_GSC.Text
                            + "',N'" + txtMoTa.Text
                            + "',N'" + lbLoaiSuCo.Text
                            + "','" + txtDate.Text
                            + "')";
                    SqlCommand cmd = new SqlCommand(strInsert, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    success.Visible = true;
                }   
            }
            catch(Exception)
            {
                danger.Visible = true;
            }
            Response.Redirect("~/frmQuanLySuCo.aspx");
            con.Close();
        }

        private void Load()
        {
            try
            {
                con.Open();

                String selectSuCo = "Select * from suco where sc_nvGapSuCo_id = '"+ Session["nvId"] + "' order by sc_tinhTrang ASC";
                SqlCommand cmdSC = new SqlCommand(selectSuCo, con);
                dtSuCo = new DataTable();
                SqlDataAdapter suco = new SqlDataAdapter(cmdSC);
                suco.Fill(dtSuCo);
                GridViewSC.DataSource = dtSuCo;
                GridViewSC.DataBind();
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert(" + ex.ToString() + ")</script>");
            }
        }

        protected void GridViewSC_SelectedIndexChanged(object sender, EventArgs e)
        {
            string scID = GridViewSC.SelectedRow.Cells[0].Text.ToString().Trim();
            Response.Redirect("frmQuanLySuCo.aspx?scID=" + scID);
        }
       
        protected void gv_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //((CommandField)(((DataControlFieldCell)(e.Row.Cells[8])).ContainingField)).ShowDeleteButton = true;
                if (e.Row.Cells[7].Text.Equals("0"))
                {
                    e.Row.Cells[7].Text = "Đang chờ";
                    e.Row.Cells[8].Visible = true;
                }

                if (e.Row.Cells[7].Text.Equals("1"))
                {
                    e.Row.Cells[7].Text = "Đang điều tra";
                    e.Row.Cells[8].Visible = false;
                }
                    
                if (e.Row.Cells[7].Text.Equals("2"))
                {
                    e.Row.Cells[7].Text = "Đã khắc phục";
                    e.Row.Cells[8].Visible = false;
                }
                if (e.Row.Cells[7].Text.Equals("3"))
                {
                    e.Row.Cells[7].Text = "Chưa khắc phục";
                    e.Row.Cells[8].Visible = false;
                }

            }

        }
        protected void GridViewSC_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            
        }

        protected void GridViewSC_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridViewSC.Rows[e.RowIndex];
            int inId = Int32.Parse(row.Cells[0].Text.ToString().Trim());
            string strDelete = "DELETE from suco Where sc_id = @sc_id";
            SqlCommand cmd = new SqlCommand(strDelete, con);
            SqlParameter p1 = new SqlParameter("@sc_id", SqlDbType.Int);
            p1.Value = inId;
            cmd.Parameters.Add(p1);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Load();
        }
        protected void btnCapNhat_click(object sender, EventArgs e)
        {
            try
            {
                string name = "";
                if (fp_img.HasFile)
                {
                    name = fp_img.FileName;
                    name = txtMaSC.Text + Path.GetExtension(name);
                    string strUpdate = "update suco set sc_nvGapSuCo_id ='" + txtNV_GSC.Text.Trim()
                            + "',sc_moTa = N'" + txtMoTa.Text.Trim()
                            + "',sc_lsc = '" + lbLoaiSuCo.Text
                            + "', sc_ngayThem = '" + txtDate.Text
                            + "',sc_img = '" + name
                            +"'where sc_id = "+txtMaSC.Text +"";

                    con.Open();
                    SqlCommand cmd1 = new SqlCommand(strUpdate, con);
                    
                    cmd1.ExecuteNonQuery();
                    string filename = "images/" + name;
                    string filepath = MapPath(filename);
                    fp_img.SaveAs(filepath);
                    success.Visible = true;
                }
                else
                {
                    string strUpdate = "update suco set sc_nvGapSuCo_id='" + txtNV_GSC.Text.Trim()
                            + "', sc_moTa = N'" + txtMoTa.Text
                            + "', sc_lsc = '" + lbLoaiSuCo.Text
                            + "', sc_ngayThem = '" + txtDate.Text
                            + "'where sc_id = " + txtMaSC.Text+"";
                    con.Open();
                    SqlCommand cmd1 = new SqlCommand(strUpdate, con);
                    
                    cmd1.ExecuteNonQuery();
                    success.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<p>" + ex.ToString() + "</p>");
                danger.Visible = true;
            }

            Response.Redirect("~/frmQuanLySuCo.aspx");
            con.Close();
        }
        protected void btnHuy_click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmQuanLySuCo.aspx");
        }
    }
}