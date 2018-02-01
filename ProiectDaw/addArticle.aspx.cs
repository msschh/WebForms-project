using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.IO;

namespace ProiectDaw
{
    public partial class addArticle : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddArticle(object sender, EventArgs e)
        {
            con.Open();
            String userId = "f948e26e-e8e3-4e28-9def-eae928620f4e";
            if (Membership.GetUser() != null)
            {
                cmd = new SqlCommand("select UserId from Users where username = @username", con);
                cmd.Parameters.AddWithValue("@username", Membership.GetUser().UserName);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    userId = dr["UserId"].ToString();
                }
                dr.Close();
            }

            DateTime date = DateTime.Now;

            cmd = new SqlCommand("INSERT INTO Articles (Title, Author_id, Date, Domain_id, Protejat) VALUES (@title, @authorId, @date, @domain, @protejat)", con);
            cmd.Parameters.AddWithValue("@title", TextBox1.Text);
            cmd.Parameters.AddWithValue("@authorId", userId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@domain", DropDownList1.SelectedValue);
            cmd.Parameters.AddWithValue("@protejat", CheckBox1.Checked.ToString());
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("select ID from Articles where Title = @title and Author_id = @authorId and Date = @date and Domain_id= @domain", con);
            cmd.Parameters.AddWithValue("@title", TextBox1.Text);
            cmd.Parameters.AddWithValue("@authorId", userId);
            cmd.Parameters.AddWithValue("@date", date);
            cmd.Parameters.AddWithValue("@domain", DropDownList1.SelectedValue);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                String articleId = dr["id"].ToString();
                dr.Close();

                cmd = new SqlCommand("INSERT INTO ArticleHistory (UserChangeId, Date_change, Continut, ArticleId) VALUES (@userChangeId, @dateChange, @continut, @articleId)", con);
                cmd.Parameters.AddWithValue("@userChangeId", userId);
                cmd.Parameters.AddWithValue("@dateChange", date);
                cmd.Parameters.AddWithValue("@continut", TextArea.Value);
                cmd.Parameters.AddWithValue("@articleId", articleId);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Redirect("~/viewArticol.aspx?id=" + articleId);
            }
        }

        protected void UploadImage(object sender, EventArgs e)
        {
            if (Path.GetExtension(FileUpload1.FileName).ToLower() != ".jpg"
                && Path.GetExtension(FileUpload1.FileName).ToLower() != ".png"
                && Path.GetExtension(FileUpload1.FileName).ToLower() != ".gif"
                && Path.GetExtension(FileUpload1.FileName).ToLower() != ".jpeg")
            {
                LabelUploadImage.Text = "Doar imaginile pot fi urcate pe server!";
            }
            else
            {
                Guid guid = Guid.NewGuid();
                FileUpload1.SaveAs(Server.MapPath("images\\" + guid + Path.GetExtension(FileUpload1.FileName).ToLower()));
                LabelUploadImage.Text = "Imaginea a fost salvata la: images\\" + guid + Path.GetExtension(FileUpload1.FileName).ToLower();
            }
        }
    }
}