using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace fill
{
    public partial class Form1 : Form
    {
        int l = 0, c = 0;//coloana
        int coloreaza = 0,count=0;
        Button[,] butoane=new Button[50,50];//matrice de butoane
        public Form1()
        {
            InitializeComponent();
        }
     
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//genereaza
        {
            ////input gresit,functioneaza doar data se introduc doar cifre sau caractere separat
            //int result = 0;           
            //bool box1 = int.TryParse(textBox1.Text, out result);
            //bool box2 = int.TryParse(textBox1.Text, out result);
            //if((box1==false)||(box2=false))
            //{
            //    MessageBox.Show("introdu doar cifre");\
            //    if (box1 == false)
            //        textBox1.Clear();
            //    if (box2 == false)
            //        textBox1.Clear();
            //    return;
            //}
            ////
            int n = int.Parse(textBox1.Text);//linie
            int m = int.Parse(textBox2.Text);//coloana
             
            l = n;c = m;
            int linie=140,coloana=0;
            for (int i = 0; i < m; i++)
            {
                coloana = 10;//pixeli!!!
                for (int j = 0; j < n; j++)
                {  //pozitia e variabila

                    butoane[i, j] = new Button();

                    butoane[i, j].Click += new EventHandler(button_tag);
                    butoane[i, j].Tag = i.ToString() + " " + j.ToString();
                    coloana = coloana + 10;
                    butoane[i,j].Location = new Point(linie,coloana);
                    butoane[i, j].Size = new Size(50, 50);
                    this.Controls.Add(butoane[i,j]);
                    coloana = coloana + 50;
                }
                linie = linie + 55;//in pixeli          

            }
            if ((l == 0) || (c == 0))
            {
                MessageBox.Show("apasa pe genereaza");
                return;
            }
            Random nr = new Random();
            int numar = 0;
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    numar = nr.Next(0, 2);
                    if (numar == 0)
                    {
                        butoane[i, j].BackColor = Color.Red;
                    }
                    else
                    {
                        butoane[i, j].BackColor = Color.Blue;
                    }
                }
            }
            button1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
                          
       
        private void button_tag(object trimitator,EventArgs e )//trimitator
        {
            Button bt = (Button)trimitator;
            //MessageBox.Show(bt.Tag.ToString());
            string v=bt.Tag.ToString();
            string[] k=v.Split();
            int i = int.Parse(k[0]),j=int.Parse(k[1]);

            //recoloreaza
            if (coloreaza == 1)
            {
                if (butoane[int.Parse(k[0]), int.Parse(k[1])].BackColor == Color.Red)
                    butoane[int.Parse(k[0]), int.Parse(k[1])].BackColor = Color.Blue;
                else
                    butoane[int.Parse(k[0]), int.Parse(k[1])].BackColor = Color.Red;
                coloreaza = 0;
                return;
            }
            //

            for (int q=i-1;q<i+2;q++)
             {
                 for(int r=j-1;r<j+2;r++)
                 {
                     if((q>-1)&&(r>-1)&&(int.Parse(textBox1.Text)>r)&&(int.Parse(textBox2.Text)>q))
                     if (butoane[q, r].BackColor == Color.Red)
                     {
                         butoane[q, r].BackColor = Color.Blue;
                     }
                     else
                     {
                         butoane[q, r].BackColor = Color.Red;
                     }
                 }
             }
            int nr=0,red=0,blue=0;
             for (int w = 0; w < int.Parse(textBox2.Text); w++)
             {
                 for (int t = 0; t < int.Parse(textBox1.Text); t++)
                 {
                     nr++;
                     if(butoane[w,t].BackColor==Color.Red)
                         red++;
                     if(butoane[w,t].BackColor==Color.Blue)
                         blue++;
                 }
             }
            count++;
            if((red==nr)||(blue==nr))
            {
                MessageBox.Show("o culoare din"+count.ToString()+" nutari");
                //System.Threading.Thread.Sleep(1000);
            }
          
        }

        private void button2_Click(object sender, EventArgs e)//sterge tot 
        {
           
        }

        private void button3_Click(object sender, EventArgs e)//recoloreaza buton
        {
            coloreaza = 1;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsNumber(e.KeyChar)&&(!char.IsControl(e.KeyChar)))
                e.Handled = true;//daca-i true nu mai poti sa scrii
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
                if (!char.IsNumber(e.KeyChar)&&(!char.IsControl(e.KeyChar))&&!(e.KeyChar==97))
                    e.Handled = true;
          
        }w
       
        private void button4_Click(object sender, EventArgs e)//joc nou
        {
            Application.Restart();
            button1.Show();
        }

    }
}
