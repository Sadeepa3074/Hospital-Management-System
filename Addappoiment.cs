using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Hospitalmngsystem
{
    public partial class Addappoiment : Form
    {
        public Addappoiment()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comboBox1.Text) ||
                string.IsNullOrWhiteSpace(comboBox2.Text))
            {

                MessageBox.Show("Please fill in all required fields.");
            }
            else
            {
                Appointmentdb();

            }
        }
        public void Appointmentdb()
        {
            int pid = patientididUni.patientId;
            string conString = "server=localhost; uid=root;pwd=1234; database=hospitalDB;";
            using (MySqlConnection con = new MySqlConnection(conString))
            {
                try
                {
                    con.Open();

                    string query = "INSERT INTO Appointment (Docname,PatientID, date, time ,note) " +
                                   "VALUES (@name, @id, @date, @time, @note)";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@name", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@id", pid);
                    cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@time", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@note", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Appointment Made successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            patientDashboard cdb = new patientDashboard();
            cdb.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Addappoiment_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

