using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dental_clinic
{
    public partial class doctor : Form
    {
        public doctor()
        {
            InitializeComponent();
        }

        void load()
        {
            string query = "select * from DTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            doctorDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from DTable where Doctor_Name like '%" + searchtab.Text + "%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            doctorDVG.DataSource = ds.Tables[0];
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            string query = "insert into DTable values('" + DName.Text + "','" + DPhone.Text + "','" + DSpec.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Doctor Added Successfully...!");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;
        private void doctorDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DName.Text = doctorDVG.SelectedRows[0].Cells[1].Value.ToString();
            DPhone.Text = doctorDVG.SelectedRows[0].Cells[2].Value.ToString();
            DSpec.Text = doctorDVG.SelectedRows[0].Cells[3].Value.ToString();
            if (DName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(doctorDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void doctor_Load(object sender, EventArgs e)
        {
            load();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select the Doctor");
            }
            else
            {
                try
                {
                    string query = "Delete from DTable where Doctor_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Doctor Removed Successfully...!");
                    load();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select the Doctor");
            }
            else
            {
                try
                {
                    string query = "Update DTable set Doctor_Name='" + DName.Text + "',Doctor_Phone='" + DPhone.Text + "',Doctor_Speciality='" + DSpec.Text + "' where Doctor_Id = " + key + "";
                    Pat.EditPatient(query);
                    MessageBox.Show("Doctor Updated Successfully...!");
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            dashbord dash = new dashbord();
            dash.Show();
            this.Hide();
        }

        private void label4_Click_1(object sender, EventArgs e)
        {
            appoinment app = new appoinment();
            app.Show();
            this.Hide();
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

        private void label9_Click(object sender, EventArgs e)
        {
            pharmacy par = new pharmacy();
            par.Show();
            this.Hide();
        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }
    }
}
