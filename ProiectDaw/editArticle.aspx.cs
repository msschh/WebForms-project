using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Security;
using System.Data;
using System.IO;

namespace ProiectDaw
{
    public partial class editArticle : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                con.Open();
                cmd = new SqlCommand("SELECT TOP 1 ART.PROTEJAT , ART.TITLE as 'ArticleTitle', DOM.NAME as 'DomainName', ARH.CONTINUT, USR.USERNAME as 'AutorUsername' FROM ARTICLES ART INNER JOIN USERS USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID INNER JOIN ARTICLEHISTORY ARH ON ART.ID = ARH.ARTICLEID WHERE ART.ID = @ID ORDER BY ARH.DATE_CHANGE DESC; ", con);
                cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    if (dr["protejat"].ToString().Equals("True") && Membership.GetUser() == null)
                    {
                        Response.Redirect("~/NoRights.aspx?message=Utilizatorii nelogati nu au dreptul sa modifice aceasta pagina!");
                    }
                    TextBox1.Text = dr["ArticleTitle"].ToString();
                    TextBox2.Text = dr["AutorUsername"].ToString();
                    TextBox3.Text = dr["DomainName"].ToString();
                    TextArea.Value = dr["Continut"].ToString();
                }
                dr.Close();
            }
        }

        protected void BackToView(object sender, EventArgs e)
        {
            Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
        }

        protected void UpdateArticle(object sender, EventArgs e)
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

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

            cmd = new SqlCommand("INSERT INTO ArticleHistory (UserChangeId, Date_change, Continut, ArticleId) VALUES (@userChangeId, @dateChange, @continut, @articleId)", con);
            cmd.Parameters.AddWithValue("@userChangeId", userId);
            cmd.Parameters.AddWithValue("@dateChange", DateTime.Now);
            cmd.Parameters.AddWithValue("@continut", TextArea.Value);
            cmd.Parameters.AddWithValue("@articleId", Request.Params["id"].ToString());
            cmd.ExecuteNonQuery();

            Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
        }

        protected void ChangeProtection(object sender, EventArgs e)
        {
            if(con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            if (Membership.GetUser() != null)
            {
                cmd = new SqlCommand("select UserName from Users inner join Articles on Author_id = UserId where ID = @id", con);
                cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    String username = dr["UserName"].ToString();
                    dr.Close();
                    if (Membership.GetUser().UserName.Equals(username))
                    {
                        cmd = new SqlCommand("UPDATE Articles SET Protejat = @protejat where Id = @id", con);
                        cmd.Parameters.AddWithValue("@protejat", DropDownList1.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                        cmd.ExecuteNonQuery();
                        Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
                    }
                    else
                    {
                        cmd = new SqlCommand("select UIR.RoleId from UsersInRoles UIR inner join Users USR on UIR.UserId = USR.UserId where USR.UserName = @UserName", con);
                        cmd.Parameters.AddWithValue("@UserName", Membership.GetUser().UserName);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            String roleId = dr["RoleId"].ToString();
                            dr.Close();
                            if (roleId.Equals("4e563690-03c5-4fb5-b8bf-9f64f06dc3c4"))
                            {
                                cmd = new SqlCommand("UPDATE Articles SET Protejat = @protejat where Id = @id", con);
                                cmd.Parameters.AddWithValue("@protejat", DropDownList1.SelectedValue.ToString());
                                cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                                cmd.ExecuteNonQuery();
                                Response.Redirect("~/viewArticol.aspx?id=" + Request.Params["id"].ToString());
                            }
                            else
                            {
                                Response.Redirect("~/NoRights.aspx?message=Doar autorul sau un moderator are voie sa modifice restrictionarea accesului la editarea acestui articol!");
                            }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("~/NoRights.aspx?message=Doar autorul sau un moderator are voie sa modifice restrictionarea accesului la editarea acestui articol!");
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