using System;
using System.Windows.Forms;

namespace Kolko_i_krzyzyk
{
    public partial class FormController : Form
    {
        public FormController()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Invoke(Form1.Instance.Visible
                ? (() => Form1.Instance.Hide())
                : new Action(() => Form1.Instance.Show()));
        }

        private void FormController_Load(object sender, EventArgs e)
        {
            Invoke(new Action(() => Form1.Instance.Hide()));
        }
    }
}
