using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gm
{
    public partial class About : Form
    {

        Font myFont;
        Font myFont2;


        public About()
        {
            InitializeComponent();
            LoadFont();

        }
        private void LoadFont()
        {
            PrivateFontCollection nfont = new PrivateFontCollection();
            PrivateFontCollection mfont = new PrivateFontCollection();

            nfont.AddFontFile("F77.ttf");
            myFont = new Font(nfont.Families[0], 30);
            myFont2 = new Font(nfont.Families[0], 20);
            label3.Font = myFont;
            label1.Font = myFont2;

        }

        private void About_Load(object sender, EventArgs e)
        {

        }

        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MainScreen mainSc = new MainScreen();
            mainSc.Show();
            this.Hide();
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.x2;

        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.x;

        }
    }
}
