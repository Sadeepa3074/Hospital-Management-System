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

namespace Hospitalmngsystem
{
    public partial class Adminpatient : Form
    {
        public Adminpatient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            patients();
        }
        MySqlDataAdapter dataAdapter;
        DataTable dataTable;
        private void patients()
        {
            string connStr = "server=localhost;user=root;password=1234;database=hospitalDB;";
            MySqlConnection conn = new MySqlConnection(connStr);

            try
            {
                conn.Open();
                string query = "SELECT * FROM patient";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                dataAdapter = new MySqlDataAdapter(cmd);
                MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter);

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                dataAdapter.Update(dataTable);
                MessageBox.Show("Changes saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save changes: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admindb adb = new Admindb();
            adb.Show();
            this.Hide();
        }
    }
}
