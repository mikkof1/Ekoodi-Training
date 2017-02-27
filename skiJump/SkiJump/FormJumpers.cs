﻿using System;
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
        JumperManager _jumperManager;
        List<Jumper> _jumperList;
        string _cupName;


        public FormJumpers(object jumperManager)
        {
            InitializeComponent();

            _jumperManager = (JumperManager)jumperManager;
            SetJumperListBox();
        }

        private void SetJumperListBox()
        {
            _jumperList = _jumperManager.GetJumperList();
            lbxJumpers.DisplayMember = "name";
            lbxJumpers.ValueMember = "id";
            refreshJumperListBox();
        }

        public string GetCupName()
        {
            _cupName = txbCup.Text;
            return _cupName;
        }

        // ******************************************************************************************
        // Form Events 
        // ******************************************************************************************


        private void btnAddJumper_Click(object sender, EventArgs e)
        {
            if (txbName.Text == string.Empty) return;

            Jumper newJumper = new Jumper();
            newJumper.name = txbName.Text;

            long idNumber = _jumperManager.AddNewJumper(newJumper);
            refreshJumperListBox();
            txbName.Text = "";

        }


        private void btnModifyJumper_Click(object sender, EventArgs e)
        {
            int listBoxIndex = lbxJumpers.SelectedIndex;
            bool itemIsSelected = listBoxIndex >= 0 && txbName.Text != string.Empty;
            if (itemIsSelected)
            {
                Jumper jumper = (Jumper)lbxJumpers.Items[listBoxIndex];
                jumper.name = txbName.Text;
                _jumperManager.ModifyJumper(jumper);

                refreshJumperListBox();

                txbName.Text = "";

            }

        }


        private void refreshJumperListBox()
        {
            lbxJumpers.Items.Clear();
            List<Jumper> jumperList = _jumperManager.GetJumperList();

            foreach (Jumper jumper in jumperList)
            {
                lbxJumpers.Items.Add(jumper);
            }

            lbxJumpers.SelectedIndex = -1;
        }


        private void btnRemoveJumper_Click(object sender, EventArgs e)
        {
            int listBoxIndex = lbxJumpers.SelectedIndex;
            bool itemIsSelected = listBoxIndex >= 0;
            if (itemIsSelected)
            {
                Jumper jumper = (Jumper)lbxJumpers.Items[listBoxIndex];
                DialogResult dr = MessageBox.Show("Haluatko varmasti poistaa hyppääjän \n\r" + jumper.name, "Hyppääjän poistaminen", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                bool deleteJumper = dr == DialogResult.Yes;
                if (deleteJumper)
                {
                    bool jumperIsDeleted = _jumperManager.DeleteJumper(jumper);
                    refreshJumperListBox();
                }
                else
                {
                    return;
                }

            }

        }

        private void btnTecnical_Click(object sender, EventArgs e)
        {
            FormTecnical tecnicalForm = new FormTecnical();
            tecnicalForm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
