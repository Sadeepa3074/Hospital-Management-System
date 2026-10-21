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
    public partial class patientDashboard : Form
    {
        public patientDashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Addappoiment cdb = new Addappoiment();
            cdb.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edituserdata cdb = new edituserdata();
            cdb.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 cdb = new Form1();
            cdb.Show();
            this.Hide();
        }
    }
}
