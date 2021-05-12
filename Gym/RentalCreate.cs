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
    public partial class RentalCreate : Form
    {
        public RentalCreate()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void EmailTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void megj_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            PriceTb.Text = "";
            DayTb.Text = "";
            NumberTb.Text = "";
            Time1Tb.Text = "";
            Time2Tb.Text = "";
            DayNumberTb.Text = "";

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button3_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PriceTb.Text == "" || DayTb.Text == "" || NumberTb.Text == "" || Time1Tb.Text == "" || Time2Tb.Text == "" || DayNumberTb.Text == "")
            {
                MessageBox.Show("Hiányzó információk!");
            }
            else
            {
                try
                {

                    Con.Open();
                    string query = "insert into BerletTipusok values('" + NameTb.Text + "','" + PriceTb.Text + "','" + DayTb.Text + "','" + NumberTb.Text + "','" + 0 + "','" + DayNumberTb.Text + "','" + Time1Tb.Text + "','" + Time2Tb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Új Bérlet Típus sikeresen hozzá adva!");
                    Con.Close();
                    NameTb.Text = "";
                    PriceTb.Text = "";
                    DayTb.Text = "";
                    NumberTb.Text = "";
                    Time1Tb.Text = "";
                    Time2Tb.Text = "";
                    DayNumberTb.Text = "";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
