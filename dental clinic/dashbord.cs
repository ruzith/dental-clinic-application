using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dental_clinic
{
    public partial class dashbord : Form
    {
        public dashbord()
        {
            InitializeComponent();
        }
        ConnectionString MyConnection = new ConnectionString();
        private void dashbord_Load(object sender, EventArgs e)
        {
            PendingAppProgress.Value = 100;
            Patients.Value = 100;
            UsersProgress.Value = 100;
            NextApp.Value = 100;
            SqlConnection Con = MyConnection.GetCon();
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select count(*) from ATable", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Pendinglbl.Text = dt.Rows[0][0].ToString();
            SqlDataAdapter sdal = new SqlDataAdapter("select count(*) from PTable", Con);
            DataTable dtl = new DataTable();
            sdal.Fill(dtl);
            Patientlbl.Text = dtl.Rows[0][0].ToString();
            SqlDataAdapter sda2 = new SqlDataAdapter("select count(*) from UTable", Con);
            DataTable dt2 = new DataTable();
            sda2.Fill(dt2);
            Userlbl.Text = dt2.Rows[0][0].ToString();
            SqlDataAdapter sda3 = new SqlDataAdapter("select min(Appointment_Date) from ATable", Con);
            DataTable dt3= new DataTable();
            sda3.Fill(dt3);
            NextApplbl.Text = dt3.Rows[0][0].ToString();
            Con.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NextApplbl_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            appoinment app = new appoinment();
            app.Show();
            this.Hide();
        }
    }
}
