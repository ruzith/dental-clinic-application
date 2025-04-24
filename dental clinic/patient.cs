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
    public partial class patient : Form
    {
        public patient()
        {
            InitializeComponent();
        }

        void load()
        {
            string query = "select * from PTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            patientDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from PTable where Patient_Name like '%"+searchtab.Text+"%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            patientDVG.DataSource = ds.Tables[0];
        }
        private void patient_Load(object sender, EventArgs e)
        {
            load();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into PTable values('" + PNameTb.Text + "','" + PPhoneTb.Text + "','" + AddressTb.Text + "','" + DOBDate.Value.Date + "','" + GenCb.SelectedItem.ToString() + "','" + AllergyTb.Text + "','" + SymptomTb.Text + "','" + MailTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Patient added Successfully...!");
                load();
            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        int key = 0;
        private void patientDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PNameTb.Text = patientDVG.SelectedRows[0].Cells[1].Value.ToString();
            PPhoneTb.Text = patientDVG.SelectedRows[0].Cells[2].Value.ToString();
            AddressTb.Text = patientDVG.SelectedRows[0].Cells[3].Value.ToString();
            GenCb.Text = patientDVG.SelectedRows[0].Cells[5].Value.ToString();            
            AllergyTb.Text = patientDVG.SelectedRows[0].Cells[6].Value.ToString();
            SymptomTb.Text = patientDVG.SelectedRows[0].Cells[7].Value.ToString();
            MailTb.Text = patientDVG.SelectedRows[0].Cells[8].Value.ToString();
            if (PNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(patientDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            
            MyPatient Pat = new MyPatient();
            if(key == 0)
            {
                MessageBox.Show("Select the Patient");
            }
            else
            {
                try
                {
                    string query = "Delete from PTable where Patient_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Patient Removed Successfully...!");
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
                MessageBox.Show("Select the Patient");
            }
            else
            {
                try
                {
                    string query = "Update PTable set Patient_Name='"+PNameTb.Text+"',Patient_Phone='"+PPhoneTb.Text+"',Patient_Address='"+AddressTb.Text+"',Patient_DOB='"+DOBDate.Value.Date+"',Patient_Gender='"+GenCb.SelectedItem.ToString()+"',Patient_Allergies='"+AllergyTb.Text+"',Patient_Symptoms='"+SymptomTb.Text+"',Patient_Email='"+MailTb.Text+"' where Patient_Id = "+key+"";
                    Pat.EditPatient(query);
                    MessageBox.Show("Patient Updated Successfully...!");
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            appoinment app = new appoinment();
            app.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            dashbord dash = new dashbord();
            dash.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Prescription pre = new Prescription();
            pre.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
        {
            pharmacy par = new pharmacy();
            par.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            login log  = new login();
            log.Show();
            this.Hide();
        }
    }
}
