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
        JumperManager jumperManager;
        PointsHandler pointsHandler;
        List<Jumper> jumpOrderList;
        List<Jumper> resultList;
        Jumper currentJumper;
        int jumpRound;
        int currentJumperIndex;
        int maxJumpers;

        public FormCounter()
        {
            InitializeComponent();
            StartSkiJumpProgram();

         //   testJumpers();
        }


        private void testJumpers()
        {

            Jumper jump1 = new Jumper {name = "Toni"};
            jumperManager.AddNewJumper(jump1);
            Jumper jump2 = new Jumper {name = "Matti"};
            jumperManager.AddNewJumper(jump2);
            Jumper jump3 = new Jumper {name = "Janne"};
            jumperManager.AddNewJumper(jump3);

        }


        private void StartSkiJumpProgram()
        {
            jumperManager = new JumperManager();
            pointsHandler = new PointsHandler();
            jumpOrderList = new List<Jumper>();
            jumpRound = 0;
            SetTowerDetalies();

            btnCalculatePoints.Text = "Hae Hyppääjät";

        }

        private void SetTowerDetalies()
        {
            string towerDetalies = "K-piste: " + pointsHandler.GetKPoint() + "\r\nVaikeuskerroin:  " + pointsHandler.GetDifficulity() + "\r\nLavan korkeus: " + pointsHandler.GetStageHeight();

            lblTecnicalDetalies.Text = towerDetalies;

        }

        private void SetjumpOrderList()
        {
            jumpOrderList = new List<Jumper>();
            jumpOrderList = jumperManager.GetJumperList();
            bool noJumperOnList = jumpOrderList.Count < 1;
            if (noJumperOnList)
                return;

            jumpRound = 1;
            maxJumpers = jumpOrderList.Count;
            currentJumperIndex = 1;
            dgvJumpResults.Rows.Clear();

            btnCalculatePoints.Text = "Laske pisteet";

            resultList = new List<Jumper>();
            SetNextJumper();
        }


        private bool CheckEmptyResults()
        {
            bool jumpLenghtMissing = txbJumpLenght.Text == string.Empty;
            if (jumpLenghtMissing)
            {
                MessageBox.Show("Hypyn pituus puuttuu", "Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag != null)
                {
                    if (textBox.Tag.ToString() == ("wind") && textBox.Text == string.Empty)
                    {
                        MessageBox.Show("Tuuliarvo puuttuu", "Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    if (textBox.Tag.ToString() == ("style") && textBox.Text == string.Empty)
                    {
                        MessageBox.Show("Tyylipisteet puuttuvat", "Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }

            return false;
        }

        private void CalculateJump()
        {
            float jumpPoints = 0;

            bool startSkiJumpCompetition = jumpRound == 0;
            if (startSkiJumpCompetition) jumpRound = 1;

            try
            {
                float[] styleTable = new float[5];
                float[] windTable = new float[5];

                int styleIndex = 0;
                int windIndex = 0;
                foreach (TextBox textBox in this.Controls.OfType<TextBox>())
                {
                    if (textBox.Tag != null)
                    {
                        if (textBox.Tag.ToString() == "style")
                        {
                            float stylePoints = float.Parse(textBox.Text);
                            if (stylePoints > 20)
                            {
                                MessageBox.Show("Tyylipisteet liian suuret", "Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            styleTable[styleIndex] = stylePoints;
                            styleIndex++;
                        }

                        if (textBox.Tag.ToString() == "wind")
                        {
                            windTable[windIndex] = float.Parse(textBox.Text);
                            windIndex++;
                        }
                    }

                } // add more try catches if needed to seperaded errors
                float jumpLenght = float.Parse(txbJumpLenght.Text);

                jumpPoints = pointsHandler.CalculatePoints(jumpLenght, styleTable, windTable);

            }
            catch
            {
                MessageBox.Show("Väärin meni", "Virheellinen arvo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetJumperResultList(jumpPoints);
        } // end CalculateJump


        private void SetJumperResultList(float jumpPoints)
        {
            currentJumper.points += jumpPoints;

            resultList.Add(currentJumper);
            resultList = resultList.OrderByDescending(currentJumper => currentJumper.points).ToList();

            dgvJumpResults.Rows.Clear();

            int placeIndex = 1;
            foreach (Jumper jumper in resultList)
            {
                string[] row = new string[] { placeIndex.ToString(), jumper.name, jumper.points.ToString() };
                dgvJumpResults.Rows.Add(row);
                placeIndex++;
            }

            SetNextJumper();

        }


        private void SetNextJumper()
        {
            bool removeCurrentJumper = currentJumper != null;
            if (removeCurrentJumper)
            {
                jumpOrderList.Remove(currentJumper);
                currentJumperIndex++;
            }

            bool getNextCurrentJumper = jumpOrderList.Count > 0;
            if (getNextCurrentJumper)
            {
                currentJumper = jumpOrderList[0];
            }
            else
            {
                bool secondRound = jumpRound > 0;
                if (secondRound)
                {
                    jumpRound++;
                    List<Jumper> newJumpOrder = resultList.OrderBy(currentJumper => currentJumper.points).ToList();
                    jumpOrderList = newJumpOrder;

                    currentJumperIndex = 1;
                    resultList = new List<Jumper>();

                    currentJumper = jumpOrderList[0];
                }

            }

            bool endSkiJumpCup = jumpRound > 2;
            if (endSkiJumpCup)
            {
                jumpRound = 0;
                currentJumper = null;
                btnCalculatePoints.Text = "Hae Hyppääjät";
            }

            if (currentJumper != null)
            {
                lblRound.Text = "Kierros: " + jumpRound;
                lblJumper.Text = "Hyppääjä: " + (currentJumperIndex) + "/" + maxJumpers + "\r\n" + currentJumper.name;
            }

            ClearJumpPointsTextBoxes();

        } // end SetNextJumper


        private void ClearJumpPointsTextBoxes()
        {
            foreach (TextBox textBox in this.Controls.OfType<TextBox>())
            {
                if (textBox.Tag != null)
                {
                    if (textBox.Tag.ToString() == "style" || textBox.Tag.ToString() == "jump")
                    {
                        textBox.Text = "";
                    }
                }
            }

        }


        // ******************************************************************************************
        // Form Events 
        // ******************************************************************************************


        private void btnCalculatePoints_Click(object sender, EventArgs e)
        {
            bool getJumpersFirsts = jumpOrderList.Count == 0 || jumpRound == 0;
            if (getJumpersFirsts)
            {
                OpenJumpersForm();
            }
            else
            {
                bool someValuesAreMissing = CheckEmptyResults();
                if (someValuesAreMissing)
                    return;

                CalculateJump();

            }

        }


        private void btnJumpers_Click(object sender, EventArgs e)
        {
            bool changeJumpers = jumpOrderList.Count == 0 || jumpRound == 0; ;
            if (changeJumpers)
            {
                OpenJumpersForm();
            }
        }

        private void OpenJumpersForm()
        {
            currentJumper = null;
            FormJumpers jumpersForm = new FormJumpers(jumperManager);
            jumpersForm.ShowDialog();
            lblCupName.Text = jumpersForm.GetCupName();
            SetjumpOrderList();
            SetTowerDetalies();
        }


        private void btnTecnical_Click(object sender, EventArgs e)
        {
            FormTecnical tecnicalForm = new FormTecnical();
            tecnicalForm.ShowDialog();
            SetTowerDetalies();
        }


        private void txbStyle1_KeyPress(object sender, KeyPressEventArgs e)
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


        private void txbWind1_KeyPress(object sender, KeyPressEventArgs e)
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


    }
}
