using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace dental_clinic
{
    public partial class appoinment : Form
    {
        public appoinment()
        {
            InitializeComponent();
        }
        ConnectionString MyCon = new ConnectionString();

        private void fillpatient()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Patient_Name from PTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Patient_Name", typeof(string));
            dat.Load(rdr);
            PatientCb.ValueMember = "Patient_Name";
            PatientCb.DataSource = dat;
            Con.Close();
        }

        private void filltreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Treatment_Name from TTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Treatment_Name", typeof(string));
            dat.Load(rdr);
            TreatmentCb.ValueMember = "Treatment_Name";
            TreatmentCb.DataSource = dat;
            Con.Close();
        }
        private void filldoctor()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Doctor_Name from DTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Doctor_Name", typeof(string));
            dat.Load(rdr);
            DoctorCb.ValueMember = "Doctor_Name";
            DoctorCb.DataSource = dat;
            Con.Close();
        }
        private void label8_Click(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                    }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void appoinment_Load(object sender, EventArgs e)
        {
            fillpatient();
            filltreatment();
            filldoctor();
            load();
        }

        void load()
        {
            string query = "select * from ATable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            appointmentDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from ATable where Patient like '%" + searchtab.Text + "%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            appointmentDVG.DataSource = ds.Tables[0];
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into ATable values('" + PatientCb.SelectedValue.ToString() + "','" + TreatmentCb.SelectedValue.ToString() + "','" + ADate.Value.Date + "','"+ATime.Value.TimeOfDay+ "','" + DoctorCb.SelectedValue.ToString() + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Appointment Booked");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select An Appointment");
            }
            else
            {
                try
                {
                    string query = "Update ATable set Patient='" + PatientCb.SelectedValue.ToString() + "',Treatment='" + TreatmentCb.SelectedValue.ToString() + "',Appointment_Date='" + ADate.Value.Date + "',Appointment_Time='"+ATime.Value.TimeOfDay+ "',Doctor='" + TreatmentCb.SelectedValue.ToString() + "' where Appointment_Id = " + key + "";
                    Pat.EditPatient(query);
                    MessageBox.Show("Appointment Updated Successfully...!");
                    load();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ATime_ValueChanged(object sender, EventArgs e)
        {

        }

        int key = 0;
        private void appointmentDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PatientCb.SelectedValue = appointmentDVG.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentCb.SelectedValue = appointmentDVG.SelectedRows[0].Cells[2].Value.ToString();
            DoctorCb.SelectedValue = appointmentDVG.SelectedRows[0].Cells[3].Value.ToString();
            string pat = appointmentDVG.SelectedRows[0].Cells[4].Value.ToString();
            if (pat == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(appointmentDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select An Appointment");
            }
            else
            {
                try
                {
                    string query = "Delete from ATable where Appointment_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Appointment Cancelled...!");
                    load();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void searchtab_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void guna2PictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription pre = new Prescription();
            pre.Show();
            this.Hide();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            treatment treat = new treatment();
            treat.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            doctor doc = new doctor();
            doc.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            pharmacy par = new pharmacy();
            par.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {
            dashbord dash = new dashbord();
            dash.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
