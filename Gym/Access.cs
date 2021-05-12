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
    public partial class Access : Form
    {
        public Access()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            IdTb.Text = "";
            CodeTb.Text = "";
        }

        private void Access_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                SqlDataAdapter sda3 = new SqlDataAdapter("select b.napontahanyszorhasznalhato from KliensBerletei k join BerletTipusok b on k.berlet_id = b.berlet_id where k.kliens_id = '" + IdTb.Text + "' and k.vonalkod = '" + CodeTb.Text + "'", Con);
                DataTable dt3 = new DataTable();
                sda3.Fill(dt3);
                string napontahanyszorhasznalhato = dt3.Rows[0][0].ToString();
                Con.Close();
                int napontahanyszorhasznalhato_int = Int32.Parse(napontahanyszorhasznalhato);

                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select EddigiBelepesszam from KliensBerletei where kliens_id = '" + IdTb.Text + "' and vonalkod = '" + CodeTb.Text + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                string belepesszam = dt.Rows[0][0].ToString();
                Con.Close();

                int belepesszam_int = Int32.Parse(belepesszam);
                if (belepesszam_int >= napontahanyszorhasznalhato_int)
                {
                    MessageBox.Show("A berlete lejart!!!!!");
                }
                else
                {
                    belepesszam_int = belepesszam_int + 1;
                    Con.Open();
                    string query = "Update KliensBerletei set EddigiBelepesszam ='" + belepesszam_int + "' where kliens_id = " + IdTb.Text + " and vonalkod = " + CodeTb.Text + ";";
                    SqlCommand cmd1 = new SqlCommand(query, Con);
                    cmd1.ExecuteNonQuery();
                    Con.Close();
                    int x = napontahanyszorhasznalhato_int - belepesszam_int;
                    if (x < 4)
                    {
                        MessageBox.Show("A bérlete hamarosan lejár! Hátralévő belépések száma: " + x + "!!!!");
                    }
                    else MessageBox.Show("Hatralevő Belépések száma: " + x + " ");
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Helytelen ID vagy Vonalkód!!!!");
            }
        }
    }
}
