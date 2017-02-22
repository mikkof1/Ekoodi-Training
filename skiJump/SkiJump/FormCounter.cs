using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkiJump
{
    public partial class FormCounter : Form
    {
        public FormCounter()
        {
            InitializeComponent();

            btnCalculatePoints.Text = "Aloita";
        }

        private void btnCalculatePoints_Click(object sender, EventArgs e)
        {
            bool startCup = btnCalculatePoints.Text == "Aloita";
            if (startCup)
            {
                FormJumpers jumpersForm = new FormJumpers();
                jumpersForm.ShowDialog();
                btnCalculatePoints.Text = "Laske pisteet";
            }

        }
    }
}
