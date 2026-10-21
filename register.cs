using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace Hospitalmngsystem
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text))
            {

                MessageBox.Show("Please fill in all required fields.");
            }
            else if (textBox5.Text == textBox6.Text)
            {
                patientdata();
                Form1 cdb = new Form1();
                cdb.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Password and Conform password dosen't match");
            }
        }
        public void patientdata()
        {
            string conString = "server=localhost; uid=root;pwd=1234; database=hospitalDB;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO patient (Name, Brithday, Gender, NIC ,Email,PhoneNumber,password) " +
                                   "VALUES (@name, @bday, @gender, @nic, @mail,@number,@pswd)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@bday", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@gender", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@nic", textBox2.Text);
                    cmd.Parameters.AddWithValue("@mail", textBox3.Text);
                    cmd.Parameters.AddWithValue("@number", textBox4.Text);
                    cmd.Parameters.AddWithValue("@pswd", textBox5.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("patient registered successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 cdb = new Form1();
            cdb.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
} 

