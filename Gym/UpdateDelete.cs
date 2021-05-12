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
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void clients()
        {
            Con.Open();
            string query = "select * from Kliensek where is_deleted = 0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            clients();
        }

        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow row = this.MemberSDGV.Rows[e.RowIndex];

                key = Convert.ToInt32(row.Cells["Kliens_id"].Value.ToString());
                NameTb.Text = row.Cells["nev"].Value.ToString();
                PhoneTb.Text = row.Cells["telefon"].Value.ToString();
                EmailTb.Text = row.Cells["email"].Value.ToString();
                CNPTb.Text = row.Cells["szemelyi"].Value.ToString();
                AddressTb.Text = row.Cells["cim"].Value.ToString();
                CommentTb.Text = row.Cells["megjegyzesek"].Value.ToString();
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Válassza ki a törülni kívánt elemet!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Kliensek set is_deleted = 1 where Kliens_id =" + key + ";";
                    //string query = "delete from Kliensek where Kliens_id=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A Klines sikeresen törölve lett!");
                    Con.Close();
                    button4_Click(sender, e);
                    clients();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddressTb.Text = "";
            CNPTb.Text = "";
            CommentTb.Text = "";
            EmailTb.Text = "";
            NameTb.Text = "";
            PhoneTb.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || AddressTb.Text == "" || CNPTb.Text == "" || EmailTb.Text == "")
            {
                MessageBox.Show("Hiányzó információ!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update Kliensek set nev='" + NameTb.Text + "', telefon='" + PhoneTb.Text + "', email='" + EmailTb.Text + "', cim='" + AddressTb.Text + "', szemelyi='" + CNPTb.Text + "' , megjegyzesek ='" + CommentTb.Text + "' where Kliens_id = "+key+";";
                    //string query = "delete from Kliensek where Kliens_id=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A Klines sikeresen frissítve lett!");
                    Con.Close();
                    clients();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
