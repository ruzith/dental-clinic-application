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
    public partial class pharmacy : Form
    {
        public pharmacy()
        {
            InitializeComponent();
        }
        void load()
        {
            string query = "select * from MTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            medDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from MTable where Medicine_Name like '%" + searchtab.Text + "%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            medDVG.DataSource = ds.Tables[0];
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into MTable values('" + MedName.Text + "','" + MedCost.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Medicine Added");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void pharmacy_Load(object sender, EventArgs e)
        {
            load();
        }

        int key = 0;
        private void medDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MedName.Text = medDVG.SelectedRows[0].Cells[1].Value.ToString();
            MedCost.Text = medDVG.SelectedRows[0].Cells[2].Value.ToString();
            if (MedName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(medDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select the Medicine");
            }
            else
            {
                try
                {
                    string query = "Delete from MTable where Medicine_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Medicine Removed ");
                    load();
                }
                catch (Exception Ex)
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
                MessageBox.Show("Select the Medicine");
            }
            else
            {
                try
                {
                    string query = "Update MTable set Medicine_Name='" + MedName.Text + "',Medicine_Cost='" + MedCost.Text + "' where Medicine_Id = " + key + "";
                    Pat.EditPatient(query);
                    MessageBox.Show("Medicine Updated");
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

        private void label6_Click(object sender, EventArgs e)
        {
            dashbord dash = new dashbord();
            dash.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
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

        private void label3_Click(object sender, EventArgs e)
        {
            patient pat = new patient();
            pat.Show();
            this.Hide();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }
    }
}
