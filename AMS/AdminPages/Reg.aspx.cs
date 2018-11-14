using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace AMS.AdminPages
{
    public partial class Reg : System.Web.UI.Page
    {
        //Enzo
        private string connstr =
             System.Web.Configuration.WebConfigurationManager.ConnectionStrings
             ["AMSConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader rdr;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Enzo
            int curUser = SessionManager.UserRole;
            if (curUser == 1)
            {
                lblCurrentTime.Text = DateTime.Now.ToString("hh:mm tt");
                lblCurrentDate.Text = DateTime.Now.ToString("MM/dd/yyyy");
                lblCurrentUser.Text = SessionManager.Username;
                this.BtnState1();
                if (!this.IsPostBack)
                {
                    this.ShowUsers();
                }

            }
            else
            {
                Response.Redirect("~/401.aspx");
                return;
            }

}

        private void ShowUsers()
        {
            //Enzo
            string constr = ConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Email, Password, FirstName, LastName, UAccess, roleId FROM Users"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdwUsers.DataSource = dt;
                            gdwUsers.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Enzo
            gdwUsers.PageIndex = e.NewPageIndex;
            this.ShowUsers();
        }
        public void BtnState1()
        { 
            //Enzo
            btnSave.Enabled = true;
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;
            btnCancel.Enabled = false;
        }
        public void BtnState2()
        {
            //Enzo
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnUpdate.Enabled = true;
            btnCancel.Enabled = true;
        }
        public void ClearFields()
        {
            //Enzo
            lblMsg.Text = "";
            lblUId.Text = "";
            lblRoleId.Text = "";
            inputEmail.Value = "";
            inputFirstName.Value = "";
            inputLastName.Value = "";
            inputPassword.Value = "";
            
            drpUAccess.Text = "";
        }
        
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //Enzo
            conn = new SqlConnection(connstr);
            conn.Open();
            string checkEmail = "select count(*) from Users where Email ='" + inputEmail.Value + "'";
            cmd = new SqlCommand(checkEmail, conn);
            string strTemp = cmd.ExecuteScalar().ToString();
            int temp = Convert.ToInt32(strTemp);
            if (temp >= 1)
            {
                lblMsg.Text = "An account with this Email already exists.";
                inputEmail.Focus();
                return;
            }
            conn.Close();
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("INSERT into Users (Email, Password, FirstName, LastName, UAccess, RoleId) values (@Email, @Password, @FirstName, @LastName, @UAccess, @RoleId)", conn);
            cmd.Parameters.AddWithValue("@Email", inputEmail.Value);
            cmd.Parameters.AddWithValue("@Password", inputPassword.Value);
            cmd.Parameters.AddWithValue("@FirstName", inputFirstName.Value);
            cmd.Parameters.AddWithValue("@LastName", inputLastName.Value);
            cmd.Parameters.AddWithValue("@UAccess", drpUAccess.Text);
            string roleState = drpUAccess.Text;
            switch (roleState)
            {
                case "Administrator":
                    lblRoleId.Text = "1";
                    break;
                case "Tutor":
                    lblRoleId.Text = "2";
                    break;
                case "Student":
                    lblRoleId.Text = "3";
                    break;
            }
            cmd.Parameters.AddWithValue("@RoleId", lblRoleId.Text);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                this.ClearFields();
                lblMsg.Text = "User has been added.";
            }
            conn.Close();
            this.ShowUsers();
            this.BtnState1();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //Enzo
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("update Users set Email=@Email, Password=@Password, FirstName=@FirstName, LastName=@LastName, UAccess=@UAccess, RoleId=@RoleId where Id=@Id", conn);

            cmd.Parameters.AddWithValue("@Id", lblUId.Text);
            cmd.Parameters.AddWithValue("@Email", inputEmail.Value);
            cmd.Parameters.AddWithValue("@Password", inputPassword.Value);
            cmd.Parameters.AddWithValue("@FirstName", inputFirstName.Value);
            cmd.Parameters.AddWithValue("@LastName", inputLastName.Value);
            cmd.Parameters.AddWithValue("@UAccess", drpUAccess.Text);
            cmd.Parameters.AddWithValue("@RoleId", lblRoleId.Text);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                this.ClearFields();
                lblMsg.Text = "Member is updated!";
            }
            conn.Close();
            this.ShowUsers();
            this.BtnState1();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //Enzo
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("delete from Users where Id='" + lblUId.Text + "'", conn);

            conn.Open();
            cmd.ExecuteNonQuery();
            this.ClearFields();
            lblMsg.Text = "User has been deleted.";
            conn.Close();
            this.ShowUsers();
            this.BtnState1();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            int rowIndex = gdwUsers.SelectedIndex;
            lblUId.Text = gdwUsers.SelectedRow.Cells[1].Text;
            inputEmail.Value = gdwUsers.SelectedRow.Cells[2].Text;
            inputPassword.Value = gdwUsers.SelectedRow.Cells[3].Text;
            inputFirstName.Value = gdwUsers.SelectedRow.Cells[4].Text;
            inputLastName.Value = gdwUsers.SelectedRow.Cells[5].Text;
            drpUAccess.Text = gdwUsers.SelectedRow.Cells[6].Text;
            lblRoleId.Text = gdwUsers.SelectedRow.Cells[7].Text;
            this.BtnState2();
            lblMsg.Text = "";
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        protected void lgOff_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void drpUAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            string SelRole = drpUAccess.SelectedItem.Text;
            switch (SelRole)
            {
                case "Administrator":
                    lblRoleId.Text = "1";
                    break;
                case "Tutor":
                    lblRoleId.Text = "2";
                    break;
                case "Student":
                    lblRoleId.Text = "3";
                    break;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            //Enzo
            this.ClearFields();
            this.BtnState1();
            gdwUsers.SelectedIndex = -1;
        }

        protected void gdwUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Enzo
            int rowIndex = gdwUsers.SelectedIndex;
            lblUId.Text = gdwUsers.SelectedRow.Cells[1].Text;
            inputEmail.Value = gdwUsers.SelectedRow.Cells[2].Text;
            inputPassword.Value = gdwUsers.SelectedRow.Cells[3].Text;
            inputFirstName.Value = gdwUsers.SelectedRow.Cells[4].Text;
            inputLastName.Value= gdwUsers.SelectedRow.Cells[5].Text;
            drpUAccess.Text = gdwUsers.SelectedRow.Cells[6].Text;
            lblRoleId.Text = gdwUsers.SelectedRow.Cells[7].Text;
            this.BtnState2();
            lblMsg.Text = "";
        }
    }
}