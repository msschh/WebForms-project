using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data;

namespace ProiectDaw
{
    public partial class viewArticol : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                con.Open();
                cmd = new SqlCommand("SELECT TOP 1 ART.ID as 'ArticleId', ART.PROTEJAT , ART.TITLE as 'ArticleTitle', DOM.NAME as 'DomainName', ARH.CONTINUT, ART.DATE as 'DateOfCreation', ARH.DATE_CHANGE as 'DateOfLastChange', USR.USERNAME as 'AutorUsername', USR2.USERNAME as 'LastChangerUsername' FROM ARTICLES ART INNER JOIN USERS USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID INNER JOIN ARTICLEHISTORY ARH ON ART.ID = ARH.ARTICLEID INNER JOIN USERS USR2 ON ARH.USERCHANGEID = USR2.UserId WHERE ART.ID = @ID ORDER BY ARH.DATE_CHANGE DESC; ", con);
                cmd.Parameters.AddWithValue("@id", Request.Params["id"].ToString());
                dr = cmd.ExecuteReader();
                if(dr.Read())
                {
                    ArticleTitleTxt.Text = dr["ArticleTitle"].ToString();
                    AuthorUsernameTxt.Text = dr["AutorUsername"].ToString();
                    DateOfCreationTxt.Text = dr["DateOfCreation"].ToString();
                    DomainNameTxt.Text = dr["DomainName"].ToString();
                    ChangeUsernameTxt.Text = dr["LastChangerUsername"].ToString();
                    ChangeDateTxt.Text = dr["DateOfLastChange"].ToString();
                    ContinutDiv.InnerHtml = dr["continut"].ToString();
                    CheckBox1.Checked = bool.Parse(dr["protejat"].ToString());
                }
                dr.Close();
                con.Close();
            }
            
        }

        protected void EditArticle(object sender, EventArgs e)
        {
            Response.Redirect("~/editArticle.aspx?id=" + Request.Params["id"].ToString());
        }

        protected void DeleteArticle(object sender, EventArgs e)
        {
            Response.Redirect("~/editor/deleteArticle.aspx?id=" + Request.Params["id"].ToString() + "&type=2");
        }

        protected void DeleteModification(object sender, EventArgs e)
        {
            Response.Redirect("~/editor/deleteArticle.aspx?id=" + Request.Params["id"].ToString() + "&type=1");
        }
    }
}