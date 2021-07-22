using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLIBRARY
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO 
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            GetMemberById();
        }
        //active
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("Active");
        }
        //pending
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("Pending");
        }
        //deactive
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            UpdateMemberStatusById("Deactive");
        }
        //delete
        protected void Button5_Click(object sender, EventArgs e)
        {
            Deletememberbyid();
        }
        bool Checkifmemberexists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>=1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void GetMemberById()
        {
            if (Checkifmemberexists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("select * from member_master_tb1 where member_id='" + TextBox1.Text.Trim() + "' ", con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            TextBox3.Text = dr.GetValue(0).ToString();
                            TextBox7.Text = dr.GetValue(10).ToString();
                            TextBox8.Text = dr.GetValue(1).ToString();
                            TextBox9.Text = dr.GetValue(2).ToString();
                            TextBox10.Text = dr.GetValue(3).ToString();
                            TextBox11.Text = dr.GetValue(4).ToString();
                            TextBox12.Text = dr.GetValue(5).ToString();
                            TextBox13.Text = dr.GetValue(6).ToString();
                            TextBox4.Text = dr.GetValue(7).ToString();

                        }

                    }
                    else
                    {
                        Response.Write("<script>alert('invalid credentials');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('invalid member id');</script>");
            }
        }

        void UpdateMemberStatusById( string status)
        {
            if (Checkifmemberexists())
            {
                try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE member_master_tb1 SET account_status='"+status+"' where member_id='" + TextBox1.Text.Trim() + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GridView1.DataBind();
                Response.Write("<script>alert('member status updated');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
            else
            {
                Response.Write("<script>alert('invalid member id');</script>");
            }
        }
        void Deletememberbyid()
        {
            if (Checkifmemberexists())
            {
                try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //  SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);
                SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tb1 WHERE  member_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('member deleted Successfully');</script>");
                // clearForm();
                GridView1.DataBind();
                Clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            }
            else
            {
                Response.Write("<script>alert('invalid member id');</script>");
            }
        }
        void Clearform()
        {
            TextBox3.Text = "";
            TextBox7.Text = "";
            TextBox8.Text = "";
            TextBox9.Text = "";
            TextBox10.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox4.Text = "";
        }
    }
}