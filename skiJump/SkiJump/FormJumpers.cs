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
    public partial class FormJumpers : Form
    {
        public FormJumpers()
        {
            InitializeComponent();
            lbxJumpers.DisplayMember = "name";
        }

        private void btnAddJumper_Click(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty) return;

            Jumper newJumper= new Jumper();
            newJumper.name = txbName.Text;

            JumperManager jumperManager = new JumperManager();
            long idNumber =jumperManager.AddNewJumper(newJumper );
            lbxJumpers.Items.Add(newJumper);
            txbName.Text = "";
           
        }

        private void btnModifyJumper_Click(object sender, EventArgs e)
        {
            int listBoxIndex = lbxJumpers.SelectedIndex;
            bool itemIsSelected = listBoxIndex >= 0 && txbName.Text!=string.Empty;
            if (itemIsSelected)
            {
                Jumper jumper =(Jumper) lbxJumpers.Items[listBoxIndex];
                jumper.name = txbName.Text;

                JumperManager jumperManager = new JumperManager();
                jumperManager.ModifyJumper(jumper);
                refreshJumperListBox();
                txbName.Text = "";
                lbxJumpers.SelectedIndex = -1;
            }
        }

        private void refreshJumperListBox()
        {
            lbxJumpers.Items.Clear();
            JumperManager jumperManager = new JumperManager();
            List<Jumper> jumperList = jumperManager.GetJumperList();

            foreach (Jumper jumper in jumperList)
            {
                lbxJumpers.Items.Add(jumper);
            }
           
        }


    }
}
