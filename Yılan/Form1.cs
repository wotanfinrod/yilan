using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Yılan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        int puan = 0;
        SoundPlayer tık = new SoundPlayer(Properties.Resources.Kick___Sound_Effect);
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
           

            if (e.KeyCode == Keys.Left && timersağ.Enabled != true)
            {
                timersol.Enabled = true;
                timersağ.Enabled = false;
                timeraşağı.Enabled = false;
                timeryukarı.Enabled = false;
            }
            if (e.KeyCode == Keys.Right && timersol.Enabled != true)
            {
                timersol.Enabled = false;
                timersağ.Enabled = true;
                timeraşağı.Enabled = false;
                timeryukarı.Enabled = false;
            }
            if (e.KeyCode == Keys.Up && timeraşağı.Enabled !=true)
            {

                timersol.Enabled = false;
                timersağ.Enabled = false;
                timeraşağı.Enabled = false;
                timeryukarı.Enabled = true;
            }
            if (e.KeyCode == Keys.Down && timeryukarı.Enabled !=true)
            {
                timersol.Enabled = false;
                timersağ.Enabled = false;
                timeraşağı.Enabled = true;
                timeryukarı.Enabled = false;
                //asdkasdjaskdsakdjkalaksldşqwjeqwkl
                //sadadklasdşaslkjJSKADJA
            }


           
            
        }

        void kontrolyem()
        {
            int yemx = rnd.Next(5, 61);
            int yemy = rnd.Next(5, 41);

            if (label1.Location.X == labelyem.Location.X && label1.Location.Y == labelyem.Location.Y)
            {
                tık.Play();
                labelyem.Location = new Point(yemx * 10, yemy * 10);

                if (puan >= 90) puan++;
                if (puan < 90) puan += 10;
               
         
                label11.Text = puan.ToString(); 

            } 
        }
        void kontrolkaybetme()
        {
            
            if (label1.Left <= 0 || label1.Right >= 700 || label1.Top <= 0 || label1.Bottom >= 500 || label1.Location == label3.Location || label1.Location == label4.Location || label1.Location == label5.Location || label1.Location == label6.Location || label1.Location == label6.Location || label1.Location ==label7.Location || label1.Location == label8.Location || label1.Location == label9.Location || label1.Location == label10.Location)
            {
                DialogResult baslama = new DialogResult();
                timersağ.Enabled = false;
                timersol.Enabled = false;
                timeraşağı.Enabled = false;
                timeryukarı.Enabled = false;

                MessageBox.Show("Kaybettiniz. Puanınız "+puan+".");
               
                baslama = MessageBox.Show("Yeniden Oynamak İstiyor Musunuz?", "Kaybettiniz", MessageBoxButtons.YesNo);
                if (baslama == DialogResult.Yes) yenidenbasla();
                else if (baslama == DialogResult.No) Application.Exit();             
            }

            if (puan == 99)
            {
                timersağ.Enabled = false;
                timersol.Enabled = false;
                timeraşağı.Enabled = false;
                timeryukarı.Enabled = false;

                MessageBox.Show("Tebrikler, kazandiniz!");
                Application.Exit();
                
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timersol.Enabled = false;
        }

        private void timersol_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Left - 10, label1.Top);
            kontrolyem();
            sürükleme();           
            kontrolkaybetme();
            hızlanma();
        }

        private void timersağ_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Left + 10, label1.Top);
            sürükleme();
            kontrolyem();
            kontrolkaybetme();
            hızlanma();

        }

        private void timeryukarı_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Left, label1.Top - 10);
            sürükleme();
            kontrolyem();
            kontrolkaybetme();
            hızlanma();
        }

        private void timeraşağı_Tick(object sender, EventArgs e)
        {
            label1.Location = new Point(label1.Left, label1.Top + 10);
            sürükleme();
            kontrolyem();
            kontrolkaybetme();
        }

        void sürükleme()
        {
            label10.Location = new Point(label9.Location.X, label9.Location.Y);
            label9.Location = new Point(label8.Location.X, label8.Location.Y);
            label8.Location = new Point(label7.Location.X, label7.Location.Y);
            label7.Location = new Point(label6.Location.X, label6.Location.Y);
            label6.Location = new Point(label5.Location.X, label5.Location.Y);
            label5.Location = new Point(label4.Location.X, label4.Location.Y);
            label4.Location = new Point(label3.Location.X, label3.Location.Y);
            label3.Location = new Point(label2.Location.X, label2.Location.Y);
            label2.Location = new Point(label1.Location.X, label1.Location.Y);
        }
        void yenidenbasla()
        {
            puan = 0;
            label11.Text = puan.ToString();
            labelyem.Location = new Point(220, 160);
            label1.Location = new Point(230,160);
            label2.Location = new Point(240,160);
            label3.Location = new Point(250,160);
            label4.Location = new Point(260,160);
            label5.Location = new Point(270,160);
            label6.Location = new Point(280,160);
            label7.Location = new Point(290,160);
            label8.Location = new Point(300,160);
            label9.Location = new Point(310,160);
            label10.Location = new Point(320,160);
        }

        void hızlanma()
        {
            
                timersağ.Interval =100- puan ;
                timersol.Interval =100- puan ;
                timeraşağı.Interval =100- puan ;
                timeryukarı.Interval =100- puan ;
            
        }

        

        
       
    }
}
