using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace dental_clinic
{
    public partial class Prescription : Form
    {
        public Prescription()
        {
            InitializeComponent();
        }

        ConnectionString MyCon = new ConnectionString();

        private void fillpatient()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Patient from ATable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Patient", typeof(string));
            dat.Load(rdr);
            PID.ValueMember = "Patient";
            PID.DataSource = dat;
            Con.Close();
        }
        private void filltreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Treatment from TTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Patient", typeof(string));
            dat.Load(rdr);
            PID.ValueMember = "Patient";
            PID.DataSource = dat;
            Con.Close();
        }
        private void gettreatment()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from ATable where Patient='" + PID.SelectedValue.ToString() + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TreatmentCb.Text = dr["Treatment"].ToString();
            }
            Con.Close();
        }
        private void getcost()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from TTable where Treatment_Name='" + TreatmentCb.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                TreatmetnCostCb.Text = dr["Treatment_Cost"].ToString();
            }
            Con.Close();
        }
        private void fillmedicine()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Medicine_Name from MTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Medicine_Name", typeof(string));
            dat.Load(rdr);
            MID.ValueMember = "Medicine_Name";
            MID.DataSource = dat;
            Con.Close();
        }
        private void fillmmedicine()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Medicine_Name from MTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Medicine_Name", typeof(string));
            dat.Load(rdr);
            MMID.ValueMember = "Medicine_Name";
            MMID.DataSource = dat;
            Con.Close();
        }
        private void fillmmmedicine()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Medicine_Name from MTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Medicine_Name", typeof(string));
            dat.Load(rdr);
            MMMID.ValueMember = "Medicine_Name";
            MMMID.DataSource = dat;
            Con.Close();
        }
        private void fillmmmmedicine()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select Medicine_Name from MTable", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dat = new DataTable();
            dat.Columns.Add("Medicine_Name", typeof(string));
            dat.Load(rdr);
            MMMMID.ValueMember = "Medicine_Name";
            MMMMID.DataSource = dat;
            Con.Close();
        }
        private void getmedcost()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from MTable where Medicine_Name='" + MID.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MCostTb.Text = dr["Medicine_Cost"].ToString();
            }
            Con.Close();
        }
        private void getmmedcost()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from MTable where Medicine_Name='" + MMID.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MMCostTb.Text = dr["Medicine_Cost"].ToString();
            }
            Con.Close();
        }
        private void getmmmedcost()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from MTable where Medicine_Name='" + MMMID.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MMMCostTb.Text = dr["Medicine_Cost"].ToString();
            }
            Con.Close();
        }
        private void getmmmmedcost()
        {
            SqlConnection Con = MyCon.GetCon();
            Con.Open();
            SqlCommand cmd = new SqlCommand("select * from MTable where Medicine_Name='" + MMMMID.Text + "'", Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                MMMMCostTb.Text = dr["Medicine_Cost"].ToString();
            }
            Con.Close();
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Prescription_Load(object sender, EventArgs e)
        {
            fillpatient();
            fillmedicine();
            fillmmedicine();
            fillmmmedicine();
            fillmmmmedicine();
            load();
        }

        private void PID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            gettreatment();
        }

        private void TreatmentCb_TextChanged(object sender, EventArgs e)
        {
            getcost();
        }

        void load()
        {
            string query = "select * from PresTable";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            prescriptionDVG.DataSource = ds.Tables[0];
        }
        void search()
        {
            string query = "select * from PresTable where Patient_Name like '%" + searchtab.Text + "%'";
            MyPatient Pat = new MyPatient();
            DataSet ds = Pat.DisplayPatient(query);
            prescriptionDVG.DataSource = ds.Tables[0];
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string query = "insert into PresTable values('" + PID.SelectedValue.ToString() + "','" + TreatmentCb.Text + "','" + TreatmetnCostCb.Text + "','" + MID.SelectedValue.ToString() + "," + MMID.SelectedValue.ToString() + "," + MMMID.SelectedValue.ToString() + "," + MMMMID.SelectedValue.ToString() + "','" + QtyTb.Text + ","+QQtyTb.Text+ "," + QQQtyTb.Text + "," + QQQQtyTb.Text + " ','" + ZCostTb.Text + "','" + TTCostTb.Text + "')";
            MyPatient Pat = new MyPatient();
            try
            {
                Pat.AddPatient(query);
                MessageBox.Show("Prescription Added...!");
                load();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        int key = 0;
        private void prescriptionDVG_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            PID.SelectedValue = prescriptionDVG.SelectedRows[0].Cells[1].Value.ToString();
            TreatmentCb.Text = prescriptionDVG.SelectedRows[0].Cells[2].Value.ToString();
            TreatmetnCostCb.Text = prescriptionDVG.SelectedRows[0].Cells[3].Value.ToString();
            MID.SelectedValue = prescriptionDVG.SelectedRows[0].Cells[4].Value.ToString();
            QtyTb.Text = prescriptionDVG.SelectedRows[0].Cells[5].Value.ToString();
            ZCostTb.Text = prescriptionDVG.SelectedRows[0].Cells[6].Value.ToString();
            TTCostTb.Text = prescriptionDVG.SelectedRows[0].Cells[7].Value.ToString();
            if (TreatmentCb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(prescriptionDVG.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            MyPatient Pat = new MyPatient();
            if (key == 0)
            {
                MessageBox.Show("Select The Prescription");
            }
            else
            {
                try
                {
                    string query = "Delete from PresTable where Prescription_Id=" + key + "";
                    Pat.RemovePatient(query);
                    MessageBox.Show("Prescription Removed...!");
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void PID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TreatmetnCostCb_TextChanged(object sender, EventArgs e)
        {

        }

        private void MID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmedcost();
        }

        private void MMCostTb_TextChanged(object sender, EventArgs e)
        { 

        }

        private void label10_Click_1(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QtyTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ZCostTb.Text = (float.Parse(MCostTb.Text) * float.Parse(QtyTb.Text)).ToString();
            }
            catch
            {

            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ZCostTb.Text = ((float.Parse(MCostTb.Text) * float.Parse(QtyTb.Text)) + (float.Parse(MMCostTb.Text) * float.Parse(QQtyTb.Text)) + (float.Parse(MMMCostTb.Text) * float.Parse(QQQtyTb.Text))).ToString();
            }
            catch
            {

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void TTCostTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
                    }

        private void QQtyTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ZCostTb.Text = ((float.Parse(MCostTb.Text) * float.Parse(QtyTb.Text)) + (float.Parse(MMCostTb.Text) * float.Parse(QQtyTb.Text))).ToString();
            }
            catch
            {

            }
        }

        private void QQQQtyTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ZCostTb.Text = ((float.Parse(MCostTb.Text) * float.Parse(QtyTb.Text)) + (float.Parse(MMCostTb.Text) * float.Parse(QQtyTb.Text)) + (float.Parse(MMMCostTb.Text) * float.Parse(QQQtyTb.Text)) + (float.Parse(MMMMCostTb.Text) * float.Parse(QQQQtyTb.Text))).ToString();
            }
            catch
            {

            }
        }

        private void MMID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmmedcost();
        }

        private void MMMID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmmmedcost();
        }

        private void MMMMID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            getmmmmedcost();
        }

        private void XXXXCostTb_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void MMCostTb_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void ZCostTb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TTCostTb.Text = (float.Parse(TreatmetnCostCb.Text) + float.Parse(ZCostTb.Text)).ToString();
            }
            catch
            {

            }
        }

        Bitmap bitmap;

        public object PdfTable { get; private set; }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            int height = prescriptionDVG.Height;
            prescriptionDVG.Height = prescriptionDVG.RowCount * prescriptionDVG.RowTemplate.Height * 2;
            bitmap = new Bitmap(prescriptionDVG.Width, prescriptionDVG.Height);
            prescriptionDVG.DrawToBitmap(bitmap, new System.Drawing.Rectangle(0, 10, prescriptionDVG.Width, prescriptionDVG.Height));
            prescriptionDVG.Height = height;
            printPreviewDialog1.ShowDialog();

            
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            dashbord dash = new dashbord();
            dash.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            appoinment app = new appoinment();
            app.Show();
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

        private void label9_Click_1(object sender, EventArgs e)
        {
            pharmacy par = new pharmacy();
            par.Show();
            this.Hide();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
           
        }
    }
}
