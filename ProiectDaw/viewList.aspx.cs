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
    public partial class viewList : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            ListView1.ItemCommand += new EventHandler<ListViewCommandEventArgs>(ListView1_ItemCommand);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = new DataTable();
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
                SqlCommand com = new SqlCommand("SELECT ART.ID as 'ArticleId', ART.TITLE as 'ArticleTitle', ART.DATE as 'DateOfCreation', DOM.NAME as 'DomainName', USR.USERNAME as 'Username' FROM ARTICLES as ART INNER JOIN USERS as USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID WHERE ART.DOMAIN_ID = @domainId ORDER BY ART.DATE DESC;", con);
                com.Parameters.AddWithValue("domainId", Request.Params["id"].ToString());
                SqlDataAdapter adp = new SqlDataAdapter(com);
                adp.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }
        }

        void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int primaryKey = Convert.ToInt32((String)e.CommandArgument);
            Response.Redirect("~/viewArticol.aspx?id=" + primaryKey);
        }

        protected void SortList(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
            String interogation = "SELECT ART.ID as 'ArticleId', ART.TITLE as 'ArticleTitle', ART.DATE as 'DateOfCreation', DOM.NAME as 'DomainName', USR.USERNAME as 'Username' FROM ARTICLES as ART INNER JOIN USERS as USR ON ART.AUTHOR_ID = USR.UserId INNER JOIN DOMAINS DOM ON ART.DOMAIN_ID = DOM.ID WHERE ART.DOMAIN_ID = @domainId ORDER BY " + "ART." + DropDownList1.SelectedValue.ToString() + " " + DropDownList2.SelectedValue.ToString();
            SqlCommand com = new SqlCommand(interogation, con);
            com.Parameters.AddWithValue("domainId", Request.Params["id"].ToString());
            SqlDataAdapter adp = new SqlDataAdapter(com);
            adp.Fill(dt);
            ListView1.DataSource = dt;
            ListView1.DataBind();
        }
    }
}