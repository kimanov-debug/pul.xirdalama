using System;
using System.Drawing;
using System.Windows.Forms;

namespace xirdalanacaq.mebleg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedTextBox1.Mask = "";

            Control[] elementler = {
                pictureBox1, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9,
                label2, label3, label4, label5, label6, label7, label8, label9
            };

            foreach (var item in elementler)
            {
                if (item != null)
                {
                    item.BringToFront();
                }
            }

            ResetVisibility();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string daxilEdilen = maskedTextBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(daxilEdilen))
            {
                errorProvider1.SetError(maskedTextBox1, "Məbləğ daxil edin");
                ResetVisibility();
                return;
            }
            else
            {
                errorProvider1.SetError(maskedTextBox1, string.Empty);
            }

            if (!int.TryParse(daxilEdilen, out int mebleg))
            {
                MessageBox.Show("Zəhmət olmasa düzgün rəqəm daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetVisibility();
                return;
            }

            if (mebleg <= 0)
            {
                MessageBox.Show("Mənfi və ya sıfır məbləğ xırdalanmaz", "Diqqət", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ResetVisibility();
                return;
            }

            int say500 = mebleg / 500; mebleg %= 500;
            int say200 = mebleg / 200; mebleg %= 200;
            int say100 = mebleg / 100; mebleg %= 100;
            int say50 = mebleg / 50; mebleg %= 50;
            int say20 = mebleg / 20; mebleg %= 20;
            int say10 = mebleg / 10; mebleg %= 10;
            int say5 = mebleg / 5; mebleg %= 5;
            int say1 = mebleg / 1;

            ShowResult(label9, pictureBox9, say500);
            ShowResult(label8, pictureBox8, say200);
            ShowResult(label7, pictureBox7, say100);
            ShowResult(label6, pictureBox6, say50);
            ShowResult(label5, pictureBox5, say20);
            ShowResult(label4, pictureBox4, say10);
            ShowResult(label3, pictureBox3, say5);
            ShowResult(label2, pictureBox1, say1);
        }

        private void ShowResult(Label lbl, PictureBox pic, int count)
        {
            if (lbl != null && pic != null)
            {
                lbl.Text = count > 0 ? count.ToString() : "";
                lbl.Visible = count > 0;
                pic.Visible = count > 0;

                if (count > 0)
                {
                    lbl.BringToFront();
                    pic.BringToFront();
                }
            }
        }

        private void ResetVisibility()
        {
            label2.Visible = label3.Visible = label4.Visible = label5.Visible =
            label6.Visible = label7.Visible = label8.Visible = label9.Visible = false;

            pictureBox1.Visible = pictureBox3.Visible = pictureBox4.Visible =
            pictureBox5.Visible = pictureBox6.Visible = pictureBox7.Visible =
            pictureBox8.Visible = pictureBox9.Visible = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e) { }
    }
}
