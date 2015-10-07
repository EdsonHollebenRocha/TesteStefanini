
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Classes.User user = Classes.User.getUsuarioByLogin(txtEmail.Text, txtPassword.Text);
            if(user == null)
            {
                trAlertTr.Attributes.CssStyle.Value = "trVisible";
                lblLoginError.Text = "The e-mail and/or password entered is invalid. Please try again";
                txtEmail.BorderColor = System.Drawing.Color.Red;
                txtPassword.BorderColor = System.Drawing.Color.Red;
            }
            else
            {
                Session["User"] = user;
                trAlertTr.Attributes.CssStyle.Value = "trInvisible";
                txtEmail.BorderColor = System.Drawing.Color.Black;
                txtPassword.BorderColor = System.Drawing.Color.Black;
                Response.Redirect("CustomerListPage.aspx");
            }
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            //Login1.
        }
    }
}