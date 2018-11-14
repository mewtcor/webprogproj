using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace AMS
{
    public partial class ForgotPW : System.Web.UI.Page
    {
        //Maikel
        private string connstr =
            System.Web.Configuration.WebConfigurationManager.ConnectionStrings
            ["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnResetPass_Click(object sender, EventArgs e)
        {
            //Maikel
            this.ShowPass();
        }
        public void ShowPass()
        {
            //Maikel and Leann
            SqlDataReader rdr;
            conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select Password from Users where Email ='" + txtEmail.Text + "'", conn);
            DataTable dt = new DataTable();

            conn.Open();
            rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string pw = rdr["Password"].ToString();

                string newPW = "";

                for (int i = 0; i < pw.Length; i++)
                {
                    if (i == 0)
                        newPW += pw[0];
                    else
                        newPW += "*";
                }

                lblMSG.Text = newPW;
            }

            conn.Close();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Maikel
            Response.Redirect("Login.aspx");
        }
    }
}