﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eLIBRARY
{
    public partial class adminbook_inventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Fillauthorpublishervalues();
            GridView1.DataBind();
        }
        //go
        protected void Button3_Click(object sender, EventArgs e)
        {
            getBookByID();
        }
        //add
        protected void Button5_Click(object sender, EventArgs e)
        {
            if(CheckIfBookExists())
            {
                Response.Write("<script>alert('book alerdy exists,try some other book id');</script>");
            }
            else
            {
                Addnewbook();
            }
        }
        //update
        protected void Button1_Click(object sender, EventArgs e)
        {
            UpdateBookByID();
        }
        //delete
        protected void Button2_Click(object sender, EventArgs e)
        {
            deletebookbyid();
        }

        void deletebookbyid()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    //  SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tb1(author_id,author_name) values(@author_id,@author_name)", con);
                    SqlCommand cmd = new SqlCommand("DELETE FROM book_master_tb1 WHERE  book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('book deleted Successfully');</script>");
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
            TextBox4.Text = "";
            TextBox7.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox1.Text = "";
            TextBox11.Text = "";
            TextBox12.Text = "";
            TextBox13.Text = "";
            TextBox4.Text = "";
        }

        void UpdateBookByID()
        {

            if (CheckIfBookExists())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox5.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox6.Text.Trim());

                    if (global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if (actual_stock < global_issued_books)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the Issued books');</script>");
                            return;


                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_books;
                            TextBox6.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/imgs/book";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if (filename == "" || filename == null)
                    {
                        filepath = global_filepath;

                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("imgs/" + filename));
                        filepath = "~/imgs/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE book_master_tb1 set book_name=@book_name, genre=@genre, author_name=@author_name, publisher_name=@publisher_name, publish_date=@publish_date, language=@language, edition=@edition, book_cost=@book_cost, no_of_pages=@no_of_pages, book_description=@book_description, actual_stock=@actual_stock, current_stock=@current_stock, book_img_link=@book_img_link where book_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.Parameters.AddWithValue("@book_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@publish_date", TextBox2.Text.Trim());
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox11.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_cost", TextBox12.Text.Trim());
                    cmd.Parameters.AddWithValue("@no_of_pages", TextBox13.Text.Trim());
                    cmd.Parameters.AddWithValue("@book_description", TextBox4.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@book_img_link", filepath);


                    cmd.ExecuteNonQuery();
                    con.Close();
                    
                    Response.Write("<script>alert('Book Updated Successfully');</script>");
                    GridView1.DataBind();

                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }




        void getBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select * from book_master_tb1 where book_id='" + TextBox1.Text.Trim() + "';", con)
                {

                };
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count>=1)
                {
                    TextBox3.Text = dt.Rows[0]["book_name"].ToString();
                    TextBox2.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox11.Text = dt.Rows[0]["edition"].ToString();
                    TextBox12.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    TextBox13.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    TextBox5.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox6.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox7.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString())
                        - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    TextBox4.Text = dt.Rows[0]["book_description"].ToString();

                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
                    DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    ListBox1.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < ListBox1.Items.Count; j++)
                        {
                            if (ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;

                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock =Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());

                    global_issued_books = global_actual_stock - global_current_stock;

                    global_filepath = dt.Rows[0]["book_img_link"].ToString();


                }
                else
                {
                    Response.Write("<script>alert('invalid book id')</script>");
                }
                

            }
            catch (Exception ex)
            {

            }
        }

        void Fillauthorpublishervalues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("select author_name from author_master_tb1;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "author_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("select publisher_name from publisher_master_tb1;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "publisher_name";
                DropDownList2.DataBind();

            }
            catch (Exception ex)
            {

            }
        }
        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tb1 where book_id='" + TextBox1.Text.Trim() + "' OR book_name='"+TextBox3.Text.Trim()+"';", con);
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


        void Addnewbook()
        {
            try
            {
                string genres = "";
                foreach(int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~//book.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("imgs/" + filename));
                filepath = "~/imgs/" + filename;


                SqlConnection con = new SqlConnection(strcon);
                if(con.State==ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tb1(book_id,book_name,gener,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) VALUES(@book_id,@book_name,@gener,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@gener", genres);
                cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name",DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox11.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox12.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", TextBox13.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('book added successfully');</script>");
                GridView1.DataBind();

            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

       
    }
}