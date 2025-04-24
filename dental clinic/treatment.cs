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
    public partial class treatment : Form
    {
        public treatment()
        {
            InitializeComponent();
        }
        void load()
        {
            string query = "select * from TTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            treatmentDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from TTable where Treatment_Name like '%" + searchtab.Text + "%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            treatmentDVG.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into TTable values('" + TNameTb.Text + "','" + TDesTb.Text + "'," + TCostTb.Text + ")";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Treatment added Successfully...!");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void treatment_Load(object sender, EventArgs e)
        {
            load();
        }

        int key = 0;
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select the Treatment");
            }
            else
            {
                try
                {
                    string query = "Update TTable set Treatment_Name='" + TNameTb.Text + "',Treatment_Description='" + TDesTb.Text + "',Treatment_Cost='" + TCostTb.Text + "' where Treatment_Id = " + key + "";
                    Pat.EditPatient(query);
                    MessageBox.Show("Treatment Updated Successfully...!");
                    load();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select the Treatment");
            }
            else
            {
                try
                {
                    string query = "Delete from TTable where Treatment_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Treatment Removed Successfully...!");
                    load();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void treatmentDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TNameTb.Text = treatmentDVG.SelectedRows[0].Cells[1].Value.ToString();
            TDesTb.Text = treatmentDVG.SelectedRows[0].Cells[2].Value.ToString();
            TCostTb.Text = treatmentDVG.SelectedRows[0].Cells[3].Value.ToString();
            if (TNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(treatmentDVG.SelectedRows[0].Cells[0].Value.ToString());
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

        private void label1_Click(object sender, EventArgs e)
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
