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
    public partial class level2 : Form
    {
        public PictureBox exitWin = new PictureBox();
        public Label sure = new Label();
        public Label sure2 = new Label();
        public PictureBox yes = new PictureBox();
        public PictureBox no = new PictureBox();
        public PictureBox main = new PictureBox();
        public PictureBox repeat = new PictureBox();

        public bool statusSmallest = false;
        public bool statusSmall = false;
        public bool statusMid = false;
        public bool statusBig = false;

        PrivateFontCollection nfont = new PrivateFontCollection();
        PrivateFontCollection mfont = new PrivateFontCollection();

        public static Point[,] ringSmallest = new Point[3, 4];
        public static Point[,] ringSmall = new Point[3, 3];
        public static Point[,] ringMid = new Point[3, 2];
        public static Point[,] ringBig = new Point[3, 1];

        public int[] area1 = new int[3] { 360, 745, 1117 };
        public int[] area = new int[3] { 0, 360, 745 };

        public int currentLocSmallest = 0;
        public Point currentLocSmallestCoord = new Point();
        public int columnSmallest = 0;

        public int currentLocSmall = 0;
        public Point currentLocSmallCoord = new Point();
        public int columnSmall = 0;

        public int currentLocMid = 0;
        public Point currentLocMidCoord = new Point();
        public int columnMid = 0;

        public int currentLocBig = 0;
        public Point currentLocBigCoord = new Point();
        public int columnBig = 0;

        Font myFont;
        Font myFont2;
        DateTime date;
        public int count = 0;

        public level2()
        {
            InitializeComponent();
            LoadFont();

        }

        private void LoadFont()
        {

            nfont.AddFontFile("F77.ttf");
            myFont = new Font(nfont.Families[0], 22);
            myFont2 = new Font(nfont.Families[0], 15);
            label10.Font = myFont2;
            label14.Font = myFont2;
            label3.Font = myFont;
        }
        Timer timer = new Timer();

        private void level2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            label1.Enabled = false;
            label2.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;

            this.Controls.Add(exitWin);
            exitWin.BringToFront();

            sure.Location = new Point(320, 230);
            sure.Font = myFont;
            sure.Text = "Выйти в главное меню?";
            this.Controls.Add(sure);
            sure.BringToFront();


            this.Controls.Add(yes);
            yes.BringToFront();

            this.Controls.Add(no);
            no.BringToFront();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            label6.Location = new Point(ringSmallest[0, 0].X, ringSmallest[0, 0].Y);
            label5.Location = new Point(ringSmall[0, 0].X, ringSmall[0, 0].Y);
            label2.Location = new Point(ringMid[0, 0].X, ringMid[0, 0].Y);
            label1.Location = new Point(ringBig[0, 0].X, ringBig[0, 0].Y);

            currentLocSmallest = 0;
            columnSmallest = 0;

            currentLocSmall = 0;
            columnSmall = 0;

            currentLocMid = 0;
            columnMid = 0;

            currentLocBig = 0;
            columnBig = 0;

            count = 0;
            label14.Text = Convert.ToString(count);

            currentLocSmallestCoord = new Point(ringSmallest[0, 0].X, ringSmallest[0, 0].Y);
            currentLocSmallCoord = new Point(ringSmall[0, 0].X, ringSmall[0, 0].Y);
            currentLocMidCoord = new Point(ringMid[0, 0].X, ringMid[0, 0].Y);
            currentLocBigCoord = new Point(ringBig[0, 0].X, ringBig[0, 0].Y);

            timer.Start();
            date = DateTime.Now;
            this.Controls.Remove(exitWin);
            this.Controls.Remove(sure);
            this.Controls.Remove(sure2);
            this.Controls.Remove(main);
            this.Controls.Remove(repeat);

            label1.Enabled = true;
            label2.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;
        }

        private void level2_Load(object sender, EventArgs e)
        {
            #region
            ringSmallest[0, 0] = new Point(111, 410);    //1 столб 1 сверху
            ringSmallest[0, 1] = new Point(111, 456);
            ringSmallest[0, 2] = new Point(111, 502);
            ringSmallest[0, 3] = new Point(111, 548);
            ringSmallest[1, 0] = new Point(505, 410);    //2 столб 1 сверху
            ringSmallest[1, 1] = new Point(505, 456);
            ringSmallest[1, 2] = new Point(505, 502);
            ringSmallest[1, 3] = new Point(505, 548);
            ringSmallest[2, 0] = new Point(890, 410);    //3 столб 1 сверху
            ringSmallest[2, 1] = new Point(890, 456);
            ringSmallest[2, 2] = new Point(890, 502);
            ringSmallest[2, 3] = new Point(890, 548);

            ringSmall[0, 0] = new Point(80, 456);    //1 столб 2 сверху
            ringSmall[0, 1] = new Point(80, 502);
            ringSmall[0, 2] = new Point(80, 548);
            ringSmall[1, 0] = new Point(472, 456);   //2 столб 2 сверху
            ringSmall[1, 1] = new Point(472, 502);
            ringSmall[1, 2] = new Point(472, 548);
            ringSmall[2, 0] = new Point(860, 456);   //3 столб 2 сверху
            ringSmall[2, 1] = new Point(860, 502);
            ringSmall[2, 2] = new Point(860, 548);

            ringMid[0, 0] = new Point(44, 502);    //1 столб 3 сверху
            ringMid[0, 1] = new Point(44, 548);
            ringMid[1, 0] = new Point(436, 502);   //2 столб 3 сверху
            ringMid[1, 1] = new Point(436, 548);
            ringMid[2, 0] = new Point(824, 502);   //3 столб 3 сверху
            ringMid[2, 1] = new Point(824, 548);

            ringBig[0, 0] = new Point(12, 548);       //1 столб
            ringBig[1, 0] = new Point(402, 548);      //2 столб 
            ringBig[2, 0] = new Point(792, 548);      //3 столб 

            currentLocSmallestCoord = new Point(ringSmallest[0, 0].X, ringSmallest[0, 0].Y);
            currentLocSmallCoord = new Point(ringSmall[0, 0].X, ringSmall[0, 0].Y);
            currentLocMidCoord = new Point(ringMid[0, 0].X, ringMid[0, 0].Y);
            currentLocBigCoord = new Point(ringBig[0, 0].X, ringBig[0, 0].Y);
            #endregion

            date = DateTime.Now;
            timer.Interval = 10;
            timer.Tick += new EventHandler(tickTimer);
            timer.Start();
        }

        private void tickTimer(object sender, EventArgs e)
        {
            long tick = DateTime.Now.Ticks - date.Ticks;
            DateTime stopWatch = new DateTime();
            stopWatch = stopWatch.AddTicks(tick);
            label3.Text = String.Format("{0:HH:mm:ss:ff}", stopWatch);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        //МАЛЕНЬКОЕ КОЛЬЦО
        #region 
        private void label5_MouseUp(object sender, MouseEventArgs e)
        {
            statusSmall = false;
            currentLocSmall = label5.Location.X + 80;

            for (int i = 0; i < 3; i++)
            {
                if (currentLocSmall < area1[i] && currentLocSmall > area[i])
                {
                    if (label1.Location == ringBig[i, 0] && label2.Location == ringMid[i, 0]&&label6.Location!=ringSmallest[i,0]&& label6.Location != ringSmallest[i, 1])
                    {
                        label5.Location = new Point(ringSmall[i, 0].X, ringSmall[i, 0].Y);
                        if (currentLocSmallCoord.X != label5.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallCoord = new Point(ringSmall[i, 0].X, ringSmall[i, 0].Y);
                        columnSmall = i;
                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location == ringMid[i, 1] && label6.Location != ringSmallest[i, 2])
                    {
                        label5.Location = new Point(ringSmall[i, 1].X, ringSmall[i, 1].Y);
                        if (currentLocSmallCoord.X != label5.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallCoord = new Point(ringSmall[i, 1].X, ringSmall[i, 1].Y);
                        columnSmall = i;
                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location != ringMid[i, 1] && label2.Location != ringMid[i, 0] && label6.Location != ringSmallest[i, 3])
                    {
                        label5.Location = new Point(ringSmall[i, 2].X, ringSmall[i, 2].Y);
                        if (currentLocSmallCoord.X != label5.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallCoord = new Point(ringSmall[i, 2].X, ringSmall[i, 2].Y);
                        columnSmall = i;
                    }
                    else if (label1.Location == ringBig[i, 0] && label2.Location != ringMid[i, 0] && label6.Location != ringSmallest[i, 2])
                    {
                        label5.Location = new Point(ringSmall[i, 1].X, ringSmall[i, 1].Y);
                        if (currentLocSmallCoord.X != label5.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallCoord = new Point(ringSmall[i, 1].X, ringSmall[i, 1].Y);
                        columnSmall = i;
                    }
                    else
                    {
                        label5.Location = new Point(currentLocSmallCoord.X, currentLocSmallCoord.Y);
                    }


                }
            }
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            statusSmall = true;
        }

        private void label5_MouseMove(object sender, MouseEventArgs e)
        {
            if (statusSmall && columnSmallest != columnSmall)
            {
                #region

                if (Cursor.Position.X - this.Location.X - 80 >= 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.X - this.Location.X + 70 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label5.Location = new Point((Cursor.Position.X - this.Location.X - 80), (Cursor.Position.Y - this.Location.Y - 50)); //общая работа
                }
                else if (Cursor.Position.X - this.Location.X - 80 < 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label5.Location = new Point(0, (Cursor.Position.Y - this.Location.Y - 50));  //левая граница
                }
                else if ((Cursor.Position.X - this.Location.X - 80 >= 0 && Cursor.Position.X - this.Location.X + 70 <= this.Width && Cursor.Position.Y - this.Location.Y - 50 < 60))
                {
                    label5.Location = new Point((Cursor.Position.X - this.Location.X - 80), 60);   //верхняя граница
                }
                else if (Cursor.Position.X - this.Location.X + 70 > this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height && Cursor.Position.Y - this.Location.Y - 50 >= 60)
                {
                    label5.Location = new Point(this.Width - 150, (Cursor.Position.Y - this.Location.Y - 50));  //правая граница
                }
                else if (Cursor.Position.X - this.Location.X + 70 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 > this.Height && Cursor.Position.X - this.Location.X - 80 >= 0)
                {
                    label5.Location = new Point((Cursor.Position.X - this.Location.X - 80), this.Height - 90);  //нижняя граница
                }
                #endregion
            }
        }
        #endregion


        //СРЕДНЕЕ КОЛЬЦО
        #region
        private void label2_MouseUp(object sender, MouseEventArgs e)
        {
            statusMid = false;
            currentLocMid = label2.Location.X + 120;

            for (int i = 0; i < 3; i++)
            {
                if (currentLocMid < area1[i] && currentLocMid > area[i])
                {

                    if (label5.Location != ringSmall[i, 1] && label1.Location == ringBig[i, 0] && label6.Location != ringSmallest[i, 2])
                    {
                        label2.Location = new Point(ringMid[i, 0].X, ringMid[i, 0].Y);
                        if (currentLocMidCoord.X != label2.Location.X)
                        {
                            Count();
                        }
                        currentLocMidCoord = new Point(ringMid[i, 0].X, ringMid[i, 0].Y);
                        columnMid = i;

                    }
                    else if (label5.Location != ringSmall[i, 1]&& label1.Location != ringBig[i, 0]&& label5.Location != ringSmall[i, 2] && label6.Location != ringSmallest[i, 3])
                    {
                        label2.Location = new Point(ringMid[i, 1].X, ringMid[i, 1].Y);
                        if (currentLocMidCoord.X != label2.Location.X)
                        {
                            Count();
                        }
                        currentLocMidCoord = new Point(ringMid[i, 1].X, ringMid[i, 1].Y);
                        columnMid = i;


                    }
                    else
                    {
                        label2.Location = new Point(currentLocMidCoord.X, currentLocMidCoord.Y);
                    }
                }
            }
        }

        private void label2_MouseDown(object sender, MouseEventArgs e)
        {
            statusMid = true;
        }

        private void label2_MouseMove(object sender, MouseEventArgs e)
        {
            if (statusMid && columnSmall != columnMid && columnSmallest != columnMid)
            {
                #region

                if (Cursor.Position.X - this.Location.X - 120 >= 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.X - this.Location.X + 110 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label2.Location = new Point((Cursor.Position.X - this.Location.X - 120), (Cursor.Position.Y - this.Location.Y - 50)); //общая работа
                }
                else if (Cursor.Position.X - this.Location.X - 120 < 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label2.Location = new Point(0, (Cursor.Position.Y - this.Location.Y - 50));  //левая граница
                }
                else if ((Cursor.Position.X - this.Location.X - 120 >= 0 && Cursor.Position.X - this.Location.X + 110 <= this.Width && Cursor.Position.Y - this.Location.Y - 50 < 60))
                {
                    label2.Location = new Point((Cursor.Position.X - this.Location.X - 120), 60);   //верхняя граница
                }
                else if (Cursor.Position.X - this.Location.X + 110 > this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height && Cursor.Position.Y - this.Location.Y - 50 >= 60)
                {
                    label2.Location = new Point(this.Width - 230, (Cursor.Position.Y - this.Location.Y - 50));  //правая граница
                }
                else if (Cursor.Position.X - this.Location.X + 110 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 > this.Height && Cursor.Position.X - this.Location.X - 120 >= 0)
                {
                    label2.Location = new Point((Cursor.Position.X - this.Location.X - 120), this.Height - 90);  //нижняя граница
                }
                #endregion
            }
        }
        #endregion


        //БОЛЬШОЕ КОЛЬЦО
        #region
        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            statusBig = false;
            currentLocBig = label1.Location.X + 150;
            for (int i = 0; i < 3; i++)
            {
                if (currentLocBig < area1[i] && currentLocBig > area[i])
                {
                    if (label5.Location != ringSmall[i, 2] && label2.Location != ringMid[i, 1]&&label6.Location!=ringSmallest[i,3])
                    {
                        label1.Location = new Point(ringBig[i, 0].X, ringBig[i, 0].Y);
                        if (currentLocBigCoord.X != label1.Location.X)
                        {
                            Count();
                        }
                        currentLocBigCoord = new Point(ringBig[i, 0].X, ringBig[i, 0].Y);
                        columnBig = i;

                    }
                    else
                    {
                        label1.Location = new Point(currentLocBigCoord.X, currentLocBigCoord.Y);

                    }
                }
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            statusBig = true;
        }

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if (statusBig && columnSmall != columnBig && columnMid != columnBig && columnSmallest != columnBig)
            {
                #region

                if (Cursor.Position.X - this.Location.X - 150 >= 0 && Cursor.Position.Y - this.Location.Y - 50 >= 0 && Cursor.Position.X - this.Location.X + 150 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label1.Location = new Point((Cursor.Position.X - this.Location.X - 150), (Cursor.Position.Y - this.Location.Y - 50)); //общая работа
                }
                else if (Cursor.Position.X - this.Location.X - 150 < 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label1.Location = new Point(0, (Cursor.Position.Y - this.Location.Y - 50));  //левая граница
                }
                else if ((Cursor.Position.X - this.Location.X - 150 >= 0 && Cursor.Position.X - this.Location.X + 150 <= this.Width && Cursor.Position.Y - this.Location.Y - 50 < 60))
                {
                    label1.Location = new Point((Cursor.Position.X - this.Location.X - 150), 60);   //верхняя граница
                }
                else if (Cursor.Position.X - this.Location.X + 150 > this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height && Cursor.Position.Y - this.Location.Y - 50 >= 60)
                {
                    label1.Location = new Point(this.Width - 300, (Cursor.Position.Y - this.Location.Y - 50));  //правая граница
                }
                else if (Cursor.Position.X - this.Location.X + 150 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 > this.Height && Cursor.Position.X - this.Location.X - 150 >= 0)
                {
                    label1.Location = new Point((Cursor.Position.X - this.Location.X - 150), this.Height - 90);  //нижняя граница
                }
                #endregion
            }
        }
        #endregion

        //ОЧЕНЬ МАЛЕНЬКОЕ КОЛЬЦО
        #region
        private void label6_MouseUp(object sender, MouseEventArgs e)
        {
            statusSmallest = false;
            currentLocSmallest = label6.Location.X + 50;

            for (int i = 0; i < 3; i++)
            {
                if (currentLocSmallest < area1[i] && currentLocSmallest > area[i])
                {
                    if (label1.Location == ringBig[i, 0] && label2.Location == ringMid[i, 0] &&label5.Location==ringSmall[i,0])
                    {
                        label6.Location = new Point(ringSmallest[i, 0].X, ringSmallest[i, 0].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 0].X, ringSmallest[i, 0].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location == ringMid[i, 1]&&label5.Location==ringSmall[i,1])
                    {
                        label6.Location = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location != ringMid[i, 1] && label5.Location == ringSmall[i, 2])
                    {
                        label6.Location = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location == ringMid[i, 1] && label5.Location != ringSmall[i, 2])
                    {
                        label6.Location = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location == ringBig[i, 0] && label2.Location != ringMid[i, 0] && label5.Location == ringSmall[i, 1])
                    {
                        label6.Location = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location == ringBig[i, 0] && label2.Location == ringMid[i, 0] && label5.Location != ringSmall[i, 0])
                    {
                        label6.Location = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 1].X, ringSmallest[i, 1].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location == ringBig[i, 0] && label2.Location != ringMid[i, 0] && label5.Location != ringSmall[i, 1])
                    {
                        label6.Location = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 2].X, ringSmallest[i, 2].Y);
                        columnSmallest = i;

                    }
                    else if (label1.Location != ringBig[i, 0] && label2.Location != ringMid[i, 1] && label5.Location != ringSmall[i, 2])
                    {
                        label6.Location = new Point(ringSmallest[i, 3].X, ringSmallest[i, 3].Y);
                        if (currentLocSmallestCoord.X != label6.Location.X)
                        {
                            Count();
                        }
                        currentLocSmallestCoord = new Point(ringSmallest[i, 3].X, ringSmallest[i, 3].Y);
                        columnSmallest = i;

                    }
                }
            }

            if (label1.Location == ringBig[2, 0] && label2.Location == ringMid[2, 0] && label5.Location == ringSmall[2, 0] && label6.Location == ringSmallest[2, 0] && label6.Location == ringSmallest[2, 0])
            {
                timer.Stop();
                label1.Enabled = false;
                label2.Enabled = false;
                label5.Enabled = false;
                label6.Enabled = false;
                pictureBox1.Enabled = false;
                pictureBox2.Enabled = false;
                this.Controls.Add(exitWin);
                exitWin.BringToFront();
                sure.Location = new Point(420, 210);
                sure.Font = myFont;
                sure.Text = "Вы победили!";
                this.Controls.Add(sure);
                sure.BringToFront();
                string time = label3.Text;
                sure2.Location = new Point(330, 270);
                sure2.Font = myFont;
                sure2.Text = $"Ваше время {time}\nКоличество шагов: {count}";
                this.Controls.Add(sure2);
                sure2.BringToFront();

                this.Controls.Add(main);
                main.BringToFront();

                this.Controls.Add(repeat);
                repeat.BringToFront();

            }
        }
        private void label6_MouseDown(object sender, MouseEventArgs e)
        {
            statusSmallest = true;

        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
                #region
            if (statusSmallest)
            {
                if (Cursor.Position.X - this.Location.X - 40 >= 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.X - this.Location.X + 50 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label6.Location = new Point((Cursor.Position.X - this.Location.X - 40), (Cursor.Position.Y - this.Location.Y - 50)); //общая работа
                }
                else if (Cursor.Position.X - this.Location.X - 40 < 0 && Cursor.Position.Y - this.Location.Y - 50 >= 60 && Cursor.Position.Y - this.Location.Y + 40 <= this.Height)
                {
                    label6.Location = new Point(0, (Cursor.Position.Y - this.Location.Y - 50));  //левая граница
                }
                else if ((Cursor.Position.X - this.Location.X - 40 >= 0 && Cursor.Position.X - this.Location.X + 70 <= this.Width && Cursor.Position.Y - this.Location.Y - 50 < 60))
                {
                    label6.Location = new Point((Cursor.Position.X - this.Location.X - 40), 60);   //верхняя граница
                }
                else if (Cursor.Position.X - this.Location.X + 50 > this.Width && Cursor.Position.Y - this.Location.Y + 40 <= this.Height && Cursor.Position.Y - this.Location.Y - 50 >= 60)
                {
                    label6.Location = new Point(this.Width - 90, (Cursor.Position.Y - this.Location.Y - 50));  //правая граница
                }
                else if (Cursor.Position.X - this.Location.X + 70 <= this.Width && Cursor.Position.Y - this.Location.Y + 40 > this.Height && Cursor.Position.X - this.Location.X - 40 >= 0)
                {
                    label6.Location = new Point((Cursor.Position.X - this.Location.X - 40), this.Height - 90);  //нижняя граница
                }
            }
            #endregion
        }
        #endregion

        //ВЫХОД ДА
        #region
        private void yes_MouseDown(object sender, MouseEventArgs e)
        {
            yes.BackgroundImage = Properties.Resources.yes2;
        }

        private void yes_MouseUp(object sender, MouseEventArgs e)
        {
            yes.BackgroundImage = Properties.Resources.yes;
        }

        private void yes_Click(object sender, EventArgs e)
        {
            MainScreen mainSc = new MainScreen();
            this.Hide();
            mainSc.Show();

        }
        #endregion


        //ВЫХОД НЕТ
        #region
        private void no_MouseDown(object sender, MouseEventArgs e)
        {
            no.BackgroundImage = Properties.Resources.no2;
        }

        private void no_MouseUp(object sender, MouseEventArgs e)
        {
            no.BackgroundImage = Properties.Resources.no;
        }
        private void no_Click(object sender, EventArgs e)
        {
            this.Controls.Remove(exitWin);
            this.Controls.Remove(sure);
            this.Controls.Remove(yes);
            this.Controls.Remove(no);

            label1.Enabled = true;
            label2.Enabled = true;
            label5.Enabled = true;
            label6.Enabled = true;
            pictureBox1.Enabled = true;
            pictureBox2.Enabled = true;

        }
        #endregion

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.exit2;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BackgroundImage = Properties.Resources.exit1;
        }

        //ГЛАВНОЕ МЕНЮ
        #region
        private void main_MouseDown(object sender, MouseEventArgs e)
        {
            main.BackgroundImage = Properties.Resources.main2;
        }

        private void main_MouseUp(object sender, MouseEventArgs e)
        {
            main.BackgroundImage = Properties.Resources.main1;
        }
        private void main_Click(object sender, EventArgs e)
        {
            MainScreen mainSc = new MainScreen();

            mainSc.Show();

            this.Hide();

        }
        #endregion

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.repeat2;

        }
        private void repeat_MouseDown(object sender, MouseEventArgs e)
        {
            repeat.BackgroundImage = Properties.Resources.repeat2;
        }

        private void repeat_MouseUp(object sender, MouseEventArgs e)
        {
            repeat.BackgroundImage = Properties.Resources.repeat1;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BackgroundImage = Properties.Resources.repeat1;
        }

        private void Count()
        {
            count++;
            label14.Text = Convert.ToString(count);
        }


    }
}
