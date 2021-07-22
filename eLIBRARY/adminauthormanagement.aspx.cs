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
    public partial class adminauthormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //add
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(CheckIfAuthorExists())
            {
                Response.Write("<script>alert('author with this id already exists,you cannot add another author with the same author id');</script>");
            }
            else
            {
                AddNewAuthor();
                
            }

        }

        //update
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                //  Response.Write("<script>alert('author with this id already exists,you cannot add another author with the same author id');</script>");
                UpdateAuthor();
                
            }
            else
            {
                Response.Write("<script>alert('author does not exists');</script>");
            }
        }
        //delete
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (CheckIfAuthorExists())
            {
                //  Response.Write("<script>alert('author with this id already exists,you cannot add another author with the same author id');</script>");
                DeleteAuthor();
            }
            else
            {
                Response.Write("<script>alert('author does not exists');</script>");
            }
        }
        //Go
        protected void Button2_Click(object sender, EventArgs e)
        {
            AuthorById();
        }

        //userdefined function 
        bool CheckIfAuthorExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where author_id='" + TextBox1.Text.Trim() + "';", con);
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

        void AddNewAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author added Successfully');</script>");
                Clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void UpdateAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE author_master_tb1 SET author_name=@author_name WHERE author_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.Parameters.AddWithValue("@author_name", TextBox3.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully');</script>");
                Clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void DeleteAuthor()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                //  SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tb1 WHERE  author_id='" + TextBox1.Text.Trim() + "'", con);
               
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author deleted Successfully');</script>");
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

       void AuthorById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tb1 where author_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {

                    TextBox3.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('invalid author id');</script>");
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
               

            }
        }
    }
}