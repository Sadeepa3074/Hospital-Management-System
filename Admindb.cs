using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospitalmngsystem
{
    public partial class Admindb : Form
    {
        public Admindb()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AdminAppointment cdb = new AdminAppointment();
            cdb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Adminpatient adb = new Adminpatient();
            adb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 adb = new Form1();
            adb.Show();
            this.Hide();
        }
    }
}
