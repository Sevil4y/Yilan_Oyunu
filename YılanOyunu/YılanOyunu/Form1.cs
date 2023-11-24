using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace YılanOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        yılan yılanımız = new yılan();
        yon yonumuz;
        PictureBox[] pb_yılanParcaları;
        bool yemVarMi = false;
        Random rastgele = new Random();
        PictureBox pbYem;
        int skor = 0;


        private void Form1_Load(object sender, EventArgs e)
        {
            pb_yılanParcaları = new PictureBox[0];

            for (int i =0; i < 3; i++)
            { 
                Array.Resize(ref pb_yılanParcaları, pb_yılanParcaları.Length + 1);
                pb_yılanParcaları[i] = Pb_ekle();
            }
            timer1.Start();
        }

        private PictureBox Pb_ekle()
        {
            PictureBox pb = new PictureBox();
            pb.Size = new Size(10, 10); 
            pb.BackColor =Color.Orange;
            pb.Location = yılanımız.GetPos(pb_yılanParcaları.Length - 1);
            panel1.Controls.Add(pb);
            return pb;
        }

        private void Pb_guncelle()
        {
            for(int i = 0; i < pb_yılanParcaları.Length; i++)
            {
                pb_yılanParcaları[i].Location = yılanımız.GetPos(i);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                yonumuz = new yon(0, -10);
            }
            else if (e.KeyCode == Keys.Down)
            {
                yonumuz = new yon(0, 10);
            }
            else if (e.KeyCode == Keys.Left)
            {
                yonumuz = new yon(-10, 0);
            }
            else if (e.KeyCode == Keys.Right)
            {
                yonumuz = new yon(10, 0);
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblSkor.Text = skor.ToString();
            yılanımız.İlerle(yonumuz);
            Pb_guncelle();
            yemOlustur();
            yemYendiMi();
            duvaraCarpti();
        }

        public void yemOlustur()
        {
            if(!yemVarMi)
            {
                PictureBox pb = new PictureBox();
                pb.BackColor = Color.Aqua;
                pb.Size = new Size(10, 10);
                pb.Location = new Point(rastgele.Next(panel1.Width / 10) * 10, rastgele.Next(panel1.Height / 10) * 10);
                pbYem = pb;
                yemVarMi = true;
                panel1.Controls.Add(pb);
            }
        }

        public void yemYendiMi()
        {
            if(yılanımız.GetPos(0) == pbYem.Location)
            {
                skor ++;
                yılanımız.Buyu();
                Array.Resize(ref pb_yılanParcaları, pb_yılanParcaları.Length + 1);
                pb_yılanParcaları[pb_yılanParcaları.Length - 1] = Pb_ekle();
                yemVarMi = false;
                panel1.Controls.Remove(pbYem); 
            }
        }

        public void duvaraCarpti()
        {
            Point p = yılanımız.GetPos(0);

            if(p.X < 0 || p.X > panel1.Width-10 || p.Y < 0 || p.Y > panel1.Height-10)
            {
                timer1.Stop();
                MessageBox.Show("Oyun Bitti.. Kaybettiniz !");
            }
        }

    }
}
