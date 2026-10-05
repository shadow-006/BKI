using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace BMI_Calculator_AZ
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.ilkin;
        }

        private void btnHesabla_Click(object sender, EventArgs e)
        {
            double boy;
            double ceki;

            if (txtBoy.Text.Trim() == "")
            {
                MessageBox.Show("Zəhmət olmasa boyunuzu daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoy.Focus();
                return;
            }

            if (txtCeki.Text.Trim() == "")
            {
                MessageBox.Show("Zəhmət olmasa çəkinizi daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCeki.Focus();
                return;
            }

            if (!double.TryParse(txtBoy.Text.Trim().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out boy))
            {
                MessageBox.Show("Zəhmət olmasa düzgün rəqəm daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoy.Focus();
                return;
            }

            if (!double.TryParse(txtCeki.Text.Trim().Replace(",", "."), NumberStyles.Float, CultureInfo.InvariantCulture, out ceki))
            {
                MessageBox.Show("Zəhmət olmasa düzgün rəqəm daxil edin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCeki.Focus();
                return;
            }

            if (boy < 50 || boy > 250)
            {
                MessageBox.Show("Boy 50 sm ilə 250 sm arasında olmalıdır.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBoy.Focus();
                return;
            }

            if (ceki < 10 || ceki > 300)
            {
                MessageBox.Show("Çəki 10 kq ilə 300 kq arasında olmalıdır.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCeki.Focus();
                return;
            }

            double metr = boy / 100;
            double bmi = ceki / (metr * metr);

            lblBmi.Text = "Sizin BKİ-niz: " + bmi.ToString("0.0", CultureInfo.InvariantCulture);

            if (bmi < 16)
            {
                lblNetice.Text = "Nəticə: ÇOX ARIQ";
                lblNetice.ForeColor = Color.Red;
                pictureBox1.Image = Properties.Resources.cox_ariq;
            }
            else if (bmi < 18.5)
            {
                lblNetice.Text = "Nəticə: ARIQ";
                lblNetice.ForeColor = Color.Orange;
                pictureBox1.Image = Properties.Resources.ariq;
            }
            else if (bmi < 25)
            {
                lblNetice.Text = "Nəticə: NORMAL";
                lblNetice.ForeColor = Color.Green;
                pictureBox1.Image = Properties.Resources.normal;
            }
            else if (bmi < 30)
            {
                lblNetice.Text = "Nəticə: KÖK";
                lblNetice.ForeColor = Color.DarkOrange;
                pictureBox1.Image = Properties.Resources.kok;
            }
            else
            {
                lblNetice.Text = "Nəticə: ÇOX KÖK";
                lblNetice.ForeColor = Color.DarkRed;
                pictureBox1.Image = Properties.Resources.cox_kok;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtBoy.Clear();
            txtCeki.Clear();
            lblBmi.Text = "";
            lblNetice.Text = "";
            lblNetice.ForeColor = Color.Black;
            pictureBox1.Image = Properties.Resources.ilkin;
            txtBoy.Focus();
        }

        private void btnCixis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
