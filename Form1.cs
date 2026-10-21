using Microsoft.VisualBasic.ApplicationServices;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;

namespace Hospitalmngsystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            String pass = textBox2.Text;
            if ((name == "admin") && (pass == "admin123"))
            {
                Admindb adb = new Admindb();
                adb.Show();
                this.Hide();
            }
            else if ((name == "doc1") && (pass == "1234"))
            {
                docAppointment f2 = new docAppointment();
                f2.Username = "Dr. Gotabaya Ranasinghe";
                f2.Show();
                this.Hide();
            }
            else if ((name == "doc2") && (pass == "123"))
            {
                docAppointment f2 = new docAppointment();
                f2.Username = "Dr. Asoka Kamaladasa";
                f2.Show();
                this.Hide();
            }
            else if ((name == "doc3") && (pass == "12"))
            {
                docAppointment f2 = new docAppointment();
                f2.Username = "Dr. Dulmini Anjani";
                f2.Show();
                this.Hide();
            }
            else
            {
                string connStr = "server=localhost;user=root;password=1234;database=hospitalDB;";
                string query = "SELECT patientid FROM patient WHERE Name = @user AND password = @pass";

                using (MySqlConnection conn = new MySqlConnection(connStr))
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@user", name);
                    cmd.Parameters.AddWithValue("@pass", pass);

                    conn.Open();
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        int patientId = reader.GetInt32(0);
                        patientididUni.patientId = patientId;
                        patientDashboard adb = new patientDashboard();
                        adb.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.");
                    }
                }
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            register adb = new register();
            adb.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
