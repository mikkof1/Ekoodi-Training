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
    public partial class FormTecnical : Form
    {
        PointsHandler pointsHandler;

        public FormTecnical( )
        {
            InitializeComponent();
            pointsHandler = new PointsHandler();
            SetTowerValues();
        }

        private void SetTowerValues()
        {
            txbKPoint.Text = pointsHandler.GetKPoint().ToString();
            txbDifficulity.Text = pointsHandler.GetDifficulity().ToString();
            txbStageHeight.Text = pointsHandler.GetStageHeight().ToString();

        }


        private void SaveTowerValues()
        {
            try
            {
                float kPoint = float.Parse(txbKPoint.Text);
                float multiplier = float.Parse(txbDifficulity.Text);
                float stage = float.Parse(txbStageHeight.Text);

                pointsHandler.SetTowerDetalies(kPoint,multiplier,stage);

            }
            catch
            {
                MessageBox.Show("Virheellinen merkki", "Väärä arvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }


        // ******************************************************************************************
        // Form Events 
        // ******************************************************************************************


        private void txbKPoint_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool acceptNumbers = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) ;
            if (acceptNumbers)
            {
                e.Handled = true;
            }

        }

        private void txbMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool acceptNumbersAndComma = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',');
            if (acceptNumbersAndComma)
            {
                e.Handled = true;
            }

            bool acceptOnlyOneComma = (e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1);
            if (acceptOnlyOneComma)
            {
                e.Handled = true;
            }
        }

        private void txbStage_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool acceptNumbersCommaAndDash = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ',') && (e.KeyChar != '-');
            if (acceptNumbersCommaAndDash)
            {
                e.Handled = true;
            }

            bool acceptOnlyOneComma = (e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1);
            if (acceptOnlyOneComma)
            {
                e.Handled = true;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveTowerValues();
            Close();
        }
    }
}
