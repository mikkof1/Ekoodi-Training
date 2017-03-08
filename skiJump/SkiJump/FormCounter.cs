using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkiJump
{
    public partial class FormCounter : Form
    {
        JumperManager _jumperManager;
        PointsHandler _pointsHandler;
        List<Jumper> _jumpOrderList;
        List<Jumper> _resultList;
        Jumper _currentJumper;
        int _jumpRound;
        int _currentJumperIndex;
        int _maxJumpers;

        public FormCounter()
        {
            InitializeComponent();
            StartSkiJumpProgram();

            //   testJumpers();
        }


        private void TestJumpers()
        {

            Jumper jump1 = new Jumper { Name = "Toni" };
            _jumperManager.AddNewJumper(jump1);
            Jumper jump2 = new Jumper { Name = "Matti" };
            _jumperManager.AddNewJumper(jump2);
            Jumper jump3 = new Jumper { Name = "Janne" };
            _jumperManager.AddNewJumper(jump3);

        }


        private void StartSkiJumpProgram()
        {
            _jumperManager = new JumperManager();
            _pointsHandler = new PointsHandler();
            _jumpOrderList = new List<Jumper>();
            _jumpRound = 0;
            SetTowerDetalies();

            btnCalculatePoints.Text = @"Hae Hyppääjät";

        }

        private void SetTowerDetalies()
        {
            string towerDetalies = "K-piste: " + _pointsHandler.GetKPoint() + "\r\nVaikeuskerroin:  " + _pointsHandler.GetDifficulity() + "\r\nLavan korkeus: " + _pointsHandler.GetStageHeight();

            lblTecnicalDetalies.Text = towerDetalies;

        }

        private void SetjumpOrderList()
        {
            _jumpOrderList = new List<Jumper>();
            _jumpOrderList = _jumperManager.GetJumperList();
            bool noJumperOnList = _jumpOrderList.Count < 1;
            if (noJumperOnList)
                return;

            _jumpRound = 1;
            _maxJumpers = _jumpOrderList.Count;
            _currentJumperIndex = 1;
            dgvJumpResults.Rows.Clear();

            btnCalculatePoints.Text = @"Laske pisteet";

            _resultList = new List<Jumper>();
            SetNextJumper();
        }


        private bool CheckEmptyResults()
        {
            bool jumpLenghtMissing = txbJumpLenght.Text == string.Empty;
            if (jumpLenghtMissing)
            {
                MessageBox.Show("Hypyn pituus puuttuu", @"Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }

            foreach (TextBox textBox in Controls.OfType<TextBox>())
            {
                if (textBox.Tag != null)
                {
                    if (textBox.Tag.ToString() == ("wind") && textBox.Text == string.Empty)
                    {
                        MessageBox.Show("Tuulipisteet puuttuu", @"Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }

                    if (textBox.Tag.ToString() == ("style") && textBox.Text == string.Empty)
                    {
                        MessageBox.Show(@"Tyylipisteet puuttuu", @"Puutteellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return true;
                    }
                }
            }

            return false;
        }

        private void CalculateJump()
        {
            float jumpPoints = 0;

            bool startSkiJumpCompetition = _jumpRound == 0;
            if (startSkiJumpCompetition) _jumpRound = 1;

            try
            {
                float[] styleTable = new float[5];
                float[] windTable = new float[5];

                int styleIndex = 0;
                int windIndex = 0;
                foreach (TextBox textBox in Controls.OfType<TextBox>())
                {
                    if (textBox.Tag != null)
                    {
                        if (textBox.Tag.ToString() == "style")
                        {
                            float stylePoints = float.Parse(textBox.Text);
                            if (stylePoints > 20 || stylePoints < 0)
                            {
                                MessageBox.Show(@"Tyylipisteet tulee antaa väliltä 0 - 20 ", @"Virheellinen arvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

                jumpPoints = _pointsHandler.CalculatePoints(jumpLenght, styleTable, windTable);

            }
            catch
            {
                MessageBox.Show(@"Olet syöttänyt väärän arvon", @"Virheellinen tieto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            SetJumperResultList(jumpPoints);
        } // end CalculateJump


        private void SetJumperResultList(float jumpPoints)
        {
            _currentJumper.Points += jumpPoints;

            _resultList.Add(_currentJumper);
            _resultList = _resultList.OrderByDescending(currentJumper => currentJumper.Points).ToList();

            dgvJumpResults.Rows.Clear();

            int placeIndex = 1;
            foreach (Jumper jumper in _resultList)
            {
                string[] row = new string[] { placeIndex.ToString(), jumper.Name, jumper.Points.ToString(CultureInfo.InvariantCulture) };
                dgvJumpResults.Rows.Add(row);
                placeIndex++;
            }

            SetNextJumper();

        }


        private void SetNextJumper()
        {
            bool removeCurrentJumper = _currentJumper != null;
            if (removeCurrentJumper)
            {
                _jumpOrderList.Remove(_currentJumper);
                _currentJumperIndex++;
            }

            bool getNextCurrentJumper = _jumpOrderList.Count > 0;
            if (getNextCurrentJumper)
            {
                _currentJumper = _jumpOrderList[0];
            }
            else
            {
                bool secondRound = _jumpRound > 0;
                if (secondRound)
                {
                    _jumpRound++;
                    List<Jumper> newJumpOrder = _resultList.OrderBy(currentJumper => currentJumper.Points).ToList();
                    _jumpOrderList = newJumpOrder;

                    _currentJumperIndex = 1;
                    _resultList = new List<Jumper>();

                    _currentJumper = _jumpOrderList[0];
                }

            }

            bool endSkiJumpCup = _jumpRound > 2;
            if (endSkiJumpCup)
            {
                _jumpRound = 0;
                _currentJumper = null;
                btnCalculatePoints.Text = @"Hae Hyppääjät";
            }

            if (_currentJumper != null)
            {
                lblRound.Text = @"Kierros: " + _jumpRound;
                lblJumper.Text = "Hyppääjä: " + _currentJumperIndex + "/" + _maxJumpers + "\r\n" + _currentJumper.Name;
            }

            ClearJumpPointsTextBoxes();

        } // end SetNextJumper


        private void ClearJumpPointsTextBoxes()
        {
            foreach (TextBox textBox in Controls.OfType<TextBox>())
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
            bool getJumpersFirsts = _jumpOrderList.Count == 0 || _jumpRound == 0;
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
            bool changeJumpers = _jumpOrderList.Count == 0 || _jumpRound == 0;
            if (changeJumpers)
            {
                OpenJumpersForm();
            }
        }

        private void OpenJumpersForm()
        {
            _currentJumper = null;
            FormJumpers jumpersForm = new FormJumpers(_jumperManager);
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

            bool acceptOnlyOneComma = (e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf(',') > -1);
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

            bool acceptOnlyOneComma = (e.KeyChar == ',') && (((TextBox)sender).Text.IndexOf(',') > -1);
            if (acceptOnlyOneComma)
            {
                e.Handled = true;
            }
        }


    }
}
