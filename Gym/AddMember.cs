using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Gym
{
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        string hanynapigervenyesKey_id;
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
            hanynapigervenyesKey_id = BerletTypeDb.ValueMember;
            BerletTypeDb.DataSource = dt;
            Con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void AddMember_Load(object sender, EventArgs e)
        {
            FillRentalName();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NameTb.Text == "" || PhoneTb.Text == "" || AddresTb.Text == "" || CNPTb.Text == "" || EmailTb.Text == "")
            {
                MessageBox.Show("Hiányzó információk!");
            }
            else
            {
                try
                {
                    Random rnd = new Random();
                    int vonalkod = rnd.Next(99999);
                    Con.Open();
                    string query = "insert into Kliensek values('"+NameTb.Text+"','"+PhoneTb.Text+"','"+EmailTb.Text+"','"+0+"','"+ dateTimePicker1.Text + "','"+CNPTb.Text+"','"+AddresTb.Text+"','" + vonalkod + "','" + CommentTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("A Kliens sikeresen hozzá lett addva!");
                    Con.Close();



                    Con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter("select Kliens_id from Kliensek where Kliens_id=(select max(Kliens_id) from Kliensek)", Con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    string klient_id_nr = dt.Rows[0][0].ToString();
                    Con.Close();


                    Con.Open();
                    //string hanynapigervenyes = "select a.Ervenyesseg+b.hanynapigervenyes from BerletTipusok b join KliensBerletei a on a.berlet_id = b.berlet_id where berlet_id = " + hanynapigervenyesKey_id + "";
                    string query2 = "insert into KliensBerletei values('"+ klient_id_nr + "','" + BerletTypeDb.Text + "','" + dateTimePicker1.Text + "','" + vonalkod + "','" + 0 + "','" + dateTimePicker2.Text + "')";
                    SqlCommand cmd2 = new SqlCommand(query2, Con);
                    cmd2.ExecuteNonQuery();
                    Con.Close();


                    AddresTb.Text = "";
                    CNPTb.Text = "";
                    CommentTb.Text = "";
                    EmailTb.Text = "";
                    NameTb.Text = "";
                    PhoneTb.Text = "";
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddresTb.Text = "";
            CNPTb.Text = "";
            CommentTb.Text = "";
            EmailTb.Text = "";
            NameTb.Text = "";
            PhoneTb.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();
        }

        private void NameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void BerletTypeDb_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
