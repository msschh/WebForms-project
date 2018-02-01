using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ProiectDaw
{
    public partial class deleteArticle : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                con.Open();
                if (Request.Params["type"].ToString().Equals("1"))
                {
                    cmd = new SqlCommand("SELECT COUNT(*) as 'NumberOfArticles' FROM ArticleHistory group by ArticleId having ArticleId = @articleId", con);
                    cmd.Parameters.AddWithValue("@articleId", Request.Params["id"].ToString());
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {                        
                        String count = dr["NumberOfArticles"].ToString();
                        if (count.Equals("1"))
                        {
                            Label1.Text = "Acest articol nu a fost modificat pana acum. Doresti sa stergi acest articolul?";
                        }
                        else
                        {
                            Label1.Text = "Esti sigur ca vrei sa stergi ultima versiune a articolului?";
                        }
                    }
                    dr.Close();
                }
                else
                {
                    Label1.Text = "Esti sigur ca vrei sa stergi acest articol?";
                }
            }
        }

        protected void DeleteArticle(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (Request.Params["type"].ToString().Equals("1"))
            {
                cmd = new SqlCommand("SELECT COUNT(*) as 'NumberOfArticles' FROM ArticleHistory group by ArticleId having ArticleId = @articleId", con);
                cmd.Parameters.AddWithValue("@articleId", Request.Params["id"].ToString());
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    String count = dr["NumberOfArticles"].ToString();
                    dr.Close();


                    if (count.Equals("1"))
                    {
                        cmd = new SqlCommand("DELETE FROM Articles WHERE ID = @id", con);
                        cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        cmd = new SqlCommand("SELECT TOP 1 ID FROM ArticleHistory WHERE ArticleId = @articleId ORDER BY DATE_CHANGE DESC", con);
                        cmd.Parameters.AddWithValue("@articleId", Request.Params["id"].ToString());
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            String id = dr["id"].ToString();
                            dr.Close();
                            cmd = new SqlCommand("DELETE FROM ArticleHistory WHERE ID = @id", con);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                            Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
                        }
                    }
                }
            }
            else
            {
                cmd = new SqlCommand("DELETE FROM Articles WHERE ID = @id", con);
                cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                cmd.ExecuteNonQuery();
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void BackToView(object sender, EventArgs e)
        {
            Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
        }
    }
}