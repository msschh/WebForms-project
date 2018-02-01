using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace ProiectDaw.admin
{
    public partial class ManageRoles : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\mssqllocaldb;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True");
        SqlCommand cmd = null;
        SqlDataReader dr = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ChangeRole(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                cmd = new SqlCommand("select UserId from Users where username = @username", con);
                cmd.Parameters.AddWithValue("@username", usernameTextBox.Text);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    String userId = dr["UserId"].ToString();
                    dr.Close();

                    cmd = new SqlCommand("update UsersInRoles set RoleId = @roleId where UserId = @userId", con);
                    cmd.Parameters.AddWithValue("@roleId", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.ExecuteNonQuery();
                    Response.Redirect(Request.RawUrl);
                }
                else
                {
                    answerLabel.Text = "Username-ul nu exista!";
                }
            }
            catch(Exception ex)
            {
                answerLabel.Text = ex.Message;
            }
        }
    }
}