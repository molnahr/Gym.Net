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
    public partial class RentalDeleteUpdate : Form
    {
        public RentalDeleteUpdate()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void rentals()
        {
            Con.Open();
            string query = "select * from BerletTipusok where is_deleted =  0";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            MemberSDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void RentalDeleteUpdate_Load(object sender, EventArgs e)
        {
            rentals();
        }


        int key = 0;
        private void MemberSDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.MemberSDGV.Rows[e.RowIndex];

                key = Convert.ToInt32(row.Cells["berlet_id"].Value.ToString());
                NameTb.Text = row.Cells["megnevezes"].Value.ToString();
                PhoneTb.Text = row.Cells["ar"].Value.ToString();
                DayTb.Text = row.Cells["hanynapigervenyes"].Value.ToString();
                NumberTb.Text = row.Cells["hanybelepeservenyes"].Value.ToString();
                DayNumberTb.Text = row.Cells["napontahanyszorhasznalhato"].Value.ToString();
                Time1Tb.Text = row.Cells["hanyoratol"].Value.ToString();
                Time2Tb.Text = row.Cells["hanyoraig"].Value.ToString();
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || DayTb.Text == "" || Time1Tb.Text == "" || Time2Tb.Text == "" || NumberTb.Text == "" || DayTb.Text == "" || DayNumberTb.Text == "")
            {
                MessageBox.Show("Hiányzó információ!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update BerletTipusok set megnevezes='" + NameTb.Text + "', ar='" + PhoneTb.Text + "', hanynapigervenyes='" + DayTb.Text + "', hanybelepeservenyes='" + NumberTb.Text + "', napontahanyszorhasznalhato='" + DayNumberTb.Text + "' , hanyoratol ='" + Time1Tb.Text + "' , hanyoraig ='" + Time2Tb.Text + "' where berlet_id = " + key + ";";
                    //string query = "delete from Kliensek where Kliens_id=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A Bérlet sikeresen frissítve lett!");
                    Con.Close();
                    rentals();
                }
                catch (Exception Ex)
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
            NameTb.Text = "";
            PhoneTb.Text = "";
            DayTb.Text = "";
            NumberTb.Text = "";
            Time1Tb.Text = "";
            Time2Tb.Text = "";
            DayNumberTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Válassza ki a törülni kívánt elemet!");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "Update BerletTipusok set is_deleted = 1 where berlet_id =" + key + ";";
                    //string query = "delete from Kliensek where Kliens_id=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A Bétlet sikeresen törölve lett!");
                    Con.Close();
                    rentals();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void PhoneTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
