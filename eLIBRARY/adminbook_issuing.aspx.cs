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
    public partial class adminbook_issuing : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }
        // go button
        protected void Button2_Click(object sender, EventArgs e)
        {
            Getnames();
        }
        //issue button
        protected void Button3_Click(object sender, EventArgs e)
        {
            if(Checkifbookexist() && Checkifmemberexist())
            {
                if(Checkifissueentryexist())
                {
                    Response.Write("<script>alert('this master already has this book');</script>");
                }
                else
                {
                    IssueBook();
                }
                
            }
            else
            {
                Response.Write("<script>alert('wrong book id');</script>");

            }
        }
        //return
        protected void Button5_Click(object sender, EventArgs e)
        {
            if (Checkifbookexist() && Checkifmemberexist())
            {
                if (Checkifissueentryexist())
                {
                    //  Response.Write("<script>alert('this master already has this book');</script>");
                    returnBook();
                }   
                else
                {
                    //IssueBook();

                    Response.Write("<script>alert('this entry doesnot exists');</script>");
                }

            }
            else
            {
                Response.Write("<script>alert('wrong book id');</script>");

            }
        }

        void  IssueBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tb1(member_id,member_name,book_id,book_name,issue_date,due_date) values(@member_id,@member_name,@book_id,@book_name,@issue_date,@due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();
                cmd = new SqlCommand("update book_master_tb1 set current_stock=current_stock-1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('book issued Successfully');</script>");
                
                GridView1.DataBind();
            }
            catch (Exception ex)
             {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool Checkifbookexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tb1 WHERE book_id='" + TextBox1.Text.Trim() + "'And current_stock >0 ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    // TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    return true;
                }
                else
                {
                    //Response.Write("<script>alert('wrong book id');</script>");
                    return false;
                }
            }
            catch(Exception ex)
            {
                return false;
            }
            
        }

        void returnBook()
        {
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Delete from book_issue_tb1 WHERE book_id='" + TextBox3.Text.Trim() + "' AND member_id='" + TextBox1.Text.Trim() + "' ", con);

            int result = cmd.ExecuteNonQuery();
            
            if(result>0)
            {
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd = new SqlCommand("update book_master_tb1 set current_stock=current_stock+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Book returned successsfully');</script>");
                GridView1.DataBind();
                con.Close();
            }
        }

        bool Checkifmemberexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select full_name from member_master_tb1 WHERE book_id='" + TextBox3.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    // TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    return true;
                }
                else
                {
                    //Response.Write("<script>alert('wrong book id');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        bool Checkifissueentryexist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_issue_tb1 WHERE book_id='" + TextBox3.Text.Trim() + "' AND member_id='"+TextBox1.Text.Trim()+"' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    // TextBox4.Text = dt.Rows[0]["book_name"].ToString();
                    return true;
                }
                else
                {
                    //Response.Write("<script>alert('wrong book id');</script>");
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        void Getnames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select book_name from book_master_tb1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >=1)
                {
                    TextBox4.Text = dt.Rows[0]["book_name"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('wrong book id');</script>");

                }
                 cmd = new SqlCommand("select full_name from member_master_tb1 WHERE member_id='" + TextBox3.Text.Trim() + "'", con);
                 da = new SqlDataAdapter(cmd);
                 dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0]["full_name"].ToString();

                }
                else
                {
                    Response.Write("<script>alert('wrong user id');</script>");

                }

            }
            catch (Exception ex)
            {

            }
        }

        protected void GridView1_RowDataBound(object sender,GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType==DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;

                    if(today>dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleGreen;

                    }

                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

         
    }
}