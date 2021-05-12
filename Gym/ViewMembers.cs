using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gym
{
    public partial class ViewMembers : Form
    {
        public ViewMembers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void filterByID()
        {
            Con.Open();
            string query = "select * from KliensBerletei where kliens_id = '"+SearchByID.Text+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void clients()
        {
            Con.Open();
            string query = "select * from KliensBerletei";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void FillRentalName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select berlet_id from BerletTipusok where is_deleted = 0", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("berlet_id", typeof(string));
            dt.Load(rdr);
            BerletTypeDb.ValueMember = "berlet_id";
            BerletTypeDb.DataSource = dt;
            Con.Close();
        }

        private void ViewMembers_Load(object sender, EventArgs e)
        {
            clients();
            FillRentalName();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SearchByID.Text = "";
        }

        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.MemberSDGV.Rows[e.RowIndex];

                key = Convert.ToInt32(row.Cells["kliens_berletei_id"].Value.ToString());
                ClientIDTb.Text = row.Cells["kliens_id"].Value.ToString();
                BerletTypeDb.Text = row.Cells["berlet_id"].Value.ToString();
                dateTimePicker1.Text = row.Cells["vasarlasi_datum"].Value.ToString();
                dateTimePicker2.Text = row.Cells["ervenyesseg"].Value.ToString();


            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (key == 0 || ClientIDTb.Text == "" || BerletTypeDb.Text == "" || dateTimePicker1.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Hiányzó információ!");
            }
            else
            {
                try
                {
                    Random rnd = new Random();
                    int vonalkod = rnd.Next(99999);
                    Con.Open();
                    string query = "insert into KliensBerletei values ('" + ClientIDTb.Text + "', '" + BerletTypeDb.Text + "', '" + dateTimePicker1.Text + "','" + vonalkod + "','" + 0 + "','" + dateTimePicker2.Text + "')";          
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Sikeresen létrehozott egy új Bérletet a felhaszáló számára!");
                    Con.Close();
                    clients();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void kereses_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            filterByID();
        }
    }
}
