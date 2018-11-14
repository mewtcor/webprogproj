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
    public partial class Class : System.Web.UI.Page
    {
        //Maikel
        private string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
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
                if (!this.IsPostBack)
                {
                    this.ShowClass();
                }
            }
            else
            {
                Response.Redirect("~/401.aspx");
                return;
            }
            this.PopulateTutorsLst();
            this.BtnState1();
        }
        public void PopulateTutorsLst()
        {
            //Enzo
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Tutors", conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            conn.Open();
            SqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                if (Page.IsPostBack == false)
                {
                    drpLstTutors.DataSource = rdr;
                    drpLstTutors.DataTextField = "Tutor";
                    drpLstTutors.DataValueField = "Id";
                    drpLstTutors.DataBind();
                    drpLstTutors.Items.Insert(0, new ListItem(string.Empty, String.Empty));
                    drpLstTutors.SelectedIndex = 0;
                }
            }
        }
        public void ShowClass()
            //Maikel
        {
            string constr = ConfigurationManager.ConnectionStrings["AMSConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Class"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gdwClass.DataSource = dt;
                            gdwClass.DataBind();
                        }
                    }
                }
            }
        }
        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Maikel
            this.ShowClass();
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Enzo
            SessionManager.LogOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            //Enzo
            lblCurrentTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        protected void gdwClassSched_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Maikel
            int rowIndex = gdwClass.SelectedIndex;
            lblClass.Text = gdwClass.SelectedRow.Cells[1].Text;
            txtClass.Text = gdwClass.SelectedRow.Cells[2].Text;
            DropDownListStt.SelectedItem.Text = gdwClass.SelectedRow.Cells[3].Text;
            txtDate.Text = gdwClass.SelectedRow.Cells[4].Text;
            txtStartTime.Text = gdwClass.SelectedRow.Cells[5].Text;
            txtEndTime.Text = gdwClass.SelectedRow.Cells[6].Text;
            txtHours.Text = gdwClass.SelectedRow.Cells[7].Text;
            if (gdwClass.SelectedRow.Cells[8].Text == "&nbsp;")
            {
                txtPractical.Text = "";
            }
            else
            {
                txtPractical.Text = gdwClass.SelectedRow.Cells[8].Text;
            }
            if (gdwClass.SelectedRow.Cells[9].Text == "&nbsp;")
            {
                txtTheory.Text = "";
            }
            else
            {
                txtTheory.Text = gdwClass.SelectedRow.Cells[9].Text;

            }
            txtEnrolments.Text = gdwClass.SelectedRow.Cells[10].Text;
            txtVenue.Text = gdwClass.SelectedRow.Cells[12].Text;
            this.BtnState2();
            drpLstTutors.Visible = false;
            txtTrainerEmail.Visible = false;
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Maikel
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("update Class set ClassName=@ClassName, Status=@Status, Date=@Date, StartTime=@StartTime, EndTime=@EndTime, Hours=@Hours, Practical=@Practical, Theory=@Theory, Enrolments=@Enrolments, Trainer=@Trainer, Venue=@Venue where Id=@Id", conn);

            cmd.Parameters.AddWithValue("@Id", lblClass.Text);
            cmd.Parameters.AddWithValue("@ClassName", txtClass.Text);
            cmd.Parameters.AddWithValue("@Status", DropDownListStt.Text);
            cmd.Parameters.AddWithValue("@Date", txtDate.Text);
            cmd.Parameters.AddWithValue("@StartTime", txtStartTime.Text);
            cmd.Parameters.AddWithValue("@EndTime", txtEndTime.Text);
            cmd.Parameters.AddWithValue("@Hours", txtHours.Text);
            cmd.Parameters.AddWithValue("@Practical", txtPractical.Text);
            cmd.Parameters.AddWithValue("@Theory", txtTheory.Text);
            cmd.Parameters.AddWithValue("@Enrolments", txtEnrolments.Text);
            cmd.Parameters.AddWithValue("@Trainer", drpLstTutors.Text);
            cmd.Parameters.AddWithValue("@Venue", txtVenue.Text);
            cmd.Parameters.AddWithValue("@TrainerEmail", txtTrainerEmail.Text);

            conn.Open();
            if (cmd.ExecuteNonQuery() == 1)
            {
                lblMSG.Text = "Member is updated!";
            }
            conn.Close();
            this.ShowClass();
            this.ClearFields();
            this.BtnState1();
            txtTrainerEmail.Visible = true;
            drpLstTutors.Visible = true;
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            //Maikel
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("delete from Class where Id='" + lblClass.Text + "'", conn);
            
            conn.Open();

            cmd.ExecuteNonQuery();
            this.ClearFields();
            lblMSG.Text = "User has been deleted.";
            conn.Close();
            this.ShowClass();
            this.ClearFields();
            this.BtnState1();
            drpLstTutors.Visible = true;
            txtTrainerEmail.Visible = true;
        }
        public void ClearFields()
        {
            //Maikel
            lblMSG.Text = "";
            lblClass.Text = "";
            txtClass.Text = "";
            DropDownListStt.SelectedIndex = 0;
            txtDate.Text = "";
            txtStartTime.Text = "";
            txtEndTime.Text = "";
            txtHours.Text = "";
            txtPractical.Text = "";
            txtTheory.Text = "";
            txtEnrolments.Text = "";
            txtTrainerEmail.Text = "";
            txtVenue.Text = "";
            drpLstTutors.SelectedIndex = 0;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            //Maikel
            conn = new SqlConnection(connstr);
            cmd = new SqlCommand("INSERT into Class (ClassName, Status, Date, StartTime, EndTime, Hours, Practical, Theory, Enrolments, Trainer, Venue, AttStatus, TrainerEmail) values (@ClassName, @Status, @Date, @StartTime, @EndTime, @Hours, @Practical, @Theory, @Enrolments, @Trainer, @Venue, @AttStatus, @TrainerEmail)", conn);
            cmd.Parameters.AddWithValue("@ClassName", txtClass.Text);
            cmd.Parameters.AddWithValue("@Status", DropDownListStt.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@Date", txtDate.Text.Trim());
            cmd.Parameters.AddWithValue("@StartTime", txtStartTime.Text);
            cmd.Parameters.AddWithValue("@EndTime", txtEndTime.Text);
            cmd.Parameters.AddWithValue("@Hours", float.Parse(txtHours.Text));
            cmd.Parameters.AddWithValue("@Practical", txtPractical.Text);
            cmd.Parameters.AddWithValue("@Theory", txtTheory.Text);
            cmd.Parameters.AddWithValue("@Enrolments", txtEnrolments.Text);
            cmd.Parameters.AddWithValue("@Trainer", drpLstTutors.Text);
            cmd.Parameters.AddWithValue("@Venue", txtVenue.Text);
            cmd.Parameters.AddWithValue("@AttStatus", 0);
            cmd.Parameters.AddWithValue("@TrainerEmail", txtTrainerEmail.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            lblClass.Text = "Class has been added.";
            this.ShowClass();
            this.BtnState1();
            this.ClearFields();
            txtClass.Focus();
            drpLstTutors.Visible = true;
            txtTrainerEmail.Visible = true;

            conn.Close();
        }
        public void BtnState1()
        {
            //Maikel
            BtnSave.Enabled = true;
            BtnDelete.Enabled = false;
            BtnUpdate.Enabled = false;
        }
        public void BtnState2()
        {
            //Maikel
            BtnSave.Enabled = false;
            BtnDelete.Enabled = true;
            BtnUpdate.Enabled = true;
        }

        protected void PopulateTxt(object sender, EventArgs e)
        {
            //Enzo
            int num = Int32.Parse(drpLstTutors.Text);

            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand("select Email from Tutors where Id = @Id", conn);
            cmd.Parameters.AddWithValue("@Id", num);

            conn.Open();
            object o = cmd.ExecuteScalar();
            {
                string TutEmail = o.ToString();
                txtTrainerEmail.Text = TutEmail;
            }
        }

        protected void gdwClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Maikel
            int rowIndex = gdwClass.SelectedIndex;
            lblClass.Text = gdwClass.SelectedRow.Cells[1].Text;
            txtClass.Text = gdwClass.SelectedRow.Cells[2].Text;
            DropDownListStt.SelectedItem.Text = gdwClass.SelectedRow.Cells[3].Text;
            txtDate.Text = gdwClass.SelectedRow.Cells[4].Text;
            txtStartTime.Text = gdwClass.SelectedRow.Cells[5].Text;
            txtEndTime.Text = gdwClass.SelectedRow.Cells[6].Text;
            txtHours.Text = gdwClass.SelectedRow.Cells[7].Text;
            txtEnrolments.Text = gdwClass.SelectedRow.Cells[8].Text;
            txtVenue.Text = gdwClass.SelectedRow.Cells[10].Text;
            this.BtnState2();
            drpLstTutors.Visible = false;
            txtTrainerEmail.Visible = false;
        }
    }
}