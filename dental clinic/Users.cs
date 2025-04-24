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
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        void load()
        {
            string query = "select * from UTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            UserDVG.DataSource = ds.Tables[0];
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into UTable values('" + UserNameTb.Text + "','" + utils.hashpassword(PasswordTb.Text)+ "','" + PhoneTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("New User added");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            load();
        }

        int key = 0;
        private void UserDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            UserNameTb.Text = UserDVG.SelectedRows[0].Cells[1].Value.ToString();
            PasswordTb.Text = UserDVG.SelectedRows[0].Cells[2].Value.ToString();
            PhoneTb.Text = UserDVG.SelectedRows[0].Cells[3].Value.ToString();
            if (UserNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(UserDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The User");
            }
            else
            {
                try
                {
                    string query = "Delete from UTable where User_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("User Removed");
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
                MessageBox.Show("Select The User");
            }
            else
            {
                try
                {
                    string query = "Update UTable set User_Name='" + UserNameTb.Text + "',User_Password='" + PasswordTb.Text + "',User_Phone='" + PhoneTb.Text + "' where User_Id = " + key + "";
                    Pat.EditPatient(query);
                    MessageBox.Show("User Updated");
                    load();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
