using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int health = 3;
        public Form1()
        {

            InitializeComponent();

            //İmleci Start'a çekme
            Point kontrol = new Point((Start.Left + Start.Right) / 2, (Start.Top + Start.Bottom) / 2);
            Point nokta = Start.Parent.PointToScreen(kontrol);
            Cursor.Position = nokta;




        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)

        {
            
            //Point point = this.PointToClient(Cursor.Position);
            //MessageBox.Show(point.ToString());

            Thread thread1 = new Thread(new ThreadStart(Restart));
            Thread thread2 = new Thread(new ThreadStart(Reset));
           

            //Can durumunu gösterme
            Health_check.Text = health.ToString();

            //Duvar renklerini değiştirme

            button1.BackColor = Color.Red;
            button2.BackColor = Color.Red;
            button3.BackColor = Color.Red;
            button4.BackColor = Color.Red;
            button6.BackColor = Color.Red;
            button7.BackColor = Color.Red;
            button8.BackColor = Color.Red;
            button9.BackColor = Color.Red;
            button10.BackColor = Color.Red;
            button11.BackColor = Color.Red;
            button12.BackColor = Color.Red;
            button13.BackColor = Color.Red;
            button14.BackColor = Color.Red;
            button15.BackColor = Color.Red;
            button16.BackColor = Color.Red;
            button17.BackColor = Color.Red;
            button18.BackColor = Color.Red;
            button19.BackColor = Color.Red;
            button20.BackColor = Color.Red;
            button21.BackColor = Color.Red;
            button22.BackColor = Color.Red;
            button23.BackColor = Color.Red;
            button24.BackColor = Color.Red;
            button25.BackColor = Color.Red;
            button26.BackColor = Color.Red;
            button27.BackColor = Color.Red;
            button28.BackColor = Color.Red;
            button29.BackColor = Color.Red;
            button31.BackColor = Color.Red;

            // Duvara çarpmayı kontrol ediyor. 
            if (button31.BackColor == Color.Red)
            {

                //Mesaj kutusu ile kullanıcıya devam işlemleri soruluyor
                var degisken = MessageBox.Show("Try Again! (If you want to restart the game click on No, If you want to exit the game click on Cancel)", "Failed", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Error);
                if (degisken == DialogResult.Yes)
                {
                    thread1.Start();

                }

                else if (degisken == DialogResult.No)
                {
                    thread2.Start();
                }
                else if (degisken == DialogResult.Cancel)
                {
                    this.Close();
                    Application.Exit();
                }

            };


        }

        //Oyunu baştan başlatmak isterse
        private void Reset()
        {
            //Renkleri Sıfırla
            label1.BackColor = Color.Black;
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;
            button6.BackColor = Color.Gray;
            button7.BackColor = Color.Gray;
            button8.BackColor = Color.Gray;
            button9.BackColor = Color.Gray;
            button10.BackColor = Color.Gray;
            button11.BackColor = Color.Gray;
            button12.BackColor = Color.Gray;
            button13.BackColor = Color.Gray;
            button14.BackColor = Color.Gray;
            button15.BackColor = Color.Gray;
            button16.BackColor = Color.Gray;
            button17.BackColor = Color.Gray;
            button18.BackColor = Color.Gray;
            button19.BackColor = Color.Gray;
            button20.BackColor = Color.Gray;
            button21.BackColor = Color.Gray;
            button22.BackColor = Color.Gray;
            button23.BackColor = Color.Gray;
            button24.BackColor = Color.Gray;
            button25.BackColor = Color.Gray;
            button26.BackColor = Color.Gray;
            button27.BackColor = Color.Gray;
            button28.BackColor = Color.Gray;
            button29.BackColor = Color.Gray;
            button31.BackColor = Color.Gray;

            //İmceli başlangıç noktasına çekme
            Point kontrol = new Point((Start.Left + Start.Right) / 2, (Start.Top + Start.Bottom) / 2);
            Point nokta = Start.Parent.PointToScreen(kontrol);
            Cursor.Position = nokta;


            //Can sıfırlama
            health = 3;
            Health_check.Text = health.ToString();


            //Can kontrol
            if (health == 0)
            { Over.Text = "Game is Over"; }
        }

        //Oyunda yeni can ile başlangıç yapmak isterse
        private void Restart()
        {
            this.InvokeIfRequired(() =>
            {            
            #region do
            System.Threading.Thread.Sleep(1000);
            while (button1.BackColor == Color.Red)
            {

                //Renkleri Sıfırla
                button1.BackColor = Color.Gray;
                button2.BackColor = Color.Gray;
                button3.BackColor = Color.Gray;
                button4.BackColor = Color.Gray;
                button6.BackColor = Color.Gray;
                button7.BackColor = Color.Gray;
                button8.BackColor = Color.Gray;
                button9.BackColor = Color.Gray;
                button10.BackColor = Color.Gray;
                button11.BackColor = Color.Gray;
                button12.BackColor = Color.Gray;
                button13.BackColor = Color.Gray;
                button14.BackColor = Color.Gray;
                button15.BackColor = Color.Gray;
                button16.BackColor = Color.Gray;
                button17.BackColor = Color.Gray;
                button18.BackColor = Color.Gray;
                button19.BackColor = Color.Gray;
                button20.BackColor = Color.Gray;
                button21.BackColor = Color.Gray;
                button22.BackColor = Color.Gray;
                button23.BackColor = Color.Gray;
                button24.BackColor = Color.Gray;
                button25.BackColor = Color.Gray;
                button26.BackColor = Color.Gray;
                button27.BackColor = Color.Gray;
                button28.BackColor = Color.Gray;
                button29.BackColor = Color.Gray;
                button31.BackColor = Color.Gray;

                //İmceli başlangıç noktasına çekme
                Point kontrol = new Point((Start.Left + Start.Right) / 2, (Start.Top + Start.Bottom) / 2);
                Point nokta = Start.Parent.PointToScreen(kontrol);
                Cursor.Position = nokta;


                //Can azaltma
                Health_check.Text = ((health) - (1)).ToString();
                --health;

                //Can kontrol
                if (health == 0)
                { Over.Text = "Game is Over"; }


            }
                #endregion
            });

        }




        private void button1_Click(object sender, EventArgs e)
        {
            

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void button4_Click(object sender, EventArgs e)
        {


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            //Renkleri Sıfırla
            button1.BackColor = Color.Gray;
            button2.BackColor = Color.Gray;
            button3.BackColor = Color.Gray;
            button4.BackColor = Color.Gray;

            //İmceli başlangıç noktasına çekme
            Point kontrol = new Point((Start.Left + Start.Right) / 2, (Start.Top + Start.Bottom) / 2);
            Point nokta = Start.Parent.PointToScreen(kontrol);
            Cursor.Position = nokta;


            //Can sıfırlama
            health = 3;
            Health_check.Text = health.ToString();
            

            //Can kontrol
            if (health == 0)
            { Over.Text = "Game is Over"; }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Win.Text = "You Win";
            Score_header.Text = "Your score is: ";
            Score.Text = (health * 100).ToString();
        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void Start_Click(object sender, EventArgs e)
        {

        }
    }
}
