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
    public partial class adminpublishermanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        //ADD
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                Response.Write("<script>alert('publisher with this id already exists,you cannot add another publisher with the same publisher id');</script>");
            }
            else
            {
                AddNewPublisher();

            }
        }
        //UPDATE
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                //  Response.Write("<script>alert('author with this id already exists,you cannot add another author with the same author id');</script>");
                UpdatePublisher();

            }
            else
            {
                Response.Write("<script>alert('publisher does not exists');</script>");
            }
        }
        //DELETE
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (CheckIfPublisherExists())
            {
                //  Response.Write("<script>alert('author with this id already exists,you cannot add another author with the same author id');</script>");
                DeletePublisher();
            }
            else
            {
                Response.Write("<script>alert('publisher does not exists');</script>");
            }
        }
        //GO
        protected void Button2_Click(object sender, EventArgs e)
        {
            PublisherById();
        }

        bool CheckIfPublisherExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;

                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;

            }
        }
        void AddNewPublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tb1(publisher_id,publisher_name) values(@publisher_id,@publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher added Successfully');</script>");
                Clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void UpdatePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tb1 SET publisher_name=@publisher_name WHERE publisher_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@publisher_name", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher Updated Successfully');</script>");
                Clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeletePublisher()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //  SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tb1 WHERE  publisher_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('publisher deleted Successfully');</script>");
                // clearForm();
                GridView1.DataBind();
                Clearform();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void Clearform()
        {
            TextBox1.Text = "";
            TextBox3.Text = "";
        }

        void PublisherById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tb1 where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    TextBox3.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('invalid publisher id');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");


            }
        }



    }
}